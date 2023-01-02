namespace AccessControl1s
{
    partial class Reboot
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
            this.button_RebootYes = new System.Windows.Forms.Button();
            this.button_RebootNo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure to reboot?";
            // 
            // button_RebootYes
            // 
            this.button_RebootYes.Location = new System.Drawing.Point(44, 109);
            this.button_RebootYes.Name = "button_RebootYes";
            this.button_RebootYes.Size = new System.Drawing.Size(75, 32);
            this.button_RebootYes.TabIndex = 1;
            this.button_RebootYes.Text = "Yes(是)";
            this.button_RebootYes.UseVisualStyleBackColor = true;
            this.button_RebootYes.Click += new System.EventHandler(this.button_RebootYes_Click);
            // 
            // button_RebootNo
            // 
            this.button_RebootNo.Location = new System.Drawing.Point(160, 108);
            this.button_RebootNo.Name = "button_RebootNo";
            this.button_RebootNo.Size = new System.Drawing.Size(75, 32);
            this.button_RebootNo.TabIndex = 2;
            this.button_RebootNo.Text = "No(否)";
            this.button_RebootNo.UseVisualStyleBackColor = true;
            this.button_RebootNo.Click += new System.EventHandler(this.button_RebootNo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(44, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "是否确认重启？";
            // 
            // Reboot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 174);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_RebootNo);
            this.Controls.Add(this.button_RebootYes);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reboot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prompt(提示)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_RebootYes;
        private System.Windows.Forms.Button button_RebootNo;
        private System.Windows.Forms.Label label2;
    }
}