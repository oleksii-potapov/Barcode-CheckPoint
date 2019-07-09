using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Repositories;
using ClosedXML.Excel;

namespace CheckPoint.Model.ImportExport
{
    class ImportEmployeesFromExcel : IImportData
    {
        private XLWorkbook _workbook;
        private readonly EmployeeRepository _employeeRepository;
        private readonly PostRepository _postRepository;
        public ImportEmployeesFromExcel(string fileName)
        {
            FileName = fileName;
            _employeeRepository = new EmployeeRepository();
            _postRepository = new PostRepository();
        }

        public string FileName { get; }
        public void Import()
        {
            OpenFile();
            var employees = ImportEmployeesToList();
            ImportEmployeesFromListToDataBase(employees);
        }

        private void OpenFile()
        {
            _workbook = new XLWorkbook(FileName);
        }

        private IEnumerable<Employee> ImportEmployeesToList()
        {
            var listEmployees = new List<Employee>();
            var worksheet = _workbook.Worksheet(1);
            int firstDataRow = 2;
            var lastDataRow = worksheet.RowsUsed().Count();

            for (int i = firstDataRow; i <= lastDataRow; i++)
            {
                var postValue = worksheet.Cell(i, 5).Value.ToString();
                var post = _postRepository.FindByName(postValue) ?? _postRepository.AddByName(postValue);
                listEmployees.Add(new Employee()
                {
                    BarCode = worksheet.Cell(i, 1).Value.ToString(),
                    FirstName = worksheet.Cell(i, 2).Value.ToString(),
                    LastName = worksheet.Cell(i, 3).Value.ToString(),
                    Patronymic = worksheet.Cell(i, 4).Value.ToString(),
                    Post = post,
                });
            }
            return listEmployees;
        }

        private void ImportEmployeesFromListToDataBase(IEnumerable<Employee> employees)
        {
            var empList = employees;
            var isNewEmployee = false;
            foreach (var item in empList)
            {
                var employee = _employeeRepository.GetOne(item.BarCode);
                if (employee == null)
                {
                    employee = item;
                    isNewEmployee = true;
                }

                if (isNewEmployee)
                    _employeeRepository.Add(employee);
                else
                    _employeeRepository.Update(employee);
            }
        }
    }
}
