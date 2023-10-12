using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTI
{
    public partial class frm_PreviewResult : Form
    {
        String strResult;
        int iReocrdCount, iColumnCount;
        public frm_PreviewResult()
        {
            InitializeComponent();
            strResult = "";
        }

        private void frm_PreviewResult_Load(object sender, EventArgs e)
        {
            rtb_Result.Text = strResult;
            this.Text = String.Format("{0} rows, {1} columns",iReocrdCount.ToString(), iColumnCount.ToString());
        }

        public void SetResult(String strResult, int iReocrdCount, int iColumnCount)
        {
            this.iColumnCount = iColumnCount;
            this.iReocrdCount = iReocrdCount;
            this.strResult = strResult;
        }

        private void frm_PreviewResult_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
