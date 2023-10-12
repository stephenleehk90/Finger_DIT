using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace TTI
{
    class SilentModeClass
    {
        MySqlConnection conn;
        ExportClass export;
        List<String> lst_Views;
        Setting setting;
        SettingClass settingClass;
        List<String[]> lst_File;
        public SilentModeClass()
        {
            lst_Views = new List<String>();
            settingClass = new SettingClass();
            setting = settingClass.GetSetting("");
        }

        //*********************************************
        // Edit Stephen 2017-08-03
        //*********************************************
        public void Run(String strMode, bool bWebService, List<String> lst_Report_View)
        //*********************************************
        {
            LoadView();
            lst_File = new List<String[]>();
            //Pat 20160810 in_resume---------------------------------------------------------
            WebServiceJsonClass wsjc = new WebServiceJsonClass();
            bool bWsLogin = false;
            if (bWebService)
            {
                wsjc.setConfig(strMode);
                bWsLogin = wsjc.EDULogin();
                if(!bWsLogin)
                    Console.WriteLine("Error: Login web service fail, use moduleKey.");
            }

            foreach (String str in lst_Views)
            {
                //*********************************************
                // Edit Stephen 2017-08-03
                //*********************************************
                bool b_Specify_View = false;
                string strTemp = str.ToLower();
                if (lst_Report_View.Contains(strTemp))
                    b_Specify_View = true;

                if (Global.modeViewApprove(strMode, str) || b_Specify_View)
                //*********************************************
                // Edit Stephen 2017-08-03
                //*********************************************
                {

                    export = new ExportClass(str);
                    String strFileFullPath = export.ExportToFile();
//                    Console.WriteLine(strFileFullPath);
                    String[] strArr = new String[2];
                    strArr[0] = strFileFullPath;
                    strArr[1] = "";
                    //web service
                    if (bWebService 
                        //&& bWsLogin 
                        && !strFileFullPath.Equals(""))
                    {
                        bool result = false;
                        String strTimeType = "";
                        String strPostFileType = "";
                        Global.getViewTimeType(str, ref strTimeType, ref strPostFileType);
                        String strWsResult = wsjc.EDUPostFile(strFileFullPath, strTimeType, strPostFileType);
                        if (strWsResult.Equals("postFile_success"))
                            result = true;                            

                        if (result)
                            strArr[1] = "Success -ws";
                        else
                            strArr[1] = "Error -ws + (" + strWsResult + ")";
                    }
                    lst_File.Add(strArr);
                }
                //-------------------------------------------------------------------------------
            }
        }

        public List<String[]> GetFileList()
        {
            return lst_File;
        }

        private void LoadView()
        {
            string SQL = "SHOW FULL TABLES IN ingress WHERE TABLE_TYPE LIKE 'VIEW';";
            try
            {
                //MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //MySqlDataReader myData = cmd.ExecuteReader();
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    return;
                else
                {
                    while (myData.Read())
                    {
                        String str = String.Format("{0}", myData.GetString(0));
                        lst_Views.Add(str);
                    }
                }
                myData.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private MySqlDataReader GetSqlResult(String strSql)
        {
            MySqlCommand cmd = new MySqlCommand(strSql, conn);
            MySqlDataReader myData = null;
            try
            {
                myData = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Connect();
                cmd = new MySqlCommand(strSql, conn);
                myData = cmd.ExecuteReader();
            }

            return myData;
        }

        private bool Connect()
        {
            string connStrFormat = "Server={0};Port={1};Uid={2};Pwd={3};Database={4};";
            string connStr = String.Format(connStrFormat, setting.DBConnect.strServer,
                setting.DBConnect.strPort, setting.DBConnect.strUserName, setting.DBConnect.strPassword, setting.DBConnect.strDatabase);
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
            return true;
        }

        public bool VerifyingSerialKey()
        {
            bool bKeyIsValid;
            KeyActivationClass keyActClass = new KeyActivationClass();
            if (keyActClass.TryActivate() == false)
                bKeyIsValid = false;
            else
                bKeyIsValid = true;
            return bKeyIsValid;
        }
    }
}
