namespace TTI
{
    partial class frm_SerialKey
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
            this.tb_ClientKey = new System.Windows.Forms.TextBox();
            this.tb_SerialKey = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lb_Path = new System.Windows.Forms.Label();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please use the Client Key";
            // 
            // tb_ClientKey
            // 
            this.tb_ClientKey.Location = new System.Drawing.Point(24, 53);
            this.tb_ClientKey.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ClientKey.Name = "tb_ClientKey";
            this.tb_ClientKey.ReadOnly = true;
            this.tb_ClientKey.Size = new System.Drawing.Size(490, 24);
            this.tb_ClientKey.TabIndex = 1;
            this.tb_ClientKey.Visible = false;
            this.tb_ClientKey.WordWrap = false;
            // 
            // tb_SerialKey
            // 
            this.tb_SerialKey.Location = new System.Drawing.Point(24, 144);
            this.tb_SerialKey.Margin = new System.Windows.Forms.Padding(4);
            this.tb_SerialKey.Name = "tb_SerialKey";
            this.tb_SerialKey.Size = new System.Drawing.Size(490, 24);
            this.tb_SerialKey.TabIndex = 2;
            this.tb_SerialKey.Visible = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(231, 184);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 32);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(24, 85);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(112, 32);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lb_Path
            // 
            this.lb_Path.AutoSize = true;
            this.lb_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Path.Location = new System.Drawing.Point(21, 43);
            this.lb_Path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Path.Name = "lb_Path";
            this.lb_Path.Size = new System.Drawing.Size(221, 18);
            this.lb_Path.TabIndex = 5;
            this.lb_Path.Text = "Please Select the serial key:";
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(342, 184);
            this.btn_Copy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(221, 32);
            this.btn_Copy.TabIndex = 6;
            this.btn_Copy.Text = "Export Key File";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Visible = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(351, 166);
            this.btn_Import.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(221, 32);
            this.btn_Import.TabIndex = 7;
            this.btn_Import.Text = "Import Serial Key File";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Visible = false;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "to get the Serial Key and put it in current folder for activation";
            // 
            // frm_SerialKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 221);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lb_Path);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tb_SerialKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ClientKey);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SerialKey";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SerialKey_FormClosing);
            this.Load += new System.EventHandler(this.frm_SerialKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ClientKey;
        private System.Windows.Forms.TextBox tb_SerialKey;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lb_Path;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Label label3;
    }
}