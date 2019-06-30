using System;
using System.Collections.Generic;
using CheckPoint.Model.Entities;

namespace CheckPoint.View.Interfaces
{
    public interface IEmployeeListForm
    {
        List<Employee> Employees { get; set; }
        Employee CurrentEmployee { get; }
        int SelectedEmployeeIndex { get; set; }

        event EventHandler OnAddEmployee;
        event EventHandler OnDeleteEmployee;
        event EventHandler OnEditEmployee;
        event EventHandler OnPostFormShow;
        event EventHandler OnCurrentEmployeeChanged;
    }
}