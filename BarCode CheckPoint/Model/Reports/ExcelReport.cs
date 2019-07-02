using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Reports
{
    public abstract class ExcelReport<T> where T : class
    {
        protected XLWorkbook Workbook;
        protected readonly IEnumerable<T> DataOfReport;
        protected readonly string ReportTemplateName;
        protected readonly FilterOptions FilterOptions;

        protected ExcelReport(IEnumerable<T> dataOfReport, string reportTemplateName, FilterOptions filterOptions)
        {
            DataOfReport = dataOfReport;
            ReportTemplateName = reportTemplateName;
            FilterOptions = filterOptions;
        }

        public abstract void CreateReport();

        public abstract void ShowReport();
    }
}