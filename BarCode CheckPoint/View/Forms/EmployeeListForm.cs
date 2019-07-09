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
    public partial class EmployeeListForm : Form, IEmployeeListForm
    {
        public EmployeeListForm()
        {
            InitializeComponent();
            buttonAdd.Click += ButtonAdd_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonEdit.Click += ButtonEdit_Click;
            gridEmployee.SelectionChanged += GridEmployee_SelectionChanged;
            gridEmployee.CellDoubleClick += ButtonEdit_Click;
            buttonCleanFilter.Click += ButtonCleanFilter_Click;
            textFilter.KeyUp += TextFilter_KeyUp;
            buttonExport.Click += ButtonExport_Click;
            buttonImport.Click += ButtonImport_Click;
        }


        #region forwarding events
        private void TextFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textFilter.BackColor = Color.LimeGreen;
                OnFiltered?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ButtonCleanFilter_Click(object sender, EventArgs e)
        {
            textFilter.BackColor = Color.White;
            OnCleanFilter?.Invoke(this, EventArgs.Empty);
        }

        private void GridEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEmployee.Rows.Count == 0) return;
            SelectedEmployeeIndex = gridEmployee.CurrentCell.RowIndex;
            CurrentEmployee = Employees[SelectedEmployeeIndex];
            OnCurrentEmployeeChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            OnEditEmployee?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            OnDeleteEmployee?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OnAddEmployee?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() != DialogResult.OK) return;
            ImportFileName = openFileDialog.FileName;
            OnImportEmployees?.Invoke(this, EventArgs.Empty);
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() != DialogResult.OK) return;
            ExportFileName = saveFileDialog.FileName;
            OnExportEmployees?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        public BindingList<Employee> Employees
        {
            get => (BindingList<Employee>) gridEmployee.DataSource;
            set => gridEmployee.DataSource = value;
        }
        public Employee CurrentEmployee { get; set; }
        public int SelectedEmployeeIndex { get; set; }
        public string Filter
        {
            get => textFilter.Text;
            set => textFilter.Text = value;
        }

        public string ImportFileName { get; set; }
        public string ExportFileName { get; set; }

        #region events

        public event EventHandler OnAddEmployee;
        public event EventHandler OnDeleteEmployee;
        public event EventHandler OnEditEmployee;
        public event EventHandler OnCurrentEmployeeChanged;
        public event EventHandler OnFiltered;
        public event EventHandler OnCleanFilter;
        public event EventHandler OnExportEmployees;
        public event EventHandler OnImportEmployees;

        #endregion

        public void ShowForm()
        {
            Show();
        }

        public void CloseForm()
        {
            Close();
        }
    }
}
