namespace AccessControl1s
{
    partial class Network
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
            this.groupBox_DevNet = new System.Windows.Forms.GroupBox();
            this.textBox_GateWay = new System.Windows.Forms.TextBox();
            this.textBox_Mask = new System.Windows.Forms.TextBox();
            this.textBox_IPNet = new System.Windows.Forms.TextBox();
            this.button_GetNet = new System.Windows.Forms.Button();
            this.button_SetNet = new System.Windows.Forms.Button();
            this.label_GateWay = new System.Windows.Forms.Label();
            this.label_Mask = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            this.groupBox_AutoRegisterCfg = new System.Windows.Forms.GroupBox();
            this.textBox_DvripIP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_DevID = new System.Windows.Forms.TextBox();
            this.button_GetAutoCfg = new System.Windows.Forms.Button();
            this.button_SetAutoCfg = new System.Windows.Forms.Button();
            this.label_IPAutoRegister = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_DevID = new System.Windows.Forms.Label();
            this.checkBox_Enable = new System.Windows.Forms.CheckBox();
            this.label_Enable = new System.Windows.Forms.Label();
            this.groupBox_DevNet.SuspendLayout();
            this.groupBox_AutoRegisterCfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_DevNet
            // 
            this.groupBox_DevNet.Controls.Add(this.textBox_GateWay);
            this.groupBox_DevNet.Controls.Add(this.textBox_Mask);
            this.groupBox_DevNet.Controls.Add(this.textBox_IPNet);
            this.groupBox_DevNet.Controls.Add(this.button_GetNet);
            this.groupBox_DevNet.Controls.Add(this.button_SetNet);
            this.groupBox_DevNet.Controls.Add(this.label_GateWay);
            this.groupBox_DevNet.Controls.Add(this.label_Mask);
            this.groupBox_DevNet.Controls.Add(this.label_IP);
            this.groupBox_DevNet.Location = new System.Drawing.Point(21, 12);
            this.groupBox_DevNet.Name = "groupBox_DevNet";
            this.groupBox_DevNet.Size = new System.Drawing.Size(334, 166);
            this.groupBox_DevNet.TabIndex = 0;
            this.groupBox_DevNet.TabStop = false;
            this.groupBox_DevNet.Text = "DevNet(设备网络)";
            // 
            // textBox_GateWay
            // 
            this.textBox_GateWay.Location = new System.Drawing.Point(127, 77);
            this.textBox_GateWay.Name = "textBox_GateWay";
            this.textBox_GateWay.Size = new System.Drawing.Size(120, 21);
            this.textBox_GateWay.TabIndex = 7;
            this.textBox_GateWay.Text = "0.0.0.0";
            // 
            // textBox_Mask
            // 
            this.textBox_Mask.Location = new System.Drawing.Point(127, 49);
            this.textBox_Mask.Name = "textBox_Mask";
            this.textBox_Mask.Size = new System.Drawing.Size(120, 21);
            this.textBox_Mask.TabIndex = 6;
            this.textBox_Mask.Text = "0.0.0.0";
            // 
            // textBox_IPNet
            // 
            this.textBox_IPNet.Location = new System.Drawing.Point(127, 21);
            this.textBox_IPNet.Name = "textBox_IPNet";
            this.textBox_IPNet.Size = new System.Drawing.Size(120, 21);
            this.textBox_IPNet.TabIndex = 5;
            this.textBox_IPNet.Text = "0.0.0.0";
            // 
            // button_GetNet
            // 
            this.button_GetNet.Location = new System.Drawing.Point(216, 132);
            this.button_GetNet.Name = "button_GetNet";
            this.button_GetNet.Size = new System.Drawing.Size(75, 23);
            this.button_GetNet.TabIndex = 4;
            this.button_GetNet.Text = "Get(获取)";
            this.button_GetNet.UseVisualStyleBackColor = true;
            this.button_GetNet.Click += new System.EventHandler(this.button_GetNet_Click);
            // 
            // button_SetNet
            // 
            this.button_SetNet.Location = new System.Drawing.Point(51, 133);
            this.button_SetNet.Name = "button_SetNet";
            this.button_SetNet.Size = new System.Drawing.Size(75, 23);
            this.button_SetNet.TabIndex = 3;
            this.button_SetNet.Text = "Set(设置)";
            this.button_SetNet.UseVisualStyleBackColor = true;
            this.button_SetNet.Click += new System.EventHandler(this.button_SetNet_Click);
            // 
            // label_GateWay
            // 
            this.label_GateWay.AutoSize = true;
            this.label_GateWay.Location = new System.Drawing.Point(11, 77);
            this.label_GateWay.Name = "label_GateWay";
            this.label_GateWay.Size = new System.Drawing.Size(113, 12);
            this.label_GateWay.TabIndex = 2;
            this.label_GateWay.Text = "GateWay(默认网关):";
            // 
            // label_Mask
            // 
            this.label_Mask.AutoSize = true;
            this.label_Mask.Location = new System.Drawing.Point(9, 49);
            this.label_Mask.Name = "label_Mask";
            this.label_Mask.Size = new System.Drawing.Size(95, 12);
            this.label_Mask.TabIndex = 1;
            this.label_Mask.Text = "Mask(子网掩码):";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(7, 21);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(71, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP(IP地址):";
            // 
            // groupBox_AutoRegisterCfg
            // 
            this.groupBox_AutoRegisterCfg.Controls.Add(this.textBox_DvripIP);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.textBox_Port);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.textBox_DevID);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.button_GetAutoCfg);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.button_SetAutoCfg);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.label_IPAutoRegister);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.label_Port);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.label_DevID);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.checkBox_Enable);
            this.groupBox_AutoRegisterCfg.Controls.Add(this.label_Enable);
            this.groupBox_AutoRegisterCfg.Location = new System.Drawing.Point(21, 200);
            this.groupBox_AutoRegisterCfg.Name = "groupBox_AutoRegisterCfg";
            this.groupBox_AutoRegisterCfg.Size = new System.Drawing.Size(334, 180);
            this.groupBox_AutoRegisterCfg.TabIndex = 1;
            this.groupBox_AutoRegisterCfg.TabStop = false;
            this.groupBox_AutoRegisterCfg.Text = "AutoRegisterCfg(主动注册配置)";
            // 
            // textBox_DvripIP
            // 
            this.textBox_DvripIP.Location = new System.Drawing.Point(127, 113);
            this.textBox_DvripIP.Name = "textBox_DvripIP";
            this.textBox_DvripIP.Size = new System.Drawing.Size(120, 21);
            this.textBox_DvripIP.TabIndex = 9;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(127, 85);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 21);
            this.textBox_Port.TabIndex = 8;
            // 
            // textBox_DevID
            // 
            this.textBox_DevID.Location = new System.Drawing.Point(127, 54);
            this.textBox_DevID.Name = "textBox_DevID";
            this.textBox_DevID.Size = new System.Drawing.Size(100, 21);
            this.textBox_DevID.TabIndex = 7;
            // 
            // button_GetAutoCfg
            // 
            this.button_GetAutoCfg.Location = new System.Drawing.Point(216, 145);
            this.button_GetAutoCfg.Name = "button_GetAutoCfg";
            this.button_GetAutoCfg.Size = new System.Drawing.Size(75, 23);
            this.button_GetAutoCfg.TabIndex = 6;
            this.button_GetAutoCfg.Text = "Get(获取)";
            this.button_GetAutoCfg.UseVisualStyleBackColor = true;
            this.button_GetAutoCfg.Click += new System.EventHandler(this.button_GetAutoCfg_Click);
            // 
            // button_SetAutoCfg
            // 
            this.button_SetAutoCfg.Location = new System.Drawing.Point(65, 145);
            this.button_SetAutoCfg.Name = "button_SetAutoCfg";
            this.button_SetAutoCfg.Size = new System.Drawing.Size(75, 23);
            this.button_SetAutoCfg.TabIndex = 5;
            this.button_SetAutoCfg.Text = "Set(设置)";
            this.button_SetAutoCfg.UseVisualStyleBackColor = true;
            this.button_SetAutoCfg.Click += new System.EventHandler(this.button_SetAutoCfg_Click);
            // 
            // label_IPAutoRegister
            // 
            this.label_IPAutoRegister.AutoSize = true;
            this.label_IPAutoRegister.Location = new System.Drawing.Point(17, 113);
            this.label_IPAutoRegister.Name = "label_IPAutoRegister";
            this.label_IPAutoRegister.Size = new System.Drawing.Size(65, 12);
            this.label_IPAutoRegister.TabIndex = 4;
            this.label_IPAutoRegister.Text = "IP(IP地址)";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(15, 85);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(65, 12);
            this.label_Port.TabIndex = 3;
            this.label_Port.Text = "Port(端口)";
            // 
            // label_DevID
            // 
            this.label_DevID.AutoSize = true;
            this.label_DevID.Location = new System.Drawing.Point(13, 54);
            this.label_DevID.Name = "label_DevID";
            this.label_DevID.Size = new System.Drawing.Size(101, 12);
            this.label_DevID.TabIndex = 2;
            this.label_DevID.Text = "DeviceID(设备ID)";
            // 
            // checkBox_Enable
            // 
            this.checkBox_Enable.AutoSize = true;
            this.checkBox_Enable.Location = new System.Drawing.Point(91, 21);
            this.checkBox_Enable.Name = "checkBox_Enable";
            this.checkBox_Enable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Enable.TabIndex = 1;
            this.checkBox_Enable.UseVisualStyleBackColor = true;
            // 
            // label_Enable
            // 
            this.label_Enable.AutoSize = true;
            this.label_Enable.Location = new System.Drawing.Point(11, 21);
            this.label_Enable.Name = "label_Enable";
            this.label_Enable.Size = new System.Drawing.Size(77, 12);
            this.label_Enable.TabIndex = 0;
            this.label_Enable.Text = "Enable(使能)";
            // 
            // Network
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 392);
            this.Controls.Add(this.groupBox_AutoRegisterCfg);
            this.Controls.Add(this.groupBox_DevNet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Network";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Network(网络配置)";
            this.Load += new System.EventHandler(this.Network_Load);
            this.groupBox_DevNet.ResumeLayout(false);
            this.groupBox_DevNet.PerformLayout();
            this.groupBox_AutoRegisterCfg.ResumeLayout(false);
            this.groupBox_AutoRegisterCfg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_DevNet;
        private System.Windows.Forms.TextBox textBox_GateWay;
        private System.Windows.Forms.TextBox textBox_Mask;
        private System.Windows.Forms.TextBox textBox_IPNet;
        private System.Windows.Forms.Button button_GetNet;
        private System.Windows.Forms.Button button_SetNet;
        private System.Windows.Forms.Label label_GateWay;
        private System.Windows.Forms.Label label_Mask;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.GroupBox groupBox_AutoRegisterCfg;
        private System.Windows.Forms.TextBox textBox_DvripIP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_DevID;
        private System.Windows.Forms.Button button_GetAutoCfg;
        private System.Windows.Forms.Button button_SetAutoCfg;
        private System.Windows.Forms.Label label_IPAutoRegister;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_DevID;
        private System.Windows.Forms.CheckBox checkBox_Enable;
        private System.Windows.Forms.Label label_Enable;
    }
}