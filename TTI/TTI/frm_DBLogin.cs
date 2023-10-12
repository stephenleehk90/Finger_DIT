using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO;

namespace TTI
{
    public partial class frm_DBLogin : Form
    {
        SettingClass settingClass;
        Setting setting;
        public bool bOK;
        public bool bAuto;
        frm_Main frmMain;
        List<SqlView> lst_SqlView;

        public frm_DBLogin()
        {
            InitializeComponent();
            settingClass = new SettingClass();
            bOK = false;
            bAuto = false;
            lst_SqlView = new List<SqlView>();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TryValidation();
            if (bOK == false)
                return;

            setting.DBConnect.strServer = tb_Server.Text;
            setting.DBConnect.strPassword = tb_Password.Text;
            setting.DBConnect.strUserName = tb_UserName.Text;
            setting.DBConnect.strPort = tb_Port.Text;
            setting.DBConnect.strDatabase = tb_Database.Text;
            settingClass.SaveSetting(setting, true);
            frmMain.SetLoginValidated(bOK, bAuto);
            if (bOK == true)
                this.Close();
        }

        private void DBLogin_Load(object sender, EventArgs e)
        {
            setting = settingClass.GetSetting("");
            tb_Server.Text = setting.DBConnect.strServer;
            tb_Password.Text = setting.DBConnect.strPassword;
            tb_UserName.Text = setting.DBConnect.strUserName;
            tb_Database.Text = setting.DBConnect.strDatabase;
            if (setting.DBConnect.strPort == "3306" || setting.DBConnect.strPort.Length == 0)
            {
                ckb_Port.Checked = false;
                tb_Port.Text = "3306";
            }
            if (setting.DBConnect.strPort != "3306" && setting.DBConnect.strPort.Length > 0)
            {
                ckb_Port.Checked = true;
            }
            ckb_Port_CheckedChanged(null, null);
            TryValidation();
            frmMain.SetLoginValidated(bOK, bAuto);
        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void tb_Server_Leave(object sender, EventArgs e)
        {
            //TryValidation();
        }

        private void TryValidation()
        {
            if (tb_Server.Text.Length != 0 &&
                tb_UserName.Text.Length != 0 &&
                tb_Password.Text.Length != 0 &&
                tb_Database.Text.Length != 0)
            {
                Connect();
            }
        }

        private void Connect()
        {
            String strConnFormat = "Server={0};Port={1};Uid={2};Pwd={3};Database={4};";
            MySqlConnection conn = new MySqlConnection(String.Format(strConnFormat, tb_Server.Text,
                tb_Port.Text, tb_UserName.Text, tb_Password.Text, tb_Database.Text));
            try
            {
                conn.Open();
                bOK = true;
                CheckAndCreateViews(conn);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Cannot Login to DB:\r\n" + ex.Message);
                bOK = false;
                return;
            }
        }

        private void ckb_Port_CheckedChanged(object sender, EventArgs e)
        {
            bool bEnable = false;
            bEnable = ckb_Port.Checked;
            tb_Port.Enabled = bEnable;
        }

        private void tb_UserName_Leave(object sender, EventArgs e)
        {
            //TryValidation();
        }

        private void tb_Password_Leave(object sender, EventArgs e)
        {
            //TryValidation();
        }

        private void frm_DBLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroyLoginForm();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DBLogin_Shown(object sender, EventArgs e)
        {
            if (bOK == true && bAuto == true)
                btn_Cancel_Click(null, null);
        }

        private void CheckAndCreateViews(MySqlConnection conn)
        {
            PrepareCreateSql();
            for (int i = 0; i < lst_SqlView.Count; i++)
            {
                String strSql = "";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                strSql = lst_SqlView[i].strSql;
                cmd = new MySqlCommand(strSql, conn);
                cmd.ExecuteReader().Close();
                
            }
        }

        private void PrepareCreateSql()
        {
            String path = Environment.CurrentDirectory;
            path += "\\Views\\";
            try
            {
                string[] fileEntries = Directory.GetFiles(path);
                foreach (string fileName in fileEntries)
                {
                    SqlView sqlview = new SqlView();
                    String text = "";
                    FileInfo info = new FileInfo(fileName);
                    String strFileName = info.Name;
                    var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        text = streamReader.ReadToEnd();
                    }
                    sqlview.strViewName = strFileName.Substring(0, strFileName.LastIndexOf("."));
                    sqlview.strSql = text;
                    lst_SqlView.Add(sqlview);

                }
            }catch(Exception ex){}
        }
    }
}

class SqlView
{
    public String strViewName { get; set; }
    public String strSql { get; set; }
}
