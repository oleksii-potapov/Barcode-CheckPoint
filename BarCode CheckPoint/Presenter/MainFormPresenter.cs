using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.Model.CameraAndPhoto;
using CheckPoint.Model.Entities;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class MainFormPresenter
    {
        private readonly IMessageService _messageService;
        private readonly ApplicationContext _context;
        private readonly WebCamera _webCamera;
        public IMainForm View { get; }

        public event EventHandler SettingsFormShow;
        public event EventHandler EmployeeListFormShow;
        public event EventHandler PostListFormShow;

        public MainFormPresenter(IMainForm mainForm, IMessageService messageService, ApplicationContext context)
        {
            View = mainForm;
            _messageService = messageService;
            _context = context;
            _webCamera = new WebCamera();
            _webCamera.StartShowCameraImage();
            // show web-camera image

            View.OnEmployeeChecked += ViewOnEmployeeChecked;
            View.OnCheckFormClick += View_CheckFormClick;
            View.OnReportsClick += ViewOnReportsClick;
            View.OnSettingsClick += ViewOnSettingsClick;
            View.OnFormShow += ViewOnFormShow;
            View.OnFormClose += ViewOnFormClose;
            View.OnEmployeesClick += View_EmployeesClick;
            View.OnPostsClick += View_PostsClick;
            _webCamera.CameraImageChanged += _webCamera_CameraImageChanged;
        }

        #region Events of form showing forwarding

        private void View_PostsClick(object sender, EventArgs e)
        {
            PostListFormShow?.Invoke(this, EventArgs.Empty);
        }
        private void View_EmployeesClick(object sender, EventArgs e)
        {
            EmployeeListFormShow?.Invoke(this, EventArgs.Empty);
        }
        private void ViewOnSettingsClick(object sender, EventArgs e)
        {
            SettingsFormShow?.Invoke(sender, EventArgs.Empty);
        }
        private void ViewOnReportsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void View_CheckFormClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void _webCamera_CameraImageChanged(object sender, EventImageArgs e)
        {
            View.Camera = e?.Image;
        }

        private void ViewOnFormClose(object sender, EventArgs e)
        {
            if (_messageService.ShowQuestion("Close program?"))
            {
                _context.Dispose();
                View.CloseForm();
            }
        }

        private void ViewOnFormShow(object sender, EventArgs e)
        {

        }



        private void ViewOnEmployeeChecked(object sender, EventArgs e)
        {
            if (View.BarCode == string.Empty)
                return;

            var employeeCheck = new EmployeeCheck(View.IsEntry, View.BarCode, _context);
            
            var shiftCheck = employeeCheck.Check();
            if (shiftCheck != null)
            {
                SaveCheckPhoto(shiftCheck);
                ShowLastCheck(shiftCheck);
            }
            else
                View.ProcessStatus = "Employee check faulted.";

            View.BarCode = string.Empty;
        }

        private void ShowLastCheck(ShiftCheck shiftCheck)
        {
            View.FullName = shiftCheck.Employee.FullName;
            View.Post = shiftCheck.Employee.Post.Name;
            View.DateTimeEntry = shiftCheck.DateTimeEntry;
            View.DateTimeExit = shiftCheck.DateTimeExit;
            View.CheckPhoto = _webCamera.Snapshot;
            View.EmployeePhoto = Image.FromFile(Path.Combine(Properties.Settings.Default.EmployeePhotoFolder,
                string.Format($"{shiftCheck.Employee.FullName}-{shiftCheck.Employee.BarCode}.jpg")));
        }

        private void SaveCheckPhoto(ShiftCheck shiftCheck)
        {
            var way = View.IsEntry ? 1 : 2;
            var path = Path.Combine(Properties.Settings.Default.CheckPhotoFolder,
                $"{DateTime.Now:dd.MM.yyyy}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, string.Format($"{shiftCheck.Employee.FullName}_{shiftCheck.ShiftCheckId}_{way}.jpg"));
            if (View.IsEntry)
                _webCamera.SaveImageToFile(path, $"Entry - {DateTime.Now:dd.MM.yyyy HH:mm:ss}", Color.LimeGreen);
            else
                _webCamera.SaveImageToFile(path, $"Exit - {DateTime.Now:dd.MM.yyyy HH:mm:ss}", Color.Blue);
        }
    }
}