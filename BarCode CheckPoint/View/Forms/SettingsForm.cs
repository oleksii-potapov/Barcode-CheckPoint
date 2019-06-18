using System;
using System.Collections.Generic;
using System.Linq;
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FormShow?.Invoke(sender, EventArgs.Empty);
        }

        private void ButtonApplySettings_Click(object sender, EventArgs e)
        {
            ApplySettings?.Invoke(sender, EventArgs.Empty);
        }

        #endregion

        private void ButtonBrowseCheckPhotoFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textCheckPhotoFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void ButtonBrowseEmployeePhotoFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textEmployeePhotoFolder.Text = folderBrowserDialog.SelectedPath;
        }
    }
}