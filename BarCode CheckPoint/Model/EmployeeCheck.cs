using CheckPoint.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model
{
    class EmployeeCheck
    {
        private readonly bool _isEntry;
        private readonly string _barCode;
        private readonly ApplicationContext _context;
        public EmployeeCheck(bool isEntry, string barCode, ApplicationContext context)
        {
            _isEntry = isEntry;
            _barCode = barCode;
            _context = context;
        }

        public ShiftCheck Check()
        {
            ShiftCheck shiftCheck;
            if (!_context.IsConnected)
                return null;
            if (_context.Employees.Find(_barCode) == null)
                return null;

            if (_isEntry)
            {
                shiftCheck = new ShiftCheck()
                {
                    BarCode = _barCode,
                    DateTimeEntry = DateTime.Now,
                };
                _context.ShiftChecks.Add(shiftCheck);
                _context.SaveChanges();
            }
            else
            {
                var shifts = _context.ShiftChecks.Where(s => s.BarCode == _barCode);
                shiftCheck = shifts.OrderByDescending(s => s.DateTimeEntry).FirstOrDefault();
                if (shiftCheck == null
                    || shiftCheck.DateTimeExit.HasValue
                    || shiftCheck.DateTimeEntry.HasValue
                    && DateTime.Now - shiftCheck.DateTimeEntry.Value >
                    TimeSpan.FromHours(Properties.Settings.Default.MaxShiftInHours))
                {
                    shiftCheck = new ShiftCheck()
                    {
                        BarCode = _barCode,
                        DateTimeExit = DateTime.Now,
                    };
                    _context.ShiftChecks.Add(shiftCheck);
                    _context.SaveChanges();
                }
                else
                {
                    shiftCheck.DateTimeExit = DateTime.Now;
                    _context.Entry(shiftCheck).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            return shiftCheck;
        }
    }
}
