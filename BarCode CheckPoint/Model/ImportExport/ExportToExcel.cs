using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.ImportExport
{
    class ExportToExcel : IExportData
    {
        public ExportToExcel(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
        public void Export()
        {
            throw new NotImplementedException();
        }
    }
}
