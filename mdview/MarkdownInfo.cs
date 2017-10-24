using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace mdview
{
    class MarkdownInfo
    {
        string _name;
        string _executable;
        string _args;
        
        public MarkdownInfo(string name,string exe,string args,string versionarg)
        {
            _name = name;
            _executable = exe;
            _args = args;
            VersionArgument = versionarg;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string AdditionalArguments
        {
            get
            {
                return _args;
            }
            set
            {
                _args = value;
            }
        }
        public string VersionArgument
        {
            get;
            set;
        }
        public bool Exists
        {
            get
            {
                return File.Exists(ExecutableFullpath);
            }
        }
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Executable
        {
            get
            {
                return _executable;
            }
            set
            {
                _executable = value;
            }
        }
        public string ExecutableFullpath
        {
            get
            {
                if (Path.IsPathRooted(_executable))
                    return _executable;

                return Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath),
                    _executable);
            }
        }
        public string DisplayText
        {
            get
            {
                return Path.GetFileNameWithoutExtension(_executable);
            }
        }

        override public string ToString()
        {
            return Name;
        }

    }
}
