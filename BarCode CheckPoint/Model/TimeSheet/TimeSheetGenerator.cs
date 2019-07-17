using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model.TimeSheet
{
    class TimeSheetGenerator: ITimeSheetGenerator
    {
        private readonly List<TimeSheetRecord> _sheetRecords;
        private readonly List<ShiftCheck> _checks;
        private TimeSpan _startOfDayShift;
        private TimeSpan _endOfDayShift;
        public TimeSheetGenerator(List<ShiftCheck> checks)
        {
            _sheetRecords = new List<TimeSheetRecord>();
            _checks = checks;
            _startOfDayShift = new TimeSpan(6, 0, 0);
            _endOfDayShift = new TimeSpan(22, 0, 0);
        }

        public List<TimeSheetRecord> SheetRecords
        {
            get { return _sheetRecords; }
        }

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
            int round = 1;
            DateTime currentDate = check.DateTimeEntry ?? check.DateTimeExit ?? DateTime.MaxValue;
            DateTime endDate = check.DateTimeExit ?? check.DateTimeEntry ?? DateTime.MinValue;
            TimeSpan timeStart = new TimeSpan();
            TimeSpan timeEnd = new TimeSpan();
            while (true)
            {
                switch (round)
                {
                    case 1:
                        timeStart = TimeSpan.FromHours(0);
                        timeEnd = TimeSpan.FromHours(6);
                        break;
                    case 2:
                        timeStart = TimeSpan.FromHours(6);
                        timeEnd = TimeSpan.FromHours(22);
                        break;
                    case 3:
                        timeStart = TimeSpan.FromHours(22);
                        timeEnd = TimeSpan.Parse("23:59:59:999");
                        break;
                }

                if (currentDate.TimeOfDay >= timeStart &&
                    currentDate.TimeOfDay < timeEnd)
                {
                    var temp = currentDate.Date + timeEnd;
                    if (temp >= endDate)
                    {
                        temp = endDate;
                        var hours = (temp - currentDate).Hours;
                        AddShiftRecord(check.BarCode, check.Employee.FullName, check.Employee.Post.Name, temp, round, hours);
                        return;
                    }
                    else
                    {
                        var hours = (temp - currentDate).Hours;
                        AddShiftRecord(check.BarCode, check.Employee.FullName, check.Employee.Post.Name, temp, round, hours);
                        currentDate = currentDate.Date + timeEnd;
                    }
                }

                round++;
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
                    shift = 1;
                    break;
            }

            var record = SheetRecords.FirstOrDefault(sr => sr.Date == tempDate && sr.Barcode == barCode);
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
                SheetRecords.Add(sheetRecord);
            }
        }
    }
}
