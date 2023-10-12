//Pat 20160810 in_resume (this file is created by Pat)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
//for post file
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace TTI
{
    class WebServiceJsonClass
    {
        ConfigHandler config;
        SettingWebServiceClass settingWebServiceClass;
        SettingWebService settingWebService;
        wsJsonEDULoginResult eduLoginResult;
        wsJsonEDUPostFileResult eduPostFileResult;
        String strToken;
        public WebServiceJsonClass()
        {
            config = new ConfigHandler();
            setWebPathDefault();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        }
        public WebServiceJsonClass(SettingWebService settingWebService)
        {
            config = new ConfigHandler();
            setWebPathDefault();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            settingWebServiceClass = new SettingWebServiceClass();
            this.settingWebService = settingWebService;
            strToken = "";
        }
        public void setWebPathDefault()
        {
            String strTemp = config.GetKeyValue("WebService_LoginPath");
            if (strTemp.Equals(""))
                config.UpdateKeyValue("/edu/public/api/admin/login", "WebService_LoginPath");
            strTemp = config.GetKeyValue("WebService_PostFilePath");
            if (strTemp.Equals(""))
                config.UpdateKeyValue("/edu/api/public/attendance/record/import/csv", "WebService_PostFilePath");
        }
        public void setConfig(String strMode)
        {
            settingWebServiceClass = new SettingWebServiceClass();
            settingWebService = new SettingWebService();
            strToken = "";

            if (strMode.Equals("silent_in_on_time")
                    || strMode.Equals("silent_in_late")
                    || strMode.Equals("silent_resume_on_time")
                    || strMode.Equals("silent_resume_late")
                    || strMode.Equals("silent_in")
                    || strMode.Equals("silent_resume")
                    || strMode.Equals("silent_in_resume")
                    || strMode.Equals("custom"))
            {
                settingWebService = settingWebServiceClass.GetSetting();
            }
            else
            {
                //Nothing right now
            }
        }
        public bool EDULogin()
        {
            bool result = false;
            eduLoginResult = new wsJsonEDULoginResult();
            if (!settingWebService.strHostName.Equals(""))
            {
                //get json data
                WebClient webClient = new WebClient();
                StringBuilder sbWsLoginURL = new StringBuilder();
                sbWsLoginURL.Append("https://");
                sbWsLoginURL.Append(settingWebService.strHostName);
                sbWsLoginURL.Append(config.GetKeyValue("WebService_LoginPath"));


                HttpContent hcStrUsername = new StringContent(settingWebService.strUserName);
                HttpContent hcStrPassword = new StringContent(settingWebService.strPassword);
                HttpContent hcStrComID = new StringContent(settingWebService.strCompanyID);
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(hcStrUsername, "username");
                    formData.Add(hcStrPassword, "password");
                    formData.Add(hcStrComID, "comID");

                    try
                    {
                        var response = client.PostAsync(sbWsLoginURL.ToString(), formData).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            return false;
                        }
                    
                        String strJson = response.Content.ReadAsStringAsync().Result;

                        //convert to list
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        eduLoginResult = serializer.Deserialize(strJson, typeof(wsJsonEDULoginResult)) as wsJsonEDULoginResult;

                        //output
                        if (eduLoginResult.data != null)
                        {
                            strToken = eduLoginResult.data.token;
                            result = true;
                        }           

                    }
                    catch (Exception ex)
                    {

                    }
                }                

            }

            return result;
        }
        public String EDUPostFile(String strFileFullPath, String strTimeType, String strPostFileType)
        {
            if (strFileFullPath.Equals("") || strTimeType.Equals("") || strPostFileType.Equals(""))
                return "No export file";
            String result = "";
            eduPostFileResult = new wsJsonEDUPostFileResult();
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("https://");
            sbWsPostURL.Append(settingWebService.strHostName);
            sbWsPostURL.Append(config.GetKeyValue("WebService_PostFilePath"));
            try
            {
                //setting parameters
                HttpContent hcStrToken = new StringContent(strToken);
                HttpContent hcModuleKey = new StringContent(settingWebService.strModuleKey);
                String strJsonFile = "";
                if(strTimeType.Equals("am"))
                    strJsonFile = "configAM.json";
                else if (strTimeType.Equals("pm"))
                    strJsonFile = "configPM.json";
                else
                    return "Unknown";

                //FileStream fs = new FileStream(strFileFullPath, FileMode.Open);
                HttpContent hcBytesContentConf = new ByteArrayContent(File.ReadAllBytes(strJsonFile));
                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(strFileFullPath));
                //HttpContent hcSteamContentCsv = new StreamContent(fs);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    if (!strToken.Equals(""))
                        formData.Add(hcStrToken, "token");
                    else
                        formData.Add(hcModuleKey, "moduleKey");

                    formData.Add(hcBytesContentConf, "configFile", "config.json");
                    if (strPostFileType.Equals("on_time"))
                        formData.Add(hcBytesContentCsv, "dailyAttendanceImport", "dailyAttendance.csv");
                    else if (strPostFileType.Equals("late"))
                        formData.Add(hcBytesContentCsv, "lateAttendanceImport", "lateAttendance.csv");

                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return "Web service down";
                    }

                    String strJson = response.Content.ReadAsStringAsync().Result;

                    //convert to list
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    eduPostFileResult = serializer.Deserialize(strJson, typeof(wsJsonEDUPostFileResult)) as wsJsonEDUPostFileResult;

                    //output
                    if (eduPostFileResult.error == null)
                        result = "postFile_success";
                    else if (eduPostFileResult.error.msgCode == "100")
                        result = "Token error";
                    else if (eduPostFileResult.error.msgCode == "936")
                        result = "CSV format";
                    else if (eduPostFileResult.error.msgCode == "937")
                        result = "Some user not found, not all user imported";
                    else if (eduPostFileResult.error.msgCode == "938")
                        result = "Config json format";
                    else if (eduPostFileResult.error.msgCode == "939")
                        result = "Config json missing";
                    else if (eduPostFileResult.error.msgCode == "921")
                        result = "CSV missing " + eduPostFileResult.error.message;
                    else
                        result = "Unknown";

                    
                }
            
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
//EDU DATA----------------------------------------------------------------------------------------------------
//EDULogin Data------------------------------------------------
public class wsJsonEDULoginResult
{
    public String timestamp { get; set; }
    public wsJsonEDULoginResultData data { get; set; }
    public wsJsonEDULoginResultError error { get; set; }
}

public class wsJsonEDULoginResultData
{
    public String token { get; set; }
    public wsJsonEDULoginResultDataUser user { get; set; }
}

public class wsJsonEDULoginResultDataUser
{
    public String username { get; set; }
    public String displayName { get; set; }
}
public class wsJsonEDULoginResultError
{
    public String msgCode { get; set; }
    public String message { get; set; }   
}
//-------------------------------------------------------------
//EDUPostFile Data---------------------------------------------
public class wsJsonEDUPostFileResult
{
    public String timestamp { get; set; }
    public wsJsonEDUPostFileError error { get; set; }

}
public class wsJsonEDUPostFileError
{
    public String msgCode { get; set; }
    public String message { get; set; }
    public String[] email { get; set; }
}
//-------------------------------------------------------------
//------------------------------------------------------------------------------------------------------------
