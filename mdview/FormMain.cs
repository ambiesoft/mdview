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
using System.Runtime.InteropServices;

namespace mdview
{
    public partial class FormMain : Form
    {
        internal static readonly string SECTION_OPTION = "Option";
        static readonly string KEY_X = "X";
        static readonly string KEY_Y = "Y";
        static readonly string KEY_WIDTH = "Width";
        static readonly string KEY_HEIGHT = "Height";

        static readonly string KEY_RECENTS = "Recents";

        static readonly string KEY_MARKDOWN_CURRENTINDEX = "CurrentMarkdown";
        static readonly string KEY_MARKDOWN_COUNT = "MarkdownCount";
        
        static readonly string KEY_MARKDOWN_NAME = "MarkdownName";
        static readonly string KEY_MARKDOWN_EXECUTABLE = "MarkdownExecutable";
        static readonly string KEY_MARKDOWN_ADDITIONALARGUMENTS = "AdditionalArguments";
        static readonly string KEY_MARKDOWN_VERSIONARGUMENT = "VersionArgument";

        static readonly string KEY_ZOOMLEVEL = "ZoomLevel";
        static readonly string KEY_WATCH = "Watch";
        internal static readonly string KEY_LANGUAGE = "Language";

        

        readonly string _filetoopen;

        List<string> recents_ = new List<string>();
        // int maxrecents_ = 16;

        OptionDialog _optionDlg = new OptionDialog();

        List<MarkdownInfo> _mdinfos = new List<MarkdownInfo>();
        MarkdownInfo _currentMarkDown;
        MarkdownInfo CurrentMarkDown
        {
            get { return _currentMarkDown; }
            set
            {
                _currentMarkDown = value;
                slCurrentMD.Text = string.Format("MD: {0}", _currentMarkDown.DisplayText);
            }
        }


        // addtional commandline arguments for markdown
        //string _additionalArguments;
        //string AdditionalArguments
        //{
        //    get
        //    {
        //        switch (CurrentMarkDown)
        //        {
        //            case Markdown.Discount:
        //                if (_additionalArguments == null)
        //                {
        //                    Profile.GetString(SECTION_OPTION,
        //                        KEY_ADDITIONALARGUMENTS, string.Empty, out _additionalArguments, IniPath);
        //                }
        //                return _additionalArguments;
        //            case Markdown.Cmark:
        //                return string.Empty;
        //        }
        //        return string.Empty;
        //    }
        //    set
        //    {
        //        _additionalArguments = value;
        //        if (!Profile.WriteString(SECTION_OPTION,
        //            KEY_ADDITIONALARGUMENTS, _additionalArguments, IniPath))
        //        {
        //            CppUtils.Alert(Properties.Resources.INI_SAVE_FAILED);
        //        }
        //    }
        //}

        // MD currently opening
        string _currentMDFile;
        string CurrentMDFile
        {
            get
            {
                return _currentMDFile;
            }
            set
            {
                _currentMDFile = value;
                tsbRefresh.Enabled = !string.IsNullOrEmpty(_currentMDFile);
                tsbWatch.Enabled = !string.IsNullOrEmpty(_currentMDFile);
                tsbPrint.Enabled = !string.IsNullOrEmpty(_currentMDFile);
            }
        }

        WebBrowser wb;
        public FormMain(string file, HashIni initialIni)
        {
            _filetoopen = file;
            InitializeComponent();
            wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            panelBrowser.Controls.Add(wb);

            wb.ScriptErrorsSuppressed = true;
            wb.StatusTextChanged += Wb_StatusTextChanged;
            wb.WebBrowserShortcutsEnabled = true;
            wb.Navigating += Wb_Navigating;
            wb.NewWindow += Wb_NewWindow;
            wb.DocumentCompleted += Wb_DocumentCompleted;

            int intval = 0;

            int x, y, width, height;

            Profile.GetInt(SECTION_OPTION, KEY_X, -1, out x, initialIni);
            Profile.GetInt(SECTION_OPTION, KEY_Y, -1, out y, initialIni);
            Profile.GetInt(SECTION_OPTION, KEY_WIDTH, -1, out width, initialIni);
            Profile.GetInt(SECTION_OPTION, KEY_HEIGHT, -1, out height, initialIni);
            if (!(x == -1 && y == -1 && width == -1 && height == -1))
            {
                Rectangle rect = new Rectangle(x, y, width, height);
                if (AmbLib.IsRectAppearInScreen(rect))
                {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(x, y);
                    this.Size = new Size(width, height);
                }
            }

            int mdCount = 0;
            Profile.GetInt(SECTION_OPTION, 
                KEY_MARKDOWN_COUNT, 
                -1, 
                out mdCount,
                initialIni);
            for(int i=0;i<mdCount;++i)
            {
                string keyName = KEY_MARKDOWN_NAME + i.ToString();
                string keyExecutable = KEY_MARKDOWN_EXECUTABLE + i.ToString();
                string keyArgs = KEY_MARKDOWN_ADDITIONALARGUMENTS + i.ToString();
                string keyVArgs = KEY_MARKDOWN_VERSIONARGUMENT + i.ToString();

                string valueName;
                Profile.GetString(SECTION_OPTION,
                    keyName,
                    string.Empty,
                    out valueName,
                    initialIni);

                string valueExecutable;
                Profile.GetString(SECTION_OPTION,
                    keyExecutable,
                    string.Empty,
                    out valueExecutable,
                    initialIni);

                string valueArgs;
                Profile.GetString(SECTION_OPTION,
                    keyArgs,
                    string.Empty,
                    out valueArgs,
                    initialIni);

                string valueVArgs;
                Profile.GetString(SECTION_OPTION,
                    keyVArgs,
                    string.Empty,
                    out valueVArgs,
                    initialIni);

                _mdinfos.Add(new MarkdownInfo(valueName, valueExecutable, valueArgs,valueVArgs));
            }
            if(mdCount == -1)
            {
                // first launch, create default
                _mdinfos.Add(new MarkdownInfo("cmark", "cmark.exe", string.Empty, "--version"));
                _mdinfos.Add(new MarkdownInfo("discount", "markdown.exe", string.Empty, "-V"));
            }
            int currentMDIndex;
            Profile.GetInt(SECTION_OPTION,
                KEY_MARKDOWN_CURRENTINDEX,
                -1,
                out currentMDIndex,
                initialIni);
            if(currentMDIndex<0 || currentMDIndex >= _mdinfos.Count)
            {
                // invalid index
                currentMDIndex = 0;
            }
            if(_mdinfos.Count > currentMDIndex)
            {
                // valid index
                CurrentMarkDown = _mdinfos[currentMDIndex];
            }

            Profile.GetInt(SECTION_OPTION, KEY_ZOOMLEVEL, 100, out intval, initialIni);
            ZoomLevel = intval;

            Profile.GetBool(SECTION_OPTION, KEY_WATCH, false, out bool bWatch, initialIni);
            tsbWatch.Checked = bWatch;

            _optionDlg.LoadSettings(initialIni);
            RefreshRecent(initialIni);
        }

        int ZoomLevel;
        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // SetZoom(ZoomLevel);
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
                if (string.Compare(cache.CacheFileName, filename) == 0)
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
        //string MarkdownExecutable
        //{
        //    get
        //    {
        //        string ret = null;
        //        switch (CurrentMarkDown)
        //        {
        //            case Markdown.Discount:
        //                ret = Path.Combine(AppDir, "markdown.exe");
        //                if (File.Exists(ret))
        //                    return ret;
        //                return "markdown.exe";


        //            case Markdown.Cmark:
        //                ret = Path.Combine(AppDir, "cmark.exe");
        //                if (File.Exists(ret))
        //                    return ret;
        //                return "cmark.exe";

        //        }

        //        Debug.Assert(false);
        //        return null;
        //    }
        //}
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

            int max = _optionDlg.MaxRecnetCount;
            if (recents_.Count > max)
                recents_ = recents_.GetRange(0, max);

            if (!Profile.WriteStringArray(SECTION_OPTION, KEY_RECENTS, recents_.ToArray(), Program.IniPath))
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
        void OpenMD(string mdfile, bool bNavigate)
        {
            if(CurrentMarkDown==null)
            {
                CppUtils.Alert(Properties.Resources.NO_MARKDOWN);
                return;
            }
            int retval;
            string output, err;
            string baseurl = AmbLib.doubleQuoteIfSpace(AmbLib.pathToFileProtocol(Misc.PathAddBackslash(Path.GetDirectoryName(mdfile))));
            string arg = string.Format("{0} {1}",
                // baseurl,
                CurrentMarkDown.AdditionalArguments,
                AmbLib.doubleQuoteIfSpace(mdfile)
                );
            AmbLib.OpenCommandGetResult(
                CurrentMarkDown.ExecutableFullpath,
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

            string html = decorateHtml(output, baseurl, true);

            // Write to cache file,
            // if already exists, overwrite.
            CacheFile cache = null;
            foreach (CacheFile cf in _cacheFiles)
            {
                if (AmbLib.IsSameFile(cf.MDFileName, mdfile))
                    cache = cf;
            }
            if (cache == null)
            {
                cache = new CacheFile(mdfile, Path.GetTempFileName());
                _cacheFiles.Add(cache);
            }

            File.WriteAllBytes(cache.CacheFileName, Encoding.UTF8.GetBytes(html));
            cache.UpdateCacheTime();

            if(bNavigate)
                wb.Navigate(cache.CacheFileName);

            setTitle(mdfile);

            CurrentMDFile = mdfile;
            AddRecent(mdfile);
        }
        void OpenMD(string mdfile)
        {
            OpenMD(mdfile, true);
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

        bool loaded_ = false;
        private void FormMain_Load(object sender, EventArgs e)
        {
            setTitle(string.Empty);

            wb.Navigate("about:blank");
            while (wb.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();

            SetZoom(ZoomLevel);

            if (!string.IsNullOrEmpty(_filetoopen))
            {
                OpenMD(_filetoopen);
            }
            else if (_optionDlg.chkOpenLastOpened.Checked && recents_.Count != 0)
            {
                OpenMD(recents_[0]);
            }
            else
            {
                wb.Navigate("about:blank");
            }
            loaded_ = true;
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
            string inipath = Program.IniPath;
            HashIni ini = Profile.ReadAll(inipath);
            Profile.WriteInt(SECTION_OPTION, KEY_X, Location.X, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_Y, Location.Y, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_WIDTH, this.Size.Width, ini);
            Profile.WriteInt(SECTION_OPTION, KEY_HEIGHT, this.Size.Height, ini);

            Profile.WriteInt(SECTION_OPTION, KEY_ZOOMLEVEL, ZoomLevel, ini);

            Profile.WriteBool(SECTION_OPTION, KEY_WATCH, tsbWatch.Checked, ini);

            _optionDlg.SaveSettings(ini);

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

        void RefreshRecent(HashIni ini)
        {
            string[] recents = null;
            Profile.GetStringArray(SECTION_OPTION, KEY_RECENTS, out recents, ini);



            foreach (string s in recents)
            {
                recents_.Remove(s);
                recents_.Add(s);
            }

            int max = _optionDlg.MaxRecnetCount;
            if (recents_.Count > max)
                recents_ = recents_.GetRange(0, max);
        }
        void RefreshRecent()
        {
            RefreshRecent(Profile.ReadAll(Program.IniPath));
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
                item.Checked = CurrentMDFile == s;
                toadd.Add(item);
            }

            toadd.Add(new ToolStripSeparator());

            
            ToolStripMenuItem itemClearNonExistents = new ToolStripMenuItem();
            itemClearNonExistents.Text = Properties.Resources.CLEAR_NONEXISTENT_RECENTS;
            itemClearNonExistents.Click += ItemClearNonExistents_Click;
            toadd.Add(itemClearNonExistents);

            ToolStripMenuItem itemRemoveAllRecents = new ToolStripMenuItem();
            itemRemoveAllRecents.Text = Properties.Resources.CLEAR_ALL_RECENTS;
            itemRemoveAllRecents.Click += ItemRemoveAllRecents_Click;
            toadd.Add(itemRemoveAllRecents);

            tsdRecent.DropDownItems.AddRange(toadd.ToArray());
        }

        private void ItemClearNonExistents_Click(object sender, EventArgs e)
        {
            string[] recentsR = null;
            Profile.GetStringArray(SECTION_OPTION, KEY_RECENTS, out recentsR, Program.IniPath);
            if (recentsR == null || recentsR.Length == 0)
                return;

            List<string> recents = new List<string>();
            try
            {
                foreach (string rece in recentsR)
                {
                    if (File.Exists(rece))
                        recents.Add(rece);
                }

                if (!Profile.WriteStringArray(SECTION_OPTION, KEY_RECENTS, recents.ToArray(), Program.IniPath))
                    throw new Exception(Properties.Resources.INI_SAVE_FAILED);

                recents_.Clear();
                RefreshRecent();
            }
            catch(Exception ex)
            {
                CppUtils.Alert(this, ex);
            }
            
        }

        private void ItemRemoveAllRecents_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != CppUtils.YesOrNo(Properties.Resources.AREYOUSURETO_CLEAR_RECENTS,MessageBoxDefaultButton.Button2))
                return;

            try
            {
                if (!Profile.WriteStringArray(SECTION_OPTION, KEY_RECENTS, new string[0], Program.IniPath))
                    throw new Exception(Properties.Resources.INI_SAVE_FAILED);

                recents_.Clear();
                if (File.Exists(CurrentMDFile))
                    recents_.Add(CurrentMDFile);

                RefreshRecent();
            }
            catch (Exception ex)
            {
                CppUtils.Alert(this, ex);
            }
        }

        private void tsbOption_Click(object sender, EventArgs e)
        {
            _optionDlg.ShowDialog();
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (MarkdownInfo mi in _mdinfos)
            {
                int retval = 0;
                string output = string.Empty;
                string err = string.Empty;
                try
                {
                    AmbLib.OpenCommandGetResult(
                      mi.Executable,
                      mi.VersionArgument,
                      Encoding.Default,
                      out retval,
                      out output,
                      out err);

                    if (retval != 0 || !string.IsNullOrEmpty(err))
                    {
                        sb.AppendLine(String.Format("Error: returned {0}, error = \"{1}\"",
                            retval,
                            err.TrimEnd()));
                    }
                    else
                    {
                        sb.AppendLine(output.TrimEnd());
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                }
                sb.AppendLine("---------------------------------------");
            }
            using (AboutBox about = new AboutBox())
            {
                about.textBoxDescription.Text = sb.ToString();
                about.ShowDialog(this);
            }
        }

        private void tsdMarkdown_DropDownOpening(object sender, EventArgs e)
        {
            int sepIndex = tsdMarkdown.DropDownItems.IndexOf(tssOrganize);
            Debug.Assert(sepIndex >= 0);

            // remove items below separator
            while(tsdMarkdown.DropDownItems.Count > (sepIndex+1))
                tsdMarkdown.DropDownItems.RemoveAt(sepIndex+1);

            foreach(MarkdownInfo mi in _mdinfos)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem();
                tsi.Text = mi.DisplayText;
                tsi.Tag = mi;
                tsi.Checked = mi == CurrentMarkDown;
                tsi.Click += Tsi_Click;
                tsdMarkdown.DropDownItems.Add(tsi);
            }
        }

        private void Tsi_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            MarkdownInfo mi = (MarkdownInfo)tsi.Tag;
            CurrentMarkDown = mi;
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if(wb != null && wb.Created && !wb.IsDisposed)
            {
                // disabled by watch
                wb.Parent.Enabled = true;

                wb.Focus();
                HtmlDocument doc = wb.Document;
                if(doc != null)
                {
                    doc.Focus();
                }
            }
        }

        private void tsiOrganizeMD_Click(object sender, EventArgs e)
        {
            using (OrganizeMDDialog dlg = new OrganizeMDDialog())
            {
                dlg._mdinfos = _mdinfos;
                dlg.ShowDialog(this);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            wb.ShowPrintPreviewDialog();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (wb.Document == null)
                return;

            wb.Document.ExecCommand("Copy", false, null);
        }

        void RefreshBrowser()
        {
            if (string.IsNullOrEmpty(CurrentMDFile))
                return;

            OpenMD(CurrentMDFile, false);
            wb.Refresh();
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshBrowser();
        }

        //private void tsdZoom_DropDownOpening(object sender, EventArgs e)
        //{
        //    int currentZoomLevel = GetZoom();
        //    switch(currentZoomLevel)
        //    {
        //        case 50:tsmZoom50.Checked = true;break;
        //    }
        //}
        //private int GetZoom()
        //{
        //    try
        //    {
        //        int i = 0;
        //        object pi = "a";
        //        object po = (int)0;
        //        ((SHDocVw.WebBrowser)wb.ActiveXInstance).ExecWB(
        //            SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
        //            SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
        //            ref pi,
        //            ref po);
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        CppUtils.Alert(ex);
        //    }
        //    return 0;
        //}

        private void SetZoom(int zoomFactor)
        {
            try
            {
                ((SHDocVw.WebBrowser)wb.ActiveXInstance).ExecWB(
                    SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
                    SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                    zoomFactor,
                    IntPtr.Zero);
            }
            catch(Exception ex)
            {
                CppUtils.Alert(ex);
            }
        }
        private void tsmZoom_Click_Common(object sender, EventArgs e)
        {
            int factor = -1;
            if (sender == tsmZoom400)
                factor = 400;
            else if (sender == tsmZoom200)
                factor = 200;
            else if (sender == tsmZoom150)
                factor = 150;
            else if (sender == tsmZoom125)
                factor = 125;
            else if (sender == tsmZoom100)
                factor = 100;
            else if (sender == tsmZoom95)
                factor = 95;
            else if (sender == tsmZoom90)
                factor = 90;
            else if (sender == tsmZoom80)
                factor = 80;
            else if (sender == tsmZoom75)
                factor = 75;
            else if (sender == tsmZoom50)
                factor = 50;
            else
                Debug.Assert(false);

            if (factor == -1)
                return;

            ZoomLevel = factor;
            SetZoom(factor);
        }


        private void OnWatchChnaged(object source, FileSystemEventArgs e)
        {
            if(InvokeRequired)
            {
                Invoke(new FileSystemEventHandler(OnWatchChnaged), source, e);
                return;
            }
            if (!_watcher.EnableRaisingEvents)
                return;

            if (AmbLib.IsSameFile(e.FullPath, CurrentMDFile))
            {
                // make webbrowser not to steal focus
                // enabled back in various place.
                wb.Parent.Enabled = false;
                RefreshBrowser();

                // Ready state never changes.
                //while(wb.ReadyState != WebBrowserReadyState.Complete)
                //{
                //    Application.DoEvents();
                //}
            }
        }
        FileSystemWatcher _watcher;
        private void tsbWatch_CheckedChanged(object sender, EventArgs e)
        {
            if (!tsbWatch.Enabled)
                return;

            if(_watcher==null)
            {
                _watcher = new FileSystemWatcher();
                _watcher.NotifyFilter = NotifyFilters.LastWrite;
                _watcher.Changed += new FileSystemEventHandler(OnWatchChnaged);
            }

            if (tsbWatch.Checked)
            {
                _watcher.Path = Path.GetDirectoryName(CurrentMDFile);
                _watcher.Filter = Path.GetFileName(CurrentMDFile);
                _watcher.EnableRaisingEvents = true;
            }
            else
            {
                _watcher.EnableRaisingEvents = false;
            }

            if (loaded_)
            {
                if (!Profile.WriteBool(SECTION_OPTION, KEY_WATCH, tsbWatch.Checked, Program.IniPath))
                {
                    CppUtils.Alert(Properties.Resources.INI_SAVE_FAILED);
                }
            }
        }

        private void FormMain_MouseEnter(object sender, EventArgs e)
        {
            wb.Parent.Enabled = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Debug.WriteLine(keyData);
            // if (GetKeyState(0x11) < 0)
            if(keyData.HasFlag(Keys.Control) && keyData.HasFlag(Keys.Shift))
            {
                switch (keyData & Keys.KeyCode)
                {
                    case Keys.OemQuestion:
                        tsbOpen_Click(this, new EventArgs());
                        return true;
                    case Keys.OemPeriod:
                        tsbWatch.Checked = !tsbWatch.Checked;
                        return true;
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void tsbWatch_EnabledChanged(object sender, EventArgs e)
        {
            tsbWatch_CheckedChanged(sender, e);
        }
    }
}
