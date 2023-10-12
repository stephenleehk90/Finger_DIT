namespace TTI
{
    partial class frm_ImportFile
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
            this.lbl_path = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_folder = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_notic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(13, 13);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(41, 16);
            this.lbl_path.TabIndex = 0;
            this.lbl_path.Text = "Path :";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(16, 33);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(212, 22);
            this.tb_path.TabIndex = 1;
            // 
            // btn_folder
            // 
            this.btn_folder.Location = new System.Drawing.Point(234, 32);
            this.btn_folder.Name = "btn_folder";
            this.btn_folder.Size = new System.Drawing.Size(75, 23);
            this.btn_folder.TabIndex = 2;
            this.btn_folder.Text = "Folder";
            this.btn_folder.UseVisualStyleBackColor = true;
            this.btn_folder.Click += new System.EventHandler(this.btn_folder_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(47, 210);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 3;
            this.btn_import.Text = "Import";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(196, 210);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_notic
            // 
            this.lbl_notic.AutoSize = true;
            this.lbl_notic.Location = new System.Drawing.Point(16, 71);
            this.lbl_notic.Name = "lbl_notic";
            this.lbl_notic.Size = new System.Drawing.Size(12, 16);
            this.lbl_notic.TabIndex = 5;
            this.lbl_notic.Text = "-";
            // 
            // frm_ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 245);
            this.Controls.Add(this.lbl_notic);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_folder);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.lbl_path);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(337, 284);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(337, 284);
            this.Name = "frm_ImportFile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ImportFile_FormClosing);
            this.Load += new System.EventHandler(this.frm_ImportFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_folder;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_notic;
    }
}