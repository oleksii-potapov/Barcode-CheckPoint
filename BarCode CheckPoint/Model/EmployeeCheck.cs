using CheckPoint.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Repositories;

namespace CheckPoint.Model
{
    class EmployeeCheck
    {
        private readonly bool _isEntry;
        private readonly string _barCode;
        private readonly ShiftCheckRepository _shiftCheckRepository;
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeCheck(bool isEntry, string barCode)
        {
            _isEntry = isEntry;
            _barCode = barCode;
            _shiftCheckRepository = new ShiftCheckRepository();
            _employeeRepository = new EmployeeRepository();
        }

        public ShiftCheck Check()
        {
            ShiftCheck shiftCheck;
            if (_employeeRepository.GetOne(_barCode) == null)
                return null;

            if (_isEntry)
            {
                shiftCheck = new ShiftCheck()
                {
                    BarCode = _barCode,
                    DateTimeEntry = DateTime.Now,
                };
                _shiftCheckRepository.Add(shiftCheck);
            }
            else
            {
                shiftCheck = _shiftCheckRepository.GetLastEntryByBarCode(_barCode);
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
                    _shiftCheckRepository.Add(shiftCheck);
                }
                else
                {
                    shiftCheck.DateTimeExit = DateTime.Now;
                    _shiftCheckRepository.Update(shiftCheck);
                }
            }
            _shiftCheckRepository.LoadAllIncludes(shiftCheck);
            return shiftCheck;
        }
    }
}
