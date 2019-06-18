using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class SettingsFormPresenter
    {
        private readonly ISettingsForm _view;
        private readonly IMessageService _messageService;

        public SettingsFormPresenter(ISettingsForm view, IMessageService messageService)
        {
            _view = view;
            _messageService = messageService;

            _view.FormShow += _view_FormShow;
            _view.ApplySettings += _view_ApplySettings;
        }

        private void _view_ApplySettings(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder stringBuilder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CheckPointDB"].ConnectionString)
                {
                    DataSource = _view.DataBaseServer,
                    InitialCatalog = _view.DataBaseName
                };
            ConfigurationManager.ConnectionStrings["CheckPointCB"].ConnectionString = stringBuilder.ConnectionString;
            Properties.Settings.Default.CameraIndex = _view.CameraIndex;
            Properties.Settings.Default.CheckPhotoFolder = _view.CheckPhotoFolder;
            Properties.Settings.Default.EmployeePhotoFolder = _view.EmployeePhotoFolder;
            Properties.Settings.Default.PlotCode = _view.PlotCode;
            Properties.Settings.Default.MaxShiftInHours = _view.MaxShiftInHours;
            _messageService.ShowWarning("Program must be reopen!");
        }

        private void _view_FormShow(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder stringBuilder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CheckPointDB"].ConnectionString);
            _view.DataBaseServer = stringBuilder.DataSource;
            _view.DataBaseName = stringBuilder.InitialCatalog;
            _view.CameraIndex = Properties.Settings.Default.CameraIndex;
            _view.PlotCode = Properties.Settings.Default.PlotCode;
            _view.MaxShiftInHours = Properties.Settings.Default.MaxShiftInHours;

            var folder = Properties.Settings.Default.CheckPhotoFolder;
            if (folder != string.Empty)
                _view.CheckPhotoFolder = folder;
            else
            {
                _view.CheckPhotoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CheckPhoto");
                if (!Directory.Exists(_view.CheckPhotoFolder))
                    Directory.CreateDirectory(_view.CheckPhotoFolder);
            }

            folder = Properties.Settings.Default.EmployeePhotoFolder;
            if (folder != string.Empty)
                _view.EmployeePhotoFolder = Properties.Settings.Default.EmployeePhotoFolder;
            else
            {
                _view.EmployeePhotoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmployeePhoto");
                if (!Directory.Exists(_view.EmployeePhotoFolder))
                    Directory.CreateDirectory(_view.EmployeePhotoFolder);
            }
        }
    }
}