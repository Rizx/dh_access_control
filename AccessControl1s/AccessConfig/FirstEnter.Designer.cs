namespace AccessControl1s
{
    partial class FirstEnter
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
            this.comboBox_Channel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_EnableFirst = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TimeIndex = new System.Windows.Forms.TextBox();
            this.button_Set = new System.Windows.Forms.Button();
            this.button_Get = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel(门序号)：";
            // 
            // comboBox_Channel
            // 
            this.comboBox_Channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Channel.FormattingEnabled = true;
            this.comboBox_Channel.Location = new System.Drawing.Point(232, 28);
            this.comboBox_Channel.Name = "comboBox_Channel";
            this.comboBox_Channel.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Channel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "FirstEnter(是否首卡)：";
            // 
            // checkBox_EnableFirst
            // 
            this.checkBox_EnableFirst.AutoSize = true;
            this.checkBox_EnableFirst.Location = new System.Drawing.Point(232, 61);
            this.checkBox_EnableFirst.Name = "checkBox_EnableFirst";
            this.checkBox_EnableFirst.Size = new System.Drawing.Size(15, 14);
            this.checkBox_EnableFirst.TabIndex = 3;
            this.checkBox_EnableFirst.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "FirstEnterStatus(首卡开门状态)：";
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "Unknown(未知)",
            "KeepOpen(保持常开)",
            "Normal(正常状态)"});
            this.comboBox_Status.Location = new System.Drawing.Point(232, 86);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Status.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "FirstEnterTimeIndex(首卡开门时间段)：";
            // 
            // textBox_TimeIndex
            // 
            this.textBox_TimeIndex.Location = new System.Drawing.Point(232, 119);
            this.textBox_TimeIndex.Name = "textBox_TimeIndex";
            this.textBox_TimeIndex.Size = new System.Drawing.Size(100, 21);
            this.textBox_TimeIndex.TabIndex = 7;
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(59, 159);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(90, 31);
            this.button_Set.TabIndex = 8;
            this.button_Set.Text = "Set(设置)";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(188, 159);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(90, 31);
            this.button_Get.TabIndex = 9;
            this.button_Get.Text = "Get(获取)";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // FirstEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 205);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.button_Set);
            this.Controls.Add(this.textBox_TimeIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_EnableFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Channel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FirstEnterOpen(首卡开门)";
            this.Load += new System.EventHandler(this.FirstEnter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Channel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_EnableFirst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TimeIndex;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.Button button_Get;
    }
}