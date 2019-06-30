using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class EmployeeListFormPresenter
    {
        private readonly ApplicationContext _context;
        private readonly IMessageService _messageService;
        public IEmployeeListForm View { get; }

        public EmployeeListFormPresenter(IMessageService messageService, ApplicationContext context)
        {
            _context = context;
            _context.Employees.Load();
            _messageService = messageService;

            View = new EmployeeListForm() {Employees = _context.Employees.Local.ToBindingList()};

            View.OnAddEmployee += View_OnAddEmployee;
            View.OnDeleteEmployee += View_OnDeleteEmployee;
            View.OnEditEmployee += View_OnEditEmployee;

        }

        private void View_OnEditEmployee(object sender, EventArgs e)
        {
            EmployeeFormPresenter editEmployeeFormPresenter = new EmployeeFormPresenter(_messageService, _context, View.CurrentEmployee);
            editEmployeeFormPresenter.View.ShowForm();
        }

        private void View_OnDeleteEmployee(object sender, EventArgs e)
        {
            var employeeToDelete = _context.Employees.Find(View.CurrentEmployee.BarCode);
            if (employeeToDelete == null) return;
            if (_context.ShiftChecks.FirstOrDefault(sc => sc.BarCode == View.CurrentEmployee.BarCode) != null)
            {
                _messageService.ShowError("There are records in ShiftCheck table with this employee." +
                                          Environment.NewLine + "Deletion of this record is impossible.");
                return;
            }

            try
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                _messageService.ShowError("Record was not deleted." + Environment.NewLine +
                                          "Error message: " + exception.Message);
            }
        }

        private void View_OnAddEmployee(object sender, EventArgs e)
        {
            EmployeeFormPresenter addEmployeeFormPresenter = new EmployeeFormPresenter(_messageService, _context);
            addEmployeeFormPresenter.View.ShowForm();
        }
    }
}
