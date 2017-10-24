using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mdview
{
    public partial class OrganizeMDDialog : Form
    {
        internal List<MarkdownInfo> _mdinfos;
        public OrganizeMDDialog()
        {
            InitializeComponent();
        }

        private void OrganizeMDDialog_Load(object sender, EventArgs e)
        {
            Debug.Assert(_mdinfos != null);
            foreach(MarkdownInfo mi in _mdinfos)
            {
                lbMain.Items.Add(mi);
            }
        }

        private void lbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgMain.SelectedObject = lbMain.SelectedItem;
        }
    }
}
