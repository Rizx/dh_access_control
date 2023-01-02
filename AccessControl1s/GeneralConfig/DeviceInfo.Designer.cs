namespace AccessControl1s
{
    partial class DeviceInfo
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
            this.groupBox_Caps = new System.Windows.Forms.GroupBox();
            this.textBox_Caps = new System.Windows.Forms.TextBox();
            this.groupBox_Version = new System.Windows.Forms.GroupBox();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.button_Query = new System.Windows.Forms.Button();
            this.groupBox_Caps.SuspendLayout();
            this.groupBox_Version.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Caps
            // 
            this.groupBox_Caps.Controls.Add(this.textBox_Caps);
            this.groupBox_Caps.Location = new System.Drawing.Point(23, 30);
            this.groupBox_Caps.Name = "groupBox_Caps";
            this.groupBox_Caps.Size = new System.Drawing.Size(328, 289);
            this.groupBox_Caps.TabIndex = 0;
            this.groupBox_Caps.TabStop = false;
            this.groupBox_Caps.Text = "Capability(能力)";
            // 
            // textBox_Caps
            // 
            this.textBox_Caps.Location = new System.Drawing.Point(6, 20);
            this.textBox_Caps.Multiline = true;
            this.textBox_Caps.Name = "textBox_Caps";
            this.textBox_Caps.ReadOnly = true;
            this.textBox_Caps.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Caps.Size = new System.Drawing.Size(316, 263);
            this.textBox_Caps.TabIndex = 0;
            // 
            // groupBox_Version
            // 
            this.groupBox_Version.Controls.Add(this.textBox_Version);
            this.groupBox_Version.Location = new System.Drawing.Point(397, 30);
            this.groupBox_Version.Name = "groupBox_Version";
            this.groupBox_Version.Size = new System.Drawing.Size(324, 283);
            this.groupBox_Version.TabIndex = 1;
            this.groupBox_Version.TabStop = false;
            this.groupBox_Version.Text = "Version(版本)";
            // 
            // textBox_Version
            // 
            this.textBox_Version.Location = new System.Drawing.Point(7, 20);
            this.textBox_Version.Multiline = true;
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.ReadOnly = true;
            this.textBox_Version.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Version.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Version.Size = new System.Drawing.Size(311, 257);
            this.textBox_Version.TabIndex = 1;
            // 
            // button_Query
            // 
            this.button_Query.Location = new System.Drawing.Point(564, 338);
            this.button_Query.Name = "button_Query";
            this.button_Query.Size = new System.Drawing.Size(96, 37);
            this.button_Query.TabIndex = 2;
            this.button_Query.Text = "Query(获取)";
            this.button_Query.UseVisualStyleBackColor = true;
            this.button_Query.Click += new System.EventHandler(this.button_Query_Click);
            // 
            // DeviceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 396);
            this.Controls.Add(this.button_Query);
            this.Controls.Add(this.groupBox_Version);
            this.Controls.Add(this.groupBox_Caps);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeviceInfo(设备信息)";
            this.Load += new System.EventHandler(this.DeviceInfo_Load);
            this.groupBox_Caps.ResumeLayout(false);
            this.groupBox_Caps.PerformLayout();
            this.groupBox_Version.ResumeLayout(false);
            this.groupBox_Version.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Caps;
        private System.Windows.Forms.GroupBox groupBox_Version;
        private System.Windows.Forms.Button button_Query;
        private System.Windows.Forms.TextBox textBox_Caps;
        private System.Windows.Forms.TextBox textBox_Version;
    }
}