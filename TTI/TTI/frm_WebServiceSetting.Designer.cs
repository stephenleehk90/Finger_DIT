namespace TTI
{
    partial class frm_WebServiceSetting
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
            this.lbl_hostName = new System.Windows.Forms.Label();
            this.tb_hostName = new System.Windows.Forms.TextBox();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.lbl_CompanyID = new System.Windows.Forms.Label();
            this.tb_companyID = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_moduleKey = new System.Windows.Forms.Label();
            this.tb_moduleKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_hostName
            // 
            this.lbl_hostName.AutoSize = true;
            this.lbl_hostName.Location = new System.Drawing.Point(12, 24);
            this.lbl_hostName.Name = "lbl_hostName";
            this.lbl_hostName.Size = new System.Drawing.Size(82, 16);
            this.lbl_hostName.TabIndex = 0;
            this.lbl_hostName.Text = "Host Name :";
            // 
            // tb_hostName
            // 
            this.tb_hostName.Location = new System.Drawing.Point(127, 21);
            this.tb_hostName.Name = "tb_hostName";
            this.tb_hostName.Size = new System.Drawing.Size(168, 22);
            this.tb_hostName.TabIndex = 1;
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(12, 64);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(83, 16);
            this.lbl_userName.TabIndex = 2;
            this.lbl_userName.Text = "User Name :";
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(127, 61);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(168, 22);
            this.tb_userName.TabIndex = 3;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(12, 104);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(74, 16);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "Password :";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(127, 101);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(168, 22);
            this.tb_password.TabIndex = 5;
            // 
            // lbl_CompanyID
            // 
            this.lbl_CompanyID.AutoSize = true;
            this.lbl_CompanyID.Location = new System.Drawing.Point(12, 144);
            this.lbl_CompanyID.Name = "lbl_CompanyID";
            this.lbl_CompanyID.Size = new System.Drawing.Size(88, 16);
            this.lbl_CompanyID.TabIndex = 6;
            this.lbl_CompanyID.Text = "Company ID :";
            // 
            // tb_companyID
            // 
            this.tb_companyID.Location = new System.Drawing.Point(127, 141);
            this.tb_companyID.Name = "tb_companyID";
            this.tb_companyID.Size = new System.Drawing.Size(168, 22);
            this.tb_companyID.TabIndex = 7;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(198, 232);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 37);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(35, 232);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(89, 37);
            this.btn_Save.TabIndex = 12;
            this.btn_Save.Text = "OK";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_moduleKey
            // 
            this.lbl_moduleKey.AutoSize = true;
            this.lbl_moduleKey.Location = new System.Drawing.Point(12, 184);
            this.lbl_moduleKey.Name = "lbl_moduleKey";
            this.lbl_moduleKey.Size = new System.Drawing.Size(85, 16);
            this.lbl_moduleKey.TabIndex = 11;
            this.lbl_moduleKey.Text = "Module Key :";
            // 
            // tb_moduleKey
            // 
            this.tb_moduleKey.Location = new System.Drawing.Point(127, 181);
            this.tb_moduleKey.Name = "tb_moduleKey";
            this.tb_moduleKey.Size = new System.Drawing.Size(168, 22);
            this.tb_moduleKey.TabIndex = 9;
            // 
            // frm_WebServiceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 281);
            this.Controls.Add(this.tb_moduleKey);
            this.Controls.Add(this.lbl_moduleKey);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.tb_companyID);
            this.Controls.Add(this.lbl_CompanyID);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.tb_hostName);
            this.Controls.Add(this.lbl_hostName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 320);
            this.Name = "frm_WebServiceSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Service Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_WebServiceSetting_FormClosing);
            this.Load += new System.EventHandler(this.frm_WebServiceSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_hostName;
        private System.Windows.Forms.TextBox tb_hostName;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lbl_CompanyID;
        private System.Windows.Forms.TextBox tb_companyID;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_moduleKey;
        private System.Windows.Forms.TextBox tb_moduleKey;
    }
}