namespace mdview
{
    partial class OrganizeMDDialog
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
            this.lbMain = new System.Windows.Forms.ListBox();
            this.pgMain = new System.Windows.Forms.PropertyGrid();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMain.FormattingEnabled = true;
            this.lbMain.Location = new System.Drawing.Point(12, 12);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(153, 329);
            this.lbMain.TabIndex = 0;
            this.lbMain.SelectedIndexChanged += new System.EventHandler(this.lbMain_SelectedIndexChanged);
            // 
            // pgMain
            // 
            this.pgMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgMain.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pgMain.Location = new System.Drawing.Point(171, 12);
            this.pgMain.Name = "pgMain";
            this.pgMain.Size = new System.Drawing.Size(408, 322);
            this.pgMain.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(423, 340);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(156, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // OrganizeMDDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 374);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pgMain);
            this.Controls.Add(this.lbMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizeMDDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Organize Markdown";
            this.Load += new System.EventHandler(this.OrganizeMDDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMain;
        private System.Windows.Forms.PropertyGrid pgMain;
        private System.Windows.Forms.Button btnOK;
    }
}