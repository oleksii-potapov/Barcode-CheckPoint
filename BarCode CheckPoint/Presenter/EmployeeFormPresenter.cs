using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.Entities;
using CheckPoint.Model.Repositories;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class EmployeeFormPresenter
    {
        private readonly IMessageService _messageService;
        private Employee _currentEmployee;
        private readonly bool _isNewRecord;
        private readonly PostRepository _postRepository;
        private readonly EmployeeRepository _employeeRepository;
        public IEmployeeForm View { get; }
        public event EventHandler OnFormClose;

        public EmployeeFormPresenter(IMessageService messageService, EmployeeRepository employeeRepository, Employee currentEmployee = null)
        {
            _messageService = messageService;
            _currentEmployee = currentEmployee;
            _isNewRecord = currentEmployee == null;
            _postRepository = new PostRepository();
            _employeeRepository = employeeRepository;

            View = new EmployeeForm() {PostList = _postRepository.GetAll()};

            View.OnFormShow += View_OnFormShow;
            View.OnApplyChanges += View_OnApplyChanges;
            View.OnChoosePhoto += View_OnChoosePhoto;
            View.OnFormClose += View_OnFormClose;
        }

        private void View_OnFormClose(object sender, EventArgs e)
        {
            OnFormClose?.Invoke(this, EventArgs.Empty);
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

            if (_employeeRepository.GetOne(View.BarCode) != null && _isNewRecord)
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
            _currentEmployee = _employeeRepository.GetOne(_currentEmployee.BarCode);
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
            _currentEmployee = new Employee
            {
                BarCode = View.BarCode,
                FirstName = View.FirstName,
                LastName = View.LastName,
                Patronymic = View.Patronymic,
                PostId = View.PostId
            };
            _employeeRepository.Add(_currentEmployee);
        }

        private void EditRecord()
        {
            _currentEmployee.BarCode = View.BarCode;
            _currentEmployee.FirstName = View.FirstName;
            _currentEmployee.LastName = View.LastName;
            _currentEmployee.Patronymic = View.Patronymic;
            _currentEmployee.PostId = View.PostId;
            _employeeRepository.Update(_currentEmployee);
        }
    }
}