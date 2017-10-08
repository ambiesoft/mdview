using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using NDesk.Options;
using System.Text;
using System.IO;
using Ambiesoft;

namespace mdview
{
    static class Program
    {
        static string getHelp()
        {
            return "mdview.exe mdfile";
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isHelp = false;
            var p = new OptionSet() {
                    {
                        "h|?|help",
                        "show help",
                        v => { isHelp = true; }
                    },
                };

            List<string> extra = p.Parse(args);
            if (isHelp)
            {
                MessageBox.Show(
                    getHelp(),
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (extra.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(getHelp());
                sb.AppendLine();
                sb.AppendLine();
                StringWriter sw = new StringWriter(sb);
                p.WriteOptionDescriptions(sw);

                AmbLib.Alert(sb.ToString());
                return;
            }
          
            Application.Run(new FormMain(extra.Count==0?null:extra[0]));
        }
    }
}
