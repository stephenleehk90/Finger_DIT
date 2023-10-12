namespace TTI
{
    partial class frm_UserInfoImport
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
            this.lbl_selectFile = new System.Windows.Forms.Label();
            this.tb_file = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_alert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_selectFile
            // 
            this.lbl_selectFile.AutoSize = true;
            this.lbl_selectFile.Location = new System.Drawing.Point(12, 18);
            this.lbl_selectFile.Name = "lbl_selectFile";
            this.lbl_selectFile.Size = new System.Drawing.Size(80, 16);
            this.lbl_selectFile.TabIndex = 0;
            this.lbl_selectFile.Text = "Select File : ";
            // 
            // tb_file
            // 
            this.tb_file.Location = new System.Drawing.Point(98, 15);
            this.tb_file.Name = "tb_file";
            this.tb_file.ReadOnly = true;
            this.tb_file.Size = new System.Drawing.Size(593, 22);
            this.tb_file.TabIndex = 1;
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(697, 15);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Location = new System.Drawing.Point(12, 54);
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.ReadOnly = true;
            this.dgvUserInfo.Size = new System.Drawing.Size(760, 355);
            this.dgvUserInfo.TabIndex = 3;
            // 
            // btn_import
            // 
            this.btn_import.Enabled = false;
            this.btn_import.Location = new System.Drawing.Point(564, 426);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 4;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(697, 426);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_alert
            // 
            this.lbl_alert.AutoSize = true;
            this.lbl_alert.Location = new System.Drawing.Point(12, 429);
            this.lbl_alert.Name = "lbl_alert";
            this.lbl_alert.Size = new System.Drawing.Size(398, 16);
            this.lbl_alert.TabIndex = 6;
            this.lbl_alert.Text = "*If no data, please confirm the file contains a sheet calling \'Sheet1\'.";
            this.lbl_alert.Visible = false;
            // 
            // frm_UserInfoImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lbl_alert);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.dgvUserInfo);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_file);
            this.Controls.Add(this.lbl_selectFile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frm_UserInfoImport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info Import";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_UserInfoImport_FormClosing);
            this.Load += new System.EventHandler(this.frm_UserInfoImport_Load);
            this.Resize += new System.EventHandler(this.frm_UserInfoImport_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_selectFile;
        private System.Windows.Forms.TextBox tb_file;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_alert;
    }
}