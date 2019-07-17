using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.TimeSheet
{
    [Serializable]
    public class TimeSheetRecord
    {
        public string Barcode { get; set; }
        public string FullName { get; set; }
        public string Post { get; set; }
        public DateTime Date { get; set; }
        public int DayHours { get; set; }
        public int NightHours { get; set; }
    }
}
