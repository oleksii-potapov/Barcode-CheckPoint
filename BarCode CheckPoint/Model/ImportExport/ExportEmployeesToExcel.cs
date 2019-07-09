using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Repositories;
using ClosedXML.Excel;

namespace CheckPoint.Model.ImportExport
{
    class ExportEmployeesToExcel : IExportData
    {
        private XLWorkbook _workbook;
        private readonly EmployeeRepository _employeeRepository;
        public ExportEmployeesToExcel(string fileName)
        {
            FileName = fileName;
            _employeeRepository = new EmployeeRepository();
        }

        public string FileName { get; }
        public void Export()
        {
            CreateFile();
            ExportEmployees();
            SaveFile();
        }

        private void CreateFile()
        {
            _workbook = new XLWorkbook();
        }

        private void SaveFile()
        {
            _workbook.SaveAs(FileName);
        }

        private void ExportEmployees()
        {
            CreateDataHeaders();
            ExportData();
            SetStyles();
        }

        private void CreateDataHeaders()
        {
            var worksheet = _workbook.Worksheet(1);
            worksheet.Name = "Employees";
            worksheet.Cell(1, 1).Value = "BarCode";
            worksheet.Cell(1, 2).Value = "FirstName";
            worksheet.Cell(1, 3).Value = "LastName";
            worksheet.Cell(1, 4).Value = "Patronymic";
            worksheet.Cell(1, 5).Value = "Post";
        }

        private void ExportData()
        {
            var worksheet = _workbook.Worksheet(1);
            var employeeList = _employeeRepository.GetAllWithIncludes();
            var i = worksheet.RowsUsed().Count() + 1;
            foreach (var employee in employeeList)
            {
                worksheet.Cell(i, 1).Value = employee.BarCode;
                worksheet.Cell(i, 2).Value = employee.FirstName;
                worksheet.Cell(i, 3).Value = employee.LastName;
                worksheet.Cell(i, 4).Value = employee.Patronymic;
                worksheet.Cell(i, 5).Value = employee.Post;
                i++;
            }
        }

        private void SetStyles()
        {
            var worksheet = _workbook.Worksheet(1);
            worksheet.Column(1).Width = 10;
            worksheet.Column(2).Width = 20;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 20;
            worksheet.Column(5).Width = 30;
            worksheet.Row(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
    }
}
