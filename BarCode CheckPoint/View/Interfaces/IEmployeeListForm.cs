﻿using System;
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

        event EventHandler OnAddEmployee;
        event EventHandler OnDeleteEmployee;
        event EventHandler OnEditEmployee;
        event EventHandler OnCurrentEmployeeChanged;
    }
}