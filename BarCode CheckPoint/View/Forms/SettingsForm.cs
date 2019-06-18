using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckPoint.View.Interfaces;

namespace CheckPoint.View.Forms
{
    public partial class SettingsForm : Form, ISettingsForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        #region Properties

        public string DataBaseServer
        {
            get => textDataBaseServer.Text;
            set => textDataBaseServer.Text = value;
        }

        public string DataBaseName
        {
            get => textDataBaseName.Text;
            set => textDataBaseName.Text = value;
        }

        public string CheckPhotoFolder
        {
            get => textCheckPhotoFolder.Text;
            set => textCheckPhotoFolder.Text = value;
        }

        public string EmployeePhotoFolder
        {
            get => textEmployeePhotoFolder.Text;
            set => textEmployeePhotoFolder.Text = value;
        }

        public int MaxShiftInHours
        {
            get => (int) numericMaxShiftLength.Value;
            set => numericMaxShiftLength.Value = value;
        }

        public int CameraIndex
        {
            get => comboCameraList.SelectedIndex;
            set => comboCameraList.SelectedIndex = value;
        }

        public string PlotCode
        {
            get => textPlotCode.Text;
            set => textPlotCode.Text = value;
        }

        public int InterfaceLanguage { get; set; }
        public IList<string> CameraList
        {
            get => comboCameraList.Items.Cast<string>().ToList();
            set => comboCameraList.DataSource = value;
        }

        #endregion

        #region Events

        public event EventHandler FormShow;
        public event EventHandler ApplySettings;
        public event EventHandler ShowOpenDialog;
        public event EventHandler ShowFolderDialog;

        #endregion

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FormShow?.Invoke(sender, EventArgs.Empty);
        }
    }
}