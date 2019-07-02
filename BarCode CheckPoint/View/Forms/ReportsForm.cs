using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckPoint.Model.Entities;
using CheckPoint.View.Interfaces;

namespace CheckPoint.View.Forms
{
    public partial class ReportsForm : Form, IReportsForm
    {
        public ReportsForm()
        {
            InitializeComponent();
            buttonGenerateExcelReport.Click += ButtonGenerateExcelReport_Click;
            buttonGenerateTimeSheet.Click += ButtonGenerateTimeSheet_Click;
        }

        private void ButtonGenerateTimeSheet_Click(object sender, EventArgs e)
        {
            OnGenerateTimeSheet?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonGenerateExcelReport_Click(object sender, EventArgs e)
        {
            OnGenerateExcelReport?.Invoke(this, EventArgs.Empty);
        }

        public void ShowForm()
        {
            Show();
        }

        public void CloseForm()
        {
            Close();
        }

        public DateTime DateTimeBegin
        {
            get => dateTimeBegin.Value;
            set => dateTimeBegin.Value = value;
        }

        public DateTime DateTimeEnd
        {
            get => dateTimeEnd.Value;
            set => dateTimeEnd.Value = value;
        }

        public string BarCode
        {
            get => (string) comboEmployee.SelectedValue;
            set => comboEmployee.SelectedValue = value;
        }

        public BindingList<Employee> Employees
        {
            get => (BindingList<Employee>) comboEmployee.DataSource;
            set => comboEmployee.DataSource = value;
        }

        public event EventHandler OnGenerateExcelReport;
        public event EventHandler OnGenerateTimeSheet;
    }
}
