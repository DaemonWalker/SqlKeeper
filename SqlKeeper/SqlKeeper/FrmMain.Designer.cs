namespace SqlKeeper
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiRefreshBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowDict = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRevertToDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAutoBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvPanel = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSqlID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.dgvPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colSqlID,
            this.colComp,
            this.colValue});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowCellErrors = false;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(916, 414);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefreshBackup,
            this.tsmiShowDict,
            this.tsmiRevertToDB,
            this.tsmiAutoBackup,
            this.tsmiConnSet,
            this.tsmiHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(916, 25);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiRefreshBackup
            // 
            this.tsmiRefreshBackup.Name = "tsmiRefreshBackup";
            this.tsmiRefreshBackup.Size = new System.Drawing.Size(108, 21);
            this.tsmiRefreshBackup.Text = "刷新现有备份(&R)";
            this.tsmiRefreshBackup.Click += new System.EventHandler(this.tsmiRefreshBackup_Click);
            // 
            // tsmiShowDict
            // 
            this.tsmiShowDict.Name = "tsmiShowDict";
            this.tsmiShowDict.Size = new System.Drawing.Size(108, 21);
            this.tsmiShowDict.Text = "查看现有备份(&C)";
            this.tsmiShowDict.Click += new System.EventHandler(this.tsmiShowDict_Click);
            // 
            // tsmiRevertToDB
            // 
            this.tsmiRevertToDB.Name = "tsmiRevertToDB";
            this.tsmiRevertToDB.Size = new System.Drawing.Size(92, 21);
            this.tsmiRevertToDB.Text = "还原到数据库";
            this.tsmiRevertToDB.Click += new System.EventHandler(this.tsmiRevertToDB_Click);
            // 
            // tsmiAutoBackup
            // 
            this.tsmiAutoBackup.Name = "tsmiAutoBackup";
            this.tsmiAutoBackup.Size = new System.Drawing.Size(68, 21);
            this.tsmiAutoBackup.Text = "自动备份";
            this.tsmiAutoBackup.Click += new System.EventHandler(this.tsmiAutoBackup_Click);
            // 
            // tsmiConnSet
            // 
            this.tsmiConnSet.Name = "tsmiConnSet";
            this.tsmiConnSet.Size = new System.Drawing.Size(116, 21);
            this.tsmiConnSet.Text = "数据库连接字符串";
            this.tsmiConnSet.Click += new System.EventHandler(this.tsmiConnSet_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(61, 21);
            this.tsmiHelp.Text = "帮助(&H)";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // dgvPanel
            // 
            this.dgvPanel.Controls.Add(this.dgvData);
            this.dgvPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPanel.Location = new System.Drawing.Point(0, 25);
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.Size = new System.Drawing.Size(916, 414);
            this.dgvPanel.TabIndex = 7;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "尚未开启自动备份";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "选择";
            this.colSelect.Name = "colSelect";
            // 
            // colSqlID
            // 
            this.colSqlID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSqlID.DataPropertyName = "Sql_ID";
            this.colSqlID.HeaderText = "Sql_ID";
            this.colSqlID.Name = "colSqlID";
            this.colSqlID.ReadOnly = true;
            this.colSqlID.Width = 66;
            // 
            // colComp
            // 
            this.colComp.DataPropertyName = "Compnent_Name";
            this.colComp.FillWeight = 200F;
            this.colComp.HeaderText = "Compnent_Name";
            this.colComp.Name = "colComp";
            this.colComp.ReadOnly = true;
            // 
            // colValue
            // 
            this.colValue.DataPropertyName = "Value";
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.Width = 291;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 439);
            this.Controls.Add(this.dgvPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.Text = "MP_SQL备份";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.dgvPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefreshBackup;
        private System.Windows.Forms.Panel dgvPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDict;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiRevertToDB;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoBackup;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnSet;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSqlID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
    }
}

