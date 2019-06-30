using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;
using DirectShowLib;

namespace CheckPoint.Presenter
{
    class SettingsFormPresenter
    {
        private readonly IMessageService _messageService;
        private SqlConnectionStringBuilder connectionStringBuilder;

        public ISettingsForm View { get; }

        public SettingsFormPresenter(IMessageService messageService)
        {
            View = new SettingsForm();
            _messageService = messageService;

            View.OnFormShow += ViewOnFormShow;
            View.OnApplySettings += _view_ApplySettings;
        }

        private void _view_ApplySettings(object sender, EventArgs e)
        {
            connectionStringBuilder.DataSource = View.DataBaseServer;
            connectionStringBuilder.InitialCatalog = View.DataBaseName;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["CheckPointDB"].ConnectionString = connectionStringBuilder.ConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Properties.Settings.Default.CameraIndex = View.CameraIndex;
            Properties.Settings.Default.CheckPhotoFolder = View.CheckPhotoFolder;
            Properties.Settings.Default.EmployeePhotoFolder = View.EmployeePhotoFolder;
            Properties.Settings.Default.PlotCode = View.PlotCode;
            Properties.Settings.Default.MaxShiftInHours = View.MaxShiftInHours;
            Properties.Settings.Default.Save();
            _messageService.ShowWarning("Program must be reopen!");
            View.CloseForm();
        }

        private void ViewOnFormShow(object sender, EventArgs e)
        {
            connectionStringBuilder =
                new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["CheckPointDB"].ConnectionString);
            View.DataBaseServer = connectionStringBuilder.DataSource;
            View.DataBaseName = connectionStringBuilder.InitialCatalog;
            View.CameraList = FillCameraList();
            View.CameraIndex = Properties.Settings.Default.CameraIndex;
            View.PlotCode = Properties.Settings.Default.PlotCode;
            View.MaxShiftInHours = Properties.Settings.Default.MaxShiftInHours;

            var folder = Properties.Settings.Default.CheckPhotoFolder;
            if (folder != string.Empty)
                View.CheckPhotoFolder = folder;
            else
            {
                View.CheckPhotoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CheckPhoto");
                if (!Directory.Exists(View.CheckPhotoFolder))
                    Directory.CreateDirectory(View.CheckPhotoFolder);
            }

            folder = Properties.Settings.Default.EmployeePhotoFolder;
            if (folder != string.Empty)
                View.EmployeePhotoFolder = Properties.Settings.Default.EmployeePhotoFolder;
            else
            {
                View.EmployeePhotoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmployeePhoto");
                if (!Directory.Exists(View.EmployeePhotoFolder))
                    Directory.CreateDirectory(View.EmployeePhotoFolder);
            }
        }

        private IList<string> FillCameraList()
        {
            List<string> cameraList = new List<string>();
            DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            foreach (var camera in devices)
            {
                cameraList.Add(camera.Name);
            }

            return cameraList;
        }
    }
}