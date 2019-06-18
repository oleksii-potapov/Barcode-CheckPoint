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

        public string DataBaseServer { get; set; }
        public string DataBaseName { get; set; }
        public string CheckPhotoFolder { get; set; }
        public string EmployeePhotoFolder { get; set; }
        public int MaxShiftInHours { get; set; }
        public int CameraIndex { get; set; }
        public string PlotCode { get; set; }
        public int InterfaceLanguage { get; set; }
        public IList<string> CameraList { get; set; }

        #endregion

        #region Events

        public event EventHandler FormShow;
        public event EventHandler ApplySettings;
        public event EventHandler ShowOpenDialog;
        public event EventHandler ShowFolderDialog;

        #endregion
    }
}
