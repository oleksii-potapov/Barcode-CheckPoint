namespace CheckPoint.View.Forms
{
    partial class ReportsForm
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
            this.dateTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboEmployee = new System.Windows.Forms.ComboBox();
            this.buttonGenerateExcelReport = new System.Windows.Forms.Button();
            this.buttonGenerateTimeSheet = new System.Windows.Forms.Button();
            this.checkOnlySelectedEmployee = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.Location = new System.Drawing.Point(80, 12);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(132, 20);
            this.dateTimeBegin.TabIndex = 0;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(80, 38);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(132, 20);
            this.dateTimeEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Employee:";
            // 
            // comboEmployee
            // 
            this.comboEmployee.DisplayMember = "FullName";
            this.comboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmployee.FormattingEnabled = true;
            this.comboEmployee.Location = new System.Drawing.Point(80, 65);
            this.comboEmployee.Name = "comboEmployee";
            this.comboEmployee.Size = new System.Drawing.Size(230, 21);
            this.comboEmployee.TabIndex = 5;
            this.comboEmployee.ValueMember = "BarCode";
            // 
            // buttonGenerateExcelReport
            // 
            this.buttonGenerateExcelReport.Location = new System.Drawing.Point(13, 157);
            this.buttonGenerateExcelReport.Name = "buttonGenerateExcelReport";
            this.buttonGenerateExcelReport.Size = new System.Drawing.Size(139, 36);
            this.buttonGenerateExcelReport.TabIndex = 6;
            this.buttonGenerateExcelReport.Text = "Generate excel report";
            this.buttonGenerateExcelReport.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateTimeSheet
            // 
            this.buttonGenerateTimeSheet.Location = new System.Drawing.Point(171, 157);
            this.buttonGenerateTimeSheet.Name = "buttonGenerateTimeSheet";
            this.buttonGenerateTimeSheet.Size = new System.Drawing.Size(139, 36);
            this.buttonGenerateTimeSheet.TabIndex = 7;
            this.buttonGenerateTimeSheet.Text = "Generate timesheet";
            this.buttonGenerateTimeSheet.UseVisualStyleBackColor = true;
            // 
            // checkOnlySelectedEmployee
            // 
            this.checkOnlySelectedEmployee.AutoSize = true;
            this.checkOnlySelectedEmployee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkOnlySelectedEmployee.Location = new System.Drawing.Point(144, 92);
            this.checkOnlySelectedEmployee.Name = "checkOnlySelectedEmployee";
            this.checkOnlySelectedEmployee.Size = new System.Drawing.Size(166, 17);
            this.checkOnlySelectedEmployee.TabIndex = 8;
            this.checkOnlySelectedEmployee.Text = "Show only selected employee";
            this.checkOnlySelectedEmployee.UseVisualStyleBackColor = true;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 205);
            this.Controls.Add(this.checkOnlySelectedEmployee);
            this.Controls.Add(this.buttonGenerateTimeSheet);
            this.Controls.Add(this.buttonGenerateExcelReport);
            this.Controls.Add(this.comboEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeBegin);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeBegin;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboEmployee;
        private System.Windows.Forms.Button buttonGenerateExcelReport;
        private System.Windows.Forms.Button buttonGenerateTimeSheet;
        private System.Windows.Forms.CheckBox checkOnlySelectedEmployee;
    }
}