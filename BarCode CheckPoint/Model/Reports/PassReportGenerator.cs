using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Reports.Interfaces;
using FastReport;
using FastReport.Export.Image;

namespace CheckPoint.Model.Reports
{
    public class PassReportGenerator : IReportGenerator, IReportExporter
    {
        private readonly IEnumerable<Employee> _employees;
        private readonly Report _report;
        private readonly ImageExport _export;

        public PassReportGenerator(IEnumerable<Employee> employees)
        {
            _employees = employees;
            IsPrepared = false;
            _report = new Report();
            _export = new ImageExport();
        }

        public bool IsPrepared { get; private set; }

        public void LoadTemplate(string fileName)
        {
            if (File.Exists(fileName))
                _report.Load(fileName);
        }

        public void GenerateReport()
        {
            var passEmployees = _employees.Select(emp => new
            {
                emp.BarCode,
                emp.FirstName,
                emp.LastName,
                emp.Patronymic,
                Post = emp.Post.Name,
                PhotoPath = emp.FullName + "-" + emp.BarCode + ".png",
            });
            _report.RegisterData(passEmployees, "Employees");
            _report.Prepare();
            IsPrepared = true;
        }

        public void Export(string fileName)
        {
            if (!IsPrepared) return;
            _export.ImageFormat = ImageExportFormat.Png;
            _export.Resolution = 300;
            _export.SeparateFiles = true;
            _export.Export(_report, fileName);
        }
    }
}