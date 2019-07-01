using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Entities;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class EmployeeFormPresenter
    {
        private readonly ApplicationContext _context;
        private readonly IMessageService _messageService;
        private Employee _currentEmployee;
        private readonly bool _isNewRecord;
        public IEmployeeForm View { get; }

        public EmployeeFormPresenter(IMessageService messageService, ApplicationContext context, Employee currentEmployee = null)
        {
            _context = context;
            _messageService = messageService;
            _currentEmployee = currentEmployee;
            _isNewRecord = currentEmployee == null;
            _context.Posts.Load();
            View = new EmployeeForm() {PostList = _context.Posts.Local.ToBindingList()};

            View.OnFormShow += View_OnFormShow;
            View.OnApplyChanges += View_OnApplyChanges;
            View.OnChoosePhoto += View_OnChoosePhoto;
        }

        private void View_OnChoosePhoto(object sender, View.Services.EventPhotoArgs e)
        {
            var photoPath = e.PhotoPath;
            View.EmployeePhoto = Image.FromFile(photoPath);
        }

        private void View_OnApplyChanges(object sender, EventArgs e)
        {
            if (View.BarCode == String.Empty)
            {
                _messageService.ShowError("BarCode can not be empty!");
                return;
            }

            if (_context.Employees.FirstOrDefault(emp => emp.BarCode == View.BarCode) != null && _isNewRecord)
            {
                _messageService.ShowError("BarCode already exists in the database!");
                return;
            }

            if(_isNewRecord)
                AddRecord();
            else
                EditRecord();

            View.EmployeePhoto?.Save(Path.Combine(Properties.Settings.Default.EmployeePhotoFolder, string.Format($"{_currentEmployee.FullName}-{_currentEmployee.BarCode}.jpg")));
            View.CloseForm();
        }

        private void View_OnFormShow(object sender, EventArgs e)
        {
            if (!_isNewRecord)
                FillData();
        }

        private void FillData()
        {
            View.BarCode = _currentEmployee.BarCode;
            View.FirstName = _currentEmployee.FirstName;
            View.LastName = _currentEmployee.LastName;
            View.Patronymic = _currentEmployee.Patronymic;
            if (_currentEmployee.PostId != null)
                View.PostId = _currentEmployee.PostId.Value;
            var photoPath = Path.Combine(Properties.Settings.Default.EmployeePhotoFolder,
                string.Format($"{_currentEmployee.FullName}-{_currentEmployee.BarCode}.jpg"));
            if (File.Exists(photoPath))
                View.EmployeePhoto = Image.FromFile(photoPath);
        }

        private void AddRecord()
        {
            _currentEmployee = new Employee();
            _currentEmployee.BarCode = View.BarCode;
            _currentEmployee.FirstName = View.FirstName;
            _currentEmployee.LastName = View.LastName;
            _currentEmployee.Patronymic = View.Patronymic;
            _currentEmployee.PostId = View.PostId;
            _context.Employees.Add(_currentEmployee);
            _context.SaveChanges();
        }

        private void EditRecord()
        {
            _currentEmployee.BarCode = View.BarCode;
            _currentEmployee.FirstName = View.FirstName;
            _currentEmployee.LastName = View.LastName;
            _currentEmployee.Patronymic = View.Patronymic;
            _currentEmployee.PostId = View.PostId;
            _context.Entry(_currentEmployee).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}