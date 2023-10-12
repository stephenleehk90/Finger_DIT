namespace TTI
{
    partial class frm_SelectViews
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
            this.clb_Tables = new System.Windows.Forms.CheckedListBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.ckb_SelectAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clb_Tables
            // 
            this.clb_Tables.CheckOnClick = true;
            this.clb_Tables.FormattingEnabled = true;
            this.clb_Tables.Location = new System.Drawing.Point(13, 13);
            this.clb_Tables.Name = "clb_Tables";
            this.clb_Tables.Size = new System.Drawing.Size(413, 441);
            this.clb_Tables.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(90, 499);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 33);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "Confirm";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(264, 499);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 33);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ckb_SelectAll
            // 
            this.ckb_SelectAll.AutoSize = true;
            this.ckb_SelectAll.Location = new System.Drawing.Point(13, 471);
            this.ckb_SelectAll.Name = "ckb_SelectAll";
            this.ckb_SelectAll.Size = new System.Drawing.Size(87, 22);
            this.ckb_SelectAll.TabIndex = 3;
            this.ckb_SelectAll.Text = "Select All";
            this.ckb_SelectAll.UseVisualStyleBackColor = true;
            this.ckb_SelectAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ckb_SelectAll_MouseClick);
            // 
            // frmSelectTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 534);
            this.Controls.Add(this.ckb_SelectAll);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.clb_Tables);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSelectTables";
            this.Text = "frmSelectTable";
            this.Load += new System.EventHandler(this.frmSelectTables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Tables;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox ckb_SelectAll;

    }
}