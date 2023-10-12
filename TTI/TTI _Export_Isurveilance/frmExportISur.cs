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

namespace TTI
{
    public partial class frmExportISur : Form
    {
        private String m_strIP = "210.59.250.135:8080";
        private String m_strToken = "";
        private String m_strDeviceID = "";
        private String m_strPrevDeviceID = "";

        public frmExportISur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/API");
            try
            {
                //setting parameters
 //               HttpContent hcStrToken = new StringContent(strToken);
 //               HttpContent hcModuleKey = new StringContent(settingWebService.strModuleKey);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
/*                    if (!strToken.Equals(""))
                        formData.Add(hcStrToken, "token");
                    else
                        formData.Add(hcModuleKey, "moduleKey");

                    formData.Add(hcBytesContentConf, "configFile", "config.json");
                    if (strPostFileType.Equals("on_time"))
                        formData.Add(hcBytesContentCsv, "dailyAttendanceImport", "dailyAttendance.csv");
                    else if (strPostFileType.Equals("late"))
                        formData.Add(hcBytesContentCsv, "lateAttendanceImport", "lateAttendance.csv");
*/
                    var response = client.GetAsync(sbWsPostURL.ToString()).Result;

/*                    MessageBox.Show(response.Content.ToString());
                    MessageBox.Show(response.ToString());
                    MessageBox.Show(response.ReasonPhrase.ToString());
                    MessageBox.Show(response.Content.ToString());
*/
                    
                    String strJson = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show(strJson);

/*
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
                        result = "CSV missing";
                    else
                        result = "Unknown";
*/
                    
                }
            
            }
            catch (Exception ex)
            {

            }

//            return ;

        }

        //************************************************************************************************************
        // procedure name: Get_Token
        // Get Token ID (m_strToken) using the Device ID 
        // Input: /
        // Output: bool
        //************************************************************************************************************
        private bool Get_Token()
        {
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
                    //                    MessageBox.Show(m_strToken);

                    m_strToken = m_strToken.Replace("\"","").Trim();

                    m_strPrevDeviceID = m_strDeviceID;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
        //************************************************************************************************************

        private void button5_Click(object sender, EventArgs e)
        {
            Get_Token();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgFile.ShowDialog() == DialogResult.OK)
            {
                lvResult.Items.Clear();
                txtCSV.Text = dgFile.FileName.ToString();

                using (TextFieldParser parser = new TextFieldParser(txtCSV.Text))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                            //Process row
                        string[] fields = parser.ReadFields();
                        if (parser.LineNumber > 2)
                        {
                            ListViewItem lvi = lvResult.Items.Add(fields[0].ToString());
                            foreach (string field in fields)
                            {
                                lvi.SubItems.Add(field.ToString());
    //                                MessageBox.Show(field.ToString());
                                //TODO: Process field
                            }
                        }
                    }
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtAccessControlID.Text.Trim() == "")
            {
                MessageBox.Show("Please Access Control ID");
                return;
            }
            m_strDeviceID = txtAccessControlID.Text.Trim();
            
            if (m_strToken == "" || m_strDeviceID != m_strPrevDeviceID)
            {
                if (!Get_Token())
                    return;
            }
            
            if (txtCSV.Text.Trim() == "")
            {
                MessageBox.Show("Please select a CSV file");
                return;
            }


            StringBuilder sbWsPostURL = new StringBuilder();
            sbWsPostURL.Append("http://");
            sbWsPostURL.Append(m_strIP);
            sbWsPostURL.Append("/AccessEvent/" + m_strToken + "/UploadEventCSV ");
            try
            {
                //setting parameters
                //               HttpContent hcStrToken = new StringContent(strToken);
                //               HttpContent hcModuleKey = new StringContent(settingWebService.strModuleKey);
                string strFileFullPath = txtCSV.Text.Trim();
                string strFileName = strFileFullPath.Substring(strFileFullPath.IndexOf("\\")+1);
                HttpContent hcBytesContentCsv = new ByteArrayContent(File.ReadAllBytes(strFileFullPath));
                HttpContent hcStrToken = new StringContent(m_strToken);

                //start ws
                using (var client = new HttpClient())
                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(hcStrToken, "tokenId");
                    formData.Add(hcBytesContentCsv, "file", strFileName);

                    var response = client.PostAsync(sbWsPostURL.ToString(), formData).Result;

                    /*                    MessageBox.Show(response.Content.ToString());
                                        MessageBox.Show(response.ToString());
                                        MessageBox.Show(response.ReasonPhrase.ToString());
                                        MessageBox.Show(response.Content.ToString());
                    */

                    String strJson = response.Content.ReadAsStringAsync().Result;
                    MessageBox.Show(strJson);
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgSaveFile.ShowDialog() == DialogResult.OK)
            {
                string strFileName = dgSaveFile.FileName.ToString();
                StreamWriter fi = new StreamWriter(strFileName, true, Encoding.ASCII); 

                for (int i=0; i < lvResult.Items.Count; i++)
                {
                    ListViewItem lvi = lvResult.Items[i];
                    string strRow = lvi.Text.ToString();
                    strRow = strRow + "," + lvi.SubItems[0].Text.ToString();
                    strRow = strRow + "," + lvi.SubItems[1].Text.ToString();
                    strRow = strRow + "," + lvi.SubItems[2].Text.ToString();
                    strRow = strRow + "," + lvi.SubItems[3].Text.ToString();
                    strRow = strRow + "," + lvi.SubItems[3].Text.ToString();
                    fi.WriteLine(strRow);
                }
                fi.Close();
                txtCSV.Text = strFileName;
            }

        }

        private void frmExportISur_Load(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAccessControlID.Clear();
            txtEventHandle.Clear();
            txtIPCamID.Clear();
            txtEventType.Clear();
            txtUserCardID.Clear();

            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;

        }
    }
}
