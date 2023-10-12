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

namespace TTI
{
    public partial class frm_SelectViews : Form
    {
        MySqlConnection conn;
        List<String> lst_SelectedViews;
        frm_Setting frmSetting;
        public frm_SelectViews()
        {
            InitializeComponent(); 
            lst_SelectedViews = new List<String>();
        }

        public void SetFrmSetting(frm_Setting frmSetting)
        {
            this.frmSetting = frmSetting;
        }

        public void SetConnection(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public void SetSelectedViewsList(List<String> lst_SelectedViews)
        {
            this.lst_SelectedViews = new List<String>();
            for (int i = 0; i < lst_SelectedViews.Count; i++)
                {
                    String strNew = "";
                    strNew = lst_SelectedViews[i];
                    this.lst_SelectedViews.Add(strNew);
                }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            frmSetting.DestroyFrmSelectTable();
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            BuildSelectedViews();
            frmSetting.DestroyFrmSelectTable();
            this.Close();
        }

        private void BuildSelectedViews()
        {
            lst_SelectedViews.Clear();
            for (int i = 0; i < clb_Tables.CheckedItems.Count; i++)
            {
                lst_SelectedViews.Add(clb_Tables.CheckedItems[i].ToString());
            }
        }

        private void frmSelectTables_Load(object sender, EventArgs e)
        {
            LoadViews();
        }

        private void LoadViews()
        {
            string SQL = "SHOW FULL TABLES IN ingress WHERE TABLE_TYPE LIKE 'VIEW';";
            List<String> lst_Views = new List<String>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataReader myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                    MessageBox.Show("No data.");
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
            foreach (String strTable in lst_Views)
            {
                bool bCheck = false, bAllCheck = true;
                if (lst_SelectedViews.Count == 0)
                    bCheck = true;
                else
                {
                    String str = lst_SelectedViews.Find(delegate(String s) { return s == strTable; });
                    if (str != null)
                        bCheck = true;
                }
                clb_Tables.Items.Add(strTable, bCheck);
                if (bCheck == false)
                    bAllCheck = false;
                ckb_SelectAll.Checked = bAllCheck;
            }
        }

        private void ckb_SelectAll_MouseClick(object sender, MouseEventArgs e)
        {
            bool bSelectAll = ckb_SelectAll.Checked;
            for (int i = 0; i < clb_Tables.Items.Count; i++)
            {
                clb_Tables.SetItemChecked(i, bSelectAll);
            }
        }
    }
}
