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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ambiesoft;
namespace mdview
{
    public partial class OptionDialog : Form
    {
        readonly string SECTION_OPTIONDIALOG = "OptionDialog";
        readonly string KEY_OPENLASTFILE = "OpenLastFile";
        readonly string KEY_BRINGWINNDOWTOTOPAFTERAUTOREFRESHED = "BringWindowToTopAfterAutoRefreshed";
        readonly string KEY_MAXRECENTS = "MaxRecents";

        public OptionDialog()
        {
            InitializeComponent();

            cmbLanguage.Items.Add(new ComboLangItem(Properties.Resources.CLI_SYSTEMDEFAULT, string.Empty));
            cmbLanguage.Items.Add(new ComboLangItem(Properties.Resources.CLI_ENGLISH, "en"));
            cmbLanguage.Items.Add(new ComboLangItem(Properties.Resources.CLI_JAPANESE, "ja-JP"));
        }
        internal int MaxRecnetCount
        {
            get
            {
                try
                {
                    return Math.Abs(Decimal.ToInt32(nupRecents.Value));
                }
                catch (Exception)
                {
                    return 1;
                }
            }
        }

        internal string Editor
        {
            get
            {
                return txtEditor.Text;
            }
        }
        internal void LoadSettings(HashIni ini)
        {
            bool boolval;
            int intval;

            Profile.GetBool(SECTION_OPTIONDIALOG, KEY_OPENLASTFILE, false, out boolval, ini);
            chkOpenLastOpened.Checked = boolval;

            Profile.GetBool(SECTION_OPTIONDIALOG, KEY_BRINGWINNDOWTOTOPAFTERAUTOREFRESHED, false, out boolval, ini);
            chkBringWindowToTopAfterAutoRefreshed.Checked = boolval;

            Profile.GetInt(SECTION_OPTIONDIALOG, KEY_MAXRECENTS, 16, out intval, ini);
            nupRecents.Value = intval;

            string lang;
            Profile.GetString(FormMain.SECTION_OPTION, FormMain.KEY_LANGUAGE, string.Empty, out lang, ini);
            object toSelect = null;
            foreach(object ob in cmbLanguage.Items)
            {
                ComboLangItem item = (ComboLangItem)ob;
                if (item.Language == lang)
                {
                    toSelect = item;
                    break;
                }
            }
            if (toSelect != null)
                cmbLanguage.SelectedItem = toSelect;

            string editor;
            Profile.GetString(FormMain.SECTION_OPTION, FormMain.KEY_EDITOR, string.Empty, out editor, ini);
            txtEditor.Text = editor;

            lblRestartNotice.Visible = false;
        }
        internal bool SaveSettings(HashIni ini)
        {
            bool failed = false;
            failed |= !Profile.WriteBool(SECTION_OPTIONDIALOG, KEY_OPENLASTFILE, chkOpenLastOpened.Checked, ini);
            failed |= !Profile.WriteBool(SECTION_OPTIONDIALOG, KEY_BRINGWINNDOWTOTOPAFTERAUTOREFRESHED, chkBringWindowToTopAfterAutoRefreshed.Checked, ini);
            failed |= !Profile.WriteInt(SECTION_OPTIONDIALOG, KEY_MAXRECENTS, Decimal.ToInt32(nupRecents.Value), ini);

            if (cmbLanguage.SelectedItem != null)
            {
                ComboLangItem item = (ComboLangItem)cmbLanguage.SelectedItem;
                failed |= !Profile.WriteString(FormMain.SECTION_OPTION,
                    FormMain.KEY_LANGUAGE,
                    item.Language,
                    ini);
            }

            failed |= !Profile.WriteString(FormMain.SECTION_OPTION,
                FormMain.KEY_EDITOR,
                txtEditor.Text,
                ini);

            return !failed;
        }

        private void OptionDialog_Load(object sender, EventArgs e)
        {
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRestartNotice.Visible = true;
        }

        private void btnBrowseEditor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != ofdEditor.ShowDialog())
                return;

            txtEditor.Text = ofdEditor.FileName;
        }
    }
}
