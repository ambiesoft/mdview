using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Ambiesoft;

namespace mdview
{
    public partial class FormMain : Form
    {
        static readonly string SECTION_OPTION = "Option";
        static readonly string KEY_X = "X";
        static readonly string KEY_Y = "Y";
        static readonly string KEY_WIDTH = "Width";
        static readonly string KEY_HEIGHT = "Height";

        static readonly string KEY_MAXRECENTS = "MaxRecents";
        static readonly string KEY_RECENTS = "Recents";
        
        readonly string _filetoopen;

        List<string> recents_ = new List<string>();
        int maxrecents_ = 16;

        // addtional commandline arguments for markdown
        string _additionalArguments = string.Empty;

        // MD currently opening
        string currentMD_;

        public FormMain(string file)
        {
            _filetoopen = file;
            InitializeComponent();

            wb.StatusTextChanged += Wb_StatusTextChanged;
            wb.Navigating += Wb_Navigating;

            int x, y, width, height;
            HashIni ini = Profile.ReadAll(IniPath);
            Profile.GetInt(SECTION_OPTION, KEY_X, -1, out x, ini);
            Profile.GetInt(SECTION_OPTION, KEY_Y, -1, out y, ini);
            Profile.GetInt(SECTION_OPTION, KEY_WIDTH, -1, out width, ini);
            Profile.GetInt(SECTION_OPTION, KEY_HEIGHT, -1, out height, ini);
            if(!(x==-1&&y==-1&&width==-1&&height==-1))
            {
                Rectangle rect = new Rectangle(x, y, width, height);
                if(AmbLib.IsRectInScreen(rect))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(x, y);
                    this.Size = new Size(width, height);
                }
            }

       
        }
        bool isSchemeJump(string scheme)
        {
            scheme = scheme.ToLower();
            if (scheme.StartsWith("http"))
                return true;
            if (scheme.StartsWith("ftp"))
                return true;

            return false;
        }
        private void Wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.TargetFrameName))
            {
                // not care about frame
                return;
            }
            if(e.Url.Scheme=="file")
            {
                e.Cancel = true;
                OpenMD(e.Url.AbsolutePath);
                return;
            }
            else if(e.Url.Scheme=="about")
            {
                // nothing
            }
            else if(isSchemeJump(e.Url.Scheme))
            {
                e.Cancel = true;
                try
                {
                    Process.Start(e.Url.AbsoluteUri);
                }
                catch(Exception ex)
                {
                    AmbLib.Alert(ex);
                }
            }
        }

        private void Wb_StatusTextChanged(object sender, EventArgs e)
        {
            slMain.Text = wb.StatusText;
        }

        string AppDir
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }
        string getMarkdownExe()
        {
            string ret = Path.Combine(AppDir, "markdown.exe");
            if (File.Exists(ret))
                return ret;
            return "markdown.exe";
        }
        void prepareBrowser()
        {
            wb.Navigate("about:blank");
            while(wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }
        void setTitle(string title)
        {
            this.Text = title;
        }
       
        void AddRecent(string file)
        {
            RefreshRecent();

            recents_.Remove(file);
            recents_.Insert(0, file);

            if (recents_.Count > maxrecents_)
                recents_ = recents_.GetRange(0, maxrecents_);

            if(!Profile.WriteStringArray(SECTION_OPTION, KEY_RECENTS, recents_.ToArray(), IniPath))
            {
                AmbLib.Alert(Properties.Resources.INI_SAVE_FAILED);
            }
        }
        string decorateHtml(string html)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head>");
            sb.AppendLine("<style type=\"text/css\">");
            sb.AppendLine("code");
            sb.AppendLine("{ ");
            sb.AppendLine("  display: block;");
            sb.AppendLine("  white-space: pre-wrap;");
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            sb.AppendLine(html);
            sb.AppendLine("</body></html>");

            return sb.ToString();
        }
        void OpenMD(string mdfile)
        {
            int retval;
            string output, err;
            string arg = string.Format("-b {0} {1} {2}",
                AmbLib.doubleQuoteIfSpace(AmbLib.pathToFileProtocol(Misc.PathAddBackslash(Path.GetDirectoryName(mdfile)))),
                // AmbLib.doubleQuoteIfSpace((PathAddBackslash(Path.GetDirectoryName(mdfile)))),
                _additionalArguments,
                AmbLib.doubleQuoteIfSpace(mdfile)
                );
            AmbLib.OpenCommandGetResult(
                getMarkdownExe(),
                arg,
                Encoding.Default,
                out retval,
                out output,
                out err);

            if (retval != 0 || !string.IsNullOrEmpty(err))
            {
                AmbLib.Alert(string.Format("Returned => {0}\n{1}", retval, err));
                return;
            }

            prepareBrowser();
            string html = decorateHtml(output);
            wb.Document.Write(html);
            setTitle(mdfile);

            currentMD_ = mdfile;
            AddRecent(mdfile);
        }
        void OnOpenMd()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (DialogResult.OK != ofd.ShowDialog())
                    return;

                OpenMD(ofd.FileName);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                OnOpenMd();
            }
            catch (Exception ex)
            {
                AmbLib.Alert(ex);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_filetoopen))
            {
                OpenMD(_filetoopen);
            }
            else
            {
                wb.Navigate("about:blank");
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragLeave(object sender, EventArgs e)
        {

        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
                return;

            OpenMD(files[0]);
        }

        string IniPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                    Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".ini");
            }
        }


        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string inipath = IniPath;
            HashIni ini = Profile.ReadAll(inipath);
            Profile.WriteInt(SECTION_OPTION, KEY_X, Location.X, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_Y, Location.Y, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_WIDTH, this.Size.Width, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_HEIGHT, this.Size.Height, ini);



            if (!Profile.WriteAll(ini, inipath))
            {
                AmbLib.Alert(Properties.Resources.INI_SAVE_FAILED);
            }

            
        }



        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            OpenMD(item.Tag.ToString());
        }

        void RefreshRecent()
        {
            HashIni ini = Profile.ReadAll(IniPath);

            string[] recents = null;
            Profile.GetStringArray(SECTION_OPTION, KEY_RECENTS, out recents, ini);
            Profile.GetInt(SECTION_OPTION, KEY_MAXRECENTS, 16, out maxrecents_, ini);
            maxrecents_ = Math.Abs(maxrecents_);
            foreach (string s in recents)
            {
                recents_.Remove(s);
                recents_.Add(s);
            }

            if (recents_.Count > maxrecents_)
                recents_ = recents_.GetRange(0, maxrecents_);
        }
        private void toolStripDropDownButtonRecent_DropDownOpening(object sender, EventArgs e)
        {
            RefreshRecent();

            toolStripDropDownButtonRecent.DropDownItems.Clear();
            if (recents_.Count == 0)
            {
                toolStripDropDownButtonRecent.DropDownItems.Add(Properties.Resources.NO_RECENT_ITEM);
                return;
            }

            List<ToolStripItem> toadd = new List<ToolStripItem>();
            foreach (string s in recents_)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = s;
                item.Tag = s;
                item.Click += Item_Click;
                item.Checked = currentMD_ == s;
                toadd.Add(item);
            }
            toolStripDropDownButtonRecent.DropDownItems.AddRange(toadd.ToArray());
        }

        
        private void toolStripButtonOption_Click(object sender, EventArgs e)
        {
            using (OptionDialog dlg = new OptionDialog())
            {

                dlg.txtAdditionalArgument.Text = _additionalArguments;

                if (DialogResult.OK != dlg.ShowDialog())
                    return;

                _additionalArguments = dlg.txtAdditionalArgument.Text;
            }
        }
    }
}
