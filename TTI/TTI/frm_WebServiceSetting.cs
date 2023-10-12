//Pat 20160810 in_resume (this file is created by Pat)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTI
{
    public partial class frm_WebServiceSetting : Form
    {
        SettingWebServiceClass settingWebServiceClass;
        SettingWebService settingWebService;
        frm_Main frmMain;

        public frm_WebServiceSetting()
        {
            InitializeComponent();
            settingWebServiceClass = new SettingWebServiceClass();
        }

        private void frm_WebServiceSetting_Load(object sender, EventArgs e)
        {
            settingWebService = settingWebServiceClass.GetSetting();
            tb_hostName.Text = settingWebService.strHostName;
            tb_userName.Text = settingWebService.strUserName;
            tb_password.Text = settingWebService.strPassword;
            tb_companyID.Text = settingWebService.strCompanyID;
            tb_moduleKey.Text = settingWebService.strModuleKey;
        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void frm_WebServiceSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroyWebServiceSettingForm();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            settingWebService.strHostName = tb_hostName.Text;
            settingWebService.strUserName = tb_userName.Text;
            settingWebService.strPassword = tb_password.Text;
            settingWebService.strCompanyID = tb_companyID.Text;
            settingWebService.strModuleKey = tb_moduleKey.Text;

            //check setting is valid
            WebServiceJsonClass wsjc = new WebServiceJsonClass(settingWebService);
            if (wsjc.EDULogin())
            {
                settingWebServiceClass.SaveSettingWebService(settingWebService);
                this.Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Cannot connect web service by this config, continue save?", "Error", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    settingWebServiceClass.SaveSettingWebService(settingWebService);
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
