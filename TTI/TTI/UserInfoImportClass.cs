using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TTI
{
    class UserInfoImportClass
    {
        DataTable dtUser;
        DBConnectionSetting dbcs;
        public UserInfoImportClass(DataTable dtUser)
        {
            this.dtUser = dtUser;

        }

        public String import()
        {
            if (dtUser.Rows.Count < 1)
                return "no_rows";

            StringBuilder sbSql = new StringBuilder();
            DBConnectionSetting dbcs = new DBConnectionSetting();
            Global.getDBConnectionSetting(ref dbcs);
            MySqlConnection conn = new MySqlConnection();
            if (!Global.ConnectDB(ref dbcs, ref conn))
                return "DB_fail";

            foreach (DataRow dr in dtUser.Rows)
            {
                String strEmail = "";
                String strGender = "";
                String strClassAndNo = "";
                String strUserID = "";

                strEmail = dr["Email"].ToString();
                if (dr["gender"].ToString().Equals("M"))
                    strGender = "M";
                else
                    strGender = "F";
                strClassAndNo = dr["class"].ToString() + " (" + dr["class number"].ToString() + ")";
                strUserID = dr["UserID"].ToString();

                String strSqlTemp = "update user set Email = N'{0}', Gender = N'{1}', ic = N'{2}' where userid = N'{3}';";

                sbSql.Append(String.Format(strSqlTemp,strEmail,strGender,strClassAndNo, strUserID));
            }

            String strSql = sbSql.ToString();
            MySqlCommand cmd = new MySqlCommand(strSql, conn);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                return "SQL_fail";
            }

            return "Success";
        }
    }
}
