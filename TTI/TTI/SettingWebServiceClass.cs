//Pat 20160810 in_resume (this file is created by Pat)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTI
{
    class SettingWebServiceClass
    {
        ConfigHandler config;
        SettingWebService settingWebService;

        public SettingWebServiceClass()
        {
            config = new ConfigHandler();
        }

        public SettingWebService GetSetting()
        {
            config = new ConfigHandler();
            settingWebService = new SettingWebService();
            LoadSettingWebService();
            return settingWebService;
        }

        public void SaveSettingWebService(SettingWebService settingWebService)
        {
            this.settingWebService = settingWebService;
            config.UpdateKeyValue(settingWebService.strHostName, "WebService_HostName");
            config.UpdateKeyValue(settingWebService.strUserName, "WebService_UserName");
            config.UpdateKeyValue(Global.strEncryption(settingWebService.strPassword), "WebService_Password");
            config.UpdateKeyValue(settingWebService.strCompanyID, "WebService_CompanyID");
            config.UpdateKeyValue(Global.strEncryption(settingWebService.strModuleKey), "WebService_ModuleKey");
        }

        private void LoadSettingWebService()
        {
            settingWebService.strHostName = config.GetKeyValue("WebService_HostName");
            settingWebService.strUserName = config.GetKeyValue("WebService_UserName");
            settingWebService.strPassword = Global.strDecryption(config.GetKeyValue("WebService_Password"));
            settingWebService.strCompanyID = config.GetKeyValue("WebService_CompanyID");
            settingWebService.strModuleKey = Global.strDecryption(config.GetKeyValue("WebService_ModuleKey"));     
        }
    }
}

public class SettingWebService
{
    public String strHostName { get; set; }
    public String strUserName { get; set; }
    public String strPassword { get; set; }
    public String strCompanyID { get; set; }//EDU only
    public String strModuleKey { get; set; }//EDU only
}
