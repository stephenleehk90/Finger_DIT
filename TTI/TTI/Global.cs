using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace TTI
{
    class Global
    {
        //**************************************************************************************************************
        // Edit Stephen 2017-10-19
        //**************************************************************************************************************
        public static void changeDateTimeByCmbIndex_BeginEnd(int index, ref DateTime dt_time, ref DateTime dt_time_end)
        {
            switch (index)
                    {
                        case 0:
                            dt_time = dt_time.AddDays(-1);
                            dt_time_end = dt_time;
                            break;
                        case 1:
                            int iDayMinus = 0;
                            if (dt_time.DayOfWeek == DayOfWeek.Monday)
                              iDayMinus = 1;
                            else if (dt_time.DayOfWeek == DayOfWeek.Tuesday)
                                iDayMinus = 2;
                            else if (dt_time.DayOfWeek == DayOfWeek.Wednesday)
                                iDayMinus = 3;
                            else if (dt_time.DayOfWeek == DayOfWeek.Thursday)
                                iDayMinus = 4;
                            else if (dt_time.DayOfWeek == DayOfWeek.Friday)
                                iDayMinus = 5;
                            else if (dt_time.DayOfWeek == DayOfWeek.Saturday)
                                iDayMinus = 6;
                            dt_time = dt_time.AddDays(-7 - iDayMinus);
                            dt_time_end = dt_time.AddDays(6);
                            break;
                        case 2:
                            dt_time = dt_time.AddDays(-(dt_time.Day-1)).AddMonths(-1);
                            dt_time_end = dt_time.AddMonths(1).AddDays(-1);
                            break;
                        case 3:
                            dt_time = dt_time.AddDays(-(dt_time.Day-1)).AddMonths(-3);
                            dt_time_end = dt_time.AddMonths(3).AddDays(-1);
                            break;
                        case 4:
                            dt_time = dt_time.AddDays(-(dt_time.Day-1)).AddMonths(-6);
                            dt_time_end = dt_time.AddMonths(6).AddDays(-1);
                            break;
                        case 5:
                            dt_time = dt_time.AddDays(-(dt_time.DayOfYear-1)).AddYears(-1);
                            dt_time_end = dt_time.AddYears(1).AddDays(-1);
                            break;
                        case 6:
                            break;//Today no change
                    }
        }
        public static void changeDateTimeByCmbIndex(int index, ref DateTime dt_time)
        {
            switch (index)
            {
                case 0:
                    dt_time = dt_time.AddDays(-1);
                    break;
                case 1:
                    int iDayMinus = 0;
                    if (dt_time.DayOfWeek == DayOfWeek.Monday)
                        iDayMinus = 1;
                    else if (dt_time.DayOfWeek == DayOfWeek.Tuesday)
                        iDayMinus = 2;
                    else if (dt_time.DayOfWeek == DayOfWeek.Wednesday)
                        iDayMinus = 3;
                    else if (dt_time.DayOfWeek == DayOfWeek.Thursday)
                        iDayMinus = 4;
                    else if (dt_time.DayOfWeek == DayOfWeek.Friday)
                        iDayMinus = 5;
                    else if (dt_time.DayOfWeek == DayOfWeek.Saturday)
                        iDayMinus = 6;
                    dt_time = dt_time.AddDays(-7 - iDayMinus);
                    break;
                case 2:
                    dt_time = dt_time.AddDays(-(dt_time.Day - 1)).AddMonths(-1);
                    break;
                case 3:
                    dt_time = dt_time.AddDays(-(dt_time.Day - 1)).AddMonths(-3);
                    break;
                case 4:
                    dt_time = dt_time.AddDays(-(dt_time.Day - 1)).AddMonths(-6);
                    break;
                case 5:
                    dt_time = dt_time.AddDays(-(dt_time.DayOfYear - 1)).AddYears(-1);
                    break;
                case 6:
                    break;//Today no change
            }
        }
        //**************************************************************************************************************
        public static bool modeViewApprove(String strMode, String strViewName)
        {
            bool result = false;

            if (strMode.Equals("silent"))
            {
                if (strViewName.Equals("attendance_record"))
                    result = true;
            }
            else if (strMode.Equals("silent_in_on_time"))
            {
                if (strViewName.Equals("attendance_record_in_on_time"))
                    result = true;
            }
            else if (strMode.Equals("silent_in_late"))
            {
                if (strViewName.Equals("attendance_record_in_late"))
                    result = true;
            }
            else if (strMode.Equals("silent_resume_on_time"))
            {
                if (strViewName.Equals("attendance_record_resume_on_time"))
                    result = true;
            }
            else if (strMode.Equals("silent_resume_late"))
            {
                if (strViewName.Equals("attendance_record_resume_late"))
                    result = true;
            }
            else if (strMode.Equals("silent_in"))
            {
                if (strViewName.Equals("attendance_record_in_on_time")
                    || strViewName.Equals("attendance_record_in_late"))
                    result = true;
            }
            else if (strMode.Equals("silent_resume"))
            {
                if (strViewName.Equals("attendance_record_resume_on_time")
                    || strViewName.Equals("attendance_record_resume_late"))
                    result = true;
            }
            else if (strMode.Equals("silent_in_resume"))
            {
                if (strViewName.Equals("attendance_record_in_on_time")
                    || strViewName.Equals("attendance_record_in_late")
                    || strViewName.Equals("attendance_record_resume_on_time")
                    || strViewName.Equals("attendance_record_resume_late"))
                    result = true;
            }

            return result;
        }
        public static void getViewTimeType(String strViewName, ref String strTimeType, ref String strPostFileType)
        {
            if (strViewName.Equals("attendance_record_in_on_time"))
            {
                strTimeType = "am";
                strPostFileType = "on_time";
            }
            else if (strViewName.Equals("attendance_record_in_late"))
            {
                strTimeType = "am";
                strPostFileType = "late";
            }
            else if (strViewName.Equals("attendance_record_resume_on_time"))
            {
                strTimeType = "pm";
                strPostFileType = "on_time";
            }
            else if (strViewName.Equals("attendance_record_resume_late"))
            {
                strTimeType = "pm";
                strPostFileType = "late";
            }
            else
            {
                strTimeType = "";
                strPostFileType = "";
            }
        }
        public static String getViewDateCol(String strViewName)
        {
            if (strViewName.Equals("attendance_record"))
                return "Date In";
            else if (strViewName.Equals("attendance_record_in_on_time"))
                return "In Date";
            else if (strViewName.Equals("attendance_record_in_late"))
                return "In Date";
            else if (strViewName.Equals("attendance_record_resume_on_time"))
                return "In Date";
            else if (strViewName.Equals("attendance_record_resume_late"))
                return "In Date";
            else
                return "Date In";
        }

        //************************************************
        // Edit Stephen 2017-10-16
        //************************************************
        public static String getViewDateTimeCol(String strViewName)
        {
            if (strViewName.Equals("attendance_record"))
                return "addtime(`Date In`, `Time In`)";
            else if (strViewName.Equals("attendance_record_in_on_time"))
                return "addtime(`In Date`, `In Time`)";
            else if (strViewName.Equals("attendance_record_in_late"))
                return "addtime(`In Date`, `In Time`)";
            else if (strViewName.Equals("attendance_record_resume_on_time"))
                return "addtime(`In Date`, `In Time`)";
            else if (strViewName.Equals("attendance_record_resume_late"))
                return "addtime(`In Date`, `In Time`)";
            else
                return "addtime(`Date In`, `Time In`)";
        }
        //************************************************

        public static String strDecryption(String str)
        {
            if (str.Length == 0)
                return "";
            String strDone = SSTCryptographer.Decrypt(str, "founder"); ;
            return strDone;
        }
        public static String strEncryption(String str)
        {
            String strDone = SSTCryptographer.Encrypt(str, "founder");
            return strDone;
        }

        //Pat 20160912 user info import-----------------------------------------------------
        public static void getDBConnectionSetting(ref DBConnectionSetting dbcs)
        {
            ConfigHandler config = new ConfigHandler();
            dbcs.strDatabase = config.GetKeyValue("Database");
            dbcs.strPassword = strDecryption(config.GetKeyValue("Password"));
            dbcs.strPort = config.GetKeyValue("Port");
            dbcs.strServer = config.GetKeyValue("Server");
            dbcs.strUserName = config.GetKeyValue("Username");
        }
        public static bool ConnectDB(ref DBConnectionSetting dbcs, ref MySqlConnection conn)
        {
            string connStrFormat = "Server={0};Port={1};Uid={2};Pwd={3};Database={4};";
            string connStr = String.Format(connStrFormat, dbcs.strServer, dbcs.strPort, dbcs.strUserName, dbcs.strPassword, dbcs.strDatabase);
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
        //----------------------------------------------------------------------------------
    }

}
