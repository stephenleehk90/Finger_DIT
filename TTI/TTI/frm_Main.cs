using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTI
{
    public partial class frm_Main : Form
    {
        frm_Setting frmSetting;
        frm_DBLogin frmDBLogin;
        frm_SerialKey frmKeyVerify;
        frm_WebServiceSetting frmWebServiceSetting;
        frm_ImportFile frmImportFile;
        frm_UserInfoImport frmUserInfoImport;//Pat 20160912 user info import

        bool bLoginValidated, bKeyIsValid;

        public frm_Main()
        {
            InitializeComponent();
            bKeyIsValid = false;
        }

        public void DestroySettingForm()
        {
            frmSetting = null;
        }
        
        public void DestroyLoginForm()
        {
            frmDBLogin = null;
        }
        //Pat 20160810 in_resume-----------------------
        public void DestroyWebServiceSettingForm()
        {
            frmWebServiceSetting = null;
        }
        public void DestroyImportFileForm()
        {
            frmImportFile = null;
        }
        //---------------------------------------------
        public void DestroyKeyVerifyingForm(bool bCloseApp)
        {
            frmKeyVerify = null;
            if (bCloseApp == true)
                Application.Exit();
            VerifyingSerialKey();
            EnableControl();
            if (bKeyIsValid ==true)
                exportToolStripMenuItem_Click(null,null);
            else
                Application.Exit();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            VerifyingSerialKey();
            EnableControl();
            if (bKeyIsValid == false)
            {
                verifyToolStripMenuItem_Click(null, null);
                return;
            }
            exportToolStripMenuItem_Click(null, null);
        }

        private void EnableControl()
        {
            settingToolStripMenuItem.Enabled = exportToolStripMenuItem.Enabled = bKeyIsValid;
            verifyToolStripMenuItem.Enabled = !bKeyIsValid;
        }

        private void connectionSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDBLogin == null)
            {
                frmDBLogin = new frm_DBLogin();
                frmDBLogin.SetFrmMain(this);
                frmDBLogin.MdiParent = this;
                frmDBLogin.bAuto = false;
            }
            frmDBLogin.Show();
        }
        public void SetLoginValidated(bool bRet, bool bCallExport)
        {
            this.bLoginValidated = bRet;
            if (bCallExport == true && bLoginValidated == true)
            {
                if (frmSetting == null)
                {
                    frmSetting = new frm_Setting();
                    frmSetting.SetFrmMain(this);
                    frmSetting.MdiParent = this;
                }
                frmSetting.Show();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDBLogin == null)
            {
                frmDBLogin = new frm_DBLogin();
                frmDBLogin.SetFrmMain(this);
                frmDBLogin.MdiParent = this;
                frmDBLogin.bAuto = true;
            }
            frmDBLogin.Show();
        }

        private void frm_Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                ShowInTaskbar = false;
                this.Hide();
                //notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void VerifyingSerialKey()
        {
            KeyActivationClass keyActClass = new KeyActivationClass();
            if (keyActClass.TryActivate() == false)
               bKeyIsValid = false;
            else
               bKeyIsValid = true;
        }

        private void verifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKeyVerify == null)
            {
                frmKeyVerify = new frm_SerialKey();
                frmKeyVerify.SetFrmMain(this);
                frmKeyVerify.MdiParent = this;
            }
            frmKeyVerify.Show();
        }
        //Pat 20160815 in_resume-------------------------------------------------------------
        private void webServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmWebServiceSetting == null)
            {
                frmWebServiceSetting = new frm_WebServiceSetting();
                frmWebServiceSetting.SetFrmMain(this);
                frmWebServiceSetting.MdiParent = this;
            }
            frmWebServiceSetting.Show();
        }
        private void uploadCSVToolStripMenuItem_Click(object sender, EventArgs e)//useless
        {
            if (frmImportFile == null)
            {
                frmImportFile = new frm_ImportFile();
                frmImportFile.SetFrmMain(this);
                frmImportFile.MdiParent = this;
            }
            frmImportFile.Show();
        }

        //-----------------------------------------------------------------------------------
        //Pat 20160912 user info import------------------------------------------------------
        private void userInfoImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUserInfoImport == null)
            {
                frmUserInfoImport = new frm_UserInfoImport();
                frmUserInfoImport.SetFrmMain(this);
                frmUserInfoImport.MdiParent = this;                
            }
            frmUserInfoImport.Show();
        }
        public void DestroyUserInfoImportForm()
        {
            frmUserInfoImport = null;
        }

        private void exportToSurveillamceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExportISur frmES = new frmExportISur();
            frmES.ShowDialog();
        }
        //-----------------------------------------------------------------------------------
    }
}
