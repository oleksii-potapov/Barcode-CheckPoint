using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.ImportExport
{
    public interface IImportData
    {
        string FileName { get; }
        void Import();
    }
}
