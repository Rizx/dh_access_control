namespace AccessControl1s
{
    partial class DoorRecord
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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_StartQuery = new System.Windows.Forms.Button();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.btn_GetRecordCount = new System.Windows.Forms.Button();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.btn_NextFind = new System.Windows.Forms.Button();
            this.listView_DoorRecord = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "StartTime(开始时间)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "EndTime(结束时间)：";
            // 
            // btn_StartQuery
            // 
            this.btn_StartQuery.Location = new System.Drawing.Point(17, 81);
            this.btn_StartQuery.Name = "btn_StartQuery";
            this.btn_StartQuery.Size = new System.Drawing.Size(151, 28);
            this.btn_StartQuery.TabIndex = 2;
            this.btn_StartQuery.Text = "StartQuery(开始查询)";
            this.btn_StartQuery.UseVisualStyleBackColor = true;
            this.btn_StartQuery.Click += new System.EventHandler(this.btn_StartQuery_Click);
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Start.Location = new System.Drawing.Point(138, 26);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_Start.TabIndex = 40;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_End.Location = new System.Drawing.Point(138, 53);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker_End.TabIndex = 40;
            // 
            // btn_GetRecordCount
            // 
            this.btn_GetRecordCount.Location = new System.Drawing.Point(185, 80);
            this.btn_GetRecordCount.Name = "btn_GetRecordCount";
            this.btn_GetRecordCount.Size = new System.Drawing.Size(181, 28);
            this.btn_GetRecordCount.TabIndex = 5;
            this.btn_GetRecordCount.Text = "GetRecordCount(获取记录条数)";
            this.btn_GetRecordCount.UseVisualStyleBackColor = true;
            this.btn_GetRecordCount.Click += new System.EventHandler(this.btn_GetRecordCount_Click);
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(372, 84);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.ReadOnly = true;
            this.textBox_Count.Size = new System.Drawing.Size(100, 21);
            this.textBox_Count.TabIndex = 6;
            // 
            // btn_NextFind
            // 
            this.btn_NextFind.Location = new System.Drawing.Point(17, 111);
            this.btn_NextFind.Name = "btn_NextFind";
            this.btn_NextFind.Size = new System.Drawing.Size(127, 28);
            this.btn_NextFind.TabIndex = 7;
            this.btn_NextFind.Text = "NextPage(下一页)";
            this.btn_NextFind.UseVisualStyleBackColor = true;
            this.btn_NextFind.Click += new System.EventHandler(this.btn_NextFind_Click);
            // 
            // listView_DoorRecord
            // 
            this.listView_DoorRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView_DoorRecord.FullRowSelect = true;
            this.listView_DoorRecord.GridLines = true;
            this.listView_DoorRecord.Location = new System.Drawing.Point(17, 160);
            this.listView_DoorRecord.Name = "listView_DoorRecord";
            this.listView_DoorRecord.Size = new System.Drawing.Size(684, 281);
            this.listView_DoorRecord.TabIndex = 8;
            this.listView_DoorRecord.UseCompatibleStateImageBehavior = false;
            this.listView_DoorRecord.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.(编号)";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time(时间)";
            this.columnHeader2.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CardNo.(卡号)";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State(状态)";
            this.columnHeader4.Width = 99;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Door(门)";
            this.columnHeader5.Width = 108;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type(验证方式)";
            this.columnHeader6.Width = 126;
            // 
            // DoorRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 454);
            this.Controls.Add(this.listView_DoorRecord);
            this.Controls.Add(this.btn_NextFind);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.btn_GetRecordCount);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Start);
            this.Controls.Add(this.btn_StartQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoorRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DoorRecord(开门记录)";
            this.Load += new System.EventHandler(this.DoorRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_StartQuery;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Button btn_GetRecordCount;
        private System.Windows.Forms.TextBox textBox_Count;
        private System.Windows.Forms.Button btn_NextFind;
        private System.Windows.Forms.ListView listView_DoorRecord;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}