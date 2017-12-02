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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizeMDDialog));
            this.lbMain = new System.Windows.Forms.ListBox();
            this.pgMain = new System.Windows.Forms.PropertyGrid();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            resources.ApplyResources(this.lbMain, "lbMain");
            this.lbMain.FormattingEnabled = true;
            this.lbMain.Name = "lbMain";
            this.lbMain.SelectedIndexChanged += new System.EventHandler(this.lbMain_SelectedIndexChanged);
            // 
            // pgMain
            // 
            resources.ApplyResources(this.pgMain, "pgMain");
            this.pgMain.LineColor = System.Drawing.SystemColors.ControlDark;
            this.pgMain.Name = "pgMain";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // OrganizeMDDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pgMain);
            this.Controls.Add(this.lbMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizeMDDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.OrganizeMDDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMain;
        private System.Windows.Forms.PropertyGrid pgMain;
        private System.Windows.Forms.Button btnOK;
    }
}