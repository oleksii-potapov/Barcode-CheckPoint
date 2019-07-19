using System;
using System.Collections.Generic;
using System.Linq;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model.TimeSheet
{
    class TimeSheetGenerator : ITimeSheetGenerator
    {
        private readonly List<TimeSheetRecord> _sheetRecords;
        private readonly List<ShiftCheck> _checks;
        private readonly TimeSpan _startOfDayShift;
        private readonly TimeSpan _endOfDayShift;

        public TimeSheetGenerator(List<ShiftCheck> checks)
        {
            _sheetRecords = new List<TimeSheetRecord>();
            _checks = checks;

            //TODO add shift hours to settings
            _startOfDayShift = new TimeSpan(6, 0, 0);
            _endOfDayShift = new TimeSpan(22, 0, 0);
        }

        public List<TimeSheetRecord> SheetRecords => _sheetRecords;

        public void Generate()
        {
            var names = _checks.Select(c => c.Employee.FullName)
                .Distinct()
                .OrderBy(c => c);
            foreach (var name in names)
            {
                var checksOfEmployee = _checks.Where(c => c.Employee.FullName == name).ToList();
                foreach (var check in checksOfEmployee)
                {
                    CheckShiftHours(check);
                }
            }
        }

        private void CheckShiftHours(ShiftCheck check)
        {
            // variable that will change to calculate hours
            DateTime currentDate = check.DateTimeEntry ?? check.DateTimeExit ?? DateTime.MaxValue;
            DateTime endDate = check.DateTimeExit ?? check.DateTimeEntry ?? DateTime.MinValue;
            TimeSpan periodStart = new TimeSpan();
            TimeSpan periodEnd = new TimeSpan();
            int round = 1;

            while (true)
            {
                // Check the period to compare
                switch (round)
                {
                    case 1:
                        periodStart = TimeSpan.FromHours(0);
                        periodEnd = _startOfDayShift;
                        break;
                    case 2:
                        periodStart = _startOfDayShift;
                        periodEnd = _endOfDayShift;
                        break;
                    case 3:
                        periodStart = _endOfDayShift;
                        periodEnd = TimeSpan.Parse("23:59:59.9999999");
                        break;
                }

                // check if variable is in a given period
                if (currentDate.TimeOfDay >= periodStart &&
                    currentDate.TimeOfDay < periodEnd)
                {
                    var temp = currentDate.Date + periodEnd;
                    // if this is the last check loop must be stopped
                    if (temp >= endDate)
                    {
                        temp = endDate;
                        var hours = (int) Math.Round((temp - currentDate).TotalMinutes / 60);
                        AddShiftRecord(check.BarCode, check.Employee.FullName, check.Employee.Post.Name, temp, round,
                            hours);
                        return;
                    }
                    // if not then add shift record and displace variable to the next period
                    else
                    {
                        var hours = (int) Math.Round((temp - currentDate).TotalMinutes / 60);
                        AddShiftRecord(check.BarCode, check.Employee.FullName, check.Employee.Post.Name, temp, round,
                            hours);
                        currentDate = currentDate.Date + periodEnd;
                    }
                }

                round++;
                // if it was the last check of day then variable displace to the next day
                if (round == 4)
                {
                    round = 1;
                    currentDate = currentDate.Date.AddDays(1);
                }
            }
        }

        private void AddShiftRecord(string barCode, string fullName, string post, DateTime date, int round, int hours)
        {
            var shift = 0;
            var tempDate = new DateTime();
            switch (round)
            {
                case 1:
                    tempDate = date.Date - TimeSpan.FromDays(1);
                    shift = 2;
                    break;
                case 2:
                    tempDate = date.Date;
                    shift = 1;
                    break;
                case 3:
                    tempDate = date.Date;
                    shift = 2;
                    break;
            }

            // check if record with this data is already in list
            var record = _sheetRecords.FirstOrDefault(sr => sr.Date == tempDate && sr.Barcode == barCode);
            if (record != null)
            {
                if (shift == 1)
                    record.DayHours += hours;
                else
                    record.NightHours += hours;
            }
            else
            {
                TimeSheetRecord sheetRecord = new TimeSheetRecord()
                {
                    Barcode = barCode,
                    Date = tempDate,
                    DayHours = shift == 1 ? hours : 0,
                    NightHours = shift == 2 ? hours : 0,
                    FullName = fullName,
                    Post = post
                };
                _sheetRecords.Add(sheetRecord);
            }
        }
    }
}