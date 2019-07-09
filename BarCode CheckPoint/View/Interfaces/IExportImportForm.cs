using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.View.Interfaces
{
    interface IExportImportForm : IForm
    {
        event EventHandler OnExportClick;
        event EventHandler OnImportClick;
    }
}