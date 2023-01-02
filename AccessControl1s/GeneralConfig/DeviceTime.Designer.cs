namespace AccessControl1s
{
    partial class DeviceTime
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SetTime = new System.Windows.Forms.Button();
            this.btn_GetTime = new System.Windows.Forms.Button();
            this.dateTimePicker_DevTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_SetNTP = new System.Windows.Forms.Button();
            this.btn_GetNTP = new System.Windows.Forms.Button();
            this.textBox_Descrip = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_TimeZone = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_UpdatePeriod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NTPiP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_NTPEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_StopMin = new System.Windows.Forms.ComboBox();
            this.cmb_StopHour = new System.Windows.Forms.ComboBox();
            this.cmb_StopDay = new System.Windows.Forms.ComboBox();
            this.cmb_StopMonth = new System.Windows.Forms.ComboBox();
            this.cmb_StopYear = new System.Windows.Forms.ComboBox();
            this.cmb_StartMin = new System.Windows.Forms.ComboBox();
            this.cmb_StartHour = new System.Windows.Forms.ComboBox();
            this.cmb_StartDay = new System.Windows.Forms.ComboBox();
            this.cmb_StartMonth = new System.Windows.Forms.ComboBox();
            this.cmb_StartYear = new System.Windows.Forms.ComboBox();
            this.button_SetDST = new System.Windows.Forms.Button();
            this.button_GetDST = new System.Windows.Forms.Button();
            this.comboBox_WeekStop = new System.Windows.Forms.ComboBox();
            this.comboBox_WeekNoStop = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_WeekBegin = new System.Windows.Forms.ComboBox();
            this.comboBox_WeekNoBegin = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_DSTType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_DSTEnabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SetTime);
            this.groupBox1.Controls.Add(this.btn_GetTime);
            this.groupBox1.Controls.Add(this.dateTimePicker_DevTime);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Time(设备时间)";
            // 
            // btn_SetTime
            // 
            this.btn_SetTime.Location = new System.Drawing.Point(141, 167);
            this.btn_SetTime.Name = "btn_SetTime";
            this.btn_SetTime.Size = new System.Drawing.Size(75, 23);
            this.btn_SetTime.TabIndex = 2;
            this.btn_SetTime.Text = "Set(设置)";
            this.btn_SetTime.UseVisualStyleBackColor = true;
            this.btn_SetTime.Click += new System.EventHandler(this.btn_SetTime_Click);
            // 
            // btn_GetTime
            // 
            this.btn_GetTime.Location = new System.Drawing.Point(20, 168);
            this.btn_GetTime.Name = "btn_GetTime";
            this.btn_GetTime.Size = new System.Drawing.Size(75, 23);
            this.btn_GetTime.TabIndex = 1;
            this.btn_GetTime.Text = "Get(获取)";
            this.btn_GetTime.UseVisualStyleBackColor = true;
            this.btn_GetTime.Click += new System.EventHandler(this.btn_GetTime_Click);
            // 
            // dateTimePicker_DevTime
            // 
            this.dateTimePicker_DevTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_DevTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_DevTime.Location = new System.Drawing.Point(20, 40);
            this.dateTimePicker_DevTime.Name = "dateTimePicker_DevTime";
            this.dateTimePicker_DevTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_DevTime.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.btn_SetNTP);
            this.groupBox2.Controls.Add(this.btn_GetNTP);
            this.groupBox2.Controls.Add(this.textBox_Descrip);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_TimeZone);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_UpdatePeriod);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Port);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_NTPiP);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkBox_NTPEnabled);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(290, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 268);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NTP Config(时间同步配置)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(274, 126);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 12);
            this.label21.TabIndex = 14;
            this.label21.Text = "Min(分)";
            // 
            // btn_SetNTP
            // 
            this.btn_SetNTP.Location = new System.Drawing.Point(199, 230);
            this.btn_SetNTP.Name = "btn_SetNTP";
            this.btn_SetNTP.Size = new System.Drawing.Size(75, 23);
            this.btn_SetNTP.TabIndex = 13;
            this.btn_SetNTP.Text = "Set(设置)";
            this.btn_SetNTP.UseVisualStyleBackColor = true;
            this.btn_SetNTP.Click += new System.EventHandler(this.btn_SetNTP_Click);
            // 
            // btn_GetNTP
            // 
            this.btn_GetNTP.Location = new System.Drawing.Point(53, 231);
            this.btn_GetNTP.Name = "btn_GetNTP";
            this.btn_GetNTP.Size = new System.Drawing.Size(75, 23);
            this.btn_GetNTP.TabIndex = 12;
            this.btn_GetNTP.Text = "Get(获取)";
            this.btn_GetNTP.UseVisualStyleBackColor = true;
            this.btn_GetNTP.Click += new System.EventHandler(this.btn_GetNTP_Click);
            // 
            // textBox_Descrip
            // 
            this.textBox_Descrip.Location = new System.Drawing.Point(174, 176);
            this.textBox_Descrip.Name = "textBox_Descrip";
            this.textBox_Descrip.Size = new System.Drawing.Size(140, 21);
            this.textBox_Descrip.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Description(时区描述)：";
            // 
            // comboBox_TimeZone
            // 
            this.comboBox_TimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TimeZone.FormattingEnabled = true;
            this.comboBox_TimeZone.Items.AddRange(new object[] {
            "GMT+00:00",
            "GMT+01:00",
            "GMT+02:00",
            "GMT+03:00",
            "GMT+03:30",
            "GMT+04:00",
            "GMT+04:30",
            "GMT+05:00",
            "GMT+05:30",
            "GMT+05:45",
            "GMT+06:00",
            "GMT+06:30",
            "GMT+07:00",
            "GMT+08:00",
            "GMT+09:00",
            "GMT+09:30",
            "GMT+10:00",
            "GMT+11:00",
            "GMT+12:00",
            "GMT+13:00",
            "GMT-01:00",
            "GMT-02:00",
            "GMT-03:00",
            "GMT-03:30",
            "GMT-04:00",
            "GMT-05:00",
            "GMT-06:00",
            "GMT-07:00",
            "GMT-08:00",
            "GMT-09:00",
            "GMT-10:00",
            "GMT-11:00",
            "GMT-12:00"});
            this.comboBox_TimeZone.Location = new System.Drawing.Point(172, 147);
            this.comboBox_TimeZone.Name = "comboBox_TimeZone";
            this.comboBox_TimeZone.Size = new System.Drawing.Size(121, 20);
            this.comboBox_TimeZone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "TimeZone(时区)：";
            // 
            // textBox_UpdatePeriod
            // 
            this.textBox_UpdatePeriod.Location = new System.Drawing.Point(174, 119);
            this.textBox_UpdatePeriod.Name = "textBox_UpdatePeriod";
            this.textBox_UpdatePeriod.Size = new System.Drawing.Size(100, 21);
            this.textBox_UpdatePeriod.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "UpdatePeriod(更新周期)：";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(172, 87);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 21);
            this.textBox_Port.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port(端口)：";
            // 
            // textBox_NTPiP
            // 
            this.textBox_NTPiP.Location = new System.Drawing.Point(172, 59);
            this.textBox_NTPiP.Name = "textBox_NTPiP";
            this.textBox_NTPiP.Size = new System.Drawing.Size(100, 21);
            this.textBox_NTPiP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP or Net(IP地址或网络)：";
            // 
            // checkBox_NTPEnabled
            // 
            this.checkBox_NTPEnabled.AutoSize = true;
            this.checkBox_NTPEnabled.Location = new System.Drawing.Point(172, 39);
            this.checkBox_NTPEnabled.Name = "checkBox_NTPEnabled";
            this.checkBox_NTPEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBox_NTPEnabled.TabIndex = 1;
            this.checkBox_NTPEnabled.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable(使能)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cmb_StopMin);
            this.groupBox3.Controls.Add(this.cmb_StopHour);
            this.groupBox3.Controls.Add(this.cmb_StopDay);
            this.groupBox3.Controls.Add(this.cmb_StopMonth);
            this.groupBox3.Controls.Add(this.cmb_StopYear);
            this.groupBox3.Controls.Add(this.cmb_StartMin);
            this.groupBox3.Controls.Add(this.cmb_StartHour);
            this.groupBox3.Controls.Add(this.cmb_StartDay);
            this.groupBox3.Controls.Add(this.cmb_StartMonth);
            this.groupBox3.Controls.Add(this.cmb_StartYear);
            this.groupBox3.Controls.Add(this.button_SetDST);
            this.groupBox3.Controls.Add(this.button_GetDST);
            this.groupBox3.Controls.Add(this.comboBox_WeekStop);
            this.groupBox3.Controls.Add(this.comboBox_WeekNoStop);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox_WeekBegin);
            this.groupBox3.Controls.Add(this.comboBox_WeekNoBegin);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboBox_DSTType);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.checkBox_DSTEnabled);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(13, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(597, 298);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DST Config(夏令时配置)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(414, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "Minute(分)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(356, 170);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "Hour(时)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(296, 170);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "Day(日)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(233, 170);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 12);
            this.label19.TabIndex = 30;
            this.label19.Text = "Month(月)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(166, 170);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 29;
            this.label20.Text = "Year(年)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(414, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "Minute(分)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(356, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "Hour(时)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(296, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "Day(日)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "Month(月)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "Year(年)";
            // 
            // cmb_StopMin
            // 
            this.cmb_StopMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopMin.FormattingEnabled = true;
            this.cmb_StopMin.Location = new System.Drawing.Point(414, 186);
            this.cmb_StopMin.Name = "cmb_StopMin";
            this.cmb_StopMin.Size = new System.Drawing.Size(54, 20);
            this.cmb_StopMin.TabIndex = 23;
            // 
            // cmb_StopHour
            // 
            this.cmb_StopHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopHour.FormattingEnabled = true;
            this.cmb_StopHour.Location = new System.Drawing.Point(354, 186);
            this.cmb_StopHour.Name = "cmb_StopHour";
            this.cmb_StopHour.Size = new System.Drawing.Size(54, 20);
            this.cmb_StopHour.TabIndex = 22;
            // 
            // cmb_StopDay
            // 
            this.cmb_StopDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopDay.Enabled = false;
            this.cmb_StopDay.FormattingEnabled = true;
            this.cmb_StopDay.Location = new System.Drawing.Point(293, 186);
            this.cmb_StopDay.Name = "cmb_StopDay";
            this.cmb_StopDay.Size = new System.Drawing.Size(54, 20);
            this.cmb_StopDay.TabIndex = 21;
            this.cmb_StopDay.SelectedIndexChanged += new System.EventHandler(this.cmb_StopDay_SelectedIndexChanged);
            // 
            // cmb_StopMonth
            // 
            this.cmb_StopMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopMonth.FormattingEnabled = true;
            this.cmb_StopMonth.Location = new System.Drawing.Point(230, 186);
            this.cmb_StopMonth.Name = "cmb_StopMonth";
            this.cmb_StopMonth.Size = new System.Drawing.Size(54, 20);
            this.cmb_StopMonth.TabIndex = 20;
            this.cmb_StopMonth.SelectedIndexChanged += new System.EventHandler(this.cmb_StopMonth_SelectedIndexChanged);
            // 
            // cmb_StopYear
            // 
            this.cmb_StopYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopYear.FormattingEnabled = true;
            this.cmb_StopYear.Location = new System.Drawing.Point(166, 186);
            this.cmb_StopYear.Name = "cmb_StopYear";
            this.cmb_StopYear.Size = new System.Drawing.Size(54, 20);
            this.cmb_StopYear.TabIndex = 19;
            // 
            // cmb_StartMin
            // 
            this.cmb_StartMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartMin.FormattingEnabled = true;
            this.cmb_StartMin.Location = new System.Drawing.Point(414, 111);
            this.cmb_StartMin.Name = "cmb_StartMin";
            this.cmb_StartMin.Size = new System.Drawing.Size(54, 20);
            this.cmb_StartMin.TabIndex = 18;
            // 
            // cmb_StartHour
            // 
            this.cmb_StartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartHour.FormattingEnabled = true;
            this.cmb_StartHour.Location = new System.Drawing.Point(354, 111);
            this.cmb_StartHour.Name = "cmb_StartHour";
            this.cmb_StartHour.Size = new System.Drawing.Size(54, 20);
            this.cmb_StartHour.TabIndex = 17;
            // 
            // cmb_StartDay
            // 
            this.cmb_StartDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartDay.Enabled = false;
            this.cmb_StartDay.FormattingEnabled = true;
            this.cmb_StartDay.Location = new System.Drawing.Point(293, 111);
            this.cmb_StartDay.Name = "cmb_StartDay";
            this.cmb_StartDay.Size = new System.Drawing.Size(54, 20);
            this.cmb_StartDay.TabIndex = 16;
            this.cmb_StartDay.SelectedIndexChanged += new System.EventHandler(this.cmb_StartDay_SelectedIndexChanged);
            // 
            // cmb_StartMonth
            // 
            this.cmb_StartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartMonth.FormattingEnabled = true;
            this.cmb_StartMonth.Location = new System.Drawing.Point(230, 111);
            this.cmb_StartMonth.Name = "cmb_StartMonth";
            this.cmb_StartMonth.Size = new System.Drawing.Size(54, 20);
            this.cmb_StartMonth.TabIndex = 15;
            this.cmb_StartMonth.SelectedIndexChanged += new System.EventHandler(this.cmb_StartMonth_SelectedIndexChanged);
            // 
            // cmb_StartYear
            // 
            this.cmb_StartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartYear.FormattingEnabled = true;
            this.cmb_StartYear.Location = new System.Drawing.Point(166, 111);
            this.cmb_StartYear.Name = "cmb_StartYear";
            this.cmb_StartYear.Size = new System.Drawing.Size(54, 20);
            this.cmb_StartYear.TabIndex = 14;
            // 
            // button_SetDST
            // 
            this.button_SetDST.Location = new System.Drawing.Point(335, 257);
            this.button_SetDST.Name = "button_SetDST";
            this.button_SetDST.Size = new System.Drawing.Size(85, 30);
            this.button_SetDST.TabIndex = 13;
            this.button_SetDST.Text = "Set(设置)";
            this.button_SetDST.UseVisualStyleBackColor = true;
            this.button_SetDST.Click += new System.EventHandler(this.button_SetDST_Click);
            // 
            // button_GetDST
            // 
            this.button_GetDST.Location = new System.Drawing.Point(154, 257);
            this.button_GetDST.Name = "button_GetDST";
            this.button_GetDST.Size = new System.Drawing.Size(85, 30);
            this.button_GetDST.TabIndex = 12;
            this.button_GetDST.Text = "Get(获取)";
            this.button_GetDST.UseVisualStyleBackColor = true;
            this.button_GetDST.Click += new System.EventHandler(this.button_GetDST_Click);
            // 
            // comboBox_WeekStop
            // 
            this.comboBox_WeekStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeekStop.FormattingEnabled = true;
            this.comboBox_WeekStop.Items.AddRange(new object[] {
            "Sun(星期日)",
            "Mon(星期一)",
            "Tues(星期二)",
            "Wed(星期三)",
            "Thur.(星期四)",
            "Fri(星期五)",
            "Sat(星期六)"});
            this.comboBox_WeekStop.Location = new System.Drawing.Point(304, 210);
            this.comboBox_WeekStop.Name = "comboBox_WeekStop";
            this.comboBox_WeekStop.Size = new System.Drawing.Size(121, 20);
            this.comboBox_WeekStop.TabIndex = 11;
            // 
            // comboBox_WeekNoStop
            // 
            this.comboBox_WeekNoStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeekNoStop.FormattingEnabled = true;
            this.comboBox_WeekNoStop.Items.AddRange(new object[] {
            "Last Week(最后一周)",
            "First Week(第一周)",
            "Second Week(第二周)",
            "Third Week(第三周)",
            "Fourth Week(第四周)"});
            this.comboBox_WeekNoStop.Location = new System.Drawing.Point(166, 211);
            this.comboBox_WeekNoStop.Name = "comboBox_WeekNoStop";
            this.comboBox_WeekNoStop.Size = new System.Drawing.Size(121, 20);
            this.comboBox_WeekNoStop.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "DST Stop(夏令时结束)：";
            // 
            // comboBox_WeekBegin
            // 
            this.comboBox_WeekBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeekBegin.FormattingEnabled = true;
            this.comboBox_WeekBegin.Items.AddRange(new object[] {
            "Sun(星期日)",
            "Mon(星期一)",
            "Tues(星期二)",
            "Wed(星期三)",
            "Thur.(星期四)",
            "Fri(星期五)",
            "Sat(星期六)"});
            this.comboBox_WeekBegin.Location = new System.Drawing.Point(305, 137);
            this.comboBox_WeekBegin.Name = "comboBox_WeekBegin";
            this.comboBox_WeekBegin.Size = new System.Drawing.Size(121, 20);
            this.comboBox_WeekBegin.TabIndex = 7;
            // 
            // comboBox_WeekNoBegin
            // 
            this.comboBox_WeekNoBegin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeekNoBegin.FormattingEnabled = true;
            this.comboBox_WeekNoBegin.Items.AddRange(new object[] {
            "Last Week(最后一周)",
            "First Week(第一周)",
            "Second Week(第二周)",
            "Third Week(第三周)",
            "Fourth Week(第四周)"});
            this.comboBox_WeekNoBegin.Location = new System.Drawing.Point(166, 138);
            this.comboBox_WeekNoBegin.Name = "comboBox_WeekNoBegin";
            this.comboBox_WeekNoBegin.Size = new System.Drawing.Size(121, 20);
            this.comboBox_WeekNoBegin.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "DST Begin(夏令时开始)：";
            // 
            // comboBox_DSTType
            // 
            this.comboBox_DSTType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DSTType.FormattingEnabled = true;
            this.comboBox_DSTType.Items.AddRange(new object[] {
            "By Date(按日期定位)",
            "By Week(按周定位)"});
            this.comboBox_DSTType.Location = new System.Drawing.Point(166, 62);
            this.comboBox_DSTType.Name = "comboBox_DSTType";
            this.comboBox_DSTType.Size = new System.Drawing.Size(157, 20);
            this.comboBox_DSTType.TabIndex = 3;
            this.comboBox_DSTType.SelectedIndexChanged += new System.EventHandler(this.comboBox_DSTType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "DST Type(夏令时类型)：";
            // 
            // checkBox_DSTEnabled
            // 
            this.checkBox_DSTEnabled.AutoSize = true;
            this.checkBox_DSTEnabled.Location = new System.Drawing.Point(166, 29);
            this.checkBox_DSTEnabled.Name = "checkBox_DSTEnabled";
            this.checkBox_DSTEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBox_DSTEnabled.TabIndex = 1;
            this.checkBox_DSTEnabled.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Enable(使能)：";
            // 
            // DeviceTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 608);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeviceTime(设备时间)";
            this.Load += new System.EventHandler(this.DeviceTime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DevTime;
        private System.Windows.Forms.Button btn_SetTime;
        private System.Windows.Forms.Button btn_GetTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_NTPiP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_NTPEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_SetNTP;
        private System.Windows.Forms.Button btn_GetNTP;
        private System.Windows.Forms.TextBox textBox_Descrip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_TimeZone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_UpdatePeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_SetDST;
        private System.Windows.Forms.Button button_GetDST;
        private System.Windows.Forms.ComboBox comboBox_WeekStop;
        private System.Windows.Forms.ComboBox comboBox_WeekNoStop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_WeekBegin;
        private System.Windows.Forms.ComboBox comboBox_WeekNoBegin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_DSTType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_DSTEnabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_StopMin;
        private System.Windows.Forms.ComboBox cmb_StopHour;
        private System.Windows.Forms.ComboBox cmb_StopDay;
        private System.Windows.Forms.ComboBox cmb_StopMonth;
        private System.Windows.Forms.ComboBox cmb_StopYear;
        private System.Windows.Forms.ComboBox cmb_StartMin;
        private System.Windows.Forms.ComboBox cmb_StartHour;
        private System.Windows.Forms.ComboBox cmb_StartDay;
        private System.Windows.Forms.ComboBox cmb_StartMonth;
        private System.Windows.Forms.ComboBox cmb_StartYear;
        private System.Windows.Forms.Label label21;
    }
}