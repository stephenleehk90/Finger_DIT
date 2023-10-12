using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TTI
{
    public partial class frm_UserInfoImport : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        frm_Main frmMain;
        DataTable dtUser = new DataTable();

        public frm_UserInfoImport()
        {
            InitializeComponent();
        }

        private void frm_UserInfoImport_Load(object sender, EventArgs e)
        {
            ofd.Filter = "EXCEL|*.xls;*.xlsx";
            ofd.Multiselect = false;
        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void frm_UserInfoImport_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroyUserInfoImportForm();
        }

        private void frm_UserInfoImport_Resize(object sender, System.EventArgs e)
        {
            //position
            btn_import.Left = 564 + this.Width - 800;
            btn_import.Top = 426 + this.Height - 500;
            btn_cancel.Left = 697 + this.Width - 800;
            btn_cancel.Top = 426 + this.Height - 500;

            //size
            dgvUserInfo.Width = 760 + this.Width - 800;
            dgvUserInfo.Height = 355 + this.Height - 500;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            btn_import.Enabled = false;
            lbl_alert.Visible = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String strFileName = ofd.SafeFileName;
                String strFileFullPath = ofd.FileName;
                dgvUserInfo.DataSource = null;
                dtUser = new DataTable();

                if (strFileFullPath.Substring(strFileFullPath.LastIndexOf('.')).ToLower() == ".xls"  || strFileFullPath.Substring(strFileFullPath.LastIndexOf('.')).ToLower() == ".xlsx")
                {
                    OleDbConnection cnn;
                    try
                    {
                        //get xls / xlsx to datatable
                        String strConn = "";
                        if (strFileFullPath.Substring(strFileFullPath.LastIndexOf('.')).ToLower() == ".xlsx" || strFileFullPath.Substring(strFileFullPath.LastIndexOf('.')).ToLower() == ".xls")
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileFullPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";
                        //else
                        //    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileFullPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=0\"";
                        cnn = new OleDbConnection(strConn);
                        cnn.Open();
                        //get first sheet name
                        DataTable dtSchema = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        String strFirstSheetName = "";
                        if( (null != dtSchema) && ( dtSchema.Rows.Count > 0 ) )
                        {
                            strFirstSheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                        }

                        if (strFirstSheetName.Equals(""))
                            strFirstSheetName = "Sheet1";
                        OleDbCommand oconn = new OleDbCommand("select * from [" + strFirstSheetName + "]", cnn);
                        OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                        adp.Fill(dtUser);

                        //check column
                        String strAllColumn = "";
                        foreach (DataColumn column in dtUser.Columns)
                        {
                            strAllColumn += column.ColumnName.ToLower() + ";";                            
                        }

                        String strErrCol = "";
                        bool bColumnPass = true;

                        if (!strAllColumn.Contains("userid;"))
                        {
                            strErrCol += "UserID\n";
                            bColumnPass = false;
                        }
                        else if (!strAllColumn.Contains("username;"))
                        {
                            strErrCol += "Username\n";
                            bColumnPass = false;
                        }
                        else if (!strAllColumn.Contains("email;"))
                        {
                            strErrCol += "Email\n";
                            bColumnPass = false;
                        }
                        else if (!strAllColumn.Contains("gender;"))
                        {
                            strErrCol += "gender\n";
                            bColumnPass = false;
                        }
                        else if (!strAllColumn.Contains("class;"))
                        {
                            strErrCol += "class\n";
                            bColumnPass = false;
                        }
                        else if (!strAllColumn.Contains("class number;"))
                        {
                            strErrCol += "class number\n";
                            bColumnPass = false;
                        }

                        if (!strErrCol.Equals(""))
                        {
                            MessageBox.Show("Column missing:\n\n" + strErrCol);                            
                        }
                        else
                        {
                            if (dtUser.Rows.Count > 0)
                            {
                                lbl_alert.Visible = false;
                                dgvUserInfo.DataSource = dtUser;
                                btn_import.Enabled = true;
                                tb_file.Text = ofd.FileName;
                            }
                            else
                                lbl_alert.Visible = true;
                        }

                        cnn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("File type error / File is opened by other program.");
                        return;
                    }
                }
                else
                {                    
                    MessageBox.Show("File type error.");
                    return;
                }
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            UserInfoImportClass uiic = new UserInfoImportClass(dtUser);
            String result = uiic.import();
            if (result.Equals("Success"))
                MessageBox.Show("Success");
            else if (result.Equals("DB_fail"))
                MessageBox.Show("DB fail");
            else if (result.Equals("SQL_fail"))
                MessageBox.Show("SQL error");
            else if (result.Equals("no_rows"))
                MessageBox.Show("No data");
            else
                MessageBox.Show("Unknown error");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
