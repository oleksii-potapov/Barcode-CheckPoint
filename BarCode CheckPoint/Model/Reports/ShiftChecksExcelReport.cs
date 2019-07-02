using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;
using ClosedXML.Excel;
using Emgu.CV.Structure;

namespace CheckPoint.Model.Reports
{
    class ShiftChecksExcelReport : ExcelReport<ShiftCheck>
    {
        private string _fileName;

        public ShiftChecksExcelReport(IEnumerable<ShiftCheck> dataOfReport, string reportTemplateName, FilterOptions filterOptions) : base(dataOfReport,
            reportTemplateName, filterOptions)
        {
        }

        public override void CreateReport()
        {
            OpenTemplate();
            FillData();
            SaveFileToTemp();
        }

        public override void ShowReport()
        {
            System.Diagnostics.Process.Start(_fileName);
        }

        private void OpenTemplate()
        {
            Workbook = new XLWorkbook(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                ReportTemplateName + ".xlsx"));
        }

        private void FillData()
        {
            var worksheet = Workbook.Worksheet(1);
            var lastRowIndex = worksheet.RangeUsed().LastRowUsed().RowNumber();
            int i = lastRowIndex + 1;
            worksheet.Cell(2, 2).Value = FilterOptions.DateTimeBegin.Date;
            worksheet.Cell(3, 2).Value = FilterOptions.DateTimeEnd.Date;
            worksheet.Cell(4, 2).Value = FilterOptions.Employee;

            foreach (var item in DataOfReport)
            {
                worksheet.Cell(i, 1).Value = i - lastRowIndex;
                worksheet.Cell(i, 2).Value = item.Employee;
                worksheet.Cell(i, 3).Value = item.Employee.Post;
                worksheet.Cell(i, 4).Value = item.DateTimeEntry;
                worksheet.Cell(i, 5).Value = item.DateTimeExit;
                i++;
            }

            var Range = worksheet.Range(lastRowIndex, 1, 
                worksheet.RangeUsed().LastRowUsed().RowNumber(),
                worksheet.RangeUsed().LastColumnUsed().ColumnNumber());
            Range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            Range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }

        private void SaveFileToTemp()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp");
            if (Directory.Exists(path))
                Directory.CreateDirectory(path);
            _fileName = Path.Combine(path, string.Format($"{ReportTemplateName} {DateTime.Now:ddMMyyyy_HHmmss}.xlsx"));
            Workbook.SaveAs(_fileName);
        }
    }
}