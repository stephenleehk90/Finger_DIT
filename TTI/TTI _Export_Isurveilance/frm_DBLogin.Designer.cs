namespace TTI
{
    partial class frm_DBLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.tb_Server = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.ckb_Port = new System.Windows.Forms.CheckBox();
            this.tb_Database = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(43, 208);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(89, 37);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "OK";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(206, 208);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 37);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(127, 135);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(168, 22);
            this.tb_Password.TabIndex = 5;
            this.tb_Password.Leave += new System.EventHandler(this.tb_Password_Leave);
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(127, 98);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(168, 22);
            this.tb_UserName.TabIndex = 4;
            this.tb_UserName.Leave += new System.EventHandler(this.tb_UserName_Leave);
            // 
            // tb_Server
            // 
            this.tb_Server.Location = new System.Drawing.Point(127, 21);
            this.tb_Server.Name = "tb_Server";
            this.tb_Server.Size = new System.Drawing.Size(168, 22);
            this.tb_Server.TabIndex = 1;
            this.tb_Server.Leave += new System.EventHandler(this.tb_Server_Leave);
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(127, 60);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(168, 22);
            this.tb_Port.TabIndex = 3;
            // 
            // ckb_Port
            // 
            this.ckb_Port.AutoSize = true;
            this.ckb_Port.Location = new System.Drawing.Point(15, 60);
            this.ckb_Port.Name = "ckb_Port";
            this.ckb_Port.Size = new System.Drawing.Size(104, 20);
            this.ckb_Port.TabIndex = 2;
            this.ckb_Port.Text = "Change Port:";
            this.ckb_Port.UseVisualStyleBackColor = true;
            this.ckb_Port.CheckedChanged += new System.EventHandler(this.ckb_Port_CheckedChanged);
            // 
            // tb_Database
            // 
            this.tb_Database.Location = new System.Drawing.Point(127, 172);
            this.tb_Database.Name = "tb_Database";
            this.tb_Database.Size = new System.Drawing.Size(168, 22);
            this.tb_Database.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Database:";
            // 
            // frm_DBLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 257);
            this.Controls.Add(this.tb_Database);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckb_Port);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.tb_Server);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 284);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 284);
            this.Name = "frm_DBLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_DBLogin_FormClosing);
            this.Load += new System.EventHandler(this.DBLogin_Load);
            this.Shown += new System.EventHandler(this.frm_DBLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.TextBox tb_Server;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.CheckBox ckb_Port;
        private System.Windows.Forms.TextBox tb_Database;
        private System.Windows.Forms.Label label4;
    }
}