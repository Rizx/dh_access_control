namespace AccessControl1s
{
    partial class Upgrade
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
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.progressBar_Upgrade = new System.Windows.Forms.ProgressBar();
            this.textBox_UpgrageState = new System.Windows.Forms.TextBox();
            this.button_Upgrade = new System.Windows.Forms.Button();
            this.button_StopUpgrade = new System.Windows.Forms.Button();
            this.button_OpenFile = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.pictureBox_face = new System.Windows.Forms.PictureBox();
            this.button_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_face)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path(路径)：";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Location = new System.Drawing.Point(100, 27);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(282, 21);
            this.textBox_Path.TabIndex = 1;
            // 
            // progressBar_Upgrade
            // 
            this.progressBar_Upgrade.Location = new System.Drawing.Point(32, 66);
            this.progressBar_Upgrade.Name = "progressBar_Upgrade";
            this.progressBar_Upgrade.Size = new System.Drawing.Size(441, 23);
            this.progressBar_Upgrade.TabIndex = 2;
            // 
            // textBox_UpgrageState
            // 
            this.textBox_UpgrageState.Location = new System.Drawing.Point(32, 108);
            this.textBox_UpgrageState.Multiline = true;
            this.textBox_UpgrageState.Name = "textBox_UpgrageState";
            this.textBox_UpgrageState.Size = new System.Drawing.Size(441, 109);
            this.textBox_UpgrageState.TabIndex = 3;
            // 
            // button_Upgrade
            // 
            this.button_Upgrade.Location = new System.Drawing.Point(58, 242);
            this.button_Upgrade.Name = "button_Upgrade";
            this.button_Upgrade.Size = new System.Drawing.Size(165, 30);
            this.button_Upgrade.TabIndex = 4;
            this.button_Upgrade.Text = "Device Upgrade(设备升级)";
            this.button_Upgrade.UseVisualStyleBackColor = true;
            this.button_Upgrade.Click += new System.EventHandler(this.button_Upgrade_Click);
            // 
            // button_StopUpgrade
            // 
            this.button_StopUpgrade.Location = new System.Drawing.Point(261, 242);
            this.button_StopUpgrade.Name = "button_StopUpgrade";
            this.button_StopUpgrade.Size = new System.Drawing.Size(165, 30);
            this.button_StopUpgrade.TabIndex = 5;
            this.button_StopUpgrade.Text = "Stop(停止)";
            this.button_StopUpgrade.UseVisualStyleBackColor = true;
            this.button_StopUpgrade.Click += new System.EventHandler(this.button_StopUpgrade_Click);
            // 
            // button_OpenFile
            // 
            this.button_OpenFile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OpenFile.Location = new System.Drawing.Point(418, 25);
            this.button_OpenFile.Name = "button_OpenFile";
            this.button_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.button_OpenFile.TabIndex = 6;
            this.button_OpenFile.Text = "...";
            this.button_OpenFile.UseVisualStyleBackColor = true;
            this.button_OpenFile.Click += new System.EventHandler(this.button_OpenFile_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(0, 0);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 0;
            // 
            // pictureBox_face
            // 
            this.pictureBox_face.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_face.Name = "pictureBox_face";
            this.pictureBox_face.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_face.TabIndex = 0;
            this.pictureBox_face.TabStop = false;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(0, 0);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 0;
            // 
            // Upgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 297);
            this.Controls.Add(this.button_OpenFile);
            this.Controls.Add(this.button_StopUpgrade);
            this.Controls.Add(this.button_Upgrade);
            this.Controls.Add(this.textBox_UpgrageState);
            this.Controls.Add(this.progressBar_Upgrade);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Upgrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upgrade(设备升级)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_face)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.ProgressBar progressBar_Upgrade;
        private System.Windows.Forms.TextBox textBox_UpgrageState;
        private System.Windows.Forms.Button button_Upgrade;
        private System.Windows.Forms.Button button_StopUpgrade;
        private System.Windows.Forms.Button button_OpenFile;
        private System.Windows.Forms.PictureBox pictureBox_face;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_delete;
    }
}