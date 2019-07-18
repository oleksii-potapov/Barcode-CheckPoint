using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.TimeSheet;
using CheckPoint.Service;
using ClosedXML.Excel;

namespace CheckPoint.Model.Reports
{
    class TimeSheetReport : ExcelReport<TimeSheetRecord>
    {
        private string _fileName;

        public TimeSheetReport(IEnumerable<TimeSheetRecord> dataOfReport, string reportTemplateName,
            FilterOptions filterOptions) : base(dataOfReport, reportTemplateName, filterOptions)
        {
        }

        protected override void FillData()
        {
            throw new NotImplementedException();
        }
    }
}