//BSD 2-Clause License
//
//Copyright (c) 2017, Ambiesoft
//All rights reserved.
//
//Redistribution and use in source and binary forms, with or without
//modification, are permitted provided that the following conditions are met:
//
//* Redistributions of source code must retain the above copyright notice, this
//  list of conditions and the following disclaimer.
//
//* Redistributions in binary form must reproduce the above copyright notice,
//  this list of conditions and the following disclaimer in the documentation
//  and/or other materials provided with the distribution.
//
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
//DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
//FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
//DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
//SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
//CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
//OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
//OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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
using System.Reflection;

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

        static readonly string KEY_ADDITIONALARGUMENTS = "AdditionalArguments";

        readonly string _filetoopen;

        List<string> recents_ = new List<string>();
        int maxrecents_ = 16;

        enum Markdown {
            Cmark,
            Discount,
        };

        Markdown _currentMarkDown;
        Markdown CurrentMarkDown
        {
            get { return _currentMarkDown; }
            set { _currentMarkDown = value; }
        }


        // addtional commandline arguments for markdown
        string _additionalArguments;
        string AdditionalArguments
        {
            get
            {
                switch (CurrentMarkDown)
                {
                    case Markdown.Discount:
                        if (_additionalArguments == null)
                        {
                            Profile.GetString(SECTION_OPTION,
                                KEY_ADDITIONALARGUMENTS, string.Empty, out _additionalArguments, IniPath);
                        }
                        return _additionalArguments;
                    case Markdown.Cmark:
                        return string.Empty;
                }
                return string.Empty;
            }
            set
            {
                _additionalArguments = value;
                if (!Profile.WriteString(SECTION_OPTION,
                    KEY_ADDITIONALARGUMENTS, _additionalArguments, IniPath))
                {
                    CppUtils.Alert(Properties.Resources.INI_SAVE_FAILED);
                }
            }
        }

        // MD currently opening
        string _openingMD;

        public FormMain(string file)
        {
            _filetoopen = file;
            InitializeComponent();

            wb.StatusTextChanged += Wb_StatusTextChanged;
            wb.Navigating += Wb_Navigating;
            wb.NewWindow += Wb_NewWindow;
            wb.DocumentCompleted += Wb_DocumentCompleted;
            int x, y, width, height;
            HashIni ini = Profile.ReadAll(IniPath);
            Profile.GetInt(SECTION_OPTION, KEY_X, -1, out x, ini);
            Profile.GetInt(SECTION_OPTION, KEY_Y, -1, out y, ini);
            Profile.GetInt(SECTION_OPTION, KEY_WIDTH, -1, out width, ini);
            Profile.GetInt(SECTION_OPTION, KEY_HEIGHT, -1, out height, ini);
            if (!(x == -1 && y == -1 && width == -1 && height == -1))
            {
                Rectangle rect = new Rectangle(x, y, width, height);
                if (AmbLib.IsRectInScreen(rect))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(x, y);
                    this.Size = new Size(width, height);
                }
            }


        }

        int _ZoomLevel;
        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //int curZoomLevel = getBrowserZoomLevel();
            //if(curZoomLevel > 0)
            //{
            //    if(_ZoomLevel != curZoomLevel)
            //    {
            //        if(setBrowserZoomLevel(_ZoomLevel))
            //        {
            //            _ZoomLevel = curZoomLevel;
            //        }
            //    }
            //}
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
        bool IsMD(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return false;

            if (Path.GetExtension(filename).ToLower() != ".md")
            {
                // not md, open normally
                return false;
            }

            return true;
        }
        bool IsMDAndNotInCache(string filename)
        {
            if (!IsMD(filename))
                return false;

            foreach (CacheFile cache in _cacheFiles)
            {
                if (string.Compare(cache.FileName, filename) == 0)
                {
                    // cache file, open normally
                    return false;
                }
            }
            return true;
        }
        private void Wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.TargetFrameName))
            {
                // not care about frame
                return;
            }
            if (e.Url.Scheme == "file")
            {
                if (IsMDAndNotInCache(e.Url.AbsolutePath))
                {
                    e.Cancel = true;
                    OpenMD(e.Url.AbsolutePath);
                    return;
                }
            }
            else if (e.Url.Scheme == "about")
            {
                // nothing
            }
            else if (isSchemeJump(e.Url.Scheme))
            {
                e.Cancel = true;
                try
                {
                    Process.Start(e.Url.AbsoluteUri);
                }
                catch (Exception ex)
                {
                    CppUtils.Alert(ex);
                }
            }
        }

        string lastStatusText_;
        private void Wb_StatusTextChanged(object sender, EventArgs e)
        {
            string wbText = wb.StatusText;
            slMain.Text = wbText;
            if (!string.IsNullOrEmpty(wbText))
                lastStatusText_ = wbText;

        }
        private void Wb_NewWindow(object sender, CancelEventArgs e)
        {
            string path = AmbLib.getPathFromUrl(lastStatusText_);
            if (IsMD(path))
            {
                try
                {
                    Process.Start(Application.ExecutablePath,
                        AmbLib.doubleQuoteIfSpace(path));
                }
                catch (Exception ex)
                {
                    CppUtils.Alert(this, ex);
                }
                e.Cancel = true;
                return;
            }
        }
        string AppDir
        {
            get
            {
                return Path.GetDirectoryName(Application.ExecutablePath);
            }
        }
        string MarkdownExecutable
        {
            get
            {
                string ret = null;
                switch (CurrentMarkDown)
                {
                    case Markdown.Discount:
                        ret = Path.Combine(AppDir, "markdown.exe");
                        if (File.Exists(ret))
                            return ret;
                        return "markdown.exe";


                    case Markdown.Cmark:
                        ret = Path.Combine(AppDir, "cmark.exe");
                        if (File.Exists(ret))
                            return ret;
                        return "cmark.exe";

                }

                Debug.Assert(false);
                return null;
            }
        }
        void prepareBrowser()
        {
            wb.Navigate("about:blank");
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }
        void setTitle(string title)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(title))
            {
                sb.Append(title);
                sb.Append(" | ");
            }
            sb.Append(ProductName);

            this.Text = sb.ToString();
        }

        void AddRecent(string file)
        {
            RefreshRecent();

            recents_.Remove(file);
            recents_.Insert(0, file);

            if (recents_.Count > maxrecents_)
                recents_ = recents_.GetRange(0, maxrecents_);

            if (!Profile.WriteStringArray(SECTION_OPTION, KEY_RECENTS, recents_.ToArray(), IniPath))
            {
                CppUtils.Alert(Properties.Resources.INI_SAVE_FAILED);
            }
        }
        string HighLightStyle
        {
            get
            {
                return Path.Combine(AppDir, "highlight", "styles", "default.css");
            }
        }
        string HighLightJS
        {
            get
            {
                return Path.Combine(AppDir, "highlight", "highlight.pack.js");
            }
        }
        string decorateHtml(string html, string baseurl, bool bHighLight)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head>");
            sb.AppendLine("<meta charset=\"utf-8\">");

            if (!string.IsNullOrEmpty(baseurl))
            {
                sb.AppendFormat("<base href=\"{0}\">", baseurl);
                sb.AppendLine();
            }

            if (bHighLight)
            {
                sb.AppendFormat("<link rel=\"stylesheet\" href=\"{0}\">",
                    AmbLib.pathToFileProtocol(HighLightStyle));
                sb.AppendLine();

                sb.AppendFormat("<script src=\"{0}\"></script>",
                    AmbLib.pathToFileProtocol(HighLightJS));
                sb.AppendLine();

                sb.AppendLine("<script>hljs.initHighlightingOnLoad();</script>");
            }

            //sb.AppendLine("<style type=\"text/css\">");
            //sb.AppendLine("code");
            //sb.AppendLine("{ ");
            //sb.AppendLine("  display: block;");
            //sb.AppendLine("  white-space: pre-wrap;");
            //sb.AppendLine("}");
            //sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            sb.AppendLine(html);
            sb.AppendLine("</body></html>");

            return sb.ToString();
        }

        List<CacheFile> _cacheFiles = new List<CacheFile>();
        void OpenMD(string mdfile)
        {
            int retval;
            string output, err;
            string baseurl = AmbLib.doubleQuoteIfSpace(AmbLib.pathToFileProtocol(Misc.PathAddBackslash(Path.GetDirectoryName(mdfile))));
            string arg = string.Format("{0} {1}",
                // baseurl,
                AdditionalArguments,
                AmbLib.doubleQuoteIfSpace(mdfile)
                );
            AmbLib.OpenCommandGetResult(
                MarkdownExecutable,
                arg,
                Encoding.UTF8,
                out retval,
                out output,
                out err);

            if (retval != 0 || !string.IsNullOrEmpty(err))
            {
                CppUtils.Alert(string.Format("Returned => {0}\n{1}", retval, err));
                return;
            }

            //prepareBrowser();
            string html = decorateHtml(output, baseurl, true);

            string tempfile = Path.GetTempFileName();
            File.WriteAllBytes(tempfile, Encoding.UTF8.GetBytes(html));
            _cacheFiles.Add(new CacheFile(tempfile));

            //wb.Document.Write(html);
            wb.Navigate(tempfile);
            setTitle(mdfile);

            _openingMD = mdfile;
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

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OnOpenMd();
            }
            catch (Exception ex)
            {
                CppUtils.Alert(ex);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            setTitle(string.Empty);
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

            if (IsMDAndNotInCache(files[0]))
                OpenMD(files[0]);
            else
                wb.Navigate(files[0]);
        }

        string IniPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                    Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".ini");
            }
        }


        private int TODO_getBrowserZoomLevel()
        {
            //while(
            //    (int)(((SHDocVw.WebBrowser)wb.ActiveXInstance).QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM))
            //        != ((int)SHDocVw.OLECMDF.OLECMDF_SUPPORTED + (int)SHDocVw.OLECMDF.OLECMDF_ENABLED) )
            //{
            //    Application.DoEvents();
            //} 

            //var web = wb.ActiveXInstance.GetType();
            //object o = new object();// zoomPercentage; // Between 10 and 1000.

            //web.InvokeMember(
            //    @"ExecWB",
            //    BindingFlags.InvokeMethod,
            //    null,
            //    wb.ActiveXInstance,
            //    new[]
            //        {
            //            SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
            //            SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
            //            o,
            //            o
            //        });
            //return (int)o;


            try
            {
                object pvarOut1 = 123;
                object pvarOut2 = 124;

                var browserInst = ((SHDocVw.IWebBrowser2)(wb.ActiveXInstance));
                browserInst.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
                                   SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                                   ref pvarOut1, ref pvarOut2);
                return (int)pvarOut2;
            }
            catch (Exception)
            {
                return -1;
            }


            //object ret = new object();
            //((SHDocVw.WebBrowser)wb.ActiveXInstance).ExecWB(
            //    SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
            //    SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
            //    IntPtr.Zero,
            //    ref ret);
            //return (int)ret;
        }
        private bool TODO_setBrowserZoomLevel(int value)
        {
            try
            {
                object pvaIn = value; // A VT_I4 percentage ranging from 10% to 1000%
                var browserInst = ((SHDocVw.IWebBrowser2)(wb.ActiveXInstance));
                browserInst.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
                                   SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                                   ref pvaIn, IntPtr.Zero);
            }
            catch(Exception)
            {
                return false;
            }
            return true;

           // while (
           //(int)(((SHDocVw.WebBrowser)wb.ActiveXInstance).QueryStatusWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM))
           //    != ((int)SHDocVw.OLECMDF.OLECMDF_SUPPORTED + (int)SHDocVw.OLECMDF.OLECMDF_ENABLED))
           // {
           //     Application.DoEvents();
           // }
           // ((SHDocVw.WebBrowser)wb.ActiveXInstance).ExecWB(
           //     SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
           //     SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT,
           //     value,
           //     IntPtr.Zero);
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string inipath = IniPath;
            HashIni ini = Profile.ReadAll(inipath);
            Profile.WriteInt(SECTION_OPTION, KEY_X, Location.X, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_Y, Location.Y, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_WIDTH, this.Size.Width, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_HEIGHT, this.Size.Height, ini);

            // int zoom = getBrowserZoomLevel();

            if (!Profile.WriteAll(ini, inipath))
            {
                CppUtils.Alert(Properties.Resources.INI_SAVE_FAILED);
            }


            // delete cache
            foreach (CacheFile cf in _cacheFiles)
                cf.Delete();
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
        private void tsdRecent_DropDownOpening(object sender, EventArgs e)
        {
            RefreshRecent();

            tsdRecent.DropDownItems.Clear();
            if (recents_.Count == 0)
            {
                tsdRecent.DropDownItems.Add(Properties.Resources.NO_RECENT_ITEM);
                return;
            }

            List<ToolStripItem> toadd = new List<ToolStripItem>();
            foreach (string s in recents_)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = s;
                item.Tag = s;
                item.Click += Item_Click;
                item.Checked = _openingMD == s;
                toadd.Add(item);
            }
            tsdRecent.DropDownItems.AddRange(toadd.ToArray());
        }

        
        private void tsbOption_Click(object sender, EventArgs e)
        {
            using (OptionDialog dlg = new OptionDialog())
            {
                dlg.txtAdditionalArgument.Text = AdditionalArguments;

                if (DialogResult.OK != dlg.ShowDialog())
                    return;

                AdditionalArguments = dlg.txtAdditionalArgument.Text;
            }
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ProductName);
            sb.Append(" ");
            sb.Append("version ");
            sb.Append(Application.ProductVersion);

            sb.AppendLine();
            sb.AppendLine();

            int retval;
            string output, err;
            try
            {
                AmbLib.OpenCommandGetResult(
                  MarkdownExecutable,
                  "--version",
                  Encoding.Default,
                  out retval,
                  out output,
                  out err);

                if(retval!=0||!string.IsNullOrEmpty(err))
                {
                    sb.AppendLine("Error");
                }
                else
                {
                    sb.AppendLine(output);
                }



            }
            catch(Exception ex)
            {
                sb.AppendLine(ex.Message);
            }

            CppUtils.CenteredMessageBox(
                this,
                sb.ToString(),
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void tsdMarkdown_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in tsdMarkdown.DropDownItems)
                item.Checked = false;

            switch (CurrentMarkDown)
            {
                case Markdown.Discount:
                    tsmDiscount.Checked = true;
                    break;
                case Markdown.Cmark:
                    tsmCmark.Checked = true;
                    break;
                //default:
                //    Debug.Assert(false);
            }
            
        }

        private void tsmDiscount_Click(object sender, EventArgs e)
        {
            CurrentMarkDown = Markdown.Discount;
        }

        private void tsmCmark_Click(object sender, EventArgs e)
        {
            CurrentMarkDown = Markdown.Cmark;
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if(wb != null && wb.Created && !wb.IsDisposed)
            {
                wb.Focus();
                HtmlDocument doc = wb.Document;
                if(doc != null)
                {
                    doc.Focus();
                }
            }
        }
    }
}
