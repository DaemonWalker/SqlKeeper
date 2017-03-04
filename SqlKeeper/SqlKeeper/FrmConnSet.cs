using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Oracle.DataAccess.Client;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlKeeper
{
    public partial class FrmConnSet : Form
    {
        public FrmConnSet(Settings set)
        {
            InitializeComponent();
            tbAcc.Text = set.DBAcc;
            tbIP.Text = set.DBIP;
            tbName.Text = set.DBName;
            tbPwd.Text = set.DBPwd;
        }
        public string Account
        {
            get
            {
                return tbAcc.Text;
            }
        }
        public string Password
        {
            get
            {
                return tbPwd.Text;
            }
        }
        public string IP
        {
            get
            {
                return tbIP.Text;
            }
        }
        public string DBName
        {
            get
            {
                return tbName.Text;
            }
        }

        private void FrmConnSet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conn = new OracleConnection($"User Id={tbAcc.Text};Password={tbPwd.Text};Data Source={tbIP.Text}/{tbName.Text};");
            try
            {
                conn.Open();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("连接凭据有误,请进行检查");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
