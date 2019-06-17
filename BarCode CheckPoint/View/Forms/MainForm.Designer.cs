namespace CheckPoint.View.Forms
{
    partial class MainForm
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
            this.textBarCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioExit = new System.Windows.Forms.RadioButton();
            this.radioEntry = new System.Windows.Forms.RadioButton();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.labelDateTimeEntry = new System.Windows.Forms.Label();
            this.labelDateTimeExit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBarCode
            // 
            this.textBarCode.Location = new System.Drawing.Point(16, 15);
            this.textBarCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBarCode.Name = "textBarCode";
            this.textBarCode.PasswordChar = '*';
            this.textBarCode.Size = new System.Drawing.Size(191, 22);
            this.textBarCode.TabIndex = 0;
            this.textBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBarCode_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioExit);
            this.groupBox1.Controls.Add(this.radioEntry);
            this.groupBox1.Location = new System.Drawing.Point(16, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // radioExit
            // 
            this.radioExit.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioExit.Location = new System.Drawing.Point(108, 21);
            this.radioExit.Name = "radioExit";
            this.radioExit.Size = new System.Drawing.Size(60, 26);
            this.radioExit.TabIndex = 4;
            this.radioExit.Text = "Exit";
            this.radioExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioExit.UseVisualStyleBackColor = true;
            // 
            // radioEntry
            // 
            this.radioEntry.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioEntry.Checked = true;
            this.radioEntry.Location = new System.Drawing.Point(23, 21);
            this.radioEntry.Name = "radioEntry";
            this.radioEntry.Size = new System.Drawing.Size(60, 26);
            this.radioEntry.TabIndex = 3;
            this.radioEntry.TabStop = true;
            this.radioEntry.Text = "Enter";
            this.radioEntry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioEntry.UseVisualStyleBackColor = true;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(305, 62);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(45, 16);
            this.labelFullName.TabIndex = 4;
            this.labelFullName.Text = "label1";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(305, 100);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(45, 16);
            this.labelPost.TabIndex = 5;
            this.labelPost.Text = "label2";
            // 
            // labelDateTimeEntry
            // 
            this.labelDateTimeEntry.AutoSize = true;
            this.labelDateTimeEntry.Location = new System.Drawing.Point(305, 137);
            this.labelDateTimeEntry.Name = "labelDateTimeEntry";
            this.labelDateTimeEntry.Size = new System.Drawing.Size(45, 16);
            this.labelDateTimeEntry.TabIndex = 6;
            this.labelDateTimeEntry.Text = "label3";
            // 
            // labelDateTimeExit
            // 
            this.labelDateTimeExit.AutoSize = true;
            this.labelDateTimeExit.Location = new System.Drawing.Point(305, 177);
            this.labelDateTimeExit.Name = "labelDateTimeExit";
            this.labelDateTimeExit.Size = new System.Drawing.Size(45, 16);
            this.labelDateTimeExit.TabIndex = 7;
            this.labelDateTimeExit.Text = "label4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 374);
            this.Controls.Add(this.labelDateTimeExit);
            this.Controls.Add(this.labelDateTimeEntry);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBarCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Barcode Checkpoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBarCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioExit;
        private System.Windows.Forms.RadioButton radioEntry;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label labelDateTimeEntry;
        private System.Windows.Forms.Label labelDateTimeExit;
    }
}

