using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TTI
{
    public partial class frm_ImportFile : Form
    {
        frm_Main frmMain;

        public frm_ImportFile()
        {
            InitializeComponent();
        }

        private void frm_ImportFile_Load(object sender, EventArgs e)
        {

        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void frm_ImportFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroyImportFileForm();
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            if (dlg.SelectedPath.Length > 0)
                tb_path.Text = dlg.SelectedPath;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (tb_path.Text.Length > 0)
            {
                bool bPath = false;
                try
                {
                    if (Directory.Exists(tb_path.Text))
                        bPath = true;

                }
                catch (Exception ex)
                {

                }
                if (!bPath)
                {
                    MessageBox.Show("Path does not exists.");
                    return;
                }

                //stopped develop because of not enable manual upload csv

            }
            else
            {
                MessageBox.Show("Path empty.");
                return;
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }        
    }
}
