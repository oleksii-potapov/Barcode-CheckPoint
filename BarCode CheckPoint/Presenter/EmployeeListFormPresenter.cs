using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Repositories;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class EmployeeListFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ShiftCheckRepository _shiftCheckRepository;
        public IEmployeeListForm View { get; }

        public EmployeeListFormPresenter(IMessageService messageService, ApplicationContext context)
        {
            _employeeRepository = new EmployeeRepository();
            _shiftCheckRepository = new ShiftCheckRepository();
            _messageService = messageService;
            View = new EmployeeListForm() {Employees = _employeeRepository.GetAll()};

            View.OnAddEmployee += View_OnAddEmployee;
            View.OnDeleteEmployee += View_OnDeleteEmployee;
            View.OnEditEmployee += View_OnEditEmployee;
            View.OnCleanFilter += View_OnCleanFilter;
            View.OnFiltered += View_OnFiltered;
        }

        private void View_OnFiltered(object sender, EventArgs e)
        {
            UpdateEmployees(emp =>
                emp.FullName.IndexOf(View.Filter, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void View_OnCleanFilter(object sender, EventArgs e)
        {
            UpdateEmployees();
        }

        private void View_OnEditEmployee(object sender, EventArgs e)
        {
            EmployeeFormPresenter editEmployeeFormPresenter =
                new EmployeeFormPresenter(_messageService, View.CurrentEmployee);
            editEmployeeFormPresenter.View.ShowForm();
        }

        private void View_OnDeleteEmployee(object sender, EventArgs e)
        {
            var employeeToDelete = _employeeRepository.GetOne(View.CurrentEmployee.BarCode);
            if (employeeToDelete == null) return;
            if (_shiftCheckRepository.GetSome(sc => sc.BarCode == View.CurrentEmployee.BarCode).Count > 0)
            {
                _messageService.ShowError("There are records in ShiftCheck table with this employee." + Environment.NewLine + "Deletion of this record is impossible.");
                return;
            }
            try
            {
                _employeeRepository.Delete(employeeToDelete);
            }
            catch (Exception exception)
            {
                _messageService.ShowError("Record was not deleted." + Environment.NewLine +
                                          "Error message: " + exception.Message);
            }
            UpdateEmployees();
        }

        private void View_OnAddEmployee(object sender, EventArgs e)
        {
            EmployeeFormPresenter addEmployeeFormPresenter = new EmployeeFormPresenter(_messageService);
            addEmployeeFormPresenter.View.ShowForm();
            UpdateEmployees();
        }

        private void UpdateEmployees(Expression<Func<Employee, bool>> @where = null)
        {
            if (where == null)
                View.Employees = _employeeRepository.GetAll();
            else
                View.Employees = _employeeRepository.GetSome(where);
        }
    }
}