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
            this.wb = new System.Windows.Forms.WebBrowser();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsdRecent = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmDummy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tss0 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdMarkdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmCmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDiscount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOption = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.slMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsMain.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 25);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.ScriptErrorsSuppressed = true;
            this.wb.Size = new System.Drawing.Size(619, 417);
            this.wb.TabIndex = 0;
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdRecent,
            this.tsbOpen,
            this.tsbPrint,
            this.tss0,
            this.tsbCopy,
            this.tss1,
            this.tsdMarkdown,
            this.tsbOption,
            this.tsbHelp});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(619, 25);
            this.tsMain.TabIndex = 1;
            // 
            // tsdRecent
            // 
            this.tsdRecent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdRecent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDummy});
            this.tsdRecent.Image = ((System.Drawing.Image)(resources.GetObject("tsdRecent.Image")));
            this.tsdRecent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdRecent.Name = "tsdRecent";
            this.tsdRecent.Size = new System.Drawing.Size(29, 22);
            this.tsdRecent.Text = "Recent files";
            this.tsdRecent.DropDownOpening += new System.EventHandler(this.tsdRecent_DropDownOpening);
            // 
            // tsmDummy
            // 
            this.tsmDummy.Name = "tsmDummy";
            this.tsmDummy.Size = new System.Drawing.Size(116, 22);
            this.tsmDummy.Text = "dummy";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "&Print";
            // 
            // tss0
            // 
            this.tss0.Name = "tss0";
            this.tss0.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "&Copy";
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsdMarkdown
            // 
            this.tsdMarkdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdMarkdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCmark,
            this.tsmDiscount});
            this.tsdMarkdown.Image = ((System.Drawing.Image)(resources.GetObject("tsdMarkdown.Image")));
            this.tsdMarkdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdMarkdown.Name = "tsdMarkdown";
            this.tsdMarkdown.Size = new System.Drawing.Size(29, 22);
            this.tsdMarkdown.Text = "Markdown";
            this.tsdMarkdown.DropDownOpening += new System.EventHandler(this.tsdMarkdown_DropDownOpening);
            // 
            // tsmCmark
            // 
            this.tsmCmark.Name = "tsmCmark";
            this.tsmCmark.Size = new System.Drawing.Size(120, 22);
            this.tsmCmark.Text = "cmark";
            this.tsmCmark.Click += new System.EventHandler(this.tsmCmark_Click);
            // 
            // tsmDiscount
            // 
            this.tsmDiscount.Name = "tsmDiscount";
            this.tsmDiscount.Size = new System.Drawing.Size(120, 22);
            this.tsmDiscount.Text = "discount";
            this.tsmDiscount.Click += new System.EventHandler(this.tsmDiscount_Click);
            // 
            // tsbOption
            // 
            this.tsbOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOption.Image = ((System.Drawing.Image)(resources.GetObject("tsbOption.Image")));
            this.tsbOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOption.Name = "tsbOption";
            this.tsbOption.Size = new System.Drawing.Size(23, 22);
            this.tsbOption.Text = "Option";
            this.tsbOption.Click += new System.EventHandler(this.tsbOption_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Text = "He&lp";
            this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slMain});
            this.ss.Location = new System.Drawing.Point(0, 442);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(619, 22);
            this.ss.TabIndex = 2;
            // 
            // slMain
            // 
            this.slMain.Name = "slMain";
            this.slMain.Size = new System.Drawing.Size(604, 17);
            this.slMain.Spring = true;
            this.slMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 464);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Form1";
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
        private System.Windows.Forms.ToolStripSeparator tss0;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel slMain;
        private System.Windows.Forms.ToolStripButton tsbOption;
        private System.Windows.Forms.ToolStripDropDownButton tsdRecent;
        private System.Windows.Forms.ToolStripMenuItem tsmDummy;
        private System.Windows.Forms.ToolStripDropDownButton tsdMarkdown;
        private System.Windows.Forms.ToolStripMenuItem tsmDiscount;
        private System.Windows.Forms.ToolStripMenuItem tsmCmark;
    }
}

