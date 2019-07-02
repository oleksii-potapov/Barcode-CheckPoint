using CheckPoint.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.View.Interfaces
{
    interface IReportsForm : IForm
    {
        DateTime DateTimeBegin { get; set; }
        DateTime DateTimeEnd { get; set; }
        string BarCode { get; set; }
        string EmployeeName { get; }
        BindingList<Employee> Employees { get; set; }
        bool ShowOnlySelectedEmployeeChecks { get; set; }

        event EventHandler OnGenerateExcelReport;
        event EventHandler OnGenerateTimeSheet;
    }
}