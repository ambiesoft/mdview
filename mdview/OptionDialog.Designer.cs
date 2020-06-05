namespace mdview
{
    partial class OptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionDialog));
            this.btnOK = new System.Windows.Forms.Button();
            this.chkOpenLastOpened = new System.Windows.Forms.CheckBox();
            this.lblMaxRecents = new System.Windows.Forms.Label();
            this.nupRecents = new System.Windows.Forms.NumericUpDown();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblRestartNotice = new System.Windows.Forms.Label();
            this.lblEditor = new System.Windows.Forms.Label();
            this.txtEditor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupRecents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkOpenLastOpened
            // 
            resources.ApplyResources(this.chkOpenLastOpened, "chkOpenLastOpened");
            this.chkOpenLastOpened.Name = "chkOpenLastOpened";
            this.chkOpenLastOpened.UseVisualStyleBackColor = true;
            // 
            // lblMaxRecents
            // 
            resources.ApplyResources(this.lblMaxRecents, "lblMaxRecents");
            this.lblMaxRecents.Name = "lblMaxRecents";
            // 
            // nupRecents
            // 
            resources.ApplyResources(this.nupRecents, "nupRecents");
            this.nupRecents.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nupRecents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupRecents.Name = "nupRecents";
            this.nupRecents.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // lblRestartNotice
            // 
            resources.ApplyResources(this.lblRestartNotice, "lblRestartNotice");
            this.lblRestartNotice.Name = "lblRestartNotice";
            // 
            // lblEditor
            // 
            resources.ApplyResources(this.lblEditor, "lblEditor");
            this.lblEditor.Name = "lblEditor";
            // 
            // txtEditor
            // 
            resources.ApplyResources(this.txtEditor, "txtEditor");
            this.txtEditor.Name = "txtEditor";
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.lblEditor);
            this.Controls.Add(this.lblRestartNotice);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.nupRecents);
            this.Controls.Add(this.lblMaxRecents);
            this.Controls.Add(this.chkOpenLastOpened);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.OptionDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupRecents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.CheckBox chkOpenLastOpened;
        private System.Windows.Forms.Label lblMaxRecents;
        private System.Windows.Forms.NumericUpDown nupRecents;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblRestartNotice;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.TextBox txtEditor;
    }
}