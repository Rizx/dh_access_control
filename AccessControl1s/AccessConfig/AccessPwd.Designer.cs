namespace AccessControl1s
{
    partial class AccessPwd
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
            this.button_Operate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Get = new System.Windows.Forms.Button();
            this.button_Doors = new System.Windows.Forms.Button();
            this.textBox_OpenPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_RecNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_OperateType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OperateType(操作类型)";
            // 
            // comboBox_OperateType
            // 
            this.comboBox_OperateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OperateType.FormattingEnabled = true;
            this.comboBox_OperateType.Items.AddRange(new object[] {
            "Insert(添加)",
            "Get(获取)",
            "Update(更新)",
            "Remove(移除)",
            "Clear(清除)"});
            this.comboBox_OperateType.Location = new System.Drawing.Point(98, 33);
            this.comboBox_OperateType.Name = "comboBox_OperateType";
            this.comboBox_OperateType.Size = new System.Drawing.Size(121, 20);
            this.comboBox_OperateType.TabIndex = 0;
            this.comboBox_OperateType.SelectedIndexChanged += new System.EventHandler(this.comboBox_OperateType_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Operate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_Get);
            this.groupBox2.Controls.Add(this.button_Doors);
            this.groupBox2.Controls.Add(this.textBox_OpenPwd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_UserID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_RecNo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info(信息)";
            // 
            // button_Operate
            // 
            this.button_Operate.Location = new System.Drawing.Point(215, 161);
            this.button_Operate.Name = "button_Operate";
            this.button_Operate.Size = new System.Drawing.Size(85, 23);
            this.button_Operate.TabIndex = 9;
            this.button_Operate.Text = "Insert(添加)";
            this.button_Operate.UseVisualStyleBackColor = true;
            this.button_Operate.Click += new System.EventHandler(this.button_Operate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Doors(门)：";
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(114, 161);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(85, 23);
            this.button_Get.TabIndex = 7;
            this.button_Get.Text = "Get(获取)";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // button_Doors
            // 
            this.button_Doors.Location = new System.Drawing.Point(144, 108);
            this.button_Doors.Name = "button_Doors";
            this.button_Doors.Size = new System.Drawing.Size(75, 23);
            this.button_Doors.TabIndex = 6;
            this.button_Doors.Text = "...";
            this.button_Doors.UseVisualStyleBackColor = true;
            this.button_Doors.Click += new System.EventHandler(this.button_Doors_Click);
            // 
            // textBox_OpenPwd
            // 
            this.textBox_OpenPwd.Location = new System.Drawing.Point(144, 81);
            this.textBox_OpenPwd.Name = "textBox_OpenPwd";
            this.textBox_OpenPwd.Size = new System.Drawing.Size(100, 21);
            this.textBox_OpenPwd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "DoorOpenPwd(开门密码)：";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(144, 52);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "UserID(用户编号)：";
            // 
            // textBox_RecNo
            // 
            this.textBox_RecNo.Location = new System.Drawing.Point(144, 25);
            this.textBox_RecNo.Name = "textBox_RecNo";
            this.textBox_RecNo.Size = new System.Drawing.Size(100, 21);
            this.textBox_RecNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "RecNo(记录集序号)：";
            // 
            // AccessPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccessPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AccessPassword(开门密码)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_OperateType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Operate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Button button_Doors;
        private System.Windows.Forms.TextBox textBox_OpenPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_RecNo;
        private System.Windows.Forms.Label label1;
    }
}