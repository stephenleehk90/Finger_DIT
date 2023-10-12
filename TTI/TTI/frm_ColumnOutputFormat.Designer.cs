namespace TTI
{
    partial class frm_ColumnOutputFormat
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
            this.lbc_ExportCol = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.nud_DataLength = new System.Windows.Forms.NumericUpDown();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_DataType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DataLength)).BeginInit();
            this.SuspendLayout();
            // 
            // lbc_ExportCol
            // 
            this.lbc_ExportCol.FormattingEnabled = true;
            this.lbc_ExportCol.ItemHeight = 18;
            this.lbc_ExportCol.Location = new System.Drawing.Point(20, 36);
            this.lbc_ExportCol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbc_ExportCol.Name = "lbc_ExportCol";
            this.lbc_ExportCol.Size = new System.Drawing.Size(255, 220);
            this.lbc_ExportCol.TabIndex = 0;
            this.lbc_ExportCol.SelectedValueChanged += new System.EventHandler(this.lbc_ExportCol_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Length:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(298, 138);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 22);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Fill Zero";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // nud_DataLength
            // 
            this.nud_DataLength.Location = new System.Drawing.Point(298, 91);
            this.nud_DataLength.Name = "nud_DataLength";
            this.nud_DataLength.Size = new System.Drawing.Size(120, 24);
            this.nud_DataLength.TabIndex = 4;
            this.nud_DataLength.VisibleChanged += new System.EventHandler(this.nud_DataLength_VisibleChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(342, 225);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 31);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(342, 177);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 31);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Type:";
            // 
            // lb_DataType
            // 
            this.lb_DataType.AutoSize = true;
            this.lb_DataType.Location = new System.Drawing.Point(295, 36);
            this.lb_DataType.Name = "lb_DataType";
            this.lb_DataType.Size = new System.Drawing.Size(0, 18);
            this.lb_DataType.TabIndex = 8;
            // 
            // frm_ColumnOutputFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 274);
            this.Controls.Add(this.lb_DataType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.nud_DataLength);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbc_ExportCol);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_ColumnOutputFormat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ColumnOutputFormat_FormClosing);
            this.Load += new System.EventHandler(this.frm_ColumnOutputFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_DataLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbc_ExportCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown nud_DataLength;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_DataType;
    }
}