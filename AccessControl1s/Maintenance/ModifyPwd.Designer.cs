namespace AccessControl1s
{
    partial class ModifyPwd
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
            this.lable_User = new System.Windows.Forms.Label();
            this.label_OldPasswd = new System.Windows.Forms.Label();
            this.label_NewPasswd = new System.Windows.Forms.Label();
            this.label_Repeat = new System.Windows.Forms.Label();
            this.button_Modify = new System.Windows.Forms.Button();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_OldPasswd = new System.Windows.Forms.TextBox();
            this.textBox_NewPasswd = new System.Windows.Forms.TextBox();
            this.textBox_Repeat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lable_User
            // 
            this.lable_User.AutoSize = true;
            this.lable_User.Location = new System.Drawing.Point(32, 51);
            this.lable_User.Name = "lable_User";
            this.lable_User.Size = new System.Drawing.Size(89, 12);
            this.lable_User.TabIndex = 0;
            this.lable_User.Text = "User(用户名)：";
            // 
            // label_OldPasswd
            // 
            this.label_OldPasswd.AutoSize = true;
            this.label_OldPasswd.Location = new System.Drawing.Point(34, 80);
            this.label_OldPasswd.Name = "label_OldPasswd";
            this.label_OldPasswd.Size = new System.Drawing.Size(137, 12);
            this.label_OldPasswd.TabIndex = 1;
            this.label_OldPasswd.Text = "Old Password(旧密码)：";
            // 
            // label_NewPasswd
            // 
            this.label_NewPasswd.AutoSize = true;
            this.label_NewPasswd.Location = new System.Drawing.Point(34, 111);
            this.label_NewPasswd.Name = "label_NewPasswd";
            this.label_NewPasswd.Size = new System.Drawing.Size(137, 12);
            this.label_NewPasswd.TabIndex = 2;
            this.label_NewPasswd.Text = "New Password(新密码)：";
            // 
            // label_Repeat
            // 
            this.label_Repeat.AutoSize = true;
            this.label_Repeat.Location = new System.Drawing.Point(34, 141);
            this.label_Repeat.Name = "label_Repeat";
            this.label_Repeat.Size = new System.Drawing.Size(89, 12);
            this.label_Repeat.TabIndex = 3;
            this.label_Repeat.Text = "Repeat(确认)：";
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(120, 191);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(100, 29);
            this.button_Modify.TabIndex = 4;
            this.button_Modify.Text = "Modify(修改)";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(178, 48);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(120, 21);
            this.textBox_User.TabIndex = 5;
            // 
            // textBox_OldPasswd
            // 
            this.textBox_OldPasswd.Location = new System.Drawing.Point(178, 76);
            this.textBox_OldPasswd.Name = "textBox_OldPasswd";
            this.textBox_OldPasswd.Size = new System.Drawing.Size(120, 21);
            this.textBox_OldPasswd.TabIndex = 6;
            this.textBox_OldPasswd.UseSystemPasswordChar = true;
            // 
            // textBox_NewPasswd
            // 
            this.textBox_NewPasswd.Location = new System.Drawing.Point(178, 111);
            this.textBox_NewPasswd.Name = "textBox_NewPasswd";
            this.textBox_NewPasswd.Size = new System.Drawing.Size(120, 21);
            this.textBox_NewPasswd.TabIndex = 7;
            this.textBox_NewPasswd.UseSystemPasswordChar = true;
            // 
            // textBox_Repeat
            // 
            this.textBox_Repeat.Location = new System.Drawing.Point(178, 141);
            this.textBox_Repeat.Name = "textBox_Repeat";
            this.textBox_Repeat.Size = new System.Drawing.Size(120, 21);
            this.textBox_Repeat.TabIndex = 8;
            this.textBox_Repeat.UseSystemPasswordChar = true;
            // 
            // ModifyPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 246);
            this.Controls.Add(this.textBox_Repeat);
            this.Controls.Add(this.textBox_NewPasswd);
            this.Controls.Add(this.textBox_OldPasswd);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.button_Modify);
            this.Controls.Add(this.label_Repeat);
            this.Controls.Add(this.label_NewPasswd);
            this.Controls.Add(this.label_OldPasswd);
            this.Controls.Add(this.lable_User);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModifyPwd(修改密码)";
            this.Load += new System.EventHandler(this.ModifyPwd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_User;
        private System.Windows.Forms.Label label_OldPasswd;
        private System.Windows.Forms.Label label_NewPasswd;
        private System.Windows.Forms.Label label_Repeat;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_OldPasswd;
        private System.Windows.Forms.TextBox textBox_NewPasswd;
        private System.Windows.Forms.TextBox textBox_Repeat;
    }
}