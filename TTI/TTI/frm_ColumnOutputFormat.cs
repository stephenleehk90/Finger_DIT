using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTI
{
    public partial class frm_ColumnOutputFormat : Form
    {
        List<SelectedColumn> lst_ExportColumn;
        frm_Setting frmSetting;
        public frm_ColumnOutputFormat()
        {
            InitializeComponent();
            lst_ExportColumn = new List<SelectedColumn>();
        }

        private void frm_ColumnOutputFormat_Load(object sender, EventArgs e)
        {
            ApplyList();
        }

        public void SetFrmMain(frm_Setting frmSetting)
        {
            this.frmSetting = frmSetting;
        }

        public void SetExportColumnList(List<SelectedColumn> lst_ExportColumn)
        {
            this.lst_ExportColumn = lst_ExportColumn;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            frmSetting.UpdateExportColumnFormat(lst_ExportColumn);
        }

        private void ApplyList()
        {
            foreach (SelectedColumn col in lst_ExportColumn)
            {
                lbc_ExportCol.Items.Add(col.strColumnName);
            }
        }

        private void lbc_ExportCol_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = lbc_ExportCol.SelectedIndex;
            lb_DataType.Text = lst_ExportColumn[index].strColumnType;
            nud_DataLength.Value = lst_ExportColumn[index].iCustomLength;

        }

        private void nud_DataLength_VisibleChanged(object sender, EventArgs e)
        {
            int index = lbc_ExportCol.SelectedIndex;
            lst_ExportColumn[index].iCustomLength = Int32.Parse(nud_DataLength.Value.ToString());
        }

        private void frm_ColumnOutputFormat_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmSetting.DestroyFrmExportColumnFormatSetting();
        }
    }
}
