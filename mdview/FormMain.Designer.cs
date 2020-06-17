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
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbWatch = new System.Windows.Forms.ToolStripButton();
            this.tssBrowser = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tssPrint = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tssCopy = new System.Windows.Forms.ToolStripSeparator();
            this.tsdMarkdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiOrganizeMD = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOrganize = new System.Windows.Forms.ToolStripSeparator();
            this.tsdZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmZoom400 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom150 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom125 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom95 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom90 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom80 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom75 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOption = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.tsbDebugTest = new System.Windows.Forms.ToolStripButton();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.slMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.slCurrentMD = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBrowser = new System.Windows.Forms.Panel();
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
            this.tsbEdit,
            this.tsbWatch,
            this.tssBrowser,
            this.tsbPrint,
            this.tssPrint,
            this.tsbCopy,
            this.tssCopy,
            this.tsdMarkdown,
            this.tsdZoom,
            this.tsbOption,
            this.tsbHelp,
            this.tsbDebugTest});
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
            // tsbEdit
            // 
            resources.ApplyResources(this.tsbEdit, "tsbEdit");
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbWatch
            // 
            resources.ApplyResources(this.tsbWatch, "tsbWatch");
            this.tsbWatch.CheckOnClick = true;
            this.tsbWatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWatch.Name = "tsbWatch";
            this.tsbWatch.CheckedChanged += new System.EventHandler(this.tsbWatch_CheckedChanged);
            this.tsbWatch.EnabledChanged += new System.EventHandler(this.tsbWatch_EnabledChanged);
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
            // tsdZoom
            // 
            resources.ApplyResources(this.tsdZoom, "tsdZoom");
            this.tsdZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmZoom400,
            this.tsmZoom200,
            this.tsmZoom150,
            this.tsmZoom125,
            this.tsmZoom100,
            this.tsmZoom95,
            this.tsmZoom90,
            this.tsmZoom80,
            this.tsmZoom75,
            this.tsmZoom50});
            this.tsdZoom.Name = "tsdZoom";
            // 
            // tsmZoom400
            // 
            resources.ApplyResources(this.tsmZoom400, "tsmZoom400");
            this.tsmZoom400.Name = "tsmZoom400";
            this.tsmZoom400.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom200
            // 
            resources.ApplyResources(this.tsmZoom200, "tsmZoom200");
            this.tsmZoom200.Name = "tsmZoom200";
            this.tsmZoom200.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom150
            // 
            resources.ApplyResources(this.tsmZoom150, "tsmZoom150");
            this.tsmZoom150.Name = "tsmZoom150";
            this.tsmZoom150.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom125
            // 
            resources.ApplyResources(this.tsmZoom125, "tsmZoom125");
            this.tsmZoom125.Name = "tsmZoom125";
            this.tsmZoom125.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom100
            // 
            resources.ApplyResources(this.tsmZoom100, "tsmZoom100");
            this.tsmZoom100.Name = "tsmZoom100";
            this.tsmZoom100.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom95
            // 
            resources.ApplyResources(this.tsmZoom95, "tsmZoom95");
            this.tsmZoom95.Name = "tsmZoom95";
            this.tsmZoom95.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom90
            // 
            resources.ApplyResources(this.tsmZoom90, "tsmZoom90");
            this.tsmZoom90.Name = "tsmZoom90";
            this.tsmZoom90.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom80
            // 
            resources.ApplyResources(this.tsmZoom80, "tsmZoom80");
            this.tsmZoom80.Name = "tsmZoom80";
            this.tsmZoom80.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom75
            // 
            resources.ApplyResources(this.tsmZoom75, "tsmZoom75");
            this.tsmZoom75.Name = "tsmZoom75";
            this.tsmZoom75.Click += new System.EventHandler(this.tsmZoom_Click_Common);
            // 
            // tsmZoom50
            // 
            resources.ApplyResources(this.tsmZoom50, "tsmZoom50");
            this.tsmZoom50.Name = "tsmZoom50";
            this.tsmZoom50.Click += new System.EventHandler(this.tsmZoom_Click_Common);
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
            // tsbDebugTest
            // 
            resources.ApplyResources(this.tsbDebugTest, "tsbDebugTest");
            this.tsbDebugTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDebugTest.Name = "tsbDebugTest";
            this.tsbDebugTest.Click += new System.EventHandler(this.tsbDebugTest_ClickAsync);
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
            // panelBrowser
            // 
            resources.ApplyResources(this.panelBrowser, "panelBrowser");
            this.panelBrowser.Name = "panelBrowser";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBrowser);
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
            this.MouseEnter += new System.EventHandler(this.FormMain_MouseEnter);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ToolStripDropDownButton tsdZoom;
        private System.Windows.Forms.Panel panelBrowser;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom400;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom200;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom150;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom125;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom100;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom75;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom50;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom95;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom90;
        private System.Windows.Forms.ToolStripMenuItem tsmZoom80;
        private System.Windows.Forms.ToolStripButton tsbWatch;
        private System.Windows.Forms.ToolStripButton tsbDebugTest;
        private System.Windows.Forms.ToolStripButton tsbEdit;
    }
}

