namespace AccessControl1s
{
    partial class DoorConfig
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
            this.cmbBox_DoorIndex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBox_OpenMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UnlockHold = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CloseTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_HolidayNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBox_AccessState = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox_RepearAlarm = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_NotCloseAlarm = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_DuressAlarm = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_Sensor = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox_BreakAlarm = new System.Windows.Forms.CheckBox();
            this.btn_Get = new System.Windows.Forms.Button();
            this.btn_Set = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBox_OpenDoorMethod4 = new System.Windows.Forms.ComboBox();
            this.cmbBox_OpenDoorMethod3 = new System.Windows.Forms.ComboBox();
            this.cmbBox_OpenDoorMethod2 = new System.Windows.Forms.ComboBox();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.cmbBox_OpenDoorMethod1 = new System.Windows.Forms.ComboBox();
            this.EndTime4 = new System.Windows.Forms.DateTimePicker();
            this.EndTime3 = new System.Windows.Forms.DateTimePicker();
            this.EndTime2 = new System.Windows.Forms.DateTimePicker();
            this.EndTime1 = new System.Windows.Forms.DateTimePicker();
            this.StartTime4 = new System.Windows.Forms.DateTimePicker();
            this.StartTime3 = new System.Windows.Forms.DateTimePicker();
            this.StartTime2 = new System.Windows.Forms.DateTimePicker();
            this.StartTime1 = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_Week = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Index(门序号)：";
            // 
            // cmbBox_DoorIndex
            // 
            this.cmbBox_DoorIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_DoorIndex.FormattingEnabled = true;
            this.cmbBox_DoorIndex.Location = new System.Drawing.Point(206, 39);
            this.cmbBox_DoorIndex.Name = "cmbBox_DoorIndex";
            this.cmbBox_DoorIndex.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_DoorIndex.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "DoorOpenMethod(开门方式)：";
            // 
            // cmbBox_OpenMethod
            // 
            this.cmbBox_OpenMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_OpenMethod.DropDownWidth = 220;
            this.cmbBox_OpenMethod.FormattingEnabled = true;
            this.cmbBox_OpenMethod.Items.AddRange(new object[] {
            "Unknown(未知)",
            "PwdOnly(仅限密码)",
            "Card(门禁卡)",
            "PwdOrCard(密码或卡)",
            "CardFirst(先刷卡后密码)",
            "PwdFirst(先密码后刷卡)",
            "TimeSection(分时段)",
            "FingerPrintOnly(仅限指纹)",
            "PwdOrCardOrFingerPrint(密码或卡或指纹)",
            "Pwd+Card+FingerPrint(密码+卡+指纹)",
            "Pwd+FingerPrint(密码+指纹)",
            "Card+FingerPrint(卡+指纹)",
            "MultiPerson(多人)"});
            this.cmbBox_OpenMethod.Location = new System.Drawing.Point(206, 68);
            this.cmbBox_OpenMethod.Name = "cmbBox_OpenMethod";
            this.cmbBox_OpenMethod.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_OpenMethod.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "UnlockHold(门锁保持时间)：";
            // 
            // textBox_UnlockHold
            // 
            this.textBox_UnlockHold.Location = new System.Drawing.Point(206, 97);
            this.textBox_UnlockHold.Name = "textBox_UnlockHold";
            this.textBox_UnlockHold.Size = new System.Drawing.Size(100, 21);
            this.textBox_UnlockHold.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "CloseTimeout(关门超时时间)：";
            // 
            // textBox_CloseTimeout
            // 
            this.textBox_CloseTimeout.Location = new System.Drawing.Point(206, 127);
            this.textBox_CloseTimeout.Name = "textBox_CloseTimeout";
            this.textBox_CloseTimeout.Size = new System.Drawing.Size(100, 21);
            this.textBox_CloseTimeout.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "HolidayTimeRecNo(假期时间段序号)：";
            // 
            // textBox_HolidayNo
            // 
            this.textBox_HolidayNo.Location = new System.Drawing.Point(206, 158);
            this.textBox_HolidayNo.Name = "textBox_HolidayNo";
            this.textBox_HolidayNo.Size = new System.Drawing.Size(100, 21);
            this.textBox_HolidayNo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "AccessState(门禁状态)：";
            // 
            // cmbBox_AccessState
            // 
            this.cmbBox_AccessState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_AccessState.FormattingEnabled = true;
            this.cmbBox_AccessState.Items.AddRange(new object[] {
            "Normal(普通)",
            "CloseAlways(常闭)",
            "OpenAlways(常开)"});
            this.cmbBox_AccessState.Location = new System.Drawing.Point(206, 192);
            this.cmbBox_AccessState.Name = "cmbBox_AccessState";
            this.cmbBox_AccessState.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_AccessState.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "RepearEventAlarm(重复进入报警)：";
            // 
            // checkBox_RepearAlarm
            // 
            this.checkBox_RepearAlarm.AutoSize = true;
            this.checkBox_RepearAlarm.Location = new System.Drawing.Point(552, 43);
            this.checkBox_RepearAlarm.Name = "checkBox_RepearAlarm";
            this.checkBox_RepearAlarm.Size = new System.Drawing.Size(15, 14);
            this.checkBox_RepearAlarm.TabIndex = 13;
            this.checkBox_RepearAlarm.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "DoorNotCloseAlarm(门未关报警)：";
            // 
            // checkBox_NotCloseAlarm
            // 
            this.checkBox_NotCloseAlarm.AutoSize = true;
            this.checkBox_NotCloseAlarm.Location = new System.Drawing.Point(552, 73);
            this.checkBox_NotCloseAlarm.Name = "checkBox_NotCloseAlarm";
            this.checkBox_NotCloseAlarm.Size = new System.Drawing.Size(15, 14);
            this.checkBox_NotCloseAlarm.TabIndex = 15;
            this.checkBox_NotCloseAlarm.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "DuressAlarm(胁迫报警)：";
            // 
            // checkBox_DuressAlarm
            // 
            this.checkBox_DuressAlarm.AutoSize = true;
            this.checkBox_DuressAlarm.Location = new System.Drawing.Point(552, 105);
            this.checkBox_DuressAlarm.Name = "checkBox_DuressAlarm";
            this.checkBox_DuressAlarm.Size = new System.Drawing.Size(15, 14);
            this.checkBox_DuressAlarm.TabIndex = 17;
            this.checkBox_DuressAlarm.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "Sensor(门磁)：";
            // 
            // checkBox_Sensor
            // 
            this.checkBox_Sensor.AutoSize = true;
            this.checkBox_Sensor.Location = new System.Drawing.Point(552, 134);
            this.checkBox_Sensor.Name = "checkBox_Sensor";
            this.checkBox_Sensor.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Sensor.TabIndex = 19;
            this.checkBox_Sensor.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(416, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "BreakAlarm(闯入报警)：";
            // 
            // checkBox_BreakAlarm
            // 
            this.checkBox_BreakAlarm.AutoSize = true;
            this.checkBox_BreakAlarm.Location = new System.Drawing.Point(552, 163);
            this.checkBox_BreakAlarm.Name = "checkBox_BreakAlarm";
            this.checkBox_BreakAlarm.Size = new System.Drawing.Size(15, 14);
            this.checkBox_BreakAlarm.TabIndex = 21;
            this.checkBox_BreakAlarm.UseVisualStyleBackColor = true;
            // 
            // btn_Get
            // 
            this.btn_Get.Location = new System.Drawing.Point(168, 271);
            this.btn_Get.Name = "btn_Get";
            this.btn_Get.Size = new System.Drawing.Size(92, 28);
            this.btn_Get.TabIndex = 22;
            this.btn_Get.Text = "Get(获取)";
            this.btn_Get.UseVisualStyleBackColor = true;
            this.btn_Get.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // btn_Set
            // 
            this.btn_Set.Location = new System.Drawing.Point(323, 271);
            this.btn_Set.Name = "btn_Set";
            this.btn_Set.Size = new System.Drawing.Size(92, 28);
            this.btn_Set.TabIndex = 23;
            this.btn_Set.Text = "Set(设置)";
            this.btn_Set.UseVisualStyleBackColor = true;
            this.btn_Set.Click += new System.EventHandler(this.btn_Set_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBox_OpenDoorMethod4);
            this.groupBox1.Controls.Add(this.cmbBox_OpenDoorMethod3);
            this.groupBox1.Controls.Add(this.cmbBox_OpenDoorMethod2);
            this.groupBox1.Controls.Add(this.btn_Confirm);
            this.groupBox1.Controls.Add(this.cmbBox_OpenDoorMethod1);
            this.groupBox1.Controls.Add(this.EndTime4);
            this.groupBox1.Controls.Add(this.EndTime3);
            this.groupBox1.Controls.Add(this.EndTime2);
            this.groupBox1.Controls.Add(this.EndTime1);
            this.groupBox1.Controls.Add(this.StartTime4);
            this.groupBox1.Controls.Add(this.StartTime3);
            this.groupBox1.Controls.Add(this.StartTime2);
            this.groupBox1.Controls.Add(this.StartTime1);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.comboBox_Week);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(593, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 287);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DoorOpenTimeSec(开门时间段)";
            // 
            // cmbBox_OpenDoorMethod4
            // 
            this.cmbBox_OpenDoorMethod4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_OpenDoorMethod4.FormattingEnabled = true;
            this.cmbBox_OpenDoorMethod4.Items.AddRange(new object[] {
            "Unknown(未知)",
            "PwdOnly(仅限密码)",
            "Card(门禁卡)",
            "PwdOrCard(密码或卡)",
            "CardFirst(先刷卡后密码)",
            "PwdFirst(先密码后刷卡)",
            "TimeSection(分时段)",
            "FingerPrintOnly(仅限指纹)",
            "PwdOrCardOrFingerPrint(密码或卡或指纹)",
            "Pwd+Card+FingerPrint(密码+卡+指纹)",
            "Pwd+FingerPrint(密码+指纹)",
            "Card+FingerPrint(卡+指纹)",
            "MultiPerson(多人)"});
            this.cmbBox_OpenDoorMethod4.Location = new System.Drawing.Point(303, 194);
            this.cmbBox_OpenDoorMethod4.Name = "cmbBox_OpenDoorMethod4";
            this.cmbBox_OpenDoorMethod4.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_OpenDoorMethod4.TabIndex = 21;
            // 
            // cmbBox_OpenDoorMethod3
            // 
            this.cmbBox_OpenDoorMethod3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_OpenDoorMethod3.FormattingEnabled = true;
            this.cmbBox_OpenDoorMethod3.Items.AddRange(new object[] {
            "Unknown(未知)",
            "PwdOnly(仅限密码)",
            "Card(门禁卡)",
            "PwdOrCard(密码或卡)",
            "CardFirst(先刷卡后密码)",
            "PwdFirst(先密码后刷卡)",
            "TimeSection(分时段)",
            "FingerPrintOnly(仅限指纹)",
            "PwdOrCardOrFingerPrint(密码或卡或指纹)",
            "Pwd+Card+FingerPrint(密码+卡+指纹)",
            "Pwd+FingerPrint(密码+指纹)",
            "Card+FingerPrint(卡+指纹)",
            "MultiPerson(多人)"});
            this.cmbBox_OpenDoorMethod3.Location = new System.Drawing.Point(303, 167);
            this.cmbBox_OpenDoorMethod3.Name = "cmbBox_OpenDoorMethod3";
            this.cmbBox_OpenDoorMethod3.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_OpenDoorMethod3.TabIndex = 20;
            // 
            // cmbBox_OpenDoorMethod2
            // 
            this.cmbBox_OpenDoorMethod2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_OpenDoorMethod2.FormattingEnabled = true;
            this.cmbBox_OpenDoorMethod2.Items.AddRange(new object[] {
            "Unknown(未知)",
            "PwdOnly(仅限密码)",
            "Card(门禁卡)",
            "PwdOrCard(密码或卡)",
            "CardFirst(先刷卡后密码)",
            "PwdFirst(先密码后刷卡)",
            "TimeSection(分时段)",
            "FingerPrintOnly(仅限指纹)",
            "PwdOrCardOrFingerPrint(密码或卡或指纹)",
            "Pwd+Card+FingerPrint(密码+卡+指纹)",
            "Pwd+FingerPrint(密码+指纹)",
            "Card+FingerPrint(卡+指纹)",
            "MultiPerson(多人)"});
            this.cmbBox_OpenDoorMethod2.Location = new System.Drawing.Point(303, 135);
            this.cmbBox_OpenDoorMethod2.Name = "cmbBox_OpenDoorMethod2";
            this.cmbBox_OpenDoorMethod2.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_OpenDoorMethod2.TabIndex = 19;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(165, 237);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(121, 32);
            this.btn_Confirm.TabIndex = 18;
            this.btn_Confirm.Text = "Confirm(确定)";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // cmbBox_OpenDoorMethod1
            // 
            this.cmbBox_OpenDoorMethod1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox_OpenDoorMethod1.FormattingEnabled = true;
            this.cmbBox_OpenDoorMethod1.Items.AddRange(new object[] {
            "Unknown(未知)",
            "PwdOnly(仅限密码)",
            "Card(门禁卡)",
            "PwdOrCard(密码或卡)",
            "CardFirst(先刷卡后密码)",
            "PwdFirst(先密码后刷卡)",
            "TimeSection(分时段)",
            "FingerPrintOnly(仅限指纹)",
            "PwdOrCardOrFingerPrint(密码或卡或指纹)",
            "Pwd+Card+FingerPrint(密码+卡+指纹)",
            "Pwd+FingerPrint(密码+指纹)",
            "Card+FingerPrint(卡+指纹)",
            "MultiPerson(多人)"});
            this.cmbBox_OpenDoorMethod1.Location = new System.Drawing.Point(303, 104);
            this.cmbBox_OpenDoorMethod1.Name = "cmbBox_OpenDoorMethod1";
            this.cmbBox_OpenDoorMethod1.Size = new System.Drawing.Size(121, 20);
            this.cmbBox_OpenDoorMethod1.TabIndex = 17;
            // 
            // EndTime4
            // 
            this.EndTime4.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndTime4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime4.Location = new System.Drawing.Point(189, 196);
            this.EndTime4.Name = "EndTime4";
            this.EndTime4.ShowUpDown = true;
            this.EndTime4.Size = new System.Drawing.Size(88, 21);
            this.EndTime4.TabIndex = 16;
            // 
            // EndTime3
            // 
            this.EndTime3.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndTime3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime3.Location = new System.Drawing.Point(189, 166);
            this.EndTime3.Name = "EndTime3";
            this.EndTime3.ShowUpDown = true;
            this.EndTime3.Size = new System.Drawing.Size(88, 21);
            this.EndTime3.TabIndex = 15;
            // 
            // EndTime2
            // 
            this.EndTime2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime2.Location = new System.Drawing.Point(189, 135);
            this.EndTime2.Name = "EndTime2";
            this.EndTime2.ShowUpDown = true;
            this.EndTime2.Size = new System.Drawing.Size(88, 21);
            this.EndTime2.TabIndex = 14;
            // 
            // EndTime1
            // 
            this.EndTime1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTime1.Location = new System.Drawing.Point(189, 104);
            this.EndTime1.Name = "EndTime1";
            this.EndTime1.ShowUpDown = true;
            this.EndTime1.Size = new System.Drawing.Size(88, 21);
            this.EndTime1.TabIndex = 13;
            // 
            // StartTime4
            // 
            this.StartTime4.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartTime4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime4.Location = new System.Drawing.Point(90, 197);
            this.StartTime4.Name = "StartTime4";
            this.StartTime4.ShowUpDown = true;
            this.StartTime4.Size = new System.Drawing.Size(88, 21);
            this.StartTime4.TabIndex = 12;
            // 
            // StartTime3
            // 
            this.StartTime3.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartTime3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime3.Location = new System.Drawing.Point(90, 170);
            this.StartTime3.Name = "StartTime3";
            this.StartTime3.ShowUpDown = true;
            this.StartTime3.Size = new System.Drawing.Size(88, 21);
            this.StartTime3.TabIndex = 11;
            // 
            // StartTime2
            // 
            this.StartTime2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartTime2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime2.Location = new System.Drawing.Point(90, 135);
            this.StartTime2.Name = "StartTime2";
            this.StartTime2.ShowUpDown = true;
            this.StartTime2.Size = new System.Drawing.Size(88, 21);
            this.StartTime2.TabIndex = 10;
            // 
            // StartTime1
            // 
            this.StartTime1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartTime1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTime1.Location = new System.Drawing.Point(90, 105);
            this.StartTime1.Name = "StartTime1";
            this.StartTime1.ShowUpDown = true;
            this.StartTime1.Size = new System.Drawing.Size(88, 21);
            this.StartTime1.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 202);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 12);
            this.label19.TabIndex = 8;
            this.label19.Text = "Seg4(时段4)：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 12);
            this.label18.TabIndex = 7;
            this.label18.Text = "Seg3(时段3)：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "Seg2(时段2)：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "Seg1(时段1)：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(292, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "OpenDoorMethod(开门方式)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(179, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "EndTime(结束时间)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "StartTime(开始时间)";
            // 
            // comboBox_Week
            // 
            this.comboBox_Week.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Week.Enabled = false;
            this.comboBox_Week.FormattingEnabled = true;
            this.comboBox_Week.Items.AddRange(new object[] {
            "Sun.(星期日)",
            "Mon.(星期一) ",
            "Tue.(星期二) ",
            "Wed.(星期三) ",
            "Thu.(星期四) ",
            "Fri.(星期五) ",
            "Sat.(星期六) "});
            this.comboBox_Week.Location = new System.Drawing.Point(156, 38);
            this.comboBox_Week.Name = "comboBox_Week";
            this.comboBox_Week.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Week.TabIndex = 1;
            this.comboBox_Week.SelectedIndexChanged += new System.EventHandler(this.comboBox_Week_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(73, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Week(星期)：";
            // 
            // DoorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Set);
            this.Controls.Add(this.btn_Get);
            this.Controls.Add(this.checkBox_BreakAlarm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.checkBox_Sensor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBox_DuressAlarm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBox_NotCloseAlarm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox_RepearAlarm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBox_AccessState);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_HolidayNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_CloseTimeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_UnlockHold);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBox_OpenMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBox_DoorIndex);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoorConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DoorConfig(门配置)";
            this.Load += new System.EventHandler(this.DoorConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBox_DoorIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBox_OpenMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UnlockHold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CloseTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_HolidayNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBox_AccessState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox_RepearAlarm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_NotCloseAlarm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_DuressAlarm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_Sensor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox_BreakAlarm;
        private System.Windows.Forms.Button btn_Get;
        private System.Windows.Forms.Button btn_Set;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.ComboBox cmbBox_OpenDoorMethod1;
        private System.Windows.Forms.DateTimePicker EndTime4;
        private System.Windows.Forms.DateTimePicker EndTime3;
        private System.Windows.Forms.DateTimePicker EndTime2;
        private System.Windows.Forms.DateTimePicker EndTime1;
        private System.Windows.Forms.DateTimePicker StartTime4;
        private System.Windows.Forms.DateTimePicker StartTime3;
        private System.Windows.Forms.DateTimePicker StartTime2;
        private System.Windows.Forms.DateTimePicker StartTime1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox_Week;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBox_OpenDoorMethod4;
        private System.Windows.Forms.ComboBox cmbBox_OpenDoorMethod3;
        private System.Windows.Forms.ComboBox cmbBox_OpenDoorMethod2;
    }
}