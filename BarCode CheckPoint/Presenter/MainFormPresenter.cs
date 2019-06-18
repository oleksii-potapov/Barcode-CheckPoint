using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.CameraAndPhoto;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Repository;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class MainFormPresenter
    {
        private readonly IMainForm _view;
        private readonly IMessageService _messageService;
        private readonly ApplicationContext _context;
        private readonly GenericRepository<Employee> _employeeRepo;
        private readonly GenericRepository<Post> _postRepo;
        private readonly GenericRepository<ShiftCheck> _shiftCheckRepo;
        private readonly WebCamera _webCamera;
        private readonly Timer _cameraTimer;
        public IMainForm View => _view;

        public MainFormPresenter(IMainForm mainForm, IMessageService messageService, ApplicationContext context)
        {
            _view = mainForm;
            _messageService = messageService;
            _context = context;
            _employeeRepo = new GenericRepository<Employee>(context);
            _postRepo = new GenericRepository<Post>(context);
            _shiftCheckRepo = new GenericRepository<ShiftCheck>(context);
            _webCamera = new WebCamera();
            // show web-camera image
            _cameraTimer = new Timer((obj) => _view.Camera = _webCamera.GetImage(),
                new AutoResetEvent(false), 500, 50);

            _view.EmployeeChecked += _view_EmployeeChecked;
            _view.CheckFormClick += _view_CheckFormClick;
            _view.ReportsClick += _view_ReportsClick;
            _view.SettingsClick += _view_SettingsClick;
            _view.FormShow += _view_FormShow;
            _view.FormClose += _view_FormClose;
        }

        private void _view_FormClose(object sender, EventArgs e)
        {
            if (_messageService.ShowQuestion("Close programm?") == true)
            {
                _context.Dispose();
                _view.CloseForm();
            }
        }

        private async void _view_FormShow(object sender, EventArgs e)
        {

        }

        private void _view_SettingsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _view_ReportsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _view_CheckFormClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _view_EmployeeChecked(object sender, EventArgs e)
        {
            if (_view.BarCode == string.Empty)
                return;
            if (_context.Employees.Find(_view.BarCode) == null)
                return;

            if (_view.IsEntry)
            {
                ShiftCheck shift = new ShiftCheck()
                {
                    BarCode = _view.BarCode,
                    DateTimeEntry = DateTime.Now,
                };
                _shiftCheckRepo.Create(shift);
                ShowLastCheck(shift);
            }
            else
            {
                var shifts = _shiftCheckRepo.GetItems(s => s.BarCode == _view.BarCode);
                var lastShift = shifts.OrderByDescending(s => s.DateTimeEntry).FirstOrDefault();
                if (lastShift == null
                    || lastShift.DateTimeExit.HasValue
                    || lastShift.DateTimeEntry.HasValue
                    && DateTime.Now - lastShift.DateTimeEntry.Value >
                    TimeSpan.FromHours(Properties.Settings.Default.MaxShiftInHours))
                {
                    ShiftCheck shift = new ShiftCheck()
                    {
                        BarCode = _view.BarCode,
                        DateTimeExit = DateTime.Now,
                    };
                    _shiftCheckRepo.Create(shift);
                    ShowLastCheck(shift);
                }
                else
                {
                    lastShift.DateTimeExit = DateTime.Now;
                    _shiftCheckRepo.Update(lastShift);
                    ShowLastCheck(lastShift);
                }
            }
        }

        private void ShowLastCheck(ShiftCheck shiftCheck)
        {
            _view.FullName = shiftCheck.Employee.FullName;
            _view.Post = shiftCheck.Employee.Post.Name;
            _view.DateTimeEntry = shiftCheck.DateTimeEntry;
            _view.DateTimeExit = shiftCheck.DateTimeExit;
            _webCamera.SaveImageToFileAsync(shiftCheck.Employee.FullName + ".jpg");
            _view.CheckPhoto = _webCamera.Snapshot;
        }
    }
}