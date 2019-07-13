using System;
using System.Collections.Generic;
using System.ComponentModel;
using CheckPoint.Model.Entities;

namespace CheckPoint.View.Interfaces
{
    public interface IEmployeeListForm : IForm
    {
        BindingList<Employee> Employees { get; set; }
        Employee CurrentEmployee { get; set; }
        int SelectedEmployeeIndex { get; set; }
        IEnumerable<Employee> SelectedEmployees { get; }
        string Filter { get; set; }
        string ImportFileName { get; set; }
        string ExportFileName { get; set; }


        event EventHandler OnAddEmployee;
        event EventHandler OnDeleteEmployee;
        event EventHandler OnEditEmployee;
        event EventHandler OnCurrentEmployeeChanged;
        event EventHandler OnFiltered;
        event EventHandler OnCleanFilter;
        event EventHandler OnExportEmployees;
        event EventHandler OnImportEmployees;
    }
}