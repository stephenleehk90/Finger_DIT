namespace TTI
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInfoImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToSurveillamceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.userInfoImportToolStripMenuItem,
            this.verifyToolStripMenuItem,
            this.uploadCSVToolStripMenuItem,
            this.exportToSurveillamceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1272, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionSettingToolStripMenuItem,
            this.webServiceToolStripMenuItem,
            this.scheduleToolStripMenuItem});
            this.settingToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // connectionSettingToolStripMenuItem
            // 
            this.connectionSettingToolStripMenuItem.Name = "connectionSettingToolStripMenuItem";
            this.connectionSettingToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.connectionSettingToolStripMenuItem.Text = "Connection";
            this.connectionSettingToolStripMenuItem.Click += new System.EventHandler(this.connectionSettingToolStripMenuItem_Click);
            // 
            // webServiceToolStripMenuItem
            // 
            this.webServiceToolStripMenuItem.Name = "webServiceToolStripMenuItem";
            this.webServiceToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.webServiceToolStripMenuItem.Text = "Web Service";
            this.webServiceToolStripMenuItem.Click += new System.EventHandler(this.webServiceToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            this.scheduleToolStripMenuItem.Visible = false;
            this.scheduleToolStripMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.exportToolStripMenuItem.Text = "Data Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // userInfoImportToolStripMenuItem
            // 
            this.userInfoImportToolStripMenuItem.Name = "userInfoImportToolStripMenuItem";
            this.userInfoImportToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.userInfoImportToolStripMenuItem.Text = "User Info Import";
            this.userInfoImportToolStripMenuItem.Click += new System.EventHandler(this.userInfoImportToolStripMenuItem_Click);
            // 
            // verifyToolStripMenuItem
            // 
            this.verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
            this.verifyToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.verifyToolStripMenuItem.Text = "Verify";
            this.verifyToolStripMenuItem.Visible = false;
            this.verifyToolStripMenuItem.Click += new System.EventHandler(this.verifyToolStripMenuItem_Click);
            // 
            // uploadCSVToolStripMenuItem
            // 
            this.uploadCSVToolStripMenuItem.Name = "uploadCSVToolStripMenuItem";
            this.uploadCSVToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.uploadCSVToolStripMenuItem.Text = "Upload CSV";
            this.uploadCSVToolStripMenuItem.Visible = false;
            this.uploadCSVToolStripMenuItem.Click += new System.EventHandler(this.uploadCSVToolStripMenuItem_Click);
            // 
            // exportToSurveillamceToolStripMenuItem
            // 
            this.exportToSurveillamceToolStripMenuItem.Name = "exportToSurveillamceToolStripMenuItem";
            this.exportToSurveillamceToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.exportToSurveillamceToolStripMenuItem.Text = "Export To Surveillamce";
            this.exportToSurveillamceToolStripMenuItem.Visible = false;
            this.exportToSurveillamceToolStripMenuItem.Click += new System.EventHandler(this.exportToSurveillamceToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "FingerTec - Data Integration Tool v1.0";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 773);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerTec - Data Integration Tool v1.4.1";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.Resize += new System.EventHandler(this.frm_Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInfoImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToSurveillamceToolStripMenuItem;
    }
}

