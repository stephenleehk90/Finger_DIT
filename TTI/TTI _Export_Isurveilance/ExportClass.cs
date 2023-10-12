using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace TTI
{
    class ExportClass
    {
        MySqlConnection conn;
        String strError;
        Setting setting;
        SettingClass settingClass;
        frm_Main frmMain;
        List<SelectedColumn> lst_SelectedColumn;
        String strCurViewName, strExportResult;
        List<ExportUserWithNoAttdRec> lst_Exp;
        List<ExportUserWithNoAttdRec> lst_ExpException;

        public ExportClass()
        {
        }

        public ExportClass(String strViewName)
        {
            settingClass = new SettingClass();
            strCurViewName = strViewName;
            lst_SelectedColumn = new List<SelectedColumn>();
            setting = settingClass.GetSetting(strViewName);
            lst_SelectedColumn = setting.lst_RawExportColumn;
            strExportResult = "";
            Connect();
        }

        public String GetExportResult()
        {
            return strExportResult;
        }

        public String ExportToFile()
        {
            if (Export() == 0)
                return "";
            Directory.CreateDirectory(setting.strExportPath);
            String strFileFullPath = "", strFileName = "", strFileExtenion = "", strDateRange = "";
            strFileExtenion = setting.strExportFormat == "TXT (Plain Text)" ? "txt" : "csv";

            if (setting.strExportFileName.Length == 0)
            {
                if (strCurViewName.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == true)
                    strFileName = String.Format("Attendance-Data_Audit_List_{0}", DateTime.Now.ToString("yyyyMMddhhmmss"));
                else
                    strFileName = String.Format("Attendance- Record_{0}", DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
            else
            {
                DateTime dt_time = new DateTime();
                if (setting.dateSearchCondition.bByDateRange == false)
                    dt_time = setting.dateSearchCondition.dt_From;
                else
                {
                    dt_time = DateTime.Now;
                    //Pat 20160810 in_resume
                    Global.changeDateTimeByCmbIndex(setting.dateSearchCondition.iDateType, ref dt_time);
                }
                strFileName = setting.strExportFileName;
                strFileName = strFileName.Replace("%Y", dt_time.Year.ToString("D4"));
                strFileName = strFileName.Replace("%y", dt_time.Year.ToString("D4").Substring(2, 2));
                strFileName = strFileName.Replace("%M", dt_time.Month.ToString("D2"));
                strFileName = strFileName.Replace("%D", dt_time.Day.ToString("D2"));
            }

            if (strCurViewName.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == false)
            {
                if (strDateRange.Length > 0)
                    strFileName += "_" + strDateRange;
            }
            strFileFullPath += setting.strExportPath + "\\" + strFileName + "." + strFileExtenion;
            //Encoding utf8WithoutBom = new UTF8Encoding(false);
            Encoding utf8WithoutBom = new UTF8Encoding(true);//Pat 20160913 中文亂碼
            using (StreamWriter sw = new StreamWriter(strFileFullPath, false, utf8WithoutBom))
            {
                sw.Write(strExportResult);
                sw.Close();
            }
            return strFileFullPath;
        }
        //special case on handling one day record with exporting user information with no attendance record 
        public int ExportYesterdayForSpecial()
        {
            String SQL = BuildSQL();
            lst_Exp = new List<ExportUserWithNoAttdRec>();
            lst_ExpException = new List<ExportUserWithNoAttdRec>();
            int iRecordCount = 0;
            String strDelimiter = setting.strRawDelimiter;
            if (strDelimiter == "<TAB>")
                strDelimiter = "\t";
            try
            {
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    myData.Close();
                else
                {
                    while (myData.Read())
                    {
                        String str = "";
                        ExportUserWithNoAttdRec exp = new ExportUserWithNoAttdRec();
                        for (int i = 0; i < lst_SelectedColumn.Count; i++)
                        {
                            String strTemp = "";
                            try
                            {
                                if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date" ||
                                    lst_SelectedColumn[i].strColumnType == "time")
                                {
                                    if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date")
                                    {
                                        DateTime date = new DateTime();
                                        date = myData.GetDateTime(i);
                                        if (date == null)
                                            strTemp = "";
                                        else
                                            strTemp = GetFormattedDate(date, i, lst_SelectedColumn[i]);
                                    }
                                    else
                                    {
                                        String strTime = myData.GetString(i);
                                        String strFormat = "{0}:{1}:00";
                                        int iHour = Int32.Parse(strTime.Substring(0, 2));
                                        int iMin = Int32.Parse(strTime.Substring(3, 2));
                                        if (lst_SelectedColumn[i].dateSetting.bTimeWithSec == false)
                                            strTime = String.Format("{0}:{1}",
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());
                                        else
                                            strTime = String.Format(strFormat,
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());


                                        strTemp = strTime;
                                    }
                                }
                                else if (lst_SelectedColumn[i].strColumnType == "int")
                                {
                                    int integer = myData.GetInt32(i);
                                    strTemp = integer.ToString();
                                }
                                else
                                {
                                    strTemp = myData.GetString(i);
                                }
                                if(lst_SelectedColumn[i].strColumnName.Equals("User ID", StringComparison.OrdinalIgnoreCase))
                                    exp.strUserID = myData.GetString(i);
                            }
                            catch (Exception ex)
                            {
                                strTemp = "";
                            }

                            if (strDelimiter.Length == 0)
                            {
                                int iCount = strTemp.Length;
                                if (lst_SelectedColumn[i].iCustomLength > iCount)
                                {
                                    if (lst_SelectedColumn[i].bFillZero == true)
                                    {
                                        strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                    }
                                    else
                                    {
                                        if (lst_SelectedColumn[i].bColTrim == false)
                                        {
                                            int iFillLength = lst_SelectedColumn[i].iCustomLength - iCount;
                                            String strSpace = String.Format("{0," + iFillLength + "}", "");
                                            strTemp += strSpace;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (lst_SelectedColumn[i].bFillZeroWithDelimiter == true)
                                {
                                    strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                }
                            }
                            if (lst_SelectedColumn[i].bColTrim == true)
                                strTemp = strTemp.Trim();
                            if (setting.bAddQuotation == true)
                                strTemp = "\"" + strTemp + "\"";
                            str += strTemp + strDelimiter;
                        }
                        if (strDelimiter.Length > 0)
                            str = str.Remove(str.Length - strDelimiter.Length);
                        exp.strResult = str;
                        bool isException = false;
                        try
                        {
                            int iTest = Int32.Parse(exp.strUserID);
                        }
                        catch (Exception ex)
                        {
                            isException = true;
                        }
                        if (isException == true)
                            lst_ExpException.Add(exp);
                        else
                            lst_Exp.Add(exp);
                    }
                    myData.Close();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            String strColumns = "";
            SQL = "";
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            if (setting.dateSearchCondition.bByDateRange == true)
            {
                //Pat 20160810 in_resume
                Global.changeDateTimeByCmbIndex(setting.dateSearchCondition.iDateType, ref dt);
            }
            else
                dt = setting.dateSearchCondition.dt_From;

            for (int i = 0; i < lst_SelectedColumn.Count; i++)
            {
                //if (lst_SelectedColumn[i].strColumnName == "Date In" || lst_SelectedColumn[i].strColumnName == "Date Out")
                if (lst_SelectedColumn[i].strColumnName == "Date In" || lst_SelectedColumn[i].strColumnName == "In Date")
                    strColumns += String.Format("'{0}',", dt.ToString("yyyy-MM-dd"));
                else
                    strColumns += String.Format("`{0}`,", lst_SelectedColumn[i].strColumnName);
            }
            strColumns = strColumns.Remove(strColumns.Length - 1);
            SQL = String.Format("select {0} from `{1}`", strColumns, strCurViewName+"_null_user");
            try
            {
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    return 0;
                else
                {
                    while (myData.Read())
                    {
                        String str = "";
                        ExportUserWithNoAttdRec exp = new ExportUserWithNoAttdRec();
                        for (int i = 0; i < lst_SelectedColumn.Count; i++)
                        {
                            String strTemp = "";
                            try
                            {
                                if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date" ||
                                    lst_SelectedColumn[i].strColumnType == "time")
                                {
                                    if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date")
                                    {
                                        DateTime date = new DateTime();
                                        date = myData.GetDateTime(i);
                                        if (date == null)
                                            strTemp = "";
                                        else
                                            strTemp = GetFormattedDate(date, i, lst_SelectedColumn[i]);
                                    }
                                    else
                                    {
                                        String strTime = myData.GetString(i);
                                        String strFormat = "{0}:{1}:00";
                                        int iHour = Int32.Parse(strTime.Substring(0, 2));
                                        int iMin = Int32.Parse(strTime.Substring(3, 2));
                                        if (lst_SelectedColumn[i].dateSetting.bTimeWithSec == false)
                                            strTime = String.Format("{0}:{1}",
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());
                                        else
                                            strTime = String.Format(strFormat,
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());


                                        strTemp = strTime;
                                    }
                                }
                                else if (lst_SelectedColumn[i].strColumnType == "int")
                                {
                                    int integer = myData.GetInt32(i);
                                    strTemp = integer.ToString();
                                }
                                else
                                {
                                    strTemp = myData.GetString(i);
                                }
                                if (lst_SelectedColumn[i].strColumnName.Equals("User ID", StringComparison.OrdinalIgnoreCase))
                                {
                                    exp.strUserID = myData.GetString(i);
                                }
                            }
                            catch (Exception ex)
                            {
                                strTemp = "";
                            }

                            if (strDelimiter.Length == 0)
                            {
                                int iCount = strTemp.Length;
                                if (lst_SelectedColumn[i].iCustomLength > iCount)
                                {
                                    if (lst_SelectedColumn[i].bFillZero == true)
                                    {
                                        strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                    }
                                    else
                                    {
                                        if (lst_SelectedColumn[i].bColTrim == false)
                                        {
                                            int iFillLength = lst_SelectedColumn[i].iCustomLength - iCount;
                                            String strSpace = String.Format("{0," + iFillLength + "}", "");
                                            strTemp += strSpace;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (lst_SelectedColumn[i].bFillZeroWithDelimiter == true)
                                {
                                    strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                }
                            }
                            if (lst_SelectedColumn[i].bColTrim == true)
                                strTemp = strTemp.Trim();
                            if (setting.bAddQuotation == true)
                                strTemp = "\"" + strTemp + "\"";
                            str += strTemp + strDelimiter;
                        }

                        ExportUserWithNoAttdRec exp_ExceptionExists = lst_ExpException.Find(delegate(ExportUserWithNoAttdRec e) { return e.strUserID == exp.strUserID; });
                        ExportUserWithNoAttdRec exp_Exists = lst_Exp.Find(delegate(ExportUserWithNoAttdRec e) { return e.strUserID == exp.strUserID; });
                        if (exp_Exists == null && exp_Exists == null)
                        {
                            bool isException = false;
                            try
                            {
                                int iTest = Int32.Parse(exp.strUserID);
                            }
                            catch (Exception ex)
                            {
                                isException = true;
                            }
                            if (strDelimiter.Length > 0)
                                str = str.Remove(str.Length - strDelimiter.Length);
                            exp.strResult = str;
                            if (isException == true)
                                lst_ExpException.Add(exp);
                            else
                                lst_Exp.Add(exp);
                        }
                    }
                    myData.Close();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            lst_Exp = lst_Exp.OrderBy(x => Int32.Parse(x.strUserID)).ToList();
            //lst_Exp = lst_Exp.OrderBy(x => x.strUserID).ToList();
            lst_ExpException = lst_ExpException.OrderBy(x => x.strUserID).ToList();
            String strHeader = "";
            if (strDelimiter.Length > 0)
            {
                if (setting.bNoHeader == false)
                {
                    foreach (SelectedColumn col in lst_SelectedColumn)
                    {
                        strHeader += col.strColumnName + strDelimiter;
                    }
                    strHeader = strHeader.Remove(strHeader.Length - strDelimiter.Length);
                    strExportResult = strHeader + "\r\n";
                }
            }
            foreach(ExportUserWithNoAttdRec e in lst_Exp)
            {
                strExportResult += e.strResult + "\r\n";
            }
            foreach (ExportUserWithNoAttdRec e in lst_ExpException)
            {
                strExportResult += e.strResult + "\r\n";
            }
            return lst_Exp.Count;
        }

        public int Export()
        {
            if (setting.lst_RawExportColumn == null || setting.lst_RawExportColumn.Count == 0)
                return 0;
            if (setting.bExportNoRecordUserInfo == true)
            {
                return ExportYesterdayForSpecial();
            }
            String SQL = BuildSQL();
            lst_Exp = new List<ExportUserWithNoAttdRec>();
            lst_ExpException = new List<ExportUserWithNoAttdRec>();
            String strResult = "";
            int iRecordCount = 0;
            try
            {
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    return 0;
                else
                {
                    String strDelimiter = setting.strRawDelimiter;
                    if (strDelimiter == "<TAB>")
                        strDelimiter = "\t";
                    while (myData.Read())
                    {
                        String str = "";
                        ExportUserWithNoAttdRec exp = new ExportUserWithNoAttdRec();
                        for (int i = 0; i < lst_SelectedColumn.Count; i++)
                        {
                            String strTemp = "";
                            try
                            {
                                if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date" ||
                                    lst_SelectedColumn[i].strColumnType == "time")
                                {
                                    if (lst_SelectedColumn[i].strColumnType == "datetime" ||
                                    lst_SelectedColumn[i].strColumnType == "date")
                                    {
                                        DateTime date = new DateTime();
                                        date = myData.GetDateTime(i);
                                        if (date == null)
                                            strTemp = "";
                                        else
                                            strTemp = GetFormattedDate(date, i, lst_SelectedColumn[i]);
                                    }
                                    else
                                    {
                                        String strTime = myData.GetString(i);
                                        String strFormat = "{0}:{1}:00";
                                        int iHour = Int32.Parse(strTime.Substring(0, 2));
                                        int iMin = Int32.Parse(strTime.Substring(3, 2));
                                        if (lst_SelectedColumn[i].dateSetting.bTimeWithSec == false)
                                            strTime = String.Format("{0}:{1}",
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());
                                        else
                                            strTime = String.Format(strFormat,
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iHour.ToString("D2") : iHour.ToString(),
                                                lst_SelectedColumn[i].dateSetting.bTimeFillZero == true ? iMin.ToString("D2") : iMin.ToString());


                                        strTemp = strTime;
                                    }
                                }
                                else if (lst_SelectedColumn[i].strColumnType == "int")
                                {
                                    int integer = myData.GetInt32(i);
                                    strTemp = integer.ToString();
                                }
                                else
                                {
                                    strTemp = myData.GetString(i);
                                }
                                if (lst_SelectedColumn[i].strColumnName.Equals("User ID", StringComparison.OrdinalIgnoreCase))
                                    exp.strUserID = myData.GetString(i);
                            }
                            catch (Exception ex)
                            {
                                strTemp = "";
                            }

                            if (strDelimiter.Length == 0)
                            {
                                int iCount = strTemp.Length;
                                if (lst_SelectedColumn[i].iCustomLength > iCount)
                                {
                                    if (lst_SelectedColumn[i].bFillZero == true)
                                    {
                                        strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                    }
                                    else
                                    {
                                        if (lst_SelectedColumn[i].bColTrim == false)
                                        {
                                            int iFillLength = lst_SelectedColumn[i].iCustomLength - iCount;
                                            String strSpace = String.Format("{0," + iFillLength + "}", "");
                                            strTemp += strSpace;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (lst_SelectedColumn[i].bFillZeroWithDelimiter == true)
                                {
                                    strTemp = strTemp.PadLeft(lst_SelectedColumn[i].iCustomLength, '0');
                                }
                            }
                            if (lst_SelectedColumn[i].bColTrim == true)
                                strTemp = strTemp.Trim();
                            if (setting.bAddQuotation == true)
                                strTemp = "\"" + strTemp + "\"";
                            str += strTemp + strDelimiter;
                        }
                        if (strDelimiter.Length > 0)
                            str = str.Remove(str.Length - strDelimiter.Length);
                        //strResult += str + "\r\n";
                        exp.strResult = str;
                        bool isException = false;
                        try
                        {
                            int iTest = Int32.Parse(exp.strUserID);
                        }
                        catch (Exception ex)
                        {
                            isException = true;
                        }
                        if (isException == true)
                            lst_ExpException.Add(exp);
                        else
                            lst_Exp.Add(exp);
                        iRecordCount++;
                    }
                    myData.Close();

                    lst_Exp = lst_Exp.OrderBy(x => Int32.Parse(x.strUserID)).ToList();
                    lst_ExpException = lst_ExpException.OrderBy(x => x.strUserID).ToList();

                    foreach (ExportUserWithNoAttdRec e in lst_Exp)
                    {
                        strResult += e.strResult + "\r\n";
                    }
                    foreach (ExportUserWithNoAttdRec e in lst_ExpException)
                    {
                        strResult += e.strResult + "\r\n";
                    }

                    if (strDelimiter.Length > 0)
                    {
                        if (setting.bNoHeader == false)
                        {
                            String strHeader = "";
                            foreach (SelectedColumn col in lst_SelectedColumn)
                            {
                                strHeader += col.strColumnName + strDelimiter;
                            }
                            strHeader = strHeader.Remove(strHeader.Length - strDelimiter.Length);
                            strResult = strHeader + "\r\n" + strResult;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                return 0;
            }
            strExportResult = strResult;
            return iRecordCount;
        }

        private String BuildSQL()
        {
            String SQL = "", strColumns = "";
            for (int i = 0; i < lst_SelectedColumn.Count; i++)
            {
                strColumns += String.Format("`{0}`,", lst_SelectedColumn[i].strColumnName);
            }
            strColumns = strColumns.Remove(strColumns.Length - 1);
            SQL = String.Format("select {0} from `{1}`", strColumns, strCurViewName);

            if (strCurViewName.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == true)
                SQL += ProcessSearchConditionOnClockingTime();
            else
                SQL += ProcessSearchConditionOnAttendanceDate();
            return SQL;
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
                strError = ex.Message;
                return false;
            }
            return true;
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
                myData = cmd.ExecuteReader();
            }

            return myData;
        }

        private String GetFormattedDate(DateTime date, int iSelectedIndex, SelectedColumn col)
        {
            String strFormat = "", strYear = "", strMonth = "", strDay = "";
            //Year Format
            if (col.dateSetting.bYearTwoY == true)
                strYear = date.Year.ToString().Substring(2, 2);
            else
                strYear = date.Year.ToString();
            //ens Year
            if (col.dateSetting.bDateFillZero == true)
            {
                strMonth = date.Month.ToString("D2");
                strDay = date.Day.ToString("D2");
            }
            else
            {
                strMonth = date.Month.ToString();
                strDay = date.Day.ToString();
            }

            strFormat = col.dateSetting.strDateFormat;
            if (col.dateSetting.bOtherDelimiter == true)
                strFormat = strFormat.Replace("/", "-");
            strFormat = strFormat.Replace("yyyy", strYear);
            strFormat = strFormat.Replace("dd", strDay);
            strFormat = strFormat.Replace("mm", strMonth);

            if (col.dateSetting.bHasTime == true)
            {
                String strTimeFormat = " HH:MM:SS";
                String strHour = "", strMin = "", strSec = "";
                if (col.dateSetting.bTimeFillZero == true)
                {
                    strHour = date.Hour.ToString("D2");
                    strMin = date.Minute.ToString("D2");
                    strSec = date.Second.ToString("D2");
                }
                else
                {
                    strHour = date.Hour.ToString();
                    strMin = date.Minute.ToString();
                    strSec = date.Second.ToString();
                }
                if (col.dateSetting.bTimeIs24 == false)
                {
                    strTimeFormat += " AA";
                    if (date.Hour < 12)
                        strTimeFormat = strTimeFormat.Replace("AA", "AM");
                    else
                    {
                        strTimeFormat = strTimeFormat.Replace("AA", "PM");
                        int newHour = date.Hour - 12;
                        if (col.dateSetting.bTimeFillZero == true)
                            strHour = newHour.ToString("D2");
                        else
                            strHour = newHour.ToString();
                    }
                }
                strTimeFormat = strTimeFormat.Replace("HH", strHour);
                strTimeFormat = strTimeFormat.Replace("MM", strMin);
                if (col.dateSetting.bTimeWithSec == true)
                    strTimeFormat = strTimeFormat.Replace("SS", strSec);
                else
                    strTimeFormat = strTimeFormat.Replace(":SS", "");
                strFormat += strTimeFormat;
            }
            return strFormat;
        }

        private String ProcessSearchConditionOnAttendanceDate()
        {
            String strWhereCondition = "";
            String strDateCol = Global.getViewDateCol(strCurViewName);
            String strDateWhereFormat = " `" + strDateCol + "` between '{0}' and '{1}'", strDateWhere = "";
            //************************************************
            // Edit Stephen 2017-10-16
            //************************************************
            String strDateTimeCol = Global.getViewDateTimeCol(strCurViewName);
            String strDateTimeWhereFormat = " " + strDateTimeCol + " between '{0}' and '{1}'";
            //************************************************
            
            if (setting.dateSearchCondition.bByDateRange == true)
            {
                DateTime dt_Search = new DateTime(), dt_End = new DateTime();
                dt_Search = DateTime.Now;
                dt_End = DateTime.Now;
                dt_End = dt_End.AddDays(-1);
                //Pat 20160810 in_resume
                // Edit Stephen 2017-10-19
                Global.changeDateTimeByCmbIndex_BeginEnd(setting.dateSearchCondition.iDateType, ref dt_Search, ref dt_End);
                // Edit Stephen 2017-10-19

                //********************************************************
                // Edit Stephen 2017-10-13
                //********************************************************
/*
                if (setting.dateSearchCondition.iDateType == 0 || setting.dateSearchCondition.iDateType == 6)
                    strDateWhere = String.Format(" `" + strDateCol + "` = '{0}'", dt_Search.ToString("yyyy-MM-dd"));
                else
                    strDateWhere = String.Format(strDateWhereFormat, dt_Search.ToString("yyyy-MM-dd"), dt_End.ToString("yyyy-MM-dd"));
*/
                if (setting.dateSearchCondition.iDateType != 6)
                {
                    dt_Search = new DateTime(dt_Search.Year, dt_Search.Month, dt_Search.Day, setting.dateSearchCondition.timeRange_From.Hour, setting.dateSearchCondition.timeRange_From.Minute, setting.dateSearchCondition.timeRange_From.Second);
                    dt_End = dt_End.AddDays(setting.dateSearchCondition.iDaysAfter + 1);
                    dt_End = new DateTime(dt_End.Year, dt_End.Month, dt_End.Day, setting.dateSearchCondition.timeRange_To.Hour, setting.dateSearchCondition.timeRange_To.Minute, setting.dateSearchCondition.timeRange_To.Second);
                    strDateWhere = String.Format(strDateTimeWhereFormat, dt_Search.ToString("yyyy-MM-dd HH:mm:ss"), dt_End.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    strDateWhere = String.Format(strDateWhereFormat, dt_Search.ToString("yyyy-MM-dd 00:00:00"), dt_Search.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                //********************************************************

          
            }
            else
            {
                DateTime dt_From = new DateTime(setting.dateSearchCondition.dt_From.Year, setting.dateSearchCondition.dt_From.Month, setting.dateSearchCondition.dt_From.Day, setting.dateSearchCondition.dt_From.Hour,
                    setting.dateSearchCondition.dt_From.Minute, setting.dateSearchCondition.dt_From.Second);
                DateTime dt_To = new DateTime(setting.dateSearchCondition.dt_To.Year, setting.dateSearchCondition.dt_To.Month, setting.dateSearchCondition.dt_To.Day, setting.dateSearchCondition.dt_To.Hour,
                    setting.dateSearchCondition.dt_To.Minute, setting.dateSearchCondition.dt_To.Second);
                strDateWhere = String.Format(strDateWhereFormat, dt_From.ToString("yyyy-MM-dd"), dt_To.ToString("yyyy-MM-dd"));
            }
            strWhereCondition += "where " + strDateWhere;
            return strWhereCondition;
        }

        private String ProcessSearchConditionOnClockingTime()
        {
            String strWhereCondition = "";
            //Process on Date condition
            String strDateWhereFormat = "`Clock Time` between '{0}' and '{1}'", strDateWhere = "";

            if (setting.dateSearchCondition.bByDateRange == true)
            {
                DateTime dt_Search = new DateTime(), dt_End = new DateTime();
                dt_Search = DateTime.Now;
                dt_End = DateTime.Now;
                dt_End = dt_End.AddDays(-1);
                //Pat 20160810 in_resume
                // Edit Stephen 2017-10-19
//                Global.changeDateTimeByCmbIndex(setting.dateSearchCondition.iDateType, ref dt_Search);
                Global.changeDateTimeByCmbIndex_BeginEnd(setting.dateSearchCondition.iDateType, ref dt_Search, ref dt_End);
                // Edit Stephen 2017-10-19

                //********************************************************
                // Edit Stephen 2017-10-13
                //********************************************************
                if (setting.dateSearchCondition.iDateType != 6)
                {
                    dt_Search = new DateTime(dt_Search.Year, dt_Search.Month, dt_Search.Day, setting.dateSearchCondition.timeRange_From.Hour, setting.dateSearchCondition.timeRange_From.Minute, setting.dateSearchCondition.timeRange_From.Second);
                    dt_End = dt_End.AddDays(setting.dateSearchCondition.iDaysAfter+1);
                    dt_End = new DateTime(dt_End.Year, dt_End.Month, dt_End.Day, setting.dateSearchCondition.timeRange_To.Hour, setting.dateSearchCondition.timeRange_To.Minute, setting.dateSearchCondition.timeRange_To.Second);
                    strDateWhere = String.Format(strDateWhereFormat, dt_Search.ToString("yyyy-MM-dd HH:mm:ss"), dt_End.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    strDateWhere = String.Format(strDateWhereFormat, dt_Search.ToString("yyyy-MM-dd 00:00:00"), dt_Search.AddDays(1).ToString("yyyy-MM-dd 00:00:00"));
                //********************************************************
            }
            else
            {
                DateTime dt_From = new DateTime(setting.dateSearchCondition.dt_From.Year, setting.dateSearchCondition.dt_From.Month, setting.dateSearchCondition.dt_From.Day, setting.dateSearchCondition.dt_From.Hour,
                    setting.dateSearchCondition.dt_From.Minute, setting.dateSearchCondition.dt_From.Second);
                DateTime dt_To = new DateTime(setting.dateSearchCondition.dt_To.Year, setting.dateSearchCondition.dt_To.Month, setting.dateSearchCondition.dt_To.Day, setting.dateSearchCondition.dt_To.Hour,
                    setting.dateSearchCondition.dt_To.Minute, setting.dateSearchCondition.dt_To.Second);

                strDateWhere = String.Format(strDateWhereFormat, dt_From.ToString("yyyy-MM-dd HH:mm:ss"), dt_To.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            strWhereCondition += "where " + strDateWhere;
            //end date condition
            return strWhereCondition;
        }
    }
}

class ExportUserWithNoAttdRec
{
    public String strUserID { get; set; }
    public String strResult { get; set; }
}