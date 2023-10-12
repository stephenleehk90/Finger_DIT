using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TTI
{
    class SettingClass
    {
        ConfigHandler config;
        Setting setting;
        String strCurViewName;
        public SettingClass()
        {
            config = new ConfigHandler();
        }

        public Setting GetSetting(String strViewName)
        {
            strCurViewName = strViewName;
            config = new ConfigHandler();
            setting = new Setting();
            LoadSetting(strViewName);
            return setting;
        }

        public void SaveSetting(Setting setting, bool bSaveConnection = false)
        {
            this.setting = setting;
            String strValue = "";
            if (bSaveConnection == false)
            {
                foreach (SelectedColumn col in setting.lst_RawExportColumn)
                {
                    String str = String.Format("{0},{1},{2},{3},{4},{5}", col.strColumnName, col.strColumnType, col.iCustomLength, col.bFillZero, col.bColTrim, col.bFillZeroWithDelimiter);
                    strValue += str + "_|_";
                }
                if (strValue.Length > 0)
                    config.UpdateKeyValue(strValue.Remove(strValue.Length - 3), strCurViewName + "RawExportColumn");
                else
                    config.UpdateKeyValue(strValue, strCurViewName + "RawExportColumn");

                foreach (SelectedColumn col in setting.lst_RawExportColumn)
                {
                    if (col.strColumnType == "datetime"||
                        col.strColumnType == "date"||
                        col.strColumnType == "time")
                    {
                        String str = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                            col.dateSetting.strDateFormat, col.dateSetting.bYearTwoY, col.dateSetting.bDateFillZero, col.dateSetting.bHasTime,
                            col.dateSetting.bTimeIs24, col.dateSetting.bTimeWithSec, col.dateSetting.bTimeFillZero, col.dateSetting.bOtherDelimiter);
                        config.GetKeyValue(strCurViewName + "_DateFomatOn_" + col.strColumnName);
                        config.UpdateKeyValue(str, strCurViewName + "_DateFomatOn_" + col.strColumnName);
                    }
                }
                strValue = "";
                strValue = setting.strRawDelimiter;
                config.UpdateKeyValue(strValue, strCurViewName + "RawDelimiter");
                strValue = "";
                strValue = setting.bAddQuotation.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "RawAddQuotation");
                strValue = "";
                strValue = setting.strExportPath;
                config.UpdateKeyValue(strValue, strCurViewName + "RawExportPath");
                strValue = "";
                strValue = setting.strExportFormat;
                config.UpdateKeyValue(strValue, strCurViewName + "RawExportFormat");
                strValue = "";
                strValue = setting.strExportFileName;
                config.UpdateKeyValue(strValue, strCurViewName + "RawExportFileName");
                strValue = "";
                strValue = setting.dateSearchCondition.bByDateRange.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "RawSearchByDateRange");
                strValue = "";
                strValue = setting.dateSearchCondition.iDateType.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "RawDateType");
                strValue = "";
                strValue = setting.dateSearchCondition.dt_From.ToString("yyyy-MM-dd HH:mm:ss");
                config.UpdateKeyValue(strValue, strCurViewName + "RawDateFrom");
                strValue = "";
                strValue = setting.dateSearchCondition.dt_To.ToString("yyyy-MM-dd HH:mm:ss");
                config.UpdateKeyValue(strValue, strCurViewName + "RawDateTo");
                strValue = "";
                strValue = setting.bExportNoRecordUserInfo.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "ExportNoRecordUserInfo");
                strValue = "";
                strValue = setting.bNoHeader.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "ExportNoHeader");
                strValue = "";

                //**********************************************************************************
                // Edit Stephen 2017-10-13
                //**********************************************************************************
                strValue = setting.dateSearchCondition.timeRange_From.ToString("yyyy-MM-dd HH:mm:ss");
                config.UpdateKeyValue(strValue, strCurViewName + "RawTimeRangeFrom");
                strValue = "";
                strValue = setting.dateSearchCondition.timeRange_To.ToString("yyyy-MM-dd HH:mm:ss");
                config.UpdateKeyValue(strValue, strCurViewName + "RawTimeRangeTo");
                strValue = "";
                strValue = setting.dateSearchCondition.iDaysAfter.ToString();
                config.UpdateKeyValue(strValue, strCurViewName + "RawDaysAfter");
                strValue = "";
                //**********************************************************************************
                // Edit Stephen 2017-10-13
                //**********************************************************************************
                

            }
            else
            {
                strValue = "";
                strValue = setting.DBConnect.strServer;
                config.UpdateKeyValue(strValue, "Server");
                strValue = "";
                strValue = setting.DBConnect.strUserName;
                config.UpdateKeyValue(strValue, "Username");
                strValue = "";
                strValue = PasswordEncryption(setting.DBConnect.strPassword);
                config.UpdateKeyValue(strValue, "Password");
                strValue = "";
                strValue = setting.DBConnect.strPort;
                config.UpdateKeyValue(strValue, "Port");
                strValue = "";
                strValue = setting.DBConnect.strDatabase;
                config.UpdateKeyValue(strValue, "Database");
            }
        }

        private void LoadSetting(String strViewName)
        {
            String strTemp;
            if (strViewName.Length > 0)
            {
                try
                {
                    strTemp = config.GetKeyValue(strCurViewName + "RawExportColumn");
                    if (strTemp.Length != 0)
                    {
                        setting.lst_RawExportColumn = new List<SelectedColumn>();
                        List<String> lst_strTemp = strTemp.Split(new string[] { "_|_" }, StringSplitOptions.None).ToList<String>();
                        foreach (String str in lst_strTemp)
                        {
                            SelectedColumn col = new SelectedColumn();
                            List<String> lst_str = str.Split(',').ToList<String>();
                            col.strColumnName = lst_str[0];
                            col.strColumnType = lst_str[1];
                            col.iCustomLength = Int32.Parse(lst_str[2]);
                            col.bFillZero = bool.Parse(lst_str[3]);
                            col.bColTrim = bool.Parse(lst_str[4]);
                            col.bFillZeroWithDelimiter = bool.Parse(lst_str[5]);

                            if (col.strColumnType == "datetime"||
                                col.strColumnType == "date"||
                                col.strColumnType == "time")
                            {
                                String strDateFormat = config.GetKeyValue(strCurViewName + "_DateFomatOn_" + col.strColumnName);
                                List<String> lst_dateFormat = strDateFormat.Split(new string[] { "," }, StringSplitOptions.None).ToList<String>();
                                col.dateSetting = new DateColumnFormatSetting();
                                try
                                {
                                    col.dateSetting.strDateFormat = lst_dateFormat[0];
                                    col.dateSetting.bYearTwoY = bool.Parse(lst_dateFormat[1]);
                                    col.dateSetting.bDateFillZero = bool.Parse(lst_dateFormat[2]);
                                    col.dateSetting.bHasTime = bool.Parse(lst_dateFormat[3]);
                                    col.dateSetting.bTimeIs24 = bool.Parse(lst_dateFormat[4]);
                                    col.dateSetting.bTimeWithSec = bool.Parse(lst_dateFormat[5]);
                                    col.dateSetting.bTimeFillZero = bool.Parse(lst_dateFormat[6]);
                                    col.dateSetting.bOtherDelimiter = bool.Parse(lst_dateFormat[7]);
                                }
                                catch (Exception ex)
                                {
                                    col.dateSetting.bYearTwoY = col.dateSetting.bDateFillZero =
                                    col.dateSetting.bHasTime = col.dateSetting.bTimeIs24 =
                                    col.dateSetting.bTimeWithSec = col.dateSetting.bTimeFillZero = false;
                                }
                            }
                            setting.lst_RawExportColumn.Add(col);
                        }
                    }
                    else
                        setting.lst_RawExportColumn = new List<SelectedColumn>();
                }
                catch (Exception ex)
                {
                }

                strTemp = config.GetKeyValue(strCurViewName + "RawAddQuotation");
                if (strTemp.Length > 0)
                    setting.bAddQuotation = bool.Parse(strTemp);
                strTemp = config.GetKeyValue(strCurViewName + "RawDelimiter");
                setting.strRawDelimiter = strTemp;
                strTemp = config.GetKeyValue(strCurViewName + "RawExportPath");
                setting.strExportPath = strTemp;
                strTemp = config.GetKeyValue(strCurViewName + "RawExportFormat");
                setting.strExportFormat = strTemp;
                strTemp = config.GetKeyValue(strCurViewName + "RawExportFileName");
                setting.strExportFileName = strTemp;
                //Read Date Search Condition Setting by View
                setting.dateSearchCondition = new DateSearchCondition();
                strTemp = config.GetKeyValue(strCurViewName + "RawSearchByDateRange");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.bByDateRange = true;
                else
                    setting.dateSearchCondition.bByDateRange = bool.Parse(strTemp);
                strTemp = config.GetKeyValue(strCurViewName + "RawDateType");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.iDateType = 0;
                else
                    setting.dateSearchCondition.iDateType = Int32.Parse(strTemp);
                strTemp = config.GetKeyValue(strCurViewName + "RawDateFrom");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.dt_From = DateTime.Now;
                else
                    setting.dateSearchCondition.dt_From = DateTime.ParseExact(strTemp, "yyyy-MM-dd HH:mm:ss", null);
                strTemp = config.GetKeyValue(strCurViewName + "RawDateTo");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.dt_To = DateTime.Now;
                else
                    setting.dateSearchCondition.dt_To = DateTime.ParseExact(strTemp, "yyyy-MM-dd HH:mm:ss", null);
                strTemp = config.GetKeyValue(strCurViewName + "ExportNoRecordUserInfo");
                if (strTemp.Length == 0)
                    setting.bExportNoRecordUserInfo = true;
                else
                    setting.bExportNoRecordUserInfo = bool.Parse(strTemp); ;
                strTemp = config.GetKeyValue(strCurViewName + "ExportNoHeader");
                if (strTemp.Length == 0)
                    setting.bNoHeader = false;
                else
                    setting.bNoHeader = bool.Parse(strTemp); ;
                //

                //***************************************************************************
                // Edit Stephen 2017-10-13
                //***************************************************************************
                strTemp = config.GetKeyValue(strCurViewName + "RawTimeRangeFrom");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.timeRange_From = new DateTime(2000, 1, 1, 0, 0, 0);
                else
                    setting.dateSearchCondition.timeRange_From = DateTime.ParseExact(strTemp, "yyyy-MM-dd HH:mm:ss", null);

                strTemp = config.GetKeyValue(strCurViewName + "RawTimeRangeTo");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.timeRange_To = new DateTime(2000, 1, 1, 0, 0, 0);
                else
                    setting.dateSearchCondition.timeRange_To = DateTime.ParseExact(strTemp, "yyyy-MM-dd HH:mm:ss", null);

                strTemp = config.GetKeyValue(strCurViewName + "RawDaysAfter");
                if (strTemp.Length == 0)
                    setting.dateSearchCondition.iDaysAfter = 0;
                else
                    setting.dateSearchCondition.iDaysAfter = Convert.ToInt32(strTemp);
                //***************************************************************************
            }
            strTemp = config.GetKeyValue("Server");
            setting.DBConnect = new DBConnectionSetting();
            setting.DBConnect.strServer = strTemp;
            strTemp = config.GetKeyValue("Username");
            setting.DBConnect.strUserName = strTemp;
            strTemp = config.GetKeyValue("Password");
            setting.DBConnect.strPassword = PasswordDecryption(strTemp);
            strTemp = config.GetKeyValue("Port");
            setting.DBConnect.strPort = strTemp;
            strTemp = config.GetKeyValue("Database");
            setting.DBConnect.strDatabase = strTemp;
        }

        private bool LoadTrueFalseSetting(String strKey)
        {
            bool bResult = false;
            try
            {
                bResult = bool.Parse(config.GetKeyValue(strKey));
            }
            catch (Exception ex)
            {
                bResult = false;
            }
            return bResult;
        }

        private String PasswordEncryption(String strPassword)
        {
            String strDone = SSTCryptographer.Encrypt(strPassword, "founder");
            return strDone;
        }

        private String PasswordDecryption(String strPassword)
        {
            
            if (strPassword.Length == 0)
                return "";
            String strDone = SSTCryptographer.Decrypt(strPassword, "founder"); ;
            return strDone;
        }

        public void SaveSerialKey(String strSerialKey)
        {
            String strKey = config.GetKeyValue("SerialKey");
            config.UpdateKeyValue(strSerialKey, "SerialKey");
        }
    }
}

public class Setting
{
    public DBConnectionSetting DBConnect { get; set; }
    public List<SelectedColumn> lst_RawExportColumn { get; set; }
    public String strRawDelimiter { get; set; }
    public bool bAddQuotation { get; set; }
    public String strExportPath { get; set; }
    public String strExportFormat { get; set; }
    public DateSearchCondition dateSearchCondition { get; set; }
    public String strExportFileName { get; set; }
    public bool bIsDebug { get; set; }
    public bool bExportNoRecordUserInfo { get; set; }
    public bool bNoHeader { get; set; }
}

public class DBConnectionSetting
{
    public String strServer { get; set; }
    public String strUserName { get; set; }
    public String strPassword { get; set; }
    public String strPort { get; set; }
    public String strDatabase { get; set; }
}

public class DateSearchCondition
{
    public bool bByDateRange { get; set; }
    public int iDateType { get; set; }
    public DateTime dt_From { get; set; }
    public DateTime dt_To { get; set; }

    //**********************************************************
    // Edit Stephen 2017-10-13
    //**********************************************************
    public DateTime timeRange_From { get; set; }
    public DateTime timeRange_To { get; set; }
    public int iDaysAfter { get; set; }
    //**********************************************************

}