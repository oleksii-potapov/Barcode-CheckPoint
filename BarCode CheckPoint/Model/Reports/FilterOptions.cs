using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Reports
{
    public class FilterOptions
    {
        public DateTime DateTimeBegin { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public string Employee { get; set; }
        public string Post { get; set; }

        public FilterOptions(DateTime dateTimeBegin, DateTime dateTimeEnd, string employee = null, string post = null)
        {
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Employee = employee;
            Post = post;
        }
    }
}
