using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;
using System.Resources;

namespace SqlKeeper
{
    public partial class FrmMain : Form
    {
        private static string FilePath;
        private static string SetPath;
        private FrmShowSql FrmSql = new FrmShowSql();
        private FrmBackup FrmBackup = new FrmBackup();
        private Settings Setting;
        public string BackupSql
        {
            get
            {
                return Setting.BackupString;
            }
            set
            {
                Setting.BackupString = value;
                SaveToFile(SetPath, this.Setting);
            }
        }
        private static bool BackupRun = false;
        private Dictionary<string, MpSqlDto> SqlDict = new Dictionary<string, MpSqlDto>();
        private delegate void VoidFoo(DataTable dt);
        private delegate void SetControlEnableFoo(ToolStripMenuItem control, bool enable);


        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            ResourceManager rm = new ResourceManager(GetType().Namespace + ".Properties.Resources", Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return Assembly.Load(bytes);
        }
        public FrmMain()
        {
            var dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SqlKeeper");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            FilePath = Path.Combine(dirPath, "data.json");
            SetPath = Path.Combine(dirPath, "setting.json");
            try
            {
                Setting = new JavaScriptSerializer().Deserialize<Settings>(File.ReadAllText(SetPath));
            }
            catch
            {
                Setting = new Settings();
            }
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
        }

        private void ChangeDgvDataSource(DataTable dt)
        {
            if (dgvData.InvokeRequired)
            {
                this.Invoke(new VoidFoo(ChangeDgvDataSource), new object[] { dt });
            }
            else
            {
                dgvData.DataSource = dt;
            }
        }

        async private void FrmMain_Load(object sender, EventArgs e)
        {
            dgvData.RowsDefaultCellStyle.Font = Program.GlobalFont;
            colValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            await Task.Run(() =>
            {
                if (File.Exists(FilePath))
                {
                    using (var fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var sw = new StreamReader(fs))
                        {
                            SqlDict = JsonConvert.DeserializeObject<Dictionary<string, MpSqlDto>>(sw.ReadToEnd());
                        }
                    }
                    ShowDict();
                }
            });
        }

        private async Task SaveToFile(string filePath, object saveObj)
        {
            await Task.Run(() =>
            {
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(saveObj));
                        sw.Flush();
                    }
                }
            });
        }

        async private void tsmiRefreshBackup_Click(object sender, EventArgs e)
        {
            tsmiRefreshBackup.Enabled = false;
            await Task.Run(() =>
            {
                var sql = new StringBuilder();
                int index = 0;
                while (index < SqlDict.Keys.Count)
                {
                    sql.Clear();
                    sql.Append("select t.sql_id as Sql_ID,t.sql_value as Value from mp_sql t where t.sql_id in (");
                    while (index < SqlDict.Keys.Count && sql.Length < 2000)
                    {
                        sql.AppendFormat("'{0}',", SqlDict.Keys.ElementAt(index));
                        index++;
                    }
                    sql.Length = sql.Length - 1;
                    sql.Append(")");
                    var dataTable = RunSql(sql.ToString());
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SqlDict[row[0].ToString()].SqlValue = row[1].ToString();
                    }
                }
                SaveToFile(FilePath, SqlDict).Wait();
                tsmiRefreshBackup.Enabled = true;
                MessageBox.Show("刷新成功");
            });
        }

        private DataTable RunSql(string sql)
        {

            var adapter = new OracleDataAdapter(sql, Setting.ConnStr);
            var dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dataTable;
        }
        private void RunSql(OracleCommand comm, string sql)
        {
            comm.CommandText = sql;
            comm.ExecuteNonQuery();
        }

        private void ShowDict()
        {
            var dt = new DataTable();
            dt.Columns.Add("Sql_ID");
            dt.Columns.Add("Compnent_Name");
            dt.Columns.Add("Value");
            foreach (var key in SqlDict.Keys)
            {
                var row = dt.NewRow();
                row[0] = key;
                row[1] = SqlDict[key].CompnentName;
                row[2] = SqlDict[key].SqlValue;
                dt.Rows.Add(row);
            }
            ChangeDgvDataSource(dt);
        }

        private void tsmiShowDict_Click(object sender, EventArgs e)
        {
            ShowDict();
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            var msg = new StringBuilder();
            msg.AppendFormat("现保存 {0} 条Sql\n", this.SqlDict.Keys.Count());
            foreach (var group in SqlDict.Values.GroupBy(p => p.CompnentName))
            {
                msg.AppendFormat("组 {0} 共 {1} 条\n", group.Key, group.Count());
            }
            MessageBox.Show(msg.ToString());
        }

        async private void tsmiRevertToDB_Click(object sender, EventArgs e)
        {
            tsmiRevertToDB.Enabled = false;
            await Task.Run(() =>
            {
                var allSqlCount = 0;
                var errorCount = 0;
                using (var command = new OracleCommand())
                {
                    var conn = new OracleConnection(Setting.ConnStr);
                    MessageBox.Show(Setting.ConnStr);
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("数据库连接失败,请检查连接凭据");
                        return;
                    }
                    command.Connection = conn;
                    var ignoreExMessage = false;
                    foreach (var key in SqlDict.Keys)
                    {
                        var dto = SqlDict[key];
                        var sql = new StringBuilder();

                        sql.AppendFormat("insert into mp_sql (sql_id,compnent_name,kind_lv1_name,kind_lv2_name" +
                            ",valid_state,sql_type,sql_value) values('{0}',{1},{2},{3},'1',{4}'{5}')",
                            dto.SqlID, dto.CompnentName, dto.KindLv1Name, dto.KindLv2Name, dto.SqlType,
                            dto.SqlValue.Replace("'", "''"));
                        try
                        {
                            allSqlCount++;
                            RunSql(command, sql.ToString());
                        }
                        catch (Exception ex)
                        {
                            errorCount++;
                            if (ignoreExMessage == false)
                            {
                                if (MessageBox.Show($"异常信息:{ex.Message}\n,忽略之后抛出的异常吗?", "还原出错", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    ignoreExMessage = true;
                                }
                            }
                        }

                    }
                }
                MessageBox.Show($"还原完成！\n备份的Sql数量: {allSqlCount}个\n成功数目: {allSqlCount - errorCount}个\n失败数目: {errorCount}个");
            });
            tsmiRevertToDB.Enabled = true;
        }


        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
                this.Show();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        async private void tsmiAutoBackup_Click(object sender, EventArgs e)
        {
            if (!BackupRun)
            {
                BackupRun = true;
                tsmiAutoBackup.Text = "自动备份中";
                notifyIcon1.Text = "自动备份中";
            }
            else
            {
                BackupRun = false;
                tsmiAutoBackup.Text = "自动备份";
                notifyIcon1.Text = "尚未开启自动备份";
                return;
            }
            await Task.Run(() =>
            {
                if (FrmBackup.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                while (RunSql(BackupSql).Columns.Count == 0)
                {
                    FrmBackup.DialogResult = DialogResult.No;
                    if (FrmBackup.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                }
                while (BackupRun)
                {
                    var dt = RunSql(BackupSql);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!SqlDict.ContainsKey(row[0].ToString()))
                        {
                            var dto = new MpSqlDto();
                            var props = dto.GetType().GetProperties();
                            for (int i = 0; i < props.Length; i++)
                            {
                                if (row[i] is DBNull == false)
                                {
                                    props[i].SetValue(dto, row[i]);
                                }
                                else
                                {
                                    props[i].SetValue(dto, "");
                                }
                            }
                            SqlDict.Add(row[0].ToString(), dto);
                        }
                        else
                        {
                            var dto = SqlDict[row[0].ToString()];
                            var props = dto.GetType().GetProperties();
                            for (int i = 0; i < props.Length; i++)
                            {
                                if (row[i] is DBNull == false)
                                {
                                    props[i].SetValue(dto, row[i]);
                                }
                                else
                                {
                                    props[i].SetValue(dto, "");
                                }
                            }
                            SqlDict[row[0].ToString()] = dto;
                        }
                    }
                    SaveToFile(FilePath, SqlDict).Wait();
                    Thread.Sleep(1000 * 300);
                }
            });
            BackupRun = false;
            tsmiAutoBackup.Text = "自动备份";
            notifyIcon1.Text = "尚未开启自动备份";
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            var sql = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            FrmSql.SqlID = id;
            FrmSql.SqlValue = sql;
            FrmSql.ShowDialog();
        }

        async private void tsmiConnSet_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmConnSet(this.Setting))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Setting.DBAcc = frm.Account;
                    Setting.DBIP = frm.IP;
                    Setting.DBName = frm.DBName;
                    Setting.DBPwd = frm.Password;
                    await SaveToFile(SetPath, this.Setting);
                }
            }
        }
    }
}
