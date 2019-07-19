using System.Collections.Generic;
using System.Linq;
using CheckPoint.Model.TimeSheet;
using ClosedXML.Excel;

namespace CheckPoint.Model.Reports
{
    class TimeSheetReport : ExcelReport<TimeSheetRecord>
    {
        private IXLWorksheet _worksheet;

        public TimeSheetReport(IEnumerable<TimeSheetRecord> dataOfReport, string reportTemplateName,
            FilterOptions filterOptions) : base(dataOfReport, reportTemplateName, filterOptions)
        {
        }

        protected override void FillData()
        {
            _worksheet = Workbook.Worksheet(1);
            _worksheet.Cell("B2").Value = _worksheet.Cell("E4").Value =
                FilterOptions.DateTimeBegin;
            _worksheet.Cell("B2").Style.DateFormat.SetFormat("MMMM yyyy");
            _worksheet.Cell("E4").Style.DateFormat.SetFormat("MMMM");
            var recordNumber = 1;
            var rowIndex = _worksheet.RowsUsed().Last().RowNumber() + 2;
            var employees = DataOfReport.Select(s => s.Barcode).Distinct();
            foreach (var employee in employees)
            {
                var sheetRecords = DataOfReport.Where(s => s.Barcode == employee).ToList();
                var firstRecord = sheetRecords.FirstOrDefault();
                AddNewRow(rowIndex);
                _worksheet.Cell(rowIndex + 2, 1).Value = recordNumber++;
                _worksheet.Cell(rowIndex + 2, 2).Value = firstRecord?.FullName;
                _worksheet.Cell(rowIndex + 2, 3).Value = firstRecord?.Post;
                foreach (var sheetRecord in sheetRecords)
                {
                    AddShift(rowIndex, sheetRecord.Date.Day, sheetRecord.DayHours, sheetRecord.NightHours);
                }

                rowIndex += 3;
            }
        }

        private void AddNewRow(int rowIndex)
        {
            FormatEmployeeData(rowIndex);
            AddTotals(rowIndex);
            AddBorders(rowIndex);
        }

        private void FormatEmployeeData(int rowIndex)
        {
            _worksheet.Range(rowIndex, 1, rowIndex + 1, 3).Style.Font.FontColor = XLColor.White;
            _worksheet.Range(rowIndex, 1, rowIndex, 3).FormulaR1C1 = "=r[2]c";
            _worksheet.Range(rowIndex + 1, 1, rowIndex + 1, 3).FormulaR1C1 = "=r[1]c";
            _worksheet.Cell(rowIndex, 4).Value = "Day";
            _worksheet.Cell(rowIndex + 1, 4).Value = "Night";
            _worksheet.Cell(rowIndex + 2, 4).Value = "Total";
            _worksheet.Row(rowIndex + 2).Height = 30;
            _worksheet.Range(rowIndex + 2, 1, rowIndex + 2, 3).Style.Alignment.WrapText = true;
        }

        private void AddTotals(int rowIndex)
        {
            _worksheet.Range(rowIndex + 2, 5, rowIndex + 2, 35).FormulaR1C1 = "=SUM(r[-2]c:r[-1]c)";
            _worksheet.Cell(rowIndex + 2, 36).FormulaR1C1 = "=SUM(r[-2]c5:r[-2]c35)";
            _worksheet.Cell(rowIndex + 2, 37).FormulaR1C1 = "=SUM(r[-1]c5:r[-1]c35)";
            _worksheet.Cell(rowIndex + 2, 38).FormulaR1C1 = "=SUM(rc[-2]:rc[-1])";
        }

        private void AddBorders(int rowIndex)
        {
            _worksheet.Range(rowIndex, 1, rowIndex + 2, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            _worksheet.Range(rowIndex, 2, rowIndex + 2, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            _worksheet.Range(rowIndex, 3, rowIndex + 2, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            _worksheet.Range(rowIndex, 4, rowIndex + 2, _worksheet.ColumnsUsed().Last().ColumnNumber()).Style.Border
                .InsideBorder = XLBorderStyleValues.Thin;
            _worksheet.Range(rowIndex, 4, rowIndex + 2, _worksheet.ColumnsUsed().Last().ColumnNumber()).Style.Border
                .OutsideBorder = XLBorderStyleValues.Thin;
            _worksheet.Range(rowIndex, 1, rowIndex + 2, _worksheet.ColumnsUsed().Last().ColumnNumber()).Style.Border
                .OutsideBorder = XLBorderStyleValues.Medium;
        }

        private void AddShift(int rowIndex, int dayOfTheMonth, int dayHours, int nightHours)
        {
            const int firstDayColumn = 5;
            _worksheet.Cell(rowIndex, firstDayColumn + dayOfTheMonth - 1).Value = dayHours;
            if (nightHours > 0)
                _worksheet.Cell(rowIndex + 1, firstDayColumn + dayOfTheMonth - 1).Value = nightHours;
        }
    }
}