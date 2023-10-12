namespace TTI
{
    partial class frm_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Setting));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.tb_ExportPath = new System.Windows.Forms.TextBox();
            this.btn_FolderBrowse = new System.Windows.Forms.Button();
            this.ckb_ExportPreview = new System.Windows.Forms.CheckBox();
            this.gb_DateSearchCondition = new System.Windows.Forms.GroupBox();
            this.dtp_TimeRangeTo = new System.Windows.Forms.DateTimePicker();
            this.lbl_DaysLater = new System.Windows.Forms.Label();
            this.ud_DaysLater = new System.Windows.Forms.NumericUpDown();
            this.lbl_TimeRangeTo = new System.Windows.Forms.Label();
            this.dtp_TimeRangeFrom = new System.Windows.Forms.DateTimePicker();
            this.lbl_TimeRangeFrom = new System.Windows.Forms.Label();
            this.dtp_ToTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_FromTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.cmb_DateType = new System.Windows.Forms.ComboBox();
            this.rdb_SpecifyDateRange = new System.Windows.Forms.RadioButton();
            this.rdb_RangerFromToday = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_SelectRow = new System.Windows.Forms.NumericUpDown();
            this.ckb_Testing = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckb_NoHeader = new System.Windows.Forms.CheckBox();
            this.ckb_AddSeperater = new System.Windows.Forms.CheckBox();
            this.lstV_ExportColumn = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstv_DBColumn = new System.Windows.Forms.ListView();
            this.ch_ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_ColumnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_ColumnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gb_DateColumnFormat = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckb_FillZeroWithDelimiter = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_TimeFormat = new System.Windows.Forms.ComboBox();
            this.ckb_NoTimeFillZero = new System.Windows.Forms.CheckBox();
            this.ckb_NoTimeWithSec = new System.Windows.Forms.CheckBox();
            this.ckb_OtherDateDelimiter = new System.Windows.Forms.CheckBox();
            this.ckb_ColTrim = new System.Windows.Forms.CheckBox();
            this.ckb_ColFillZero = new System.Windows.Forms.CheckBox();
            this.nud_DataLength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_DateFormat = new System.Windows.Forms.ComboBox();
            this.ckb_NoDateFillZero = new System.Windows.Forms.CheckBox();
            this.ckb_WithTime = new System.Windows.Forms.CheckBox();
            this.ckb_TwoYOnly = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.tb_Delimiter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Release = new System.Windows.Forms.Button();
            this.btn_Pick = new System.Windows.Forms.Button();
            this.btn_SelectTables = new System.Windows.Forms.Button();
            this.btn_ExportColumnFormat = new System.Windows.Forms.Button();
            this.cmb_Views = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_FileNameFormat = new System.Windows.Forms.TextBox();
            this.cmb_ExportFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckb_IncludeNoDateUser = new System.Windows.Forms.CheckBox();
            this.gb_DateSearchCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DaysLater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectRow)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb_DateColumnFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DataLength)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(13, 594);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 32);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "Save Setting";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.Location = new System.Drawing.Point(540, 594);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(125, 32);
            this.btn_Export.TabIndex = 22;
            this.btn_Export.Text = "OK";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // tb_ExportPath
            // 
            this.tb_ExportPath.Location = new System.Drawing.Point(103, 548);
            this.tb_ExportPath.Name = "tb_ExportPath";
            this.tb_ExportPath.Size = new System.Drawing.Size(346, 24);
            this.tb_ExportPath.TabIndex = 24;
            // 
            // btn_FolderBrowse
            // 
            this.btn_FolderBrowse.Location = new System.Drawing.Point(13, 543);
            this.btn_FolderBrowse.Name = "btn_FolderBrowse";
            this.btn_FolderBrowse.Size = new System.Drawing.Size(84, 32);
            this.btn_FolderBrowse.TabIndex = 25;
            this.btn_FolderBrowse.Text = "Folder";
            this.btn_FolderBrowse.UseVisualStyleBackColor = true;
            this.btn_FolderBrowse.Click += new System.EventHandler(this.btn_FolderBrowse_Click);
            // 
            // ckb_ExportPreview
            // 
            this.ckb_ExportPreview.AutoSize = true;
            this.ckb_ExportPreview.Location = new System.Drawing.Point(700, 600);
            this.ckb_ExportPreview.Name = "ckb_ExportPreview";
            this.ckb_ExportPreview.Size = new System.Drawing.Size(93, 22);
            this.ckb_ExportPreview.TabIndex = 27;
            this.ckb_ExportPreview.Text = "View Data";
            this.ckb_ExportPreview.UseVisualStyleBackColor = true;
            // 
            // gb_DateSearchCondition
            // 
            this.gb_DateSearchCondition.Controls.Add(this.dtp_TimeRangeTo);
            this.gb_DateSearchCondition.Controls.Add(this.lbl_DaysLater);
            this.gb_DateSearchCondition.Controls.Add(this.ud_DaysLater);
            this.gb_DateSearchCondition.Controls.Add(this.lbl_TimeRangeTo);
            this.gb_DateSearchCondition.Controls.Add(this.dtp_TimeRangeFrom);
            this.gb_DateSearchCondition.Controls.Add(this.lbl_TimeRangeFrom);
            this.gb_DateSearchCondition.Controls.Add(this.dtp_ToTime);
            this.gb_DateSearchCondition.Controls.Add(this.dtp_FromTime);
            this.gb_DateSearchCondition.Controls.Add(this.dtp_To);
            this.gb_DateSearchCondition.Controls.Add(this.label6);
            this.gb_DateSearchCondition.Controls.Add(this.dtp_From);
            this.gb_DateSearchCondition.Controls.Add(this.cmb_DateType);
            this.gb_DateSearchCondition.Controls.Add(this.rdb_SpecifyDateRange);
            this.gb_DateSearchCondition.Controls.Add(this.rdb_RangerFromToday);
            this.gb_DateSearchCondition.Controls.Add(this.label5);
            this.gb_DateSearchCondition.Location = new System.Drawing.Point(13, 430);
            this.gb_DateSearchCondition.Name = "gb_DateSearchCondition";
            this.gb_DateSearchCondition.Size = new System.Drawing.Size(808, 89);
            this.gb_DateSearchCondition.TabIndex = 51;
            this.gb_DateSearchCondition.TabStop = false;
            this.gb_DateSearchCondition.Text = "Condition";
            // 
            // dtp_TimeRangeTo
            // 
            this.dtp_TimeRangeTo.CustomFormat = "HH:mm:ss";
            this.dtp_TimeRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeRangeTo.Location = new System.Drawing.Point(643, 18);
            this.dtp_TimeRangeTo.Name = "dtp_TimeRangeTo";
            this.dtp_TimeRangeTo.ShowUpDown = true;
            this.dtp_TimeRangeTo.Size = new System.Drawing.Size(83, 24);
            this.dtp_TimeRangeTo.TabIndex = 36;
            this.dtp_TimeRangeTo.Value = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
            // 
            // lbl_DaysLater
            // 
            this.lbl_DaysLater.AutoSize = true;
            this.lbl_DaysLater.Location = new System.Drawing.Point(560, 21);
            this.lbl_DaysLater.Name = "lbl_DaysLater";
            this.lbl_DaysLater.Size = new System.Drawing.Size(74, 18);
            this.lbl_DaysLater.TabIndex = 35;
            this.lbl_DaysLater.Text = "Days later";
            // 
            // ud_DaysLater
            // 
            this.ud_DaysLater.Location = new System.Drawing.Point(508, 19);
            this.ud_DaysLater.Name = "ud_DaysLater";
            this.ud_DaysLater.Size = new System.Drawing.Size(42, 24);
            this.ud_DaysLater.TabIndex = 34;
            this.ud_DaysLater.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_TimeRangeTo
            // 
            this.lbl_TimeRangeTo.AutoSize = true;
            this.lbl_TimeRangeTo.Location = new System.Drawing.Point(471, 21);
            this.lbl_TimeRangeTo.Name = "lbl_TimeRangeTo";
            this.lbl_TimeRangeTo.Size = new System.Drawing.Size(30, 18);
            this.lbl_TimeRangeTo.TabIndex = 33;
            this.lbl_TimeRangeTo.Text = "To:";
            // 
            // dtp_TimeRangeFrom
            // 
            this.dtp_TimeRangeFrom.CustomFormat = "HH:mm:ss";
            this.dtp_TimeRangeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeRangeFrom.Location = new System.Drawing.Point(377, 19);
            this.dtp_TimeRangeFrom.Name = "dtp_TimeRangeFrom";
            this.dtp_TimeRangeFrom.ShowUpDown = true;
            this.dtp_TimeRangeFrom.Size = new System.Drawing.Size(83, 24);
            this.dtp_TimeRangeFrom.TabIndex = 32;
            this.dtp_TimeRangeFrom.Value = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
            // 
            // lbl_TimeRangeFrom
            // 
            this.lbl_TimeRangeFrom.AutoSize = true;
            this.lbl_TimeRangeFrom.Location = new System.Drawing.Point(319, 21);
            this.lbl_TimeRangeFrom.Name = "lbl_TimeRangeFrom";
            this.lbl_TimeRangeFrom.Size = new System.Drawing.Size(48, 18);
            this.lbl_TimeRangeFrom.TabIndex = 31;
            this.lbl_TimeRangeFrom.Text = "From:";
            // 
            // dtp_ToTime
            // 
            this.dtp_ToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_ToTime.Location = new System.Drawing.Point(584, 48);
            this.dtp_ToTime.Name = "dtp_ToTime";
            this.dtp_ToTime.ShowUpDown = true;
            this.dtp_ToTime.Size = new System.Drawing.Size(112, 24);
            this.dtp_ToTime.TabIndex = 30;
            // 
            // dtp_FromTime
            // 
            this.dtp_FromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_FromTime.Location = new System.Drawing.Point(308, 48);
            this.dtp_FromTime.Name = "dtp_FromTime";
            this.dtp_FromTime.ShowUpDown = true;
            this.dtp_FromTime.Size = new System.Drawing.Size(116, 24);
            this.dtp_FromTime.TabIndex = 29;
            // 
            // dtp_To
            // 
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_To.Location = new System.Drawing.Point(469, 48);
            this.dtp_To.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(112, 24);
            this.dtp_To.TabIndex = 28;
            this.dtp_To.ValueChanged += new System.EventHandler(this.dtp_To_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "To:";
            // 
            // dtp_From
            // 
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_From.Location = new System.Drawing.Point(185, 48);
            this.dtp_From.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(116, 24);
            this.dtp_From.TabIndex = 26;
            this.dtp_From.ValueChanged += new System.EventHandler(this.dtp_From_ValueChanged);
            // 
            // cmb_DateType
            // 
            this.cmb_DateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DateType.FormattingEnabled = true;
            this.cmb_DateType.Items.AddRange(new object[] {
            "Yesterday",
            "Last Week",
            "Last Month",
            "Last 3 Month",
            "Last 6 Month",
            "Last Year",
            "Today"});
            this.cmb_DateType.Location = new System.Drawing.Point(143, 19);
            this.cmb_DateType.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DateType.Name = "cmb_DateType";
            this.cmb_DateType.Size = new System.Drawing.Size(158, 26);
            this.cmb_DateType.TabIndex = 25;
            this.cmb_DateType.SelectedIndexChanged += new System.EventHandler(this.cmb_DateType_SelectedIndexChanged);
            this.cmb_DateType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cb_DateType_MouseClick);
            // 
            // rdb_SpecifyDateRange
            // 
            this.rdb_SpecifyDateRange.AutoSize = true;
            this.rdb_SpecifyDateRange.Location = new System.Drawing.Point(121, 49);
            this.rdb_SpecifyDateRange.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_SpecifyDateRange.Name = "rdb_SpecifyDateRange";
            this.rdb_SpecifyDateRange.Size = new System.Drawing.Size(66, 22);
            this.rdb_SpecifyDateRange.TabIndex = 24;
            this.rdb_SpecifyDateRange.TabStop = true;
            this.rdb_SpecifyDateRange.Text = "From:";
            this.rdb_SpecifyDateRange.UseVisualStyleBackColor = true;
            this.rdb_SpecifyDateRange.Click += new System.EventHandler(this.rdb_SpecifyDateRange_Click);
            // 
            // rdb_RangerFromToday
            // 
            this.rdb_RangerFromToday.AutoSize = true;
            this.rdb_RangerFromToday.Location = new System.Drawing.Point(121, 26);
            this.rdb_RangerFromToday.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_RangerFromToday.Name = "rdb_RangerFromToday";
            this.rdb_RangerFromToday.Size = new System.Drawing.Size(14, 13);
            this.rdb_RangerFromToday.TabIndex = 23;
            this.rdb_RangerFromToday.TabStop = true;
            this.rdb_RangerFromToday.UseVisualStyleBackColor = true;
            this.rdb_RangerFromToday.Click += new System.EventHandler(this.rdb_RangerFromToday_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "Clocking Time:";
            // 
            // nud_SelectRow
            // 
            this.nud_SelectRow.Location = new System.Drawing.Point(295, 521);
            this.nud_SelectRow.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nud_SelectRow.Name = "nud_SelectRow";
            this.nud_SelectRow.Size = new System.Drawing.Size(197, 24);
            this.nud_SelectRow.TabIndex = 50;
            this.nud_SelectRow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_SelectRow.Visible = false;
            // 
            // ckb_Testing
            // 
            this.ckb_Testing.AutoSize = true;
            this.ckb_Testing.Location = new System.Drawing.Point(13, 520);
            this.ckb_Testing.Name = "ckb_Testing";
            this.ckb_Testing.Size = new System.Drawing.Size(280, 22);
            this.ckb_Testing.TabIndex = 49;
            this.ckb_Testing.Text = "Export X row of result:(for testing only)";
            this.ckb_Testing.UseVisualStyleBackColor = true;
            this.ckb_Testing.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckb_NoHeader);
            this.groupBox1.Controls.Add(this.ckb_AddSeperater);
            this.groupBox1.Controls.Add(this.lstV_ExportColumn);
            this.groupBox1.Controls.Add(this.lstv_DBColumn);
            this.groupBox1.Controls.Add(this.gb_DateColumnFormat);
            this.groupBox1.Controls.Add(this.btn_Down);
            this.groupBox1.Controls.Add(this.btn_Up);
            this.groupBox1.Controls.Add(this.tb_Delimiter);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Release);
            this.groupBox1.Controls.Add(this.btn_Pick);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(808, 386);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // ckb_NoHeader
            // 
            this.ckb_NoHeader.AutoSize = true;
            this.ckb_NoHeader.Location = new System.Drawing.Point(642, 186);
            this.ckb_NoHeader.Name = "ckb_NoHeader";
            this.ckb_NoHeader.Size = new System.Drawing.Size(99, 22);
            this.ckb_NoHeader.TabIndex = 53;
            this.ckb_NoHeader.Text = "No Header";
            this.ckb_NoHeader.UseVisualStyleBackColor = true;
            // 
            // ckb_AddSeperater
            // 
            this.ckb_AddSeperater.Location = new System.Drawing.Point(642, 205);
            this.ckb_AddSeperater.Name = "ckb_AddSeperater";
            this.ckb_AddSeperater.Size = new System.Drawing.Size(122, 26);
            this.ckb_AddSeperater.TabIndex = 52;
            this.ckb_AddSeperater.Text = "Double Quote";
            this.ckb_AddSeperater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckb_AddSeperater.UseVisualStyleBackColor = true;
            // 
            // lstV_ExportColumn
            // 
            this.lstV_ExportColumn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstV_ExportColumn.FullRowSelect = true;
            this.lstV_ExportColumn.HideSelection = false;
            this.lstV_ExportColumn.Location = new System.Drawing.Point(357, 56);
            this.lstV_ExportColumn.Name = "lstV_ExportColumn";
            this.lstV_ExportColumn.Size = new System.Drawing.Size(275, 182);
            this.lstV_ExportColumn.TabIndex = 41;
            this.lstV_ExportColumn.UseCompatibleStateImageBehavior = false;
            this.lstV_ExportColumn.View = System.Windows.Forms.View.Details;
            this.lstV_ExportColumn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstV_ExportColumn_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 95;
            // 
            // lstv_DBColumn
            // 
            this.lstv_DBColumn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ColumnName,
            this.ch_ColumnSize,
            this.ch_ColumnType});
            this.lstv_DBColumn.FullRowSelect = true;
            this.lstv_DBColumn.HideSelection = false;
            this.lstv_DBColumn.Location = new System.Drawing.Point(10, 56);
            this.lstv_DBColumn.Name = "lstv_DBColumn";
            this.lstv_DBColumn.Size = new System.Drawing.Size(289, 182);
            this.lstv_DBColumn.TabIndex = 40;
            this.lstv_DBColumn.UseCompatibleStateImageBehavior = false;
            this.lstv_DBColumn.View = System.Windows.Forms.View.Details;
            // 
            // ch_ColumnName
            // 
            this.ch_ColumnName.Text = "Name";
            this.ch_ColumnName.Width = 110;
            // 
            // ch_ColumnSize
            // 
            this.ch_ColumnSize.Text = "Size";
            // 
            // ch_ColumnType
            // 
            this.ch_ColumnType.Text = "Type";
            this.ch_ColumnType.Width = 95;
            // 
            // gb_DateColumnFormat
            // 
            this.gb_DateColumnFormat.Controls.Add(this.label10);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_FillZeroWithDelimiter);
            this.gb_DateColumnFormat.Controls.Add(this.label12);
            this.gb_DateColumnFormat.Controls.Add(this.label9);
            this.gb_DateColumnFormat.Controls.Add(this.cmb_TimeFormat);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_NoTimeFillZero);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_NoTimeWithSec);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_OtherDateDelimiter);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_ColTrim);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_ColFillZero);
            this.gb_DateColumnFormat.Controls.Add(this.nud_DataLength);
            this.gb_DateColumnFormat.Controls.Add(this.label4);
            this.gb_DateColumnFormat.Controls.Add(this.cmb_DateFormat);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_NoDateFillZero);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_WithTime);
            this.gb_DateColumnFormat.Controls.Add(this.ckb_TwoYOnly);
            this.gb_DateColumnFormat.Controls.Add(this.label7);
            this.gb_DateColumnFormat.Location = new System.Drawing.Point(14, 244);
            this.gb_DateColumnFormat.Name = "gb_DateColumnFormat";
            this.gb_DateColumnFormat.Size = new System.Drawing.Size(787, 135);
            this.gb_DateColumnFormat.TabIndex = 37;
            this.gb_DateColumnFormat.TabStop = false;
            this.gb_DateColumnFormat.Text = "Format";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 18);
            this.label10.TabIndex = 53;
            this.label10.Text = "Space:";
            // 
            // ckb_FillZeroWithDelimiter
            // 
            this.ckb_FillZeroWithDelimiter.AutoSize = true;
            this.ckb_FillZeroWithDelimiter.Location = new System.Drawing.Point(487, 28);
            this.ckb_FillZeroWithDelimiter.Name = "ckb_FillZeroWithDelimiter";
            this.ckb_FillZeroWithDelimiter.Size = new System.Drawing.Size(186, 22);
            this.ckb_FillZeroWithDelimiter.TabIndex = 52;
            this.ckb_FillZeroWithDelimiter.Text = "Zero Fill (With Delimiter)";
            this.ckb_FillZeroWithDelimiter.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(266, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 18);
            this.label12.TabIndex = 51;
            this.label12.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 18);
            this.label9.TabIndex = 50;
            this.label9.Text = "--";
            // 
            // cmb_TimeFormat
            // 
            this.cmb_TimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TimeFormat.FormattingEnabled = true;
            this.cmb_TimeFormat.Items.AddRange(new object[] {
            "hh:mm:ss (24 Hours)",
            "hh:mm:ss (12 Hours)"});
            this.cmb_TimeFormat.Location = new System.Drawing.Point(74, 87);
            this.cmb_TimeFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_TimeFormat.Name = "cmb_TimeFormat";
            this.cmb_TimeFormat.Size = new System.Drawing.Size(174, 26);
            this.cmb_TimeFormat.TabIndex = 49;
            // 
            // ckb_NoTimeFillZero
            // 
            this.ckb_NoTimeFillZero.AutoSize = true;
            this.ckb_NoTimeFillZero.Location = new System.Drawing.Point(290, 90);
            this.ckb_NoTimeFillZero.Name = "ckb_NoTimeFillZero";
            this.ckb_NoTimeFillZero.Size = new System.Drawing.Size(137, 22);
            this.ckb_NoTimeFillZero.TabIndex = 48;
            this.ckb_NoTimeFillZero.Text = "No Leading Zero";
            this.ckb_NoTimeFillZero.UseVisualStyleBackColor = true;
            // 
            // ckb_NoTimeWithSec
            // 
            this.ckb_NoTimeWithSec.AutoSize = true;
            this.ckb_NoTimeWithSec.Location = new System.Drawing.Point(433, 90);
            this.ckb_NoTimeWithSec.Name = "ckb_NoTimeWithSec";
            this.ckb_NoTimeWithSec.Size = new System.Drawing.Size(102, 22);
            this.ckb_NoTimeWithSec.TabIndex = 47;
            this.ckb_NoTimeWithSec.Text = "No Second";
            this.ckb_NoTimeWithSec.UseVisualStyleBackColor = true;
            // 
            // ckb_OtherDateDelimiter
            // 
            this.ckb_OtherDateDelimiter.AutoSize = true;
            this.ckb_OtherDateDelimiter.Location = new System.Drawing.Point(290, 59);
            this.ckb_OtherDateDelimiter.Name = "ckb_OtherDateDelimiter";
            this.ckb_OtherDateDelimiter.Size = new System.Drawing.Size(104, 22);
            this.ckb_OtherDateDelimiter.TabIndex = 44;
            this.ckb_OtherDateDelimiter.Text = "\"-\" Delimiter";
            this.ckb_OtherDateDelimiter.UseVisualStyleBackColor = true;
            // 
            // ckb_ColTrim
            // 
            this.ckb_ColTrim.AutoSize = true;
            this.ckb_ColTrim.Location = new System.Drawing.Point(328, 27);
            this.ckb_ColTrim.Name = "ckb_ColTrim";
            this.ckb_ColTrim.Size = new System.Drawing.Size(57, 22);
            this.ckb_ColTrim.TabIndex = 43;
            this.ckb_ColTrim.Text = "Trim";
            this.ckb_ColTrim.UseVisualStyleBackColor = true;
            // 
            // ckb_ColFillZero
            // 
            this.ckb_ColFillZero.AutoSize = true;
            this.ckb_ColFillZero.Location = new System.Drawing.Point(400, 28);
            this.ckb_ColFillZero.Name = "ckb_ColFillZero";
            this.ckb_ColFillZero.Size = new System.Drawing.Size(80, 22);
            this.ckb_ColFillZero.TabIndex = 2;
            this.ckb_ColFillZero.Text = "Zero Fill";
            this.ckb_ColFillZero.UseVisualStyleBackColor = true;
            // 
            // nud_DataLength
            // 
            this.nud_DataLength.Location = new System.Drawing.Point(74, 27);
            this.nud_DataLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_DataLength.Name = "nud_DataLength";
            this.nud_DataLength.Size = new System.Drawing.Size(174, 24);
            this.nud_DataLength.TabIndex = 1;
            this.nud_DataLength.Leave += new System.EventHandler(this.nud_DataLength_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Size:";
            // 
            // cmb_DateFormat
            // 
            this.cmb_DateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DateFormat.FormattingEnabled = true;
            this.cmb_DateFormat.Items.AddRange(new object[] {
            "yyyymmdd",
            "ddmmyyyy",
            "mmddyyyy",
            "yyyy/mm/dd",
            "dd/mm/yyyy",
            "mm/dd/yyyy"});
            this.cmb_DateFormat.Location = new System.Drawing.Point(74, 56);
            this.cmb_DateFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DateFormat.Name = "cmb_DateFormat";
            this.cmb_DateFormat.Size = new System.Drawing.Size(174, 26);
            this.cmb_DateFormat.TabIndex = 41;
            this.cmb_DateFormat.SelectedIndexChanged += new System.EventHandler(this.cmb_DateFormat_SelectedIndexChanged);
            // 
            // ckb_NoDateFillZero
            // 
            this.ckb_NoDateFillZero.AutoSize = true;
            this.ckb_NoDateFillZero.Location = new System.Drawing.Point(400, 59);
            this.ckb_NoDateFillZero.Name = "ckb_NoDateFillZero";
            this.ckb_NoDateFillZero.Size = new System.Drawing.Size(137, 22);
            this.ckb_NoDateFillZero.TabIndex = 40;
            this.ckb_NoDateFillZero.Text = "No Leading Zero";
            this.ckb_NoDateFillZero.UseVisualStyleBackColor = true;
            // 
            // ckb_WithTime
            // 
            this.ckb_WithTime.AutoSize = true;
            this.ckb_WithTime.Location = new System.Drawing.Point(10, 90);
            this.ckb_WithTime.Name = "ckb_WithTime";
            this.ckb_WithTime.Size = new System.Drawing.Size(64, 22);
            this.ckb_WithTime.TabIndex = 39;
            this.ckb_WithTime.Text = "Time:";
            this.ckb_WithTime.UseVisualStyleBackColor = true;
            this.ckb_WithTime.CheckedChanged += new System.EventHandler(this.ckb_WithTime_CheckedChanged);
            // 
            // ckb_TwoYOnly
            // 
            this.ckb_TwoYOnly.AutoSize = true;
            this.ckb_TwoYOnly.Location = new System.Drawing.Point(551, 59);
            this.ckb_TwoYOnly.Name = "ckb_TwoYOnly";
            this.ckb_TwoYOnly.Size = new System.Drawing.Size(125, 22);
            this.ckb_TwoYOnly.TabIndex = 38;
            this.ckb_TwoYOnly.Text = "Short Year (yy)";
            this.ckb_TwoYOnly.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Date:";
            // 
            // btn_Down
            // 
            this.btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down.Image")));
            this.btn_Down.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Down.Location = new System.Drawing.Point(642, 97);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(28, 28);
            this.btn_Down.TabIndex = 28;
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up.Image")));
            this.btn_Up.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Up.Location = new System.Drawing.Point(642, 56);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(28, 28);
            this.btn_Up.TabIndex = 27;
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // tb_Delimiter
            // 
            this.tb_Delimiter.Location = new System.Drawing.Point(642, 157);
            this.tb_Delimiter.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Delimiter.Name = "tb_Delimiter";
            this.tb_Delimiter.Size = new System.Drawing.Size(146, 24);
            this.tb_Delimiter.TabIndex = 25;
            this.tb_Delimiter.TabStop = false;
            this.tb_Delimiter.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tb_Delimiter_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(639, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Delimiter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Exporting Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Available Columns";
            // 
            // btn_Release
            // 
            this.btn_Release.Image = ((System.Drawing.Image)(resources.GetObject("btn_Release.Image")));
            this.btn_Release.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Release.Location = new System.Drawing.Point(313, 153);
            this.btn_Release.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Release.Name = "btn_Release";
            this.btn_Release.Size = new System.Drawing.Size(25, 32);
            this.btn_Release.TabIndex = 17;
            this.btn_Release.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Release.UseVisualStyleBackColor = true;
            this.btn_Release.Click += new System.EventHandler(this.btn_Release_Click);
            // 
            // btn_Pick
            // 
            this.btn_Pick.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pick.Image")));
            this.btn_Pick.Location = new System.Drawing.Point(312, 94);
            this.btn_Pick.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Pick.Name = "btn_Pick";
            this.btn_Pick.Size = new System.Drawing.Size(25, 32);
            this.btn_Pick.TabIndex = 16;
            this.btn_Pick.UseVisualStyleBackColor = true;
            this.btn_Pick.Click += new System.EventHandler(this.btn_Pick_Click);
            // 
            // btn_SelectTables
            // 
            this.btn_SelectTables.Location = new System.Drawing.Point(696, 6);
            this.btn_SelectTables.Name = "btn_SelectTables";
            this.btn_SelectTables.Size = new System.Drawing.Size(112, 31);
            this.btn_SelectTables.TabIndex = 26;
            this.btn_SelectTables.Text = "Select Views";
            this.btn_SelectTables.UseVisualStyleBackColor = true;
            this.btn_SelectTables.Visible = false;
            // 
            // btn_ExportColumnFormat
            // 
            this.btn_ExportColumnFormat.Location = new System.Drawing.Point(633, 6);
            this.btn_ExportColumnFormat.Name = "btn_ExportColumnFormat";
            this.btn_ExportColumnFormat.Size = new System.Drawing.Size(168, 31);
            this.btn_ExportColumnFormat.TabIndex = 36;
            this.btn_ExportColumnFormat.Text = "Column Format";
            this.btn_ExportColumnFormat.UseVisualStyleBackColor = true;
            this.btn_ExportColumnFormat.Visible = false;
            // 
            // cmb_Views
            // 
            this.cmb_Views.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Views.FormattingEnabled = true;
            this.cmb_Views.Location = new System.Drawing.Point(68, 6);
            this.cmb_Views.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Views.Name = "cmb_Views";
            this.cmb_Views.Size = new System.Drawing.Size(332, 26);
            this.cmb_Views.TabIndex = 22;
            this.cmb_Views.SelectedIndexChanged += new System.EventHandler(this.cmb_Views_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 18);
            this.label11.TabIndex = 52;
            this.label11.Text = "Type:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(458, 551);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 18);
            this.label13.TabIndex = 53;
            this.label13.Text = "File:";
            // 
            // tb_FileNameFormat
            // 
            this.tb_FileNameFormat.Location = new System.Drawing.Point(499, 548);
            this.tb_FileNameFormat.Name = "tb_FileNameFormat";
            this.tb_FileNameFormat.Size = new System.Drawing.Size(166, 24);
            this.tb_FileNameFormat.TabIndex = 54;
            // 
            // cmb_ExportFormat
            // 
            this.cmb_ExportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExportFormat.FormattingEnabled = true;
            this.cmb_ExportFormat.Items.AddRange(new object[] {
            "TXT (Plain Text)",
            "CSV (Plain Text)"});
            this.cmb_ExportFormat.Location = new System.Drawing.Point(684, 548);
            this.cmb_ExportFormat.Name = "cmb_ExportFormat";
            this.cmb_ExportFormat.Size = new System.Drawing.Size(137, 26);
            this.cmb_ExportFormat.TabIndex = 55;
            this.cmb_ExportFormat.SelectedIndexChanged += new System.EventHandler(this.cmb_ExportFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(10, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(809, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "_________________________________________________________________________________" +
    "________";
            // 
            // ckb_IncludeNoDateUser
            // 
            this.ckb_IncludeNoDateUser.AutoSize = true;
            this.ckb_IncludeNoDateUser.Location = new System.Drawing.Point(499, 520);
            this.ckb_IncludeNoDateUser.Name = "ckb_IncludeNoDateUser";
            this.ckb_IncludeNoDateUser.Size = new System.Drawing.Size(186, 22);
            this.ckb_IncludeNoDateUser.TabIndex = 56;
            this.ckb_IncludeNoDateUser.Text = "Non-Attendance Record";
            this.ckb_IncludeNoDateUser.UseVisualStyleBackColor = true;
            this.ckb_IncludeNoDateUser.Visible = false;
            // 
            // frm_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 632);
            this.Controls.Add(this.ckb_IncludeNoDateUser);
            this.Controls.Add(this.cmb_ExportFormat);
            this.Controls.Add(this.tb_FileNameFormat);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gb_DateSearchCondition);
            this.Controls.Add(this.nud_SelectRow);
            this.Controls.Add(this.btn_SelectTables);
            this.Controls.Add(this.btn_ExportColumnFormat);
            this.Controls.Add(this.ckb_Testing);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_Views);
            this.Controls.Add(this.ckb_ExportPreview);
            this.Controls.Add(this.btn_FolderBrowse);
            this.Controls.Add(this.tb_ExportPath);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 670);
            this.MinimumSize = new System.Drawing.Size(845, 670);
            this.Name = "frm_Setting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Export";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Setting_FormClosing);
            this.Load += new System.EventHandler(this.frm_Setting_Load);
            this.gb_DateSearchCondition.ResumeLayout(false);
            this.gb_DateSearchCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_DaysLater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_SelectRow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_DateColumnFormat.ResumeLayout(false);
            this.gb_DateColumnFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DataLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TextBox tb_ExportPath;
        private System.Windows.Forms.Button btn_FolderBrowse;
        private System.Windows.Forms.CheckBox ckb_ExportPreview;
        private System.Windows.Forms.GroupBox gb_DateSearchCondition;
        private System.Windows.Forms.DateTimePicker dtp_ToTime;
        private System.Windows.Forms.DateTimePicker dtp_FromTime;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.ComboBox cmb_DateType;
        private System.Windows.Forms.RadioButton rdb_SpecifyDateRange;
        private System.Windows.Forms.RadioButton rdb_RangerFromToday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_SelectRow;
        private System.Windows.Forms.CheckBox ckb_Testing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_DateColumnFormat;
        private System.Windows.Forms.ComboBox cmb_DateFormat;
        private System.Windows.Forms.CheckBox ckb_NoDateFillZero;
        private System.Windows.Forms.CheckBox ckb_WithTime;
        private System.Windows.Forms.CheckBox ckb_TwoYOnly;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckb_ColFillZero;
        private System.Windows.Forms.NumericUpDown nud_DataLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ExportColumnFormat;
        private System.Windows.Forms.ComboBox cmb_Views;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_SelectTables;
        private System.Windows.Forms.TextBox tb_Delimiter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Release;
        private System.Windows.Forms.Button btn_Pick;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lstv_DBColumn;
        private System.Windows.Forms.ListView lstV_ExportColumn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader ch_ColumnName;
        private System.Windows.Forms.ColumnHeader ch_ColumnSize;
        private System.Windows.Forms.ColumnHeader ch_ColumnType;
        private System.Windows.Forms.CheckBox ckb_ColTrim;
        private System.Windows.Forms.CheckBox ckb_OtherDateDelimiter;
        private System.Windows.Forms.CheckBox ckb_NoTimeFillZero;
        private System.Windows.Forms.CheckBox ckb_NoTimeWithSec;
        private System.Windows.Forms.ComboBox cmb_TimeFormat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_FileNameFormat;
        private System.Windows.Forms.ComboBox cmb_ExportFormat;
        private System.Windows.Forms.CheckBox ckb_AddSeperater;
        private System.Windows.Forms.CheckBox ckb_FillZeroWithDelimiter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ckb_IncludeNoDateUser;
        private System.Windows.Forms.CheckBox ckb_NoHeader;
        private System.Windows.Forms.DateTimePicker dtp_TimeRangeTo;
        private System.Windows.Forms.Label lbl_DaysLater;
        private System.Windows.Forms.NumericUpDown ud_DaysLater;
        private System.Windows.Forms.Label lbl_TimeRangeTo;
        private System.Windows.Forms.DateTimePicker dtp_TimeRangeFrom;
        private System.Windows.Forms.Label lbl_TimeRangeFrom;
    }
}