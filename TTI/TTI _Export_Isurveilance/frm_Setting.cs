using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;

namespace TTI
{
    public partial class frm_Setting : Form
    {
        MySqlConnection conn;
        String strError;
        frm_SelectViews frmSelectTables;
        //frm_ColumnOutputFormat frmCoumnOutputFormat;
        Setting setting;
        SettingClass settingClass;
        frm_Main frmMain;
        List<SelectedColumn> lst_SelectedColumn;
        List<DBColumn> lst_DBColumn, lst_FullDBColumn;
        int iColSettingIndex;
        bool bNeedSave, bInit;

        public frm_Setting()
        {
            InitializeComponent();
            conn = new MySqlConnection();
            settingClass = new SettingClass();
            setting = new Setting();
            lst_DBColumn = new List<DBColumn>();
            lst_SelectedColumn = new List<SelectedColumn>();
            lst_FullDBColumn = new List<DBColumn>();
            strError = "";
            iColSettingIndex = 0;
            bNeedSave = false;
            bInit = true;
        }

        public void SetFrmMain(frm_Main frmMain)
        {
            this.frmMain = frmMain;
        }

        private void frm_Setting_Load(object sender, EventArgs e)
        {
            LoadSetting();
            if (Connect() == false)
            {
                MessageBox.Show("Cannot connect to Database:" + strError);
                this.Close();
            }
            EnableIsDateColFormatSetting(false, "");
            LoadViews();
            bInit = false;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (SaveValidation() == false)
                return;
            SaveSetting();
        }

        private bool SaveValidation()
        {
            //if (tb_Delimiter.Text.Length == 0)
            //{
            //    return false;
            //}
            return true;
        }

        private void SaveSetting()
        {
            SaveColumnFormatSetting();
            setting.lst_RawExportColumn = lst_SelectedColumn;
            setting.strRawDelimiter = tb_Delimiter.Text;
            setting.strExportFormat = cmb_ExportFormat.Text;
            setting.strExportPath = tb_ExportPath.Text;
            setting.dateSearchCondition.bByDateRange = rdb_RangerFromToday.Checked;
            setting.dateSearchCondition.iDateType = cmb_DateType.SelectedIndex;
            DateTime dt_From = new DateTime(dtp_From.Value.Year, dtp_From.Value.Month, dtp_From.Value.Day, dtp_FromTime.Value.Hour,
                    dtp_FromTime.Value.Minute, dtp_FromTime.Value.Second);
            DateTime dt_To = new DateTime(dtp_To.Value.Year, dtp_To.Value.Month, dtp_To.Value.Day, dtp_ToTime.Value.Hour,
                dtp_ToTime.Value.Minute, dtp_ToTime.Value.Second);
            setting.dateSearchCondition.dt_From = dt_From;
            setting.dateSearchCondition.dt_To = dt_To;
            setting.bAddQuotation = ckb_AddSeperater.Checked;
            setting.strExportFileName = tb_FileNameFormat.Text;
            setting.bExportNoRecordUserInfo = ckb_IncludeNoDateUser.Checked;
            setting.bNoHeader = ckb_NoHeader.Checked;

            //*****************************************************************************************************
            // Edit Stephen 2017-10-13
            //*****************************************************************************************************
            DateTime timeRange_From = new DateTime(2000, 1, 1, dtp_TimeRangeFrom.Value.Hour, dtp_TimeRangeFrom.Value.Minute, dtp_TimeRangeFrom.Value.Second);
            DateTime timeRange_To = new DateTime(2000, 1, 1, dtp_TimeRangeTo.Value.Hour, dtp_TimeRangeTo.Value.Minute, dtp_TimeRangeTo.Value.Second);
            setting.dateSearchCondition.timeRange_From = timeRange_From;
            setting.dateSearchCondition.timeRange_To = timeRange_To;
            setting.dateSearchCondition.iDaysAfter = Convert.ToInt32(ud_DaysLater.Value);
            //*****************************************************************************************************
            //*****************************************************************************************************
            
            settingClass.SaveSetting(setting);
        }

        private void LoadSetting()
        {
            setting = settingClass.GetSetting(cmb_Views.Text);
            if (cmb_Views.Text.Length == 0)
                return;
            lstV_ExportColumn.Items.Clear();
            if (setting.lst_RawExportColumn.Count > 0)
            {
                foreach (SelectedColumn col in setting.lst_RawExportColumn)
                {
                    if (col.strColumnName.Length == 0)
                        continue;
                    ListViewItem item = new ListViewItem(col.strColumnName);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[1].Text = col.iCustomLength.ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[2].Text = ReturnShowColumnType(col.strColumnType);
                    lstV_ExportColumn.Items.Add(item);
                }
                lst_SelectedColumn = setting.lst_RawExportColumn;
            }
            if (cmb_DateFormat.Text.Length == 0)
                cmb_DateFormat.SelectedIndex = 0;
            tb_Delimiter.Text = setting.strRawDelimiter;
            tb_ExportPath.Text = setting.strExportPath;
            tb_FileNameFormat.Text = setting.strExportFileName;
            for (int i = 0; i < cmb_ExportFormat.Items.Count; i++)
            {
                if (cmb_ExportFormat.Items[i].ToString() == setting.strExportFormat)
                {
                    cmb_ExportFormat.SelectedIndex = i;
                    break;
                }
            }
            cmb_DateType.SelectedIndex = setting.dateSearchCondition.iDateType;
            dtp_From.Value = setting.dateSearchCondition.dt_From;
            dtp_FromTime.Value = setting.dateSearchCondition.dt_From;
            dtp_To.Value = setting.dateSearchCondition.dt_To;
            dtp_ToTime.Value = setting.dateSearchCondition.dt_To;
            if (setting.dateSearchCondition.bByDateRange == true)
            {
                rdb_RangerFromToday.Checked = true;
                rdb_SpecifyDateRange.Checked = false;
            }
            else
            {
                rdb_RangerFromToday.Checked = false;
                rdb_SpecifyDateRange.Checked = true;
            }

            ckb_IncludeNoDateUser.Checked = setting.bExportNoRecordUserInfo;
            ckb_AddSeperater.Checked = setting.bAddQuotation;
            ckb_NoHeader.Checked = setting.bNoHeader;

            //****************************************************************
            // Edit Stephen 2017-10-13
            //****************************************************************
            dtp_TimeRangeFrom.Value = setting.dateSearchCondition.timeRange_From;
            dtp_TimeRangeTo.Value = setting.dateSearchCondition.timeRange_To;
            ud_DaysLater.Value = setting.dateSearchCondition.iDaysAfter;
            //****************************************************************
        }

        private List<String> LoadViews()
        {
            string SQL = "SHOW FULL TABLES IN ingress WHERE TABLE_TYPE LIKE 'VIEW';";
            List<String> lst_Views = new List<String>();
            try
            {
                //MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //MySqlDataReader myData = cmd.ExecuteReader();
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    MessageBox.Show("No data.");
                else
                {
                    while (myData.Read())
                    {
                        String str = String.Format("{0}", myData.GetString(0));
                        if (str.IndexOf("_null_user") > -1)
                            continue;
                        lst_Views.Add(str);
                    }
                }
                myData.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            foreach (String str in lst_Views)
                cmb_Views.Items.Add(str);

            if (cmb_Views.Items.Count > 0)
            {
                cmb_Views.SelectedIndex = 0;
            }
            return lst_Views;
        }

        private void LoadDBColumn()
        {
            List<DBColumn> lst_Column = new List<DBColumn>();
            
            int iCount = 0;
            string SQL = String.Format("DESCRIBE `{0}`", cmb_Views.Text);
            try
            {
                //MySqlCommand cmd = new MySqlCommand(SQL, conn);
                //MySqlDataReader myData = cmd.ExecuteReader();
                MySqlDataReader myData = GetSqlResult(SQL);

                if (!myData.HasRows)
                    MessageBox.Show("No data.");
                else
                {
                    while (myData.Read())
                    {
                        DBColumn col = new DBColumn();
                        col.strColumnName = String.Format("{0}", myData.GetString(0));
                        col.strColumnType = String.Format("{0}", myData.GetString(1));
                        if (col.strColumnType.IndexOf("(") > -1)
                        {
                            int iStartIndex = col.strColumnType.IndexOf("(");
                            int iEndIndex = col.strColumnType.IndexOf(",") > -1 ? col.strColumnType.IndexOf(",") : col.strColumnType.IndexOf(")");
                            String strTemp = col.strColumnType.Substring(iStartIndex + 1, iEndIndex - iStartIndex - 1);
                            col.iColumnLength = Int32.Parse(strTemp);
                            col.strColumnType = col.strColumnType.Substring(0, iStartIndex);
                        }
                        if (col.strColumnType == "datetime")
                            col.iColumnLength = 19;
                        if (col.strColumnType == "date")
                            col.iColumnLength = 10;
                        if (col.strColumnType == "time")
                            col.iColumnLength = 8;
                        lst_Column.Add(col);
                        lst_FullDBColumn.Add(col);
                        iCount++;
                    }
                }
                myData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            InsertDBColumnToListControl(lst_Column);
        }

        private void InsertDBColumnToListControl(List<DBColumn> lst_Column)
        {
            foreach (DBColumn col in lst_Column)
            {
                String str = "";
                str = String.Format("{0}", col.strColumnName);
                SelectedColumn c = lst_SelectedColumn.Find(delegate (SelectedColumn cc)
                { return cc.strColumnName == col.strColumnName; });

                if (c == null)
                {
                    ListViewItem item = new ListViewItem(str);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[1].Text = col.iColumnLength.ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[2].Text = ReturnShowColumnType(col.strColumnType);
                    lstv_DBColumn.Items.Add(item);
                    lst_DBColumn.Add(col);
                }
            }
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

        private void btn_Pick_Click(object sender, EventArgs e)
        {
            if (lstv_DBColumn.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < lstv_DBColumn.SelectedItems.Count; i++)
            {
                ListViewItem item = lstv_DBColumn.SelectedItems[i];
                if (item == null)
                    return;
                lstv_DBColumn.Items.Remove(item);
                ListViewItem newItem = new ListViewItem(item.Text);
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                newItem.SubItems[1].Text = item.SubItems[1].Text;
                newItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                newItem.SubItems[2].Text = item.SubItems[2].Text;
                lstV_ExportColumn.Items.Add(newItem);
                lst_SelectedColumn.Add(GetSelectedColumnInfoFromList(item.Text));
                i = -1;
            }
        }

        private void btn_Release_Click(object sender, EventArgs e)
        {
            if (lstV_ExportColumn.Items.Count <= 1)
                return;

            for (int i = 0; i < lstV_ExportColumn.SelectedItems.Count; i++)
            {
                ListViewItem item = lstV_ExportColumn.SelectedItems[i];
                lstV_ExportColumn.Items.Remove(item);
                SelectedColumn col = lst_SelectedColumn.Find(delegate(SelectedColumn c)
                    { return c.strColumnName == item.Text; });

                DBColumn dbCol = lst_FullDBColumn.Find(delegate(DBColumn c)
                    { return c.strColumnName == item.Text; });
                if (col == null)
                    return;
                ListViewItem lstv_Item = new ListViewItem(dbCol.strColumnName);
                lstv_Item.SubItems.Add(new ListViewItem.ListViewSubItem());
                lstv_Item.SubItems[1].Text = dbCol.iColumnLength.ToString();
                lstv_Item.SubItems.Add(new ListViewItem.ListViewSubItem());
                lstv_Item.SubItems[2].Text = ReturnShowColumnType(dbCol.strColumnType);

                lstv_DBColumn.Items.Add(lstv_Item);

                lst_SelectedColumn.Remove(col);
                i = -1;
            }
        }

        private SelectedColumn GetSelectedColumnInfoFromList(String strColName)
        {
            SelectedColumn col = new SelectedColumn();
            foreach (DBColumn c in lst_FullDBColumn)
            {
                if (c.strColumnName == strColName)
                {
                    col.iCustomLength = c.iColumnLength;
                    col.strColumnName = c.strColumnName;
                    col.strColumnType = c.strColumnType;
                    if (col.strColumnType == "datetime"||
                        col.strColumnType == "date"||
                        col.strColumnType == "time")
                    {
                        col.dateSetting = new DateColumnFormatSetting();
                        col.dateSetting.strDateFormat = "dd/mm/yyyy";
                        col.dateSetting.bTimeIs24 = true;
                        col.dateSetting.bTimeWithSec = true;
                        col.dateSetting.bHasTime = col.strColumnType == "datetime"?true:false;
                        col.dateSetting.bTimeFillZero = true;
                    }
                }
            }
            return col;
        }

        private void btn_SelectTables_Click(object sender, EventArgs e)
        {
            if (frmSelectTables == null)
            {
                frmSelectTables = new frm_SelectViews();
                frmSelectTables.SetConnection(conn);
                frmSelectTables.SetFrmSetting(this);
            }
            frmSelectTables.Show();
        }

        public void DestroyFrmSelectTable()
        {
            frmSelectTables = null;
        }

        //public void DestroyFrmExportColumnFormatSetting()
        //{
        //    frmCoumnOutputFormat = null;
        //}

        public void UpdateExportColumnFormat(List<SelectedColumn> lst)
        {

        }
        private void tb_Delimiter_TextChanged(object sender, EventArgs e)
        {
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (lstV_ExportColumn.SelectedItems.Count == 0)
                return;
            ListViewItem item = lstV_ExportColumn.SelectedItems[0];
            int index = lstV_ExportColumn.SelectedIndices[0];
            if (index == 0)
                return;
            lstV_ExportColumn.Items.Remove(item);
            lstV_ExportColumn.Items.Insert(index - 1, item);
            lstV_ExportColumn.Items[index - 1].Selected = true;
            SelectedColumn col = lst_SelectedColumn[index];
            lst_SelectedColumn.RemoveAt(index);
            lst_SelectedColumn.Insert(index - 1, col);
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (lstV_ExportColumn.SelectedItems.Count == 0)
                return;
            ListViewItem item = lstV_ExportColumn.SelectedItems[0];
            int index = lstV_ExportColumn.SelectedIndices[0];
            if (index == lstV_ExportColumn.Items.Count - 1)
                return;
            lstV_ExportColumn.Items.Remove(item);
            lstV_ExportColumn.Items.Insert(index + 1, item);
            lstV_ExportColumn.Items[index + 1].Selected = true;
            SelectedColumn col = lst_SelectedColumn[index];
            lst_SelectedColumn.RemoveAt(index);
            lst_SelectedColumn.Insert(index + 1, col);
        }

        private void cmb_Views_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(bInit == false)
                SaveSetting();
            lstv_DBColumn.Items.Clear();
            lst_DBColumn.Clear();
            lst_SelectedColumn.Clear();
            lst_FullDBColumn.Clear();
            LoadSetting();
            if (cmb_Views.Text.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == false)
            {
                dtp_FromTime.Enabled = dtp_ToTime.Enabled = false;
                dtp_FromTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                dtp_ToTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }
            else
            {
                dtp_FromTime.Enabled = dtp_ToTime.Enabled = true;
            }
            LoadDBColumn();
            CheckIsOneDay();
        }

        private void frm_Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.DestroySettingForm();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (bNeedSave == true)
                lstV_ExportColumn_MouseClick(null, null);
            SaveSetting();
            if (ExportValidation() == false)
                return;
            frm_PreviewResult dlgPreview = new frm_PreviewResult();
            int iRecordCount = 0;
            //String str = Export(ref iRecordCount);
            ExportClass export = new ExportClass(cmb_Views.Text);
            iRecordCount = export.Export();
            String str = export.GetExportResult();
            if (str.Length == 0)
            {
                MessageBox.Show("No Data");
                dlgPreview = null;
                return;
            }
            if (ckb_ExportPreview.Checked == true)
            {
                dlgPreview.SetResult(str, iRecordCount, lst_SelectedColumn.Count);
                dlgPreview.Show();
            }
            if (tb_ExportPath.Text.Length > 0 && cmb_ExportFormat.SelectedIndex != -1)
                ExportToFile(str);
        }

        private void ExportToFile(String strContent)
        {
            Directory.CreateDirectory(tb_ExportPath.Text);
            String strFileFullPath = "", strFileName = "", strFileExtenion = "", strDateRange = "";
            strFileExtenion = cmb_ExportFormat.SelectedIndex == 0 ? "txt" : "csv";

            if (rdb_SpecifyDateRange.Checked == true)
            {
                //strDateRange = String.Format("{0}_To_{1}", dtp_From.Value.ToString("yyyyMMdd"), dtp_To.Value.ToString("yyyyMMdd"));
            }

            if (tb_FileNameFormat.Text.Length == 0)
            {
                if (cmb_Views.Text.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == true)
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
                strFileName = tb_FileNameFormat.Text;
                strFileName = strFileName.Replace("%Y", dt_time.Year.ToString("D4"));
                strFileName = strFileName.Replace("%y", dt_time.Year.ToString("D4").Substring(2, 2));
                strFileName = strFileName.Replace("%M", dt_time.Month.ToString("D2"));
                strFileName = strFileName.Replace("%D", dt_time.Day.ToString("D2"));
            }
            
            if (cmb_Views.Text.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == false)
            {
                if (strDateRange.Length > 0)
                    strFileName += "_" + strDateRange; 
            }
            strFileFullPath += tb_ExportPath.Text + "\\" + strFileName + "." + strFileExtenion;
            //Encoding utf8WithoutBom = new UTF8Encoding(false);
            Encoding utf8WithoutBom = new UTF8Encoding(true);////Pat 20160913 中文亂碼
            using (StreamWriter sw = new StreamWriter(strFileFullPath, false, utf8WithoutBom))
            {
                sw.Write(strContent);
                sw.Close();
            }
            MessageBox.Show("Success to Export : " + strFileFullPath);
        }

        private bool ExportValidation()
        {
            if (lstV_ExportColumn.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one column to export.");
                return false;
            }
            if (cmb_ExportFormat.Text.Length == 0)
            {
                MessageBox.Show("Please select export format");
                return false;
            }

            if (tb_ExportPath.Text.Length > 0)
            {
                try
                {
                    Directory.CreateDirectory(tb_ExportPath.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
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
            }catch(Exception ex)
            {
                Connect();
                cmd = new MySqlCommand(strSql, conn);
                myData = cmd.ExecuteReader();
            }
            
            return myData;
        }

        private void ckb_WithTime_CheckedChanged(object sender, EventArgs e)
        {
            bool bEnable = false;
            if (ckb_WithTime.Checked == true)
                bEnable = true;
            ckb_NoTimeFillZero.Enabled = bEnable;
            ckb_NoTimeWithSec.Enabled = bEnable;
            cmb_TimeFormat.Enabled = bEnable;
        }

        private void lstV_ExportColumn_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender == null || e == null)
                return;
            var info = this.lstV_ExportColumn.HitTest(e.Location.X, e.Location.Y);
            if (info.Item == null)
                return;
            int index = info.Item.Index;
            for (int i = 0; i < lstV_ExportColumn.Items.Count;i++ )
                lstV_ExportColumn.Items[i].Selected = false;
            lstV_ExportColumn.Items[index].Selected = true;
            gb_DateColumnFormat.Visible = true;
            bool bIsDate = false;
            if (lst_SelectedColumn[index].strColumnType == "datetime"||
                lst_SelectedColumn[index].strColumnType == "time"||
                lst_SelectedColumn[index].strColumnType == "date")
                bIsDate = true;
            if (lst_SelectedColumn[index].strColumnName == null)
                return;

            EnableIsDateColFormatSetting(bIsDate, lst_SelectedColumn[index].strColumnType);
            if (bIsDate == false)
            {
                if (lst_SelectedColumn[index].strColumnName.IndexOf(" ID") > -1 ||
                    lst_SelectedColumn[index].strColumnName.IndexOf(" No.") > -1)
                    ckb_ColFillZero.Enabled = ckb_FillZeroWithDelimiter.Enabled = true;
                else
                    ckb_ColFillZero.Enabled = ckb_FillZeroWithDelimiter.Enabled = false;
            }
            iColSettingIndex = index;
            LoadColumnFormatSetting();
        }

        private void EnableIsDateColFormatSetting(bool isDateCol, String strColType)
        {
            if (strColType != "")
            {
                cmb_DateFormat.Enabled = cmb_TimeFormat.Enabled =
                    ckb_WithTime.Enabled = ckb_TwoYOnly.Enabled = ckb_OtherDateDelimiter.Enabled =
                    ckb_NoTimeFillZero.Enabled = ckb_NoTimeWithSec.Enabled = ckb_NoDateFillZero.Enabled = isDateCol;

                nud_DataLength.Enabled = ckb_ColTrim.Enabled = ckb_ColFillZero.Enabled = ckb_FillZeroWithDelimiter.Enabled = !isDateCol;

                if (strColType == "date")
                {
                    ckb_NoTimeFillZero.Enabled = ckb_NoTimeWithSec.Enabled = ckb_WithTime.Enabled = cmb_TimeFormat.Enabled = false;
                }
                if (strColType == "time")
                {
                    cmb_DateFormat.Enabled = cmb_TimeFormat.Enabled = ckb_NoDateFillZero.Enabled =
                    ckb_WithTime.Enabled = ckb_TwoYOnly.Enabled = ckb_OtherDateDelimiter.Enabled = false;
                }
            }
            else
            {
                cmb_DateFormat.Enabled = cmb_TimeFormat.Enabled =
                    ckb_WithTime.Enabled = ckb_TwoYOnly.Enabled = ckb_OtherDateDelimiter.Enabled =
                    ckb_NoTimeFillZero.Enabled = ckb_NoTimeWithSec.Enabled = ckb_NoDateFillZero.Enabled = isDateCol;

                nud_DataLength.Enabled = ckb_ColTrim.Enabled = ckb_ColFillZero.Enabled = ckb_FillZeroWithDelimiter.Enabled = isDateCol;
            }
        }

        private void lstV_ExportColumn_MouseClick(object sender, MouseEventArgs e)
        {
            SaveColumnFormatSetting();
            EnableIsDateColFormatSetting(false, "");

            ckb_OtherDateDelimiter.Checked = ckb_NoTimeFillZero.Checked = ckb_NoTimeWithSec.Checked =
                ckb_TwoYOnly.Checked = ckb_WithTime.Checked = ckb_NoDateFillZero.Checked = false;
            ckb_ColTrim.Checked = ckb_ColFillZero.Checked = ckb_FillZeroWithDelimiter.Checked = false;

            cmb_DateFormat.Text = "";
            lstV_ExportColumn_MouseDoubleClick(sender, e);
        }

        private void UpdateExportColumnListOnLayout()
        {
            lstV_ExportColumn.Items.Clear();
            foreach (SelectedColumn col in lst_SelectedColumn)
            {
                ListViewItem item = new ListViewItem(col.strColumnName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[1].Text = col.iCustomLength.ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[2].Text = ReturnShowColumnType(col.strColumnType);
                lstV_ExportColumn.Items.Add(item);
            }
        }

        private void LoadColumnFormatSetting()
        {
            nud_DataLength.Value = lst_SelectedColumn[iColSettingIndex].iCustomLength;
            ckb_ColFillZero.Checked = lst_SelectedColumn[iColSettingIndex].bFillZero;
            ckb_ColTrim.Checked = lst_SelectedColumn[iColSettingIndex].bColTrim;
            ckb_FillZeroWithDelimiter.Checked = lst_SelectedColumn[iColSettingIndex].bFillZeroWithDelimiter;
            if (lst_SelectedColumn[iColSettingIndex].strColumnType == "datetime" ||
                lst_SelectedColumn[iColSettingIndex].strColumnType == "date"||
                lst_SelectedColumn[iColSettingIndex].strColumnType == "time")
            {
                ckb_TwoYOnly.Checked = lst_SelectedColumn[iColSettingIndex].dateSetting.bYearTwoY;
                ckb_WithTime.Checked = lst_SelectedColumn[iColSettingIndex].dateSetting.bHasTime;
                ckb_NoDateFillZero.Checked = !lst_SelectedColumn[iColSettingIndex].dateSetting.bDateFillZero;
                //
                ckb_OtherDateDelimiter.Checked = lst_SelectedColumn[iColSettingIndex].dateSetting.bOtherDelimiter;
                cmb_DateFormat.Text = lst_SelectedColumn[iColSettingIndex].dateSetting.strDateFormat;
                //
                if (ckb_WithTime.Checked == true || lst_SelectedColumn[iColSettingIndex].strColumnType == "time")
                {
                    if (lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeIs24)
                        cmb_TimeFormat.SelectedIndex = 0;
                    else
                        cmb_TimeFormat.SelectedIndex = 1;
                    ckb_NoTimeFillZero.Checked = !lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeFillZero;
                    ckb_NoTimeWithSec.Checked = !lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeWithSec;
                }
                nud_DataLength.Value = lst_SelectedColumn[iColSettingIndex].iCustomLength;
            }
            bNeedSave = true;
        }

        private void SaveColumnFormatSetting()
        {
            if (lst_SelectedColumn.Count == 0 || bNeedSave == false || iColSettingIndex >= lst_SelectedColumn.Count)
                return;
            lst_SelectedColumn[iColSettingIndex].iCustomLength = Int32.Parse(nud_DataLength.Value.ToString());
            lst_SelectedColumn[iColSettingIndex].bFillZero = ckb_ColFillZero.Checked;
            lst_SelectedColumn[iColSettingIndex].bColTrim = ckb_ColTrim.Checked;
            lst_SelectedColumn[iColSettingIndex].bFillZeroWithDelimiter = ckb_FillZeroWithDelimiter.Checked;
            if (lst_SelectedColumn[iColSettingIndex].strColumnType == "datetime"||
                lst_SelectedColumn[iColSettingIndex].strColumnType == "date"||
                lst_SelectedColumn[iColSettingIndex].strColumnType == "time")
            {
                lst_SelectedColumn[iColSettingIndex].dateSetting.bYearTwoY = ckb_TwoYOnly.Checked;
                lst_SelectedColumn[iColSettingIndex].dateSetting.bHasTime = ckb_WithTime.Checked;
                lst_SelectedColumn[iColSettingIndex].dateSetting.bDateFillZero = !ckb_NoDateFillZero.Checked;
                lst_SelectedColumn[iColSettingIndex].dateSetting.bOtherDelimiter = ckb_OtherDateDelimiter.Checked;
                lst_SelectedColumn[iColSettingIndex].dateSetting.strDateFormat = cmb_DateFormat.Text;
                if (ckb_WithTime.Checked == true || lst_SelectedColumn[iColSettingIndex].strColumnType == "time")
                {
                    lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeIs24 = cmb_TimeFormat.SelectedIndex == 0;
                    lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeFillZero = !ckb_NoTimeFillZero.Checked;
                    lst_SelectedColumn[iColSettingIndex].dateSetting.bTimeWithSec = !ckb_NoTimeWithSec.Checked;
                }
                lst_SelectedColumn[iColSettingIndex].iCustomLength = Int32.Parse(nud_DataLength.Value.ToString());
                lst_SelectedColumn[iColSettingIndex].bColTrim = ckb_ColTrim.Checked;
            }
            bNeedSave = false;
        }

        private void cb_DateType_MouseClick(object sender, MouseEventArgs e)
        {
            rdb_SpecifyDateRange.Checked = false;
            rdb_RangerFromToday.Checked = true;
        }

        private void dtp_From_ValueChanged(object sender, EventArgs e)
        {
            rdb_SpecifyDateRange.Checked = true;
            rdb_RangerFromToday.Checked = false;

            if (dtp_To.Value < dtp_From.Value)
                dtp_To.Value = dtp_From.Value;
            CheckIsOneDay();
        }

        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {
            rdb_SpecifyDateRange.Checked = true;
            rdb_RangerFromToday.Checked = false;
            if (dtp_To.Value < dtp_From.Value)
                dtp_From.Value = dtp_To.Value;
            CheckIsOneDay();
        }

        private void CheckIsOneDay()
        {
            TimeSpan duration = dtp_From.Value-dtp_To.Value;
            if (((rdb_RangerFromToday.Checked == false && (Math.Abs(duration.Days) < 1 ))|| 
                (rdb_RangerFromToday.Checked == true && cmb_DateType.SelectedIndex == 0)) 
            && cmb_Views.Text.Equals("Attendance - Data Audit List", StringComparison.OrdinalIgnoreCase) == false)
            {
                ckb_IncludeNoDateUser.Enabled = true;
            }
            else
            {
                ckb_IncludeNoDateUser.Checked = false;
                ckb_IncludeNoDateUser.Enabled = false;
            }
        }

        private void btn_FolderBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            if (dlg.SelectedPath.Length > 0)
                tb_ExportPath.Text = dlg.SelectedPath;
        }

        private void tb_Delimiter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                tb_Delimiter.Text = "<TAB>";
        }

        private String ReturnShowColumnType(String strColType)
        {
            String str = "";
            if (strColType == "varchar")
                str = "Characters";
            if (strColType == "int")
                str = "Numeric";
            if (strColType == "datetime")
                str = "Date Time";
            if (strColType == "date")
                str = "Date";
            if (strColType == "time")
                str = "Time";
            return str;
        }

        private void cmb_ExportFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ExportFormat.SelectedIndex == 1)
            {
                if (tb_Delimiter.Text != ",")
                {
                    if (MessageBox.Show("If delimiter not equal to \",\", the export result to CSV will not be the expected result\r\nDo you want to change delimiter to \",\"?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        tb_Delimiter.Text = ",";
                }
            }
        }

        private void nud_DataLength_Leave(object sender, EventArgs e)
        {
            SaveColumnFormatSetting();
            bNeedSave = true;
            UpdateExportColumnListOnLayout();
        }

        private void rdb_RangerFromToday_Click(object sender, EventArgs e)
        {
            CheckIsOneDay();
        }

        private void rdb_SpecifyDateRange_Click(object sender, EventArgs e)
        {
            CheckIsOneDay();
        }

        private void cmb_DateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIsOneDay();

            //*******************************************************
            // Edit Stephen 2017-10-13
            //*******************************************************
            if (cmb_DateType.SelectedItem.ToString().ToLower() == "today")
                EnableTimeRangeControl(false);
            else
                EnableTimeRangeControl(true);
            //*******************************************************
        }

        //******************************************
        // Edit Stephen 2017-10-13
        //******************************************
        private void EnableTimeRangeControl(bool bEnable)
        {
            lbl_TimeRangeFrom.Visible = bEnable;
            lbl_TimeRangeTo.Visible = bEnable;
            lbl_DaysLater.Visible = bEnable;

            dtp_TimeRangeFrom.Visible = bEnable;
            dtp_TimeRangeTo.Visible = bEnable;
            ud_DaysLater.Visible = bEnable;

        }
        //******************************************
        // Edit Stephen 2017-10-13
        //******************************************
    }
}

class DBColumn
{
    public String strColumnName { get; set; }
    public String strColumnType { get; set; }
    public int iColumnLength { get; set; }
}

public class SelectedColumn
{
    public String strColumnName { get; set; }
    public String strColumnType { get; set; }
    public int iCustomLength { get; set; }
    public bool bFillZero { get; set; }
    public bool bColTrim { get; set; }
    public bool bFillZeroWithDelimiter { get; set; }
    public DateColumnFormatSetting dateSetting { get; set; }
}

public class DateColumnFormatSetting
{
    public String strDateFormat { get; set; }
    public bool bYearTwoY { get; set; }
    public bool bDateFillZero { get; set; }
    public bool bHasTime { get; set; }
    public bool bTimeIs24 { get; set; }
    public bool bTimeWithSec { get; set; }
    public bool bTimeFillZero { get; set; }
    public bool bOtherDelimiter { get; set; }
}

class SearchCondition
{
    public String strColumnName { get; set; }
    public bool bDateCol { get; set; }
    
}