using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlKeeper
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }

        public string BackSql
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (this.Owner as FrmMain).BackupSql = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            textBox1.Font = Program.GlobalFont;
            textBox1.Text = (this.Owner as FrmMain).BackupSql;
        }
    }
}
