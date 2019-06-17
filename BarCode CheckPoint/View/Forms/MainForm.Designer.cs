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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBarCode
            // 
            this.textBarCode.Location = new System.Drawing.Point(13, 28);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // radioExit
            // 
            this.radioExit.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioExit.ForeColor = System.Drawing.Color.DarkBlue;
            this.radioExit.Location = new System.Drawing.Point(111, 21);
            this.radioExit.Name = "radioExit";
            this.radioExit.Size = new System.Drawing.Size(60, 41);
            this.radioExit.TabIndex = 4;
            this.radioExit.Text = "Exit";
            this.radioExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioExit.UseVisualStyleBackColor = true;
            // 
            // radioEntry
            // 
            this.radioEntry.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioEntry.Checked = true;
            this.radioEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioEntry.ForeColor = System.Drawing.Color.DarkGreen;
            this.radioEntry.Location = new System.Drawing.Point(21, 21);
            this.radioEntry.Name = "radioEntry";
            this.radioEntry.Size = new System.Drawing.Size(60, 41);
            this.radioEntry.TabIndex = 3;
            this.radioEntry.TabStop = true;
            this.radioEntry.Text = "Entry";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.serviceToolStripMenuItem.Text = "Service";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.propertiesToolStripMenuItem.Text = "Settings";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsFormToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // reportsFormToolStripMenuItem
            // 
            this.reportsFormToolStripMenuItem.Name = "reportsFormToolStripMenuItem";
            this.reportsFormToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reportsFormToolStripMenuItem.Text = "Reports form";
            this.reportsFormToolStripMenuItem.Click += new System.EventHandler(this.ReportsFormToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
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
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Barcode Checkpoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

