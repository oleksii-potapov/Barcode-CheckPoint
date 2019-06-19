namespace CheckPoint.View.Forms
{
    partial class SettingsForm
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
            this.textDataBaseServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDataBaseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPlotCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCheckPhotoFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowseCheckPhotoFolder = new System.Windows.Forms.Button();
            this.buttonBrowseEmployeePhotoFolder = new System.Windows.Forms.Button();
            this.textEmployeePhotoFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericMaxShiftLength = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboCameraList = new System.Windows.Forms.ComboBox();
            this.buttonApplySettings = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxShiftLength)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataBase Server";
            // 
            // textDataBaseServer
            // 
            this.textDataBaseServer.Location = new System.Drawing.Point(163, 6);
            this.textDataBaseServer.Name = "textDataBaseServer";
            this.textDataBaseServer.Size = new System.Drawing.Size(192, 20);
            this.textDataBaseServer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DataBase Name";
            // 
            // textDataBaseName
            // 
            this.textDataBaseName.Location = new System.Drawing.Point(163, 36);
            this.textDataBaseName.Name = "textDataBaseName";
            this.textDataBaseName.Size = new System.Drawing.Size(192, 20);
            this.textDataBaseName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plot Code";
            // 
            // textPlotCode
            // 
            this.textPlotCode.Location = new System.Drawing.Point(163, 69);
            this.textPlotCode.Name = "textPlotCode";
            this.textPlotCode.Size = new System.Drawing.Size(192, 20);
            this.textPlotCode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Folder with check photos";
            // 
            // textCheckPhotoFolder
            // 
            this.textCheckPhotoFolder.Location = new System.Drawing.Point(163, 102);
            this.textCheckPhotoFolder.Name = "textCheckPhotoFolder";
            this.textCheckPhotoFolder.Size = new System.Drawing.Size(192, 20);
            this.textCheckPhotoFolder.TabIndex = 7;
            // 
            // buttonBrowseCheckPhotoFolder
            // 
            this.buttonBrowseCheckPhotoFolder.Location = new System.Drawing.Point(361, 102);
            this.buttonBrowseCheckPhotoFolder.Name = "buttonBrowseCheckPhotoFolder";
            this.buttonBrowseCheckPhotoFolder.Size = new System.Drawing.Size(70, 20);
            this.buttonBrowseCheckPhotoFolder.TabIndex = 8;
            this.buttonBrowseCheckPhotoFolder.Text = "Browse";
            this.buttonBrowseCheckPhotoFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseCheckPhotoFolder.Click += new System.EventHandler(this.ButtonBrowseCheckPhotoFolder_Click);
            // 
            // buttonBrowseEmployeePhotoFolder
            // 
            this.buttonBrowseEmployeePhotoFolder.Location = new System.Drawing.Point(361, 137);
            this.buttonBrowseEmployeePhotoFolder.Name = "buttonBrowseEmployeePhotoFolder";
            this.buttonBrowseEmployeePhotoFolder.Size = new System.Drawing.Size(70, 20);
            this.buttonBrowseEmployeePhotoFolder.TabIndex = 11;
            this.buttonBrowseEmployeePhotoFolder.Text = "Browse";
            this.buttonBrowseEmployeePhotoFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseEmployeePhotoFolder.Click += new System.EventHandler(this.ButtonBrowseEmployeePhotoFolder_Click);
            // 
            // textEmployeePhotoFolder
            // 
            this.textEmployeePhotoFolder.Location = new System.Drawing.Point(163, 137);
            this.textEmployeePhotoFolder.Name = "textEmployeePhotoFolder";
            this.textEmployeePhotoFolder.Size = new System.Drawing.Size(192, 20);
            this.textEmployeePhotoFolder.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Folder with employee photos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max length of shift in hours";
            // 
            // numericMaxShiftLength
            // 
            this.numericMaxShiftLength.Location = new System.Drawing.Point(163, 172);
            this.numericMaxShiftLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMaxShiftLength.Name = "numericMaxShiftLength";
            this.numericMaxShiftLength.Size = new System.Drawing.Size(192, 20);
            this.numericMaxShiftLength.TabIndex = 13;
            this.numericMaxShiftLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Camera";
            // 
            // comboCameraList
            // 
            this.comboCameraList.FormattingEnabled = true;
            this.comboCameraList.Location = new System.Drawing.Point(163, 210);
            this.comboCameraList.Name = "comboCameraList";
            this.comboCameraList.Size = new System.Drawing.Size(192, 21);
            this.comboCameraList.TabIndex = 15;
            // 
            // buttonApplySettings
            // 
            this.buttonApplySettings.Location = new System.Drawing.Point(265, 286);
            this.buttonApplySettings.Name = "buttonApplySettings";
            this.buttonApplySettings.Size = new System.Drawing.Size(75, 23);
            this.buttonApplySettings.TabIndex = 16;
            this.buttonApplySettings.Text = "Ok";
            this.buttonApplySettings.UseVisualStyleBackColor = true;
            this.buttonApplySettings.Click += new System.EventHandler(this.ButtonApplySettings_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(356, 286);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 325);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApplySettings);
            this.Controls.Add(this.comboCameraList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericMaxShiftLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonBrowseEmployeePhotoFolder);
            this.Controls.Add(this.textEmployeePhotoFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBrowseCheckPhotoFolder);
            this.Controls.Add(this.textCheckPhotoFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPlotCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDataBaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDataBaseServer);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxShiftLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDataBaseServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDataBaseName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPlotCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCheckPhotoFolder;
        private System.Windows.Forms.Button buttonBrowseCheckPhotoFolder;
        private System.Windows.Forms.Button buttonBrowseEmployeePhotoFolder;
        private System.Windows.Forms.TextBox textEmployeePhotoFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericMaxShiftLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboCameraList;
        private System.Windows.Forms.Button buttonApplySettings;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}