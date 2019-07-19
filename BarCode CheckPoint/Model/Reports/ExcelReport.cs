using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Service;

namespace CheckPoint.Model.Reports
{
    public abstract class ExcelReport<T> where T : class
    {
        private string _fileName;
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

        public void CreateReport()
        {
            OpenTemplate();
            FillData();
            SaveFileToTemp();
        }
        private void OpenTemplate()
        {
            Workbook = new XLWorkbook(Path.Combine(ProjectDirectories.GetReportsTemplatesDirectory(),
                ReportTemplateName + ".xlsx"));
        }

        protected abstract void FillData();

        private void SaveFileToTemp()
        {
            ProjectDirectories.CreateTempIfNoExists();
            var path = ProjectDirectories.GetTempDirectory();
            _fileName = Path.Combine(path, string.Format($"{ReportTemplateName} {DateTime.Now:ddMMyyyy_HHmmssfff}.xlsx"));
            Workbook.SaveAs(_fileName);
        }
        public void ShowReport()
        {
            System.Diagnostics.Process.Start(_fileName);
        }

    }
}