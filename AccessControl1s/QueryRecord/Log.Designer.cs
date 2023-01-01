namespace AccessControl1s
{
    partial class Log
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
            this.listView_Log = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_NextLog = new System.Windows.Forms.Button();
            this.textBox_LogCount = new System.Windows.Forms.TextBox();
            this.btn_GetLogCount = new System.Windows.Forms.Button();
            this.btn_StartQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Log
            // 
            this.listView_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_Log.FullRowSelect = true;
            this.listView_Log.GridLines = true;
            this.listView_Log.Location = new System.Drawing.Point(7, 106);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.Size = new System.Drawing.Size(684, 281);
            this.listView_Log.TabIndex = 45;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.(编号)";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time(时间)";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "UserName(用户名)";
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type(类型)";
            this.columnHeader4.Width = 99;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Content(内容)";
            this.columnHeader5.Width = 280;
            // 
            // btn_NextLog
            // 
            this.btn_NextLog.Location = new System.Drawing.Point(8, 58);
            this.btn_NextLog.Name = "btn_NextLog";
            this.btn_NextLog.Size = new System.Drawing.Size(127, 28);
            this.btn_NextLog.TabIndex = 44;
            this.btn_NextLog.Text = "NextPage(下一页)";
            this.btn_NextLog.UseVisualStyleBackColor = true;
            this.btn_NextLog.Click += new System.EventHandler(this.btn_NextQuery_Click);
            // 
            // textBox_LogCount
            // 
            this.textBox_LogCount.Location = new System.Drawing.Point(363, 31);
            this.textBox_LogCount.Name = "textBox_LogCount";
            this.textBox_LogCount.ReadOnly = true;
            this.textBox_LogCount.Size = new System.Drawing.Size(100, 21);
            this.textBox_LogCount.TabIndex = 43;
            // 
            // btn_GetLogCount
            // 
            this.btn_GetLogCount.Location = new System.Drawing.Point(176, 27);
            this.btn_GetLogCount.Name = "btn_GetLogCount";
            this.btn_GetLogCount.Size = new System.Drawing.Size(181, 28);
            this.btn_GetLogCount.TabIndex = 42;
            this.btn_GetLogCount.Text = "GetRecordCount(获取记录条数)";
            this.btn_GetLogCount.UseVisualStyleBackColor = true;
            this.btn_GetLogCount.Click += new System.EventHandler(this.btn_GetLogCount_Click);
            // 
            // btn_StartQuery
            // 
            this.btn_StartQuery.Location = new System.Drawing.Point(8, 28);
            this.btn_StartQuery.Name = "btn_StartQuery";
            this.btn_StartQuery.Size = new System.Drawing.Size(151, 28);
            this.btn_StartQuery.TabIndex = 41;
            this.btn_StartQuery.Text = "StartQuery(开始查询)";
            this.btn_StartQuery.UseVisualStyleBackColor = true;
            this.btn_StartQuery.Click += new System.EventHandler(this.btn_StartQuery_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 395);
            this.Controls.Add(this.listView_Log);
            this.Controls.Add(this.btn_NextLog);
            this.Controls.Add(this.textBox_LogCount);
            this.Controls.Add(this.btn_GetLogCount);
            this.Controls.Add(this.btn_StartQuery);
            this.Name = "Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log(日志)";
            this.Load += new System.EventHandler(this.Log_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btn_NextLog;
        private System.Windows.Forms.TextBox textBox_LogCount;
        private System.Windows.Forms.Button btn_GetLogCount;
        private System.Windows.Forms.Button btn_StartQuery;
    }
}