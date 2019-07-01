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
            this.menuMainMenu = new System.Windows.Forms.MenuStrip();
            this.listsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureCamera = new System.Windows.Forms.PictureBox();
            this.pictureCheckPhoto = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.menuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheckPhoto)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // textBarCode
            // 
            this.textBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBarCode.Location = new System.Drawing.Point(13, 112);
            this.textBarCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBarCode.Name = "textBarCode";
            this.textBarCode.PasswordChar = '*';
            this.textBarCode.Size = new System.Drawing.Size(191, 26);
            this.textBarCode.TabIndex = 0;
            this.textBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBarCode_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioExit);
            this.groupBox1.Controls.Add(this.radioEntry);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
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
            this.labelFullName.Location = new System.Drawing.Point(230, 31);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(0, 16);
            this.labelFullName.TabIndex = 4;
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(230, 54);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(0, 16);
            this.labelPost.TabIndex = 5;
            // 
            // labelDateTimeEntry
            // 
            this.labelDateTimeEntry.AutoSize = true;
            this.labelDateTimeEntry.Location = new System.Drawing.Point(230, 75);
            this.labelDateTimeEntry.Name = "labelDateTimeEntry";
            this.labelDateTimeEntry.Size = new System.Drawing.Size(0, 16);
            this.labelDateTimeEntry.TabIndex = 6;
            // 
            // labelDateTimeExit
            // 
            this.labelDateTimeExit.AutoSize = true;
            this.labelDateTimeExit.Location = new System.Drawing.Point(230, 100);
            this.labelDateTimeExit.Name = "labelDateTimeExit";
            this.labelDateTimeExit.Size = new System.Drawing.Size(0, 16);
            this.labelDateTimeExit.TabIndex = 7;
            // 
            // menuMainMenu
            // 
            this.menuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listsToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuMainMenu.Name = "menuMainMenu";
            this.menuMainMenu.Size = new System.Drawing.Size(599, 24);
            this.menuMainMenu.TabIndex = 8;
            // 
            // listsToolStripMenuItem
            // 
            this.listsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.postsToolStripMenuItem});
            this.listsToolStripMenuItem.Name = "listsToolStripMenuItem";
            this.listsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.listsToolStripMenuItem.Text = "Lists";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.EmployeesToolStripMenuItem_Click);
            // 
            // postsToolStripMenuItem
            // 
            this.postsToolStripMenuItem.Name = "postsToolStripMenuItem";
            this.postsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.postsToolStripMenuItem.Text = "Posts";
            this.postsToolStripMenuItem.Click += new System.EventHandler(this.PostsToolStripMenuItem_Click);
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
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
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
            this.reportsFormToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // pictureCamera
            // 
            this.pictureCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCamera.Location = new System.Drawing.Point(12, 193);
            this.pictureCamera.Name = "pictureCamera";
            this.pictureCamera.Size = new System.Drawing.Size(245, 202);
            this.pictureCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCamera.TabIndex = 9;
            this.pictureCamera.TabStop = false;
            // 
            // pictureCheckPhoto
            // 
            this.pictureCheckPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCheckPhoto.Location = new System.Drawing.Point(342, 193);
            this.pictureCheckPhoto.Name = "pictureCheckPhoto";
            this.pictureCheckPhoto.Size = new System.Drawing.Size(245, 202);
            this.pictureCheckPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureCheckPhoto.TabIndex = 10;
            this.pictureCheckPhoto.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 411);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureEmployeePhoto
            // 
            this.pictureEmployeePhoto.Location = new System.Drawing.Point(455, 31);
            this.pictureEmployeePhoto.Name = "pictureEmployeePhoto";
            this.pictureEmployeePhoto.Size = new System.Drawing.Size(132, 156);
            this.pictureEmployeePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureEmployeePhoto.TabIndex = 12;
            this.pictureEmployeePhoto.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 433);
            this.Controls.Add(this.pictureEmployeePhoto);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureCheckPhoto);
            this.Controls.Add(this.pictureCamera);
            this.Controls.Add(this.labelDateTimeExit);
            this.Controls.Add(this.labelDateTimeEntry);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBarCode);
            this.Controls.Add(this.menuMainMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Checkpoint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.menuMainMenu.ResumeLayout(false);
            this.menuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheckPhoto)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmployeePhoto)).EndInit();
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
        private System.Windows.Forms.MenuStrip menuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureCamera;
        private System.Windows.Forms.PictureBox pictureCheckPhoto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripMenuItem listsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureEmployeePhoto;
    }
}

