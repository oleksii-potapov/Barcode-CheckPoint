using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model.Repositories
{
    class ShiftCheckRepository : BaseRepository<ShiftCheck>
    {
        public ShiftCheck GetLastEntryByBarCode(string barCode)
        {
            return Context.ShiftChecks.Where(sc => sc.BarCode == barCode)
                .OrderByDescending(sc => sc.DateTimeEntry)
                .FirstOrDefault();
        }

        public void LoadAllIncludes(ShiftCheck shiftCheck)
        {
            Context.Entry(shiftCheck).Reference(sc => sc.Employee).Load();
            var emp = shiftCheck.Employee;
            Context.Entry(emp).Reference(e => e.Post).Load();
        }

        public IEnumerable<ShiftCheck> GetSomeWithAllIncludes(Expression<Func<ShiftCheck, bool>> where)
        {
            return Context.ShiftChecks
                .Include(sc => sc.Employee)
                .Include(emp => emp.Employee.Post)
                .Where(where).ToList();
        }
    }
}