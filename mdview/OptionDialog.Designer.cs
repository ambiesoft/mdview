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
            this.btnOK = new System.Windows.Forms.Button();
            this.chkOpenLastOpened = new System.Windows.Forms.CheckBox();
            this.lblMaxRecents = new System.Windows.Forms.Label();
            this.nupRecents = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupRecents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(286, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 21);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkOpenLastOpened
            // 
            this.chkOpenLastOpened.AutoSize = true;
            this.chkOpenLastOpened.Location = new System.Drawing.Point(12, 12);
            this.chkOpenLastOpened.Name = "chkOpenLastOpened";
            this.chkOpenLastOpened.Size = new System.Drawing.Size(187, 16);
            this.chkOpenLastOpened.TabIndex = 5;
            this.chkOpenLastOpened.Text = "&Open last opened file at startup";
            this.chkOpenLastOpened.UseVisualStyleBackColor = true;
            // 
            // lblMaxRecents
            // 
            this.lblMaxRecents.AutoSize = true;
            this.lblMaxRecents.Location = new System.Drawing.Point(12, 31);
            this.lblMaxRecents.Name = "lblMaxRecents";
            this.lblMaxRecents.Size = new System.Drawing.Size(174, 12);
            this.lblMaxRecents.TabIndex = 6;
            this.lblMaxRecents.Text = "&Max count of recent opened files";
            // 
            // nupRecents
            // 
            this.nupRecents.Location = new System.Drawing.Point(14, 46);
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
            this.nupRecents.Size = new System.Drawing.Size(120, 19);
            this.nupRecents.TabIndex = 7;
            this.nupRecents.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 198);
            this.Controls.Add(this.nupRecents);
            this.Controls.Add(this.lblMaxRecents);
            this.Controls.Add(this.chkOpenLastOpened);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(282, 127);
            this.Name = "OptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option | mdview";
            ((System.ComponentModel.ISupportInitialize)(this.nupRecents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.CheckBox chkOpenLastOpened;
        private System.Windows.Forms.Label lblMaxRecents;
        private System.Windows.Forms.NumericUpDown nupRecents;
    }
}