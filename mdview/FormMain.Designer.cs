namespace mdview
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsdRecent = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmDummy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssBrowser = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tssPrint = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tssCopy = new System.Windows.Forms.ToolStripSeparator();
            this.tsdMarkdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiOrganizeMD = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOrganize = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOption = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.slMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.slCurrentMD = new System.Windows.Forms.ToolStripStatusLabel();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.tsMain.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            resources.ApplyResources(this.tsMain, "tsMain");
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdRecent,
            this.tsbOpen,
            this.tsbRefresh,
            this.tssBrowser,
            this.tsbPrint,
            this.tssPrint,
            this.tsbCopy,
            this.tssCopy,
            this.tsdMarkdown,
            this.tsbOption,
            this.tsbHelp});
            this.tsMain.Name = "tsMain";
            // 
            // tsdRecent
            // 
            resources.ApplyResources(this.tsdRecent, "tsdRecent");
            this.tsdRecent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdRecent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDummy});
            this.tsdRecent.Name = "tsdRecent";
            this.tsdRecent.DropDownOpening += new System.EventHandler(this.tsdRecent_DropDownOpening);
            // 
            // tsmDummy
            // 
            resources.ApplyResources(this.tsmDummy, "tsmDummy");
            this.tsmDummy.Name = "tsmDummy";
            // 
            // tsbOpen
            // 
            resources.ApplyResources(this.tsbOpen, "tsbOpen");
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbRefresh
            // 
            resources.ApplyResources(this.tsbRefresh, "tsbRefresh");
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tssBrowser
            // 
            resources.ApplyResources(this.tssBrowser, "tssBrowser");
            this.tssBrowser.Name = "tssBrowser";
            // 
            // tsbPrint
            // 
            resources.ApplyResources(this.tsbPrint, "tsbPrint");
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tssPrint
            // 
            resources.ApplyResources(this.tssPrint, "tssPrint");
            this.tssPrint.Name = "tssPrint";
            // 
            // tsbCopy
            // 
            resources.ApplyResources(this.tsbCopy, "tsbCopy");
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tssCopy
            // 
            resources.ApplyResources(this.tssCopy, "tssCopy");
            this.tssCopy.Name = "tssCopy";
            // 
            // tsdMarkdown
            // 
            resources.ApplyResources(this.tsdMarkdown, "tsdMarkdown");
            this.tsdMarkdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdMarkdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOrganizeMD,
            this.tssOrganize});
            this.tsdMarkdown.Name = "tsdMarkdown";
            this.tsdMarkdown.DropDownOpening += new System.EventHandler(this.tsdMarkdown_DropDownOpening);
            // 
            // tsiOrganizeMD
            // 
            resources.ApplyResources(this.tsiOrganizeMD, "tsiOrganizeMD");
            this.tsiOrganizeMD.Name = "tsiOrganizeMD";
            this.tsiOrganizeMD.Click += new System.EventHandler(this.tsiOrganizeMD_Click);
            // 
            // tssOrganize
            // 
            resources.ApplyResources(this.tssOrganize, "tssOrganize");
            this.tssOrganize.Name = "tssOrganize";
            // 
            // tsbOption
            // 
            resources.ApplyResources(this.tsbOption, "tsbOption");
            this.tsbOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOption.Name = "tsbOption";
            this.tsbOption.Click += new System.EventHandler(this.tsbOption_Click);
            // 
            // tsbHelp
            // 
            resources.ApplyResources(this.tsbHelp, "tsbHelp");
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
            // 
            // ss
            // 
            resources.ApplyResources(this.ss, "ss");
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slMain,
            this.slCurrentMD});
            this.ss.Name = "ss";
            // 
            // slMain
            // 
            resources.ApplyResources(this.slMain, "slMain");
            this.slMain.Name = "slMain";
            this.slMain.Spring = true;
            // 
            // slCurrentMD
            // 
            resources.ApplyResources(this.slCurrentMD, "slCurrentMD");
            this.slCurrentMD.Name = "slCurrentMD";
            // 
            // wb
            // 
            resources.ApplyResources(this.wb, "wb");
            this.wb.Name = "wb";
            this.wb.ScriptErrorsSuppressed = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wb);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.tsMain);
            this.Name = "FormMain";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FormMain_DragOver);
            this.DragLeave += new System.EventHandler(this.FormMain_DragLeave);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator tssPrint;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripSeparator tssCopy;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel slMain;
        private System.Windows.Forms.ToolStripButton tsbOption;
        private System.Windows.Forms.ToolStripDropDownButton tsdRecent;
        private System.Windows.Forms.ToolStripMenuItem tsmDummy;
        private System.Windows.Forms.ToolStripDropDownButton tsdMarkdown;
        private System.Windows.Forms.ToolStripMenuItem tsiOrganizeMD;
        private System.Windows.Forms.ToolStripSeparator tssOrganize;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator tssBrowser;
        private System.Windows.Forms.ToolStripStatusLabel slCurrentMD;
    }
}

