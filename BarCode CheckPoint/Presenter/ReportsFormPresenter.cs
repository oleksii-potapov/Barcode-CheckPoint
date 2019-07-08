using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Reports;
using CheckPoint.Model.Repositories;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class ReportsFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly ShiftCheckRepository _shiftCheckRepository;
        public IReportsForm View { get; }

        public ReportsFormPresenter(IMessageService messageService)
        {
            var employeeRepository = new EmployeeRepository();
            _shiftCheckRepository = new ShiftCheckRepository();
            _messageService = messageService;
            View = new ReportsForm
            {
                Employees = employeeRepository.GetBindingList()
            };

            View.OnGenerateTimeSheet += View_OnGenerateTimeSheet;
            View.OnGenerateExcelReport += View_OnGenerateExcelReport;
        }

        private void View_OnGenerateExcelReport(object sender, EventArgs e)
        {
                var beginDate = View.DateTimeBegin.Date;
                var endDate = View.DateTimeEnd.Date.AddDays(1).AddTicks(-1);
                var list = _shiftCheckRepository.GetSomeWithAllIncludes(sc => (sc.DateTimeEntry >= beginDate && sc.DateTimeEntry <= endDate) || 
                  (sc.DateTimeExit >= beginDate && sc.DateTimeExit <= endDate));
                FilterOptions filterOptions =
                    new FilterOptions(beginDate.Date, endDate.Date) {Employee = "All"};
                if (View.ShowOnlySelectedEmployeeChecks)
                {
                    list = list.Where(sc => sc.BarCode == View.BarCode);
                    filterOptions.Employee = View.EmployeeName;
                }

                ShiftChecksExcelReport report =
                    new ShiftChecksExcelReport(list.ToList(), nameof(ShiftChecksExcelReport), filterOptions);
                Task.Run(() =>
                {
                    report.CreateReport();
                    report.ShowReport();
                });
        }

        private void View_OnGenerateTimeSheet(object sender, EventArgs e)
        {
        }
    }
}
