namespace TTI
{
    partial class frm_PreviewResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_Result = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_Result
            // 
            this.rtb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Result.Font = new System.Drawing.Font("細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtb_Result.Location = new System.Drawing.Point(0, 0);
            this.rtb_Result.Name = "rtb_Result";
            this.rtb_Result.ReadOnly = true;
            this.rtb_Result.Size = new System.Drawing.Size(673, 482);
            this.rtb_Result.TabIndex = 0;
            this.rtb_Result.Text = "";
            this.rtb_Result.WordWrap = false;
            // 
            // frm_PreviewResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 482);
            this.Controls.Add(this.rtb_Result);
            this.Name = "frm_PreviewResult";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_PreviewResult_FormClosing);
            this.Load += new System.EventHandler(this.frm_PreviewResult_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Result;
    }
}