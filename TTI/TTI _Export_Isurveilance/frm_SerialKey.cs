using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTI
{
    public partial class frm_SerialKey : Form
    {
        frm_Main frmMain;
        SettingClass sc;
        KeyActivationClass keyActClass;
        bool bIsActivated = true;
        public frm_SerialKey()
        {
            InitializeComponent();
        }

        private void frm_SerialKey_Load(object sender, EventArgs e)
        {
            keyActClass = new KeyActivationClass();
            bIsActivated = false;
            FileInfo file = new FileInfo("ClientKey.ditk");
            lb_Path.Text = file.FullName;
        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void frm_SerialKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroyKeyVerifyingForm(!bIsActivated);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (keyActClass.TryActivate() == false)
            {
                bIsActivated = false;
                MessageBox.Show("Activation Failed");
            }
            bIsActivated = true;
            this.Close();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() ;
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    tb_SerialKey.Text = text;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
