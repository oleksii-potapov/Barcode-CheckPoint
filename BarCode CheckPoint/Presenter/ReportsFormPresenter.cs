using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Reports;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class ReportsFormPresenter
    {
        private readonly ApplicationContext _context;
        private readonly IMessageService _messageService;
        public IReportsForm View { get; }

        public ReportsFormPresenter(IMessageService messageService, ApplicationContext context)
        {
            _context = context;
            _messageService = messageService;
            View = new ReportsForm();
            _context.Employees.OrderBy(emp => emp.LastName).ThenBy(emp => emp.FirstName).Load();
            View.Employees = _context.Employees.Local.ToBindingList();

            View.OnGenerateTimeSheet += View_OnGenerateTimeSheet;
            View.OnGenerateExcelReport += View_OnGenerateExcelReport;
        }

        private void View_OnGenerateExcelReport(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var beginDate = View.DateTimeBegin.Date;
                var endDate = View.DateTimeEnd.Date.AddDays(1).AddTicks(-1);
                var list = _context.ShiftChecks
                    .Include(sc => sc.Employee)
                    .Include(emp => emp.Employee.Post)
                    .Where(sc => sc.DateTimeEntry >= beginDate && sc.DateTimeEntry <= endDate);
                FilterOptions filterOptions =
                    new FilterOptions(beginDate.Date, endDate.Date) {Employee = "All"};
                if (View.ShowOnlySelectedEmployeeChecks)
                {
                    list = list.Where(sc => sc.BarCode == View.BarCode);
                    filterOptions.Employee = View.EmployeeName;
                }

                ShiftChecksExcelReport report =
                    new ShiftChecksExcelReport(list.ToList(), nameof(ShiftChecksExcelReport), filterOptions);
                report.CreateReport();
                report.ShowReport();
            });
        }

        private void View_OnGenerateTimeSheet(object sender, EventArgs e)
        {
        }
    }
}
