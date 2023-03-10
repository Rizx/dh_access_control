namespace AccessControl1s
{
    partial class UserManagement
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
            this.comboBox_OperateType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_CardNo = new System.Windows.Forms.Label();
            this.label_result = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button_GetUpdate = new System.Windows.Forms.Button();
            this.button_Insert = new System.Windows.Forms.Button();
            this.button_GetPrint = new System.Windows.Forms.Button();
            this.comboBox_FirPrint = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox_First = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker_ValidEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker_ValidStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_UseTimes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_TimeSec = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Door = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_CardPwd = new System.Windows.Forms.TextBox();
            this.comboBox_CardType = new System.Windows.Forms.ComboBox();
            this.comboBox_CardStatus = new System.Windows.Forms.ComboBox();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.textBox_CardNo = new System.Windows.Forms.TextBox();
            this.dateTimePicker_CreateTime = new System.Windows.Forms.DateTimePicker();
            this.textBox_RecNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OperateType);
            this.groupBox1.Location = new System.Drawing.Point(20, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(813, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Type";
            // 
            // comboBox_OperateType
            // 
            this.comboBox_OperateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OperateType.FormattingEnabled = true;
            this.comboBox_OperateType.Items.AddRange(new object[] {
            "Insert",
            "Get",
            "Update",
            "Remove",
            "Clear"});
            this.comboBox_OperateType.Location = new System.Drawing.Point(165, 52);
            this.comboBox_OperateType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_OperateType.Name = "comboBox_OperateType";
            this.comboBox_OperateType.Size = new System.Drawing.Size(283, 28);
            this.comboBox_OperateType.TabIndex = 0;
            this.comboBox_OperateType.SelectedIndexChanged += new System.EventHandler(this.comboBox_OperateType_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_CardNo);
            this.groupBox2.Controls.Add(this.label_result);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.button_GetUpdate);
            this.groupBox2.Controls.Add(this.button_Insert);
            this.groupBox2.Controls.Add(this.button_GetPrint);
            this.groupBox2.Controls.Add(this.comboBox_FirPrint);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.checkBox_First);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dateTimePicker_ValidEnd);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dateTimePicker_ValidStart);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox_UseTimes);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button_TimeSec);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button_Door);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_CardPwd);
            this.groupBox2.Controls.Add(this.comboBox_CardType);
            this.groupBox2.Controls.Add(this.comboBox_CardStatus);
            this.groupBox2.Controls.Add(this.textBox_UserID);
            this.groupBox2.Controls.Add(this.textBox_CardNo);
            this.groupBox2.Controls.Add(this.dateTimePicker_CreateTime);
            this.groupBox2.Controls.Add(this.textBox_RecNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(20, 148);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(813, 902);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label_CardNo
            // 
            this.label_CardNo.AutoSize = true;
            this.label_CardNo.Location = new System.Drawing.Point(598, 155);
            this.label_CardNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_CardNo.Name = "label_CardNo";
            this.label_CardNo.Size = new System.Drawing.Size(60, 20);
            this.label_CardNo.TabIndex = 33;
            this.label_CardNo.Text = "label16";
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(312, 763);
            this.label_result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(42, 20);
            this.label_result.TabIndex = 32;
            this.label_result.Text = "lable";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(458, 155);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Hex";
            // 
            // button_GetUpdate
            // 
            this.button_GetUpdate.Location = new System.Drawing.Point(234, 810);
            this.button_GetUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_GetUpdate.Name = "button_GetUpdate";
            this.button_GetUpdate.Size = new System.Drawing.Size(158, 50);
            this.button_GetUpdate.TabIndex = 30;
            this.button_GetUpdate.Text = "Get";
            this.button_GetUpdate.UseVisualStyleBackColor = true;
            this.button_GetUpdate.Click += new System.EventHandler(this.button_GetUpdate_Click);
            // 
            // button_Insert
            // 
            this.button_Insert.Location = new System.Drawing.Point(422, 810);
            this.button_Insert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(158, 50);
            this.button_Insert.TabIndex = 29;
            this.button_Insert.Text = "Insert";
            this.button_Insert.UseVisualStyleBackColor = true;
            this.button_Insert.Click += new System.EventHandler(this.button_Insert_Click);
            // 
            // button_GetPrint
            // 
            this.button_GetPrint.Location = new System.Drawing.Point(422, 708);
            this.button_GetPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_GetPrint.Name = "button_GetPrint";
            this.button_GetPrint.Size = new System.Drawing.Size(112, 38);
            this.button_GetPrint.TabIndex = 28;
            this.button_GetPrint.Text = "Get";
            this.button_GetPrint.UseVisualStyleBackColor = true;
            this.button_GetPrint.Click += new System.EventHandler(this.button_GetPrint_Click);
            // 
            // comboBox_FirPrint
            // 
            this.comboBox_FirPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FirPrint.FormattingEnabled = true;
            this.comboBox_FirPrint.Items.AddRange(new object[] {
            "指纹1",
            "指纹2"});
            this.comboBox_FirPrint.Location = new System.Drawing.Point(300, 708);
            this.comboBox_FirPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_FirPrint.Name = "comboBox_FirPrint";
            this.comboBox_FirPrint.Size = new System.Drawing.Size(110, 28);
            this.comboBox_FirPrint.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(40, 717);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 26;
            this.label14.Text = "FingerPrint：";
            // 
            // checkBox_First
            // 
            this.checkBox_First.AutoSize = true;
            this.checkBox_First.Location = new System.Drawing.Point(300, 662);
            this.checkBox_First.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_First.Name = "checkBox_First";
            this.checkBox_First.Size = new System.Drawing.Size(22, 21);
            this.checkBox_First.TabIndex = 25;
            this.checkBox_First.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 662);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "FirstEnter：";
            // 
            // dateTimePicker_ValidEnd
            // 
            this.dateTimePicker_ValidEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_ValidEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ValidEnd.Location = new System.Drawing.Point(300, 608);
            this.dateTimePicker_ValidEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_ValidEnd.Name = "dateTimePicker_ValidEnd";
            this.dateTimePicker_ValidEnd.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker_ValidEnd.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 615);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "ValidDateEnd";
            // 
            // dateTimePicker_ValidStart
            // 
            this.dateTimePicker_ValidStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_ValidStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_ValidStart.Location = new System.Drawing.Point(300, 553);
            this.dateTimePicker_ValidStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_ValidStart.Name = "dateTimePicker_ValidStart";
            this.dateTimePicker_ValidStart.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker_ValidStart.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 562);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "ValidDateStart";
            // 
            // textBox_UseTimes
            // 
            this.textBox_UseTimes.Location = new System.Drawing.Point(300, 502);
            this.textBox_UseTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_UseTimes.Name = "textBox_UseTimes";
            this.textBox_UseTimes.Size = new System.Drawing.Size(148, 26);
            this.textBox_UseTimes.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 512);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "UseTime：";
            // 
            // button_TimeSec
            // 
            this.button_TimeSec.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_TimeSec.Location = new System.Drawing.Point(300, 443);
            this.button_TimeSec.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_TimeSec.Name = "button_TimeSec";
            this.button_TimeSec.Size = new System.Drawing.Size(112, 38);
            this.button_TimeSec.TabIndex = 17;
            this.button_TimeSec.Text = "···";
            this.button_TimeSec.UseVisualStyleBackColor = true;
            this.button_TimeSec.Click += new System.EventHandler(this.button_TimeSec_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 455);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "TimeSection：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 405);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Doors：";
            // 
            // button_Door
            // 
            this.button_Door.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Door.Location = new System.Drawing.Point(300, 392);
            this.button_Door.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Door.Name = "button_Door";
            this.button_Door.Size = new System.Drawing.Size(112, 38);
            this.button_Door.TabIndex = 14;
            this.button_Door.Text = "···";
            this.button_Door.UseVisualStyleBackColor = true;
            this.button_Door.Click += new System.EventHandler(this.button_Door_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 355);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "CardPassword：";
            // 
            // textBox_CardPwd
            // 
            this.textBox_CardPwd.Location = new System.Drawing.Point(300, 343);
            this.textBox_CardPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_CardPwd.Name = "textBox_CardPwd";
            this.textBox_CardPwd.Size = new System.Drawing.Size(148, 26);
            this.textBox_CardPwd.TabIndex = 12;
            this.textBox_CardPwd.UseSystemPasswordChar = true;
            // 
            // comboBox_CardType
            // 
            this.comboBox_CardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CardType.FormattingEnabled = true;
            this.comboBox_CardType.Items.AddRange(new object[] {
            "Unknown",
            "General",
            "VIP",
            "Guest",
            "Patrol",
            "BlackList",
            "Duress",
            "MotherCard"});
            this.comboBox_CardType.Location = new System.Drawing.Point(300, 297);
            this.comboBox_CardType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_CardType.Name = "comboBox_CardType";
            this.comboBox_CardType.Size = new System.Drawing.Size(180, 28);
            this.comboBox_CardType.TabIndex = 11;
            // 
            // comboBox_CardStatus
            // 
            this.comboBox_CardStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CardStatus.FormattingEnabled = true;
            this.comboBox_CardStatus.Items.AddRange(new object[] {
            "Unknown",
            "Normal",
            "Lose",
            "LogOff",
            "Freeze"});
            this.comboBox_CardStatus.Location = new System.Drawing.Point(300, 250);
            this.comboBox_CardStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_CardStatus.Name = "comboBox_CardStatus";
            this.comboBox_CardStatus.Size = new System.Drawing.Size(180, 28);
            this.comboBox_CardStatus.TabIndex = 10;
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(300, 197);
            this.textBox_UserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(148, 26);
            this.textBox_UserID.TabIndex = 9;
            // 
            // textBox_CardNo
            // 
            this.textBox_CardNo.Location = new System.Drawing.Point(300, 148);
            this.textBox_CardNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_CardNo.Name = "textBox_CardNo";
            this.textBox_CardNo.Size = new System.Drawing.Size(148, 26);
            this.textBox_CardNo.TabIndex = 8;
            // 
            // dateTimePicker_CreateTime
            // 
            this.dateTimePicker_CreateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_CreateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_CreateTime.Location = new System.Drawing.Point(300, 92);
            this.dateTimePicker_CreateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_CreateTime.Name = "dateTimePicker_CreateTime";
            this.dateTimePicker_CreateTime.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker_CreateTime.TabIndex = 7;
            // 
            // textBox_RecNo
            // 
            this.textBox_RecNo.Location = new System.Drawing.Point(300, 45);
            this.textBox_RecNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_RecNo.Name = "textBox_RecNo";
            this.textBox_RecNo.Size = new System.Drawing.Size(148, 26);
            this.textBox_RecNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 303);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "CardType：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "CardStatus：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "UserID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "CardNo：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CreateTime：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "RecNo：";
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 1050);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserManagement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_RecNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_OperateType;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.Button button_GetPrint;
        private System.Windows.Forms.ComboBox comboBox_FirPrint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox_First;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ValidEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ValidStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_UseTimes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_TimeSec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Door;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_CardPwd;
        private System.Windows.Forms.ComboBox comboBox_CardType;
        private System.Windows.Forms.ComboBox comboBox_CardStatus;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.TextBox textBox_CardNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_CreateTime;
        private System.Windows.Forms.Button button_GetUpdate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Label label_CardNo;
    }
}