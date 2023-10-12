using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;

namespace TTI
{
    public partial class frmISurMain : Form
    {
        ConfigHandler config;
        private string m_strIP = "192.168.30.20";
        private string m_strTempFilePath = "C:\\Temp";
        private string m_strRunDay = "0";
        ISurveillance m_iSur;

        public frmISurMain()
        {
            InitializeComponent();
            config = new ConfigHandler();
            m_iSur = new ISurveillance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmISurMain_Load(object sender, EventArgs e)
        {
/*            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Code");
            DataRow dr = dt.NewRow();
            dr["Name"] = "門3";
            dr["Code"] = "4359d0db-5722-45ee-94ef-fbe8d3aeef4a";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "裝置3";
            dr["Code"] = "4e834b5e-c200-4c90-b3a7-110499428600";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "裝置2";
            dr["Code"] = "b0d1a5f2-ced4-4c82-8acb-d908159fbc18";
            dt.Rows.Add(dr);
*/
//4359d0db-5722-45ee-94ef-fbe8d3aeef4a,門3,door,
//4e834b5e-c200-4c90-b3a7-110499428600,裝置3,controller,
//b0d1a5f2-ced4-4c82-8acb-d908159fbc18,裝置2,controller,
//d053cd65-fe32-43d7-a3c1-684efbe2988e,門2,door,
//e7f58ae4-8872-4b6d-9890-2ab3cc8f00e0,門1,door,
//f66979bc-28ea-430b-b6ef-22a63180f945,裝置1,controller,
            m_iSur.Add_Device("", "", "");


            m_iSur.Get_EventTypeList();
            m_iSur.Get_UserList();
            m_iSur.Get_CameraList();
            m_iSur.Get_DeviceList();

            m_strIP = config.GetKeyValue("ISurWebIP");
            if (m_strIP.Trim() == "")
                m_strIP = "192.168.30.20";
            txt_Web_IP.Text = m_strIP;

            m_strTempFilePath = config.GetKeyValue("ISurTempFilePath");
            if (m_strTempFilePath.Trim() == "")
                m_strTempFilePath = "C:\\Temp";
            txt_Path.Text = m_strTempFilePath;

            m_strRunDay = config.GetKeyValue("ISurRunDay");
            if (m_strRunDay.Trim() == "")
                m_strRunDay = "0";
            txt_Run_Day.Text = m_strRunDay;

            UpdateEventTypeList();
            UpdateDeviceList();
            UpdateUserList();
            UpdateCameraList();

        }

        private void UpdateEventTypeList()
        {
            lvResult.Items.Clear();
            for (int i = 0; i < m_iSur.lst_EventType.Count; i++)
            {
                ISurveillance.EventType stEventType = m_iSur.lst_EventType[i];
                ListViewItem lvi = lvResult.Items.Add(stEventType.strEventHandle);
                lvi.SubItems.Add(stEventType.strEventName);
                lvi.SubItems.Add(stEventType.strEventType);
                lvi.SubItems.Add(stEventType.strDesc);
            }
        }

        private void UpdateDeviceList()
        {
            lvResult_Device.Items.Clear();
            for (int i = 0; i < m_iSur.lst_Device.Count; i++)
            {
                ISurveillance.Device stDevice = m_iSur.lst_Device[i];
                ListViewItem lvi = lvResult_Device.Items.Add(stDevice.strAccessControlID);
                lvi.SubItems.Add(stDevice.strAccessControlName);
                lvi.SubItems.Add(stDevice.strEventType);
                lvi.SubItems.Add(stDevice.strDesc);
            }
        }

        private void UpdateUserList()
        {
            lvResult_User.Items.Clear();
            for (int i = 0; i < m_iSur.lst_User.Count; i++)
            {
                ISurveillance.User stUser = m_iSur.lst_User[i];
                ListViewItem lvi = lvResult_User.Items.Add(stUser.strUserCardID);
                lvi.SubItems.Add(stUser.strUserName);
                lvi.SubItems.Add(stUser.strGender);
                lvi.SubItems.Add(stUser.strPhone);
                lvi.SubItems.Add(stUser.strInService);
            }
        }

        private void UpdateCameraList()
        {
            lvResult_Cam.Items.Clear();
            for (int i = 0; i < m_iSur.lst_Camera.Count; i++)
            {
                ISurveillance.Camera stCamera = m_iSur.lst_Camera[i];
                ListViewItem lvi = lvResult_Cam.Items.Add(stCamera.strIPCamID);
                lvi.SubItems.Add(stCamera.strIP);
                lvi.SubItems.Add(stCamera.strName);
                lvi.SubItems.Add(stCamera.strDesc);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txt_EventHandle.Text.Trim() != "" && txt_EventName_Eng.Text.Trim() != "")
            {
                string strType = "door";
                if (rb_Controller.Checked)
                    strType = "controller";
                ISurveillance.EventType eventtype; 
                eventtype.strEventHandle = txt_EventHandle.Text.Trim();
                eventtype.strEventName = txt_EventName_Eng.Text.Trim();
                eventtype.strEventType = strType;
                eventtype.strDesc = txt_EventDesc.Text.Trim();
                m_iSur.lst_EventType.Add(eventtype);
                m_iSur.Update_EventType();
            }
            else
            {
                MessageBox.Show("Please input Required Information");
                return;
            }
            UpdateEventTypeList();

        }

        private void btn_Add_Device_Click(object sender, EventArgs e)
        {

            if (txt_AccessControlName.Text.Trim() == "")
            {
                MessageBox.Show("Please input Required Information");
                return;
            }

            string strType = "door";
            if (rb_Controller_Device.Checked)
                strType = "controller";

            m_iSur.Add_Device(strType, txt_AccessControlName.Text.Trim(), txt_Device_Desc.Text.Trim());

            UpdateDeviceList();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {

            if (txt_UserCardID.Text.Trim() != "" &&
                txt_UserCardID_2.Text.Trim() != "" &&
                txt_UserCardID_3.Text.Trim() != "" &&
                txt_UserCardID_4.Text.Trim() != "" &&
                txt_UserCardID_5.Text.Trim() != "" &&
                txt_UserName.Text.Trim() != "" &&
                txt_Phone.Text.Trim() != "" &&
                txt_InService.Text.Trim() != "")
            {
                string strGender = "男";
                if (rb_Female.Checked)
                    strGender = "女";

                ISurveillance.User user;
                user.strUserCardID = txt_UserCardID.Text.Trim() 
                    + "-" + txt_UserCardID_2.Text.Trim()
                    +"-" + txt_UserCardID_3.Text.Trim()
                    +"-" + txt_UserCardID_4.Text.Trim()
                    +"-" + txt_UserCardID_5.Text.Trim();
                user.strUserName = txt_UserName.Text.Trim();
                user.strGender = strGender;
                user.strPhone = txt_Phone.Text.Trim();
                user.strInService = txt_InService.Text.Trim();
 
                m_iSur.lst_User.Add(user);
                m_iSur.Update_User();

            }
            else
            {
                MessageBox.Show("Please input Required Information");
                return;
            }
            UpdateUserList();

        }

        private void btn_Add_Cam_Click(object sender, EventArgs e)
        {

            if (txt_IPCamID.Text.Trim() != "" && txt_IPCamID_2.Text.Trim() != ""
                && txt_IPCamID_3.Text.Trim() != "" && txt_IPCamID_4.Text.Trim() != ""
                && txt_IPCamID_5.Text.Trim() != "" && txt_IP.Text.Trim() != ""
                && txt_Name_Cam.Text.Trim() != "" && txt_Desc_Cam.Text.Trim() != "")
            {

                ISurveillance.Camera camera;
                camera.strIPCamID = txt_IPCamID.Text.Trim()
                    + "-" + txt_IPCamID_2.Text.Trim()
                    + "-" + txt_IPCamID_3.Text.Trim()
                    + "-" + txt_IPCamID_4.Text.Trim()
                    + "-" + txt_IPCamID_5.Text.Trim();
                camera.strIP = txt_IP.Text.Trim();
                camera.strName = txt_Name_Cam.Text.Trim();
                camera.strDesc = txt_Desc_Cam.Text.Trim();

                m_iSur.lst_Camera.Add(camera);
                m_iSur.Update_Camera();
            }
            else
            {
                MessageBox.Show("Please input Required Information");
                return;
            }

            UpdateCameraList();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_strIP = txt_Web_IP.Text.Trim();
            config.UpdateKeyValue(m_strIP, "ISurWebIP");

            m_strTempFilePath = txt_Path.Text.Trim();
            config.UpdateKeyValue(m_strTempFilePath, "ISurTempFilePath");

        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            string strRet = m_iSur.Update_Event();
            if (strRet.ToUpper() == "OK")
                MessageBox.Show("Upload Success");
            else
                MessageBox.Show("Upload Fail: " + strRet);
        }

        private void btn_Save_ISur_Click(object sender, EventArgs e)
        {
            m_strRunDay = txt_Run_Day.Text.Trim();
            config.UpdateKeyValue(m_strRunDay, "ISurRunDay");
        }


    }


}
