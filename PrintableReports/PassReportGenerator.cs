using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintableReports.Interfaces;

namespace PrintableReports
{
    public class PassReportGenerator : IReportGenerator
    {
        IEnumerable
        public PassReportGenerator()
        {
            IsPrepared = false;
        }

        public bool IsPrepared { get; }
        public void LoadTemplate(string fileName)
        {
            throw new NotImplementedException();
        }

        public void GenerateReport()
        {
            throw new NotImplementedException();
        }
    }
}
