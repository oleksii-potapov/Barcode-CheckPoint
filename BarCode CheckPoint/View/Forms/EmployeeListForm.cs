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
        }

        public BindingList<Employee> Employees { get; set; }
        public Employee CurrentEmployee { get; }
        public int SelectedEmployeeIndex { get; set; }
        public event EventHandler OnAddEmployee;
        public event EventHandler OnDeleteEmployee;
        public event EventHandler OnEditEmployee;
        public event EventHandler OnPostFormShow;
        public event EventHandler OnCurrentEmployeeChanged;
        public void ShowForm()
        {
            throw new NotImplementedException();
        }

        public void CloseForm()
        {
            throw new NotImplementedException();
        }
    }
}
