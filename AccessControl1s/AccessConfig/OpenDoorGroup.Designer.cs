namespace AccessControl1s
{
    partial class OpenDoorGroup
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
            this.comboBox_Door = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_OpenMethod1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_UserID1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_UserNo1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_OpenNum1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_OpenMethod3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_UserID3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_UserNo3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_OpenNum3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBox_OpenMethod2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_UserID2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_UserNo2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_OpenNum2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox_OpenMethod4 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_UserID4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_UserNo4 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_OpenNum4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button_Set = new System.Windows.Forms.Button();
            this.button_Get = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Door(门)";
            // 
            // comboBox_Door
            // 
            this.comboBox_Door.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Door.FormattingEnabled = true;
            this.comboBox_Door.Location = new System.Drawing.Point(150, 26);
            this.comboBox_Door.Name = "comboBox_Door";
            this.comboBox_Door.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Door.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox_OpenNum1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 187);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Group1(组1)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_OpenMethod1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_UserID1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBox_UserNo1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 136);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UserInfo(用户信息)";
            // 
            // comboBox_OpenMethod1
            // 
            this.comboBox_OpenMethod1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpenMethod1.FormattingEnabled = true;
            this.comboBox_OpenMethod1.Items.AddRange(new object[] {
            "Unknown(未知)",
            "Card(门禁卡)",
            "FingerPrint(指纹)",
            "Password(密码)"});
            this.comboBox_OpenMethod1.Location = new System.Drawing.Point(181, 73);
            this.comboBox_OpenMethod1.Name = "comboBox_OpenMethod1";
            this.comboBox_OpenMethod1.Size = new System.Drawing.Size(109, 20);
            this.comboBox_OpenMethod1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "OpenDoorMethod(开门方式)：";
            // 
            // textBox_UserID1
            // 
            this.textBox_UserID1.Location = new System.Drawing.Point(181, 45);
            this.textBox_UserID1.Name = "textBox_UserID1";
            this.textBox_UserID1.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserID1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "UserID(用户编号)：";
            // 
            // comboBox_UserNo1
            // 
            this.comboBox_UserNo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserNo1.FormattingEnabled = true;
            this.comboBox_UserNo1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49"});
            this.comboBox_UserNo1.Location = new System.Drawing.Point(181, 15);
            this.comboBox_UserNo1.Name = "comboBox_UserNo1";
            this.comboBox_UserNo1.Size = new System.Drawing.Size(109, 20);
            this.comboBox_UserNo1.TabIndex = 1;
            this.comboBox_UserNo1.SelectedIndexChanged += new System.EventHandler(this.comboBox_UserNo1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "UserNO(用户序号)：";
            // 
            // textBox_OpenNum1
            // 
            this.textBox_OpenNum1.Location = new System.Drawing.Point(187, 20);
            this.textBox_OpenNum1.Name = "textBox_OpenNum1";
            this.textBox_OpenNum1.Size = new System.Drawing.Size(100, 21);
            this.textBox_OpenNum1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserOpenNum(有效开门用户数)：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.textBox_OpenNum3);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 187);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group3(组3)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox_OpenMethod3);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textBox_UserID3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.comboBox_UserNo3);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(6, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 136);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "UserInfo(用户信息)";
            // 
            // comboBox_OpenMethod3
            // 
            this.comboBox_OpenMethod3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpenMethod3.FormattingEnabled = true;
            this.comboBox_OpenMethod3.Items.AddRange(new object[] {
            "Unknown(未知)",
            "Card(门禁卡)",
            "FingerPrint(指纹)",
            "Password(密码)"});
            this.comboBox_OpenMethod3.Location = new System.Drawing.Point(181, 73);
            this.comboBox_OpenMethod3.Name = "comboBox_OpenMethod3";
            this.comboBox_OpenMethod3.Size = new System.Drawing.Size(109, 20);
            this.comboBox_OpenMethod3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "OpenDoorMethod(开门方式)：";
            // 
            // textBox_UserID3
            // 
            this.textBox_UserID3.Location = new System.Drawing.Point(181, 45);
            this.textBox_UserID3.Name = "textBox_UserID3";
            this.textBox_UserID3.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserID3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "UserID(用户编号)：";
            // 
            // comboBox_UserNo3
            // 
            this.comboBox_UserNo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserNo3.FormattingEnabled = true;
            this.comboBox_UserNo3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49"});
            this.comboBox_UserNo3.Location = new System.Drawing.Point(181, 15);
            this.comboBox_UserNo3.Name = "comboBox_UserNo3";
            this.comboBox_UserNo3.Size = new System.Drawing.Size(109, 20);
            this.comboBox_UserNo3.TabIndex = 1;
            this.comboBox_UserNo3.SelectedIndexChanged += new System.EventHandler(this.comboBox_UserNo3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "UserNO(用户序号)：";
            // 
            // textBox_OpenNum3
            // 
            this.textBox_OpenNum3.Location = new System.Drawing.Point(187, 18);
            this.textBox_OpenNum3.Name = "textBox_OpenNum3";
            this.textBox_OpenNum3.Size = new System.Drawing.Size(100, 21);
            this.textBox_OpenNum3.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "UserOpenNum(有效开门用户数)：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.textBox_OpenNum2);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(338, 52);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(308, 187);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Group2(组2)";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox_OpenMethod2);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.textBox_UserID2);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.comboBox_UserNo2);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(6, 45);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(296, 136);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "UserInfo(用户信息)";
            // 
            // comboBox_OpenMethod2
            // 
            this.comboBox_OpenMethod2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpenMethod2.FormattingEnabled = true;
            this.comboBox_OpenMethod2.Items.AddRange(new object[] {
            "Unknown(未知)",
            "Card(门禁卡)",
            "FingerPrint(指纹)",
            "Password(密码)"});
            this.comboBox_OpenMethod2.Location = new System.Drawing.Point(181, 73);
            this.comboBox_OpenMethod2.Name = "comboBox_OpenMethod2";
            this.comboBox_OpenMethod2.Size = new System.Drawing.Size(109, 20);
            this.comboBox_OpenMethod2.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "OpenDoorMethod(开门方式)：";
            // 
            // textBox_UserID2
            // 
            this.textBox_UserID2.Location = new System.Drawing.Point(181, 45);
            this.textBox_UserID2.Name = "textBox_UserID2";
            this.textBox_UserID2.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserID2.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "UserID(用户编号)：";
            // 
            // comboBox_UserNo2
            // 
            this.comboBox_UserNo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserNo2.FormattingEnabled = true;
            this.comboBox_UserNo2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49"});
            this.comboBox_UserNo2.Location = new System.Drawing.Point(181, 15);
            this.comboBox_UserNo2.Name = "comboBox_UserNo2";
            this.comboBox_UserNo2.Size = new System.Drawing.Size(109, 20);
            this.comboBox_UserNo2.TabIndex = 1;
            this.comboBox_UserNo2.SelectedIndexChanged += new System.EventHandler(this.comboBox_UserNo2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "UserNO(用户序号)：";
            // 
            // textBox_OpenNum2
            // 
            this.textBox_OpenNum2.Location = new System.Drawing.Point(187, 21);
            this.textBox_OpenNum2.Name = "textBox_OpenNum2";
            this.textBox_OpenNum2.Size = new System.Drawing.Size(100, 21);
            this.textBox_OpenNum2.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "UserOpenNum(有效开门用户数)：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.textBox_OpenNum4);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Location = new System.Drawing.Point(338, 245);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(308, 187);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Group4(组4)";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox_OpenMethod4);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.textBox_UserID4);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.comboBox_UserNo4);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Location = new System.Drawing.Point(6, 45);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(296, 136);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "UserInfo(用户信息)";
            // 
            // comboBox_OpenMethod4
            // 
            this.comboBox_OpenMethod4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OpenMethod4.FormattingEnabled = true;
            this.comboBox_OpenMethod4.Items.AddRange(new object[] {
            "Unknown(未知)",
            "Card(门禁卡)",
            "FingerPrint(指纹)",
            "Password(密码)"});
            this.comboBox_OpenMethod4.Location = new System.Drawing.Point(181, 73);
            this.comboBox_OpenMethod4.Name = "comboBox_OpenMethod4";
            this.comboBox_OpenMethod4.Size = new System.Drawing.Size(109, 20);
            this.comboBox_OpenMethod4.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "OpenDoorMethod(开门方式)：";
            // 
            // textBox_UserID4
            // 
            this.textBox_UserID4.Location = new System.Drawing.Point(181, 45);
            this.textBox_UserID4.Name = "textBox_UserID4";
            this.textBox_UserID4.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserID4.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "UserID(用户编号)：";
            // 
            // comboBox_UserNo4
            // 
            this.comboBox_UserNo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserNo4.FormattingEnabled = true;
            this.comboBox_UserNo4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49"});
            this.comboBox_UserNo4.Location = new System.Drawing.Point(181, 15);
            this.comboBox_UserNo4.Name = "comboBox_UserNo4";
            this.comboBox_UserNo4.Size = new System.Drawing.Size(109, 20);
            this.comboBox_UserNo4.TabIndex = 1;
            this.comboBox_UserNo4.SelectedIndexChanged += new System.EventHandler(this.comboBox_UserNo4_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "UserNO(用户序号)：";
            // 
            // textBox_OpenNum4
            // 
            this.textBox_OpenNum4.Location = new System.Drawing.Point(187, 18);
            this.textBox_OpenNum4.Name = "textBox_OpenNum4";
            this.textBox_OpenNum4.Size = new System.Drawing.Size(100, 21);
            this.textBox_OpenNum4.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(179, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "UserOpenNum(有效开门用户数)：";
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(425, 446);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(85, 30);
            this.button_Set.TabIndex = 6;
            this.button_Set.Text = "Set(设置)";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(530, 446);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(85, 30);
            this.button_Get.TabIndex = 7;
            this.button_Get.Text = "Get(获取)";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // OpenDoorGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 490);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.button_Set);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox_Door);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenDoorGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OpenDoorGroup(多人组合开门)";
            this.Load += new System.EventHandler(this.OpenDoorGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Door;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_OpenMethod1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_UserID1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_UserNo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_OpenNum1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_OpenMethod3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_UserID3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_UserNo3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_OpenNum3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBox_OpenMethod2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_UserID2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_UserNo2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_OpenNum2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox comboBox_OpenMethod4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_UserID4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_UserNo4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_OpenNum4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.Button button_Get;
    }
}