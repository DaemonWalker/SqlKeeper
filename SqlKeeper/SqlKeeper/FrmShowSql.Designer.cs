namespace SqlKeeper
{
    partial class FrmShowSql
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbSqlID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSqlValue = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql_ID";
            // 
            // tbSqlID
            // 
            this.tbSqlID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSqlID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSqlID.Location = new System.Drawing.Point(77, 12);
            this.tbSqlID.Name = "tbSqlID";
            this.tbSqlID.ReadOnly = true;
            this.tbSqlID.Size = new System.Drawing.Size(674, 29);
            this.tbSqlID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // tbSqlValue
            // 
            this.tbSqlValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSqlValue.Font = new System.Drawing.Font("Inziu IosevkaCC SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSqlValue.Location = new System.Drawing.Point(76, 65);
            this.tbSqlValue.Name = "tbSqlValue";
            this.tbSqlValue.ReadOnly = true;
            this.tbSqlValue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbSqlValue.Size = new System.Drawing.Size(675, 262);
            this.tbSqlValue.TabIndex = 3;
            this.tbSqlValue.Text = "";
            // 
            // FrmShowSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 339);
            this.Controls.Add(this.tbSqlValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSqlID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmShowSql";
            this.Load += new System.EventHandler(this.FrmShowSql_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSqlID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbSqlValue;
    }
}