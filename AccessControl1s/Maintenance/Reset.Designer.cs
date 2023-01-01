namespace AccessControl1s
{
    partial class Reset
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
            this.button_ResetYes = new System.Windows.Forms.Button();
            this.button_ResetNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure to reset all?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(35, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Are you sure to reset the configuration？";
            // 
            // button_ResetYes
            // 
            this.button_ResetYes.Location = new System.Drawing.Point(37, 104);
            this.button_ResetYes.Name = "button_ResetYes";
            this.button_ResetYes.Size = new System.Drawing.Size(75, 32);
            this.button_ResetYes.TabIndex = 2;
            this.button_ResetYes.Text = "Yes";
            this.button_ResetYes.UseVisualStyleBackColor = true;
            this.button_ResetYes.Click += new System.EventHandler(this.button_ResetYes_Click);
            // 
            // button_ResetNo
            // 
            this.button_ResetNo.Location = new System.Drawing.Point(162, 103);
            this.button_ResetNo.Name = "button_ResetNo";
            this.button_ResetNo.Size = new System.Drawing.Size(75, 32);
            this.button_ResetNo.TabIndex = 3;
            this.button_ResetNo.Text = "No";
            this.button_ResetNo.UseVisualStyleBackColor = true;
            this.button_ResetNo.Click += new System.EventHandler(this.button_ResetNo_Click);
            // 
            // Reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.button_ResetNo);
            this.Controls.Add(this.button_ResetYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prompt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ResetYes;
        private System.Windows.Forms.Button button_ResetNo;
    }
}