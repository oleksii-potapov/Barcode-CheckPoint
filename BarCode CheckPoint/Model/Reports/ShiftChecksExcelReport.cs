using System;
using System.Collections.Generic;
using System.IO;
using CheckPoint.Model.Entities;
using CheckPoint.Service;
using ClosedXML.Excel;

namespace CheckPoint.Model.Reports
{
    class ShiftChecksExcelReport : ExcelReport<ShiftCheck>
    {
        public ShiftChecksExcelReport(IEnumerable<ShiftCheck> dataOfReport, string reportTemplateName, FilterOptions filterOptions) : base(dataOfReport,
            reportTemplateName, filterOptions)
        {
        }

        protected override void FillData()
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

            var range = worksheet.Range(lastRowIndex, 1, 
                worksheet.RangeUsed().LastRowUsed().RowNumber(),
                worksheet.RangeUsed().LastColumnUsed().ColumnNumber());
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        }

    }
}