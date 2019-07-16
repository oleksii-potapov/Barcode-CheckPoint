using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using CheckPoint.Model.Entities;
using CheckPoint.Model.ImportExport;
using CheckPoint.Model.Reports;
using CheckPoint.Model.Repositories;
using CheckPoint.Service;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class EmployeeListFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ShiftCheckRepository _shiftCheckRepository;
        private bool _isFiltered = false;
        public IEmployeeListForm View { get; }

        public EmployeeListFormPresenter(IMessageService messageService)
        {
            _employeeRepository = new EmployeeRepository();
            _shiftCheckRepository = new ShiftCheckRepository();
            _messageService = messageService;
            View = new EmployeeListForm() {Employees = _employeeRepository.GetBindingList()};

            View.OnAddEmployee += View_OnAddEmployee;
            View.OnDeleteEmployee += View_OnDeleteEmployee;
            View.OnEditEmployee += View_OnEditEmployee;
            View.OnCleanFilter += View_OnCleanFilter;
            View.OnFiltered += View_OnFiltered;
            View.OnExportEmployees += View_OnExportEmployees;
            View.OnImportEmployees += View_OnImportEmployees;
            View.OnGeneratePasses += View_OnGeneratePasses;
        }

        private void View_OnGeneratePasses(object sender, EventArgs e)
        {
            PassReportGenerator passReport = new PassReportGenerator(View.SelectedEmployees);
            passReport.LoadTemplate(Path.Combine(ProjectDirectories.GetReportsTemplatesDirectory(), "PassCard.frx"));
            passReport.GenerateReport();
            var savePath = Path.Combine(ProjectDirectories.GetTempReportsDirectory(), "report.png");
            ProjectDirectories.CreateTempReportsIfNoExists();
            ProjectDirectories.DeleteAllFilesFromTempReports();
            passReport.Export(savePath);
            passReport.OpenReport();
        }

        private void View_OnImportEmployees(object sender, EventArgs e)
        {
            ImportEmployees(new ImportEmployeesFromExcel(View.ImportFileName));
            UpdateEmployees();
        }

        private void View_OnExportEmployees(object sender, EventArgs e)
        {
            ExportEmployees(new ExportEmployeesToExcel(View.ExportFileName));
            _messageService.ShowMessage("Data exported to file.");
        }

        private void View_OnFiltered(object sender, EventArgs e)
        {
            _isFiltered = true;
            UpdateEmployees();
        }

        private void View_OnCleanFilter(object sender, EventArgs e)
        {
            _isFiltered = false;
            View.Filter = string.Empty;
            UpdateEmployees();
        }

        private void View_OnEditEmployee(object sender, EventArgs e)
        {
            EmployeeFormPresenter editEmployeeFormPresenter =
                new EmployeeFormPresenter(_messageService, _employeeRepository, View.CurrentEmployee);
            editEmployeeFormPresenter.View.IsCodeActive = false;
            editEmployeeFormPresenter.OnFormClose += (o, args) => UpdateEmployees();
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
            EmployeeFormPresenter addEmployeeFormPresenter = new EmployeeFormPresenter(_messageService, _employeeRepository);
            addEmployeeFormPresenter.View.IsCodeActive = true;
            addEmployeeFormPresenter.OnFormClose += (o, args) => UpdateEmployees();
            addEmployeeFormPresenter.View.ShowForm();
        }

        private void UpdateEmployees()
        {
            View.Employees = _employeeRepository.GetBindingList();
            if (_isFiltered)
            {
                Expression <Func<Employee, bool>> @where = (emp) =>
                    emp.FirstName.ToUpper().Contains(View.Filter.ToUpper()) ||
                    emp.LastName.ToUpper().Contains(View.Filter.ToUpper()) ||
                    emp.Patronymic.ToUpper().Contains(View.Filter.ToUpper());
                    
                View.Employees = new BindingList<Employee>(View.Employees.AsQueryable().Where(@where).ToList());
            }
        }

        private void ImportEmployees(IImportData import)
        {
            import.Import();
        }

        private void ExportEmployees(IExportData export)
        {
            export.Export();
        }
    }
}