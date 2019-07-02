using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class ReportsFormPresenter
    {
        private readonly ApplicationContext _context;
        private readonly IMessageService _messageService;
        public IReportsForm View { get; }

        public ReportsFormPresenter(ApplicationContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
            View = new ReportsForm();

            View.OnGenerateTimeSheet += View_OnGenerateTimeSheet;
            View.OnGenerateExcelReport += View_OnGenerateExcelReport;
        }

        private void View_OnGenerateExcelReport(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_OnGenerateTimeSheet(object sender, EventArgs e)
        {
        }
    }
}
