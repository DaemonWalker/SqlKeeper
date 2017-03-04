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
    public partial class FrmShowSql : Form
    {
        public string SqlID
        {
            get
            {
                return tbSqlID.Text;
            }
            set
            {
                tbSqlID.Text = value;
            }
        }
        public string SqlValue
        {
            get
            {
                return tbSqlValue.Text;
            }
            set
            {
                tbSqlValue.Text = value;
            }
        }
        public FrmShowSql()
        {
            InitializeComponent();
        }

        private void FrmShowSql_Load(object sender, EventArgs e)
        {
            tbSqlValue.Font = tbSqlID.Font = Program.GlobalFont;
        }
    }
}
