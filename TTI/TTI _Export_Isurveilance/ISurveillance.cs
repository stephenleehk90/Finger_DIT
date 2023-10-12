using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using System.IO;


namespace TTI
{
    public class NormalTag
    {
        public string tagcode { get; set; }
        public string tagname { get; set; }
        public string fulltagcode { get; set; }
        public string fulltagname { get; set; }
    }
    public class AdTag
    {
        public string tagname { get; set; }
    }
    
    public class TagContent
    {
        public string title { get; set; }
        public string content { get; set; }
        public NormalTag tag { get; set; }
        public NormalTag removetag { get; set; }
        public AdTag adhoctag { get; set; }
    }
    
    class ISurveillance
    {
        ConfigHandler config;
        private string m_strIP = "192.168.30.20";
        private string m_strToken = "";
        private string m_strDeviceID = "";
        private string m_strTempFilePath = "C:\\Temp";
        private string m_strRunDay = "0";

        public struct EventType
        {
            public string strEventHandle;
            public string strEventName;
            public string strEventType;
            public string strDesc;
        }

        public struct User
        {
            public string strUserCardID;
            public string strUserName;
            public string strGender;
            public string strPhone;
            public string strInService;
        }

        public struct Camera
        {
            public string strIPCamID;
            public string strIP;
            public string strName;
            public string strDesc;
        }

        public struct Device
        {
            public string strAccessControlID;
            public string strAccessControlName;
            public string strEventType;
            public string strDesc;
        }

        public List<EventType> lst_EventType;
        public List<User> lst_User;
        public List<Camera> lst_Camera;
        public List<Device> lst_Device;

        public ISurveillance()
        {
            lst_EventType = new List<EventType>();
            lst_User = new List<User>();
            lst_Camera = new List<Camera>();
            lst_Device = new List<Device>();
            config = new ConfigHandler();

            m_strIP = config.GetKeyValue("ISurWebIP");
            if (m_strIP.Trim() == "")
                m_strIP = "192.168.30.20";

            m_strTempFilePath = config.GetKeyValue("ISurTempFilePath");
            if (m_strTempFilePath.Trim() == "")
                m_strTempFilePath = "C:\\Temp";

            m_strRunDay = config.GetKeyValue("ISurRunDay");
            if (m_strRunDay.Trim() == "")
                m_strRunDay = "0";

        }

        private string ParseJSONGetOneValue(string strText, string strAttributeName)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var result = jsSerializer.DeserializeObject(strText);
            Dictionary<string, object> obj = (Dictionary<string, object>)(((object[])(result))[1]);
            return obj[strAttributeName].ToString();

            //  Dictionary<string,object>(((Dictionary<string,object>)(((object[])((ions.Generic.Dictionary<string,object>)(result)))).Items[1].Value))[0])))).Items[0]

        }

        private void ParseJSONIntoTable_EventType(string strText)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var result = jsSerializer.DeserializeObject(strText);

            var result_sub = (new Dictionary<string, object>(((Dictionary<string, object>)(result)))).ElementAt(1);
            KeyValuePair<string, object> key_pair = (KeyValuePair<string, object>)(result_sub);
            object[] obj1 = (object[])(key_pair.Value);

            int icount = obj1.Count();
            int icount_Key = key_pair.Key.Count();

            lst_EventType.Clear();
//            lvResult.Items.Clear();
            for (int i = 0; i < icount; i++)
            {
                EventType stEventType;

                string str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(1).Value);
                stEventType.strEventHandle = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(2).Value);
                stEventType.strEventName = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(3).Value);
                stEventType.strEventType = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(4).Value);
                stEventType.strDesc = str_Temp;
                lst_EventType.Add(stEventType);
//                lvi.SubItems.Add(str_Temp);
            }

        }


        private void ParseJSONIntoTable_User(string strText)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var result = jsSerializer.DeserializeObject(strText);

            var result_sub = (new Dictionary<string, object>(((Dictionary<string, object>)(result)))).ElementAt(1);
            KeyValuePair<string, object> key_pair = (KeyValuePair<string, object>)(result_sub);
            object[] obj1 = (object[])(key_pair.Value);

            int icount = obj1.Count();
            int icount_Key = key_pair.Key.Count();

            lst_User.Clear();
//            lvResult_User.Items.Clear();
            for (int i = 0; i < icount; i++)
            {
                User stUser;

                string str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(0).Value);
                stUser.strUserCardID = str_Temp;
//                ListViewItem lvi = lvResult_User.Items.Add(str_Temp);
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(1).Value);
                stUser.strUserName = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(2).Value);
                stUser.strGender = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(3).Value);
                stUser.strPhone = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(((object[])(key_pair.Value))[i])))).ElementAt(6).Value);
                stUser.strInService = str_Temp;
                lst_User.Add(stUser);
            }

        }

        private void ParseJSONIntoTable_Camera(string strText)
        {
            //            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            //          var result = jsSerializer.DeserializeObject(strText);

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var result = jsSerializer.DeserializeObject(strText);
            object[] obj1 = (object[])(result);

            int icount = obj1.Count();
//            lvResult_Cam.Items.Clear();
            lst_Camera.Clear();
            for (int i = 0; i < icount; i++)
            {
                Camera stCamera;
                string str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(0).Value);
                stCamera.strIPCamID = str_Temp;
                //ListViewItem lvi = lvResult_Cam.Items.Add(str_Temp);
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(1).Value);
                stCamera.strIP = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(2).Value);
                stCamera.strName = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(3).Value);
                stCamera.strDesc = str_Temp;
                lst_Camera.Add(stCamera);
 
//                lvi.SubItems.Add(str_Temp);
            }

        }
        private void ParseJSONIntoTable_Device(string strText)
        {
            //            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            //          var result = jsSerializer.DeserializeObject(strText);

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var result = jsSerializer.DeserializeObject(strText);
            object[] obj1 = (object[])(result);

            int icount = obj1.Count();
//            lvResult_Device.Items.Clear();
            lst_Device.Clear();
            for (int i = 0; i < icount; i++)
            {
                Device stDevice;
                string str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(0).Value);
//                ListViewItem lvi = lvResult_Device.Items.Add(str_Temp);
                stDevice.strAccessControlID = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(1).Value);
                stDevice.strAccessControlName = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(2).Value);
                stDevice.strEventType = str_Temp;
                str_Temp = Convert.ToString((new Dictionary<string, object>(((Dictionary<string, object>)(obj1[i])))).ElementAt(3).Value);
                stDevice.strDesc = str_Temp;
                lst_Device.Add(stDevice);
            }

        }



        //************************************************************************************************************
        // procedure name: Get_EventTypeList
        // Get Event Type List 
        // Input: /
        // Output: /
        //************************************************************************************************************
        public void Get_EventTypeList()
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/Eventhandler");
            try
            {
                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

                    /*                    MessageBox.Show(response.Content.ToString());
                                        MessageBox.Show(response.ToString());
                                        MessageBox.Show(response.ReasonPhrase.ToString());
                                        MessageBox.Show(response.Content.ToString());
                    */

                    string strAllContent = response.Content.ReadAsStringAsync().Result;
                    //  strAllContent = strAllContent.Replace("\"", "").Trim();

                    ParseJSONIntoTable_EventType(strAllContent);

                    //                    MessageBox.Show(m_strDeviceID);

                }

            }
            catch (Exception ex)
            {
                return;
            }
        }

        //************************************************************************************************************
        // procedure name: Get_UserList
        // Get User List 
        // Input: /
        // Output: /
        //************************************************************************************************************
        public void Get_UserList()
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/User");
            try
            {
                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

                    /*                    MessageBox.Show(response.Content.ToString());
                                        MessageBox.Show(response.ToString());
                                        MessageBox.Show(response.ReasonPhrase.ToString());
                                        MessageBox.Show(response.Content.ToString());
                    */

                    string strAllContent = response.Content.ReadAsStringAsync().Result;
                    //  strAllContent = strAllContent.Replace("\"", "").Trim();

                    ParseJSONIntoTable_User(strAllContent);

                    //                    MessageBox.Show(m_strDeviceID);

                }

            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }

        //************************************************************************************************************
        // procedure name: Get_CameraList
        // Get Camera List 
        // Input: /
        // Output: /
        //************************************************************************************************************
        public void Get_CameraList()
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/Camera");
            try
            {
                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

                    string strAllContent = response.Content.ReadAsStringAsync().Result;

                    ParseJSONIntoTable_Camera(strAllContent);

                    //                    MessageBox.Show(m_strDeviceID);

                }

            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }


        //************************************************************************************************************
        // procedure name: Get_DeviceList
        // Get Device List 
        // Input: /
        // Output: /
        //************************************************************************************************************
        public void Get_DeviceList()
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/Device");
            try
            {
                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

                    string strAllContent = response.Content.ReadAsStringAsync().Result;

                    ParseJSONIntoTable_Device(strAllContent);

                    //                    MessageBox.Show(m_strDeviceID);

                }

            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }


        //************************************************************************************************************
        // procedure name: Get_DefaultDeviceID
        // Get A Default Decice ID for getting token 
        // Input: /
        // Output: string
        //************************************************************************************************************
        private string Get_DefaultDeviceID()
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/Device");
            try
            {
                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

                    /*                    MessageBox.Show(response.Content.ToString());
                                        MessageBox.Show(response.ToString());
                                        MessageBox.Show(response.ReasonPhrase.ToString());
                                        MessageBox.Show(response.Content.ToString());
                    */

                    string strAllContent = response.Content.ReadAsStringAsync().Result;
                    //  strAllContent = strAllContent.Replace("\"", "").Trim();

                    m_strDeviceID = ParseJSONGetOneValue(strAllContent, "AccessControlID");

                    //                    MessageBox.Show(m_strDeviceID);

                }

            }
            catch (Exception ex)
            {
                return "";
            }
            return m_strDeviceID;
        }
        //************************************************************************************************************
        //************************************************************************************************************
        // procedure name: Get_Token
        // Get Token ID (m_strToken) using the Device ID 
        // Input: /
        // Output: bool
        //************************************************************************************************************
        private bool Get_Token()
        {

            Get_DefaultDeviceID();

            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strDeviceID + "/TokenID ");
            try
            {
                //setting parameters
                //               HttpContent hcStrToken = new StringContent(strToken);
                //               HttpContent hcModuleKey = new StringContent(settingWebService.strModuleKey);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    HttpContent hcStrDeciveID = new StringContent(m_strDeviceID);
                    formData.Add(hcStrDeciveID, "DeviceID");

                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;

                    /*                    MessageBox.Show(response.Content.ToString());
                                        MessageBox.Show(response.ToString());
                                        MessageBox.Show(response.ReasonPhrase.ToString());
                                        MessageBox.Show(response.Content.ToString());
                    */

                    m_strToken = response.Content.ReadAsStringAsync().Result;
                    m_strToken = m_strToken.Replace("\"", "").Trim();
                    //                  MessageBox.Show(m_strToken);

                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
        //************************************************************************************************************


        public void Update_EventType()
        {
            Get_Token();

            string strContent = "EventHandle,EventNameEn,EventNameCh,EventType,Description";

            for (int i = 0; i < lst_EventType.Count; i++)
            {
/*                ListViewItem lvi = lvResult.Items[i];
                string strRow = lvi.SubItems[0].Text.ToString();
                strRow = strRow + "," + lvi.SubItems[1].Text.ToString();
                strRow = strRow + "," + lvi.SubItems[1].Text.ToString();
                strRow = strRow + "," + lvi.SubItems[2].Text.ToString();
                strRow = strRow + "," + lvi.SubItems[3].Text.ToString();
*/
                EventType stEventType = lst_EventType[i];
                string strRow = stEventType.strEventHandle;
                strRow = strRow + "," + stEventType.strEventName;
                strRow = strRow + "," + stEventType.strEventName;
                strRow = strRow + "," + stEventType.strEventType;
                strRow = strRow + "," + stEventType.strDesc;
 
                strContent = strContent + "\r\n" + strRow;
            }

            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strToken + "/UploadEventTypeCSV");

            try
            {
                //setting parameters
                //               HttpContent hcStrToken = new StringContent(strToken);
                //               HttpContent hcModuleKey = new StringContent(settingWebService.strModuleKey);

                //strContent = strContent + "3,Normal Punch Open,正常刷機打開,controller,";

                File.WriteAllText(m_strTempFilePath + "\\EventTypeList.csv", strContent, Encoding.UTF8);

                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(m_strTempFilePath + "\\EventTypeList.csv"));
                HttpContent hcStrToken = new StringContent(m_strToken);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    //  formData.Add(hcStrToken, "tokenId");
                    formData.Add(hcBytesContentCsv, "file", "EventTypeList.csv");
                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;
                    String strJson = response.Content.ReadAsStringAsync().Result;
                    Get_EventTypeList();
                }

            }
            catch (Exception ex)
            {

            }

        }


        public void Add_Device(string strType, string strAccessControlName, string strDesc)
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            /*            sbWsPostURL.Append("http://");
                        sbWsPostURL.Append(m_strIP);
                        sbWsPostURL.Append("/Device");
            */
            sbWsPostURL.Append("http://plus.hket.com:8893/ctms/restful/get/autotagwtagged");
            try
            {



                string json = new JavaScriptSerializer().Serialize(new
                {
                    //                    AccessControlID = "00000000-0000-0000-0000-000000000000",
                    //                    AccessControlName = strAccessControlName,
                    //                    EventType = strType,
                    //                   Description = strDesc
                    title = "資金避險返債市道指曾挫183點",
                    content = "鍾欣潼（阿嬌）和賴弘國新婚燕爾，放閃是常識！剛娶得阿嬌歸的賴弘國昨日專誠用二人與雙方家長的大合照，並以家人相稱，重新為新婚妻子冠上名份"
                });

                HttpContent hcContent = new StringContent(json, Encoding.UTF8, "application/json");

                //start ws
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(sbWsPostURL.ToString(), hcContent).Result;
//                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;
                    String strJson = response.Content.ReadAsStringAsync().Result;
 //                   Get_DeviceList();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void Update_User()
        {
            Get_Token();

            string strContent = "UserCardID,UserName,Gender,Phone,Address,Email,InService,Description";

            for (int i = 0; i < lst_User.Count; i++)
            {
                User stUser = lst_User[i];
                string strRow = stUser.strUserCardID;
                strRow = strRow + "," + stUser.strUserName;
                strRow = strRow + "," + stUser.strGender;
                strRow = strRow + "," + stUser.strPhone;
                strRow = strRow + ",,," + stUser.strInService;
                strRow = strRow + ",";
                strContent = strContent + "\r\n" + strRow;
            }


            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strToken + "/UploadUserCSV");

            try
            {

                File.WriteAllText(m_strTempFilePath + "\\UserList.csv", strContent, Encoding.UTF8);

                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(m_strTempFilePath + "\\UserList.csv"));
                HttpContent hcStrToken = new StringContent(m_strToken);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    //  formData.Add(hcStrToken, "tokenId");
                    formData.Add(hcBytesContentCsv, "file", "UserList.csv");
                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;
                    String strJson = response.Content.ReadAsStringAsync().Result;
                    Get_UserList();

                    //     MessageBox.Show(strJson);
                }

            }
            catch (Exception ex)
            {

            }

        }

        public void Update_Camera()
        {
            Get_Token();

            string strContent = "IpcamID,IP,Name,Description";

            for (int i = 0; i < lst_Camera.Count; i++)
            {
                Camera stCamera = lst_Camera[i];
                string strRow = stCamera.strIPCamID;
                strRow = strRow + "," + stCamera.strIP;
                strRow = strRow + "," + stCamera.strName;
                strRow = strRow + "," + stCamera.strDesc;
                strContent = strContent + "\r\n" + strRow;
            }

            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strToken + "/UploadCameraCSV");

            try
            {

                File.WriteAllText(m_strTempFilePath + "\\CameraList.csv", strContent, Encoding.UTF8);

                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(m_strTempFilePath + "\\CameraList.csv"));
                HttpContent hcStrToken = new StringContent(m_strToken);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(hcBytesContentCsv, "file", "CameraList.csv");

                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;

                    String strJson = response.Content.ReadAsStringAsync().Result;

                    Get_CameraList();

                    //     MessageBox.Show(strJson);
                }

            }
            catch (Exception ex)
            {

            }

        }
        
        public string Update_Event()
        {
            Get_Token();
            Get_EventTypeList();
            Get_UserList();
            Get_CameraList();
            Get_DeviceList();

            string strContent = "AccessControlID,IpCamID,UserIDCard,EventHandle,TriggerEventTime,EventType";

            StringBuilder sbSql = new StringBuilder();
            DBConnectionSetting dbcs = new DBConnectionSetting();
            Global.getDBConnectionSetting(ref dbcs);
            MySqlConnection conn = new MySqlConnection();
            if (!Global.ConnectDB(ref dbcs, ref conn))
                return "fail";

            string strSQL = "SELECT d.Devicename, d.ipaddress, a.checktime, a.eventType, u.Username FROM auditdata a, user u, device d where a.userid = u.userid and a.serialno = d.serialno and a.checktime > current_date()-" + m_strRunDay;

            MySqlDataReader myData = GetSqlResult(strSQL, conn);

            if (myData.HasRows)
            {
                while (myData.Read())
                {
                    string strRow = "";

                    bool b_Found = false;
                    string strDeviceName = String.Format("{0}", myData.GetString(0));
                    string strIP = String.Format("{0}", myData.GetString(1));
                    DateTime dtCheckTime = myData.GetDateTime(2);
                    string strUserName = String.Format("{0}", myData.GetString(4));

                    string strEventHandle = String.Format("{0}", myData.GetString(3));
                    string strTriggerEventTime = dtCheckTime.ToString("yyyyMMddHHmmss");

                    string strAccessControlID = "";
                    string strIPCamID = "";
                    string strUserIDCard = "";
                    string strEventType = "";

                    for (int i = 0; i < lst_Device.Count(); i++)
                    {
                        Device dev = lst_Device[i];
                        if (dev.strAccessControlName == strDeviceName)
                        {
                            strAccessControlID = dev.strAccessControlID;
                            strEventType = dev.strEventType;
                            b_Found = true;
                            break;
                        }
                    }
                    if (!b_Found) continue;

                    b_Found = false;
                    for (int i = 0; i < lst_Camera.Count(); i++)
                    {
                        Camera cam = lst_Camera[i];
                        if (cam.strIP == strIP)
                        {
                            strIPCamID = cam.strIPCamID;
                            b_Found = true;
                            break;
                        }
                    }
                    if (!b_Found) continue;

                    b_Found = false;
                    for (int i = 0; i < lst_User.Count(); i++)
                    {
                        User usr = lst_User[i];
                        if (usr.strUserName == strUserName)
                        {
                            strUserIDCard = usr.strUserCardID;
                            b_Found = true;
                            break;
                        }
                    }
                    if (!b_Found) continue;

                    strRow = strAccessControlID + "," + strIPCamID + "," + strUserIDCard + ","
                            + strEventHandle + "," + strTriggerEventTime + "," + strEventType;

                    strContent = strContent + "\r\n" + strRow;
                }
            }
            else
                return "ok";

            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strToken + "/UploadEventCSV");

            try
            {

                File.WriteAllText(m_strTempFilePath + "\\EventList.csv", strContent, Encoding.UTF8);

                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(m_strTempFilePath + "\\EventList.csv"));
                HttpContent hcStrToken = new StringContent(m_strToken);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(hcBytesContentCsv, "file", "EventList.csv");

                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;
                    String strJson = response.Content.ReadAsStringAsync().Result;
                    return response.ReasonPhrase;

                    //       Get_CameraList();

                    //     MessageBox.Show(strJson);
                }

            }
            catch (Exception ex)
            {
                return "fail";
            }
            return "ok";
        }

        private MySqlDataReader GetSqlResult(String strSql, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataReader myData = null;
            try
            {
                myData = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand(strSql, conn);
                myData = cmd.ExecuteReader();
            }

            return myData;
        }
    }
}
