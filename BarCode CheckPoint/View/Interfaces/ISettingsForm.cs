using System;
using System.Collections.Generic;

namespace CheckPoint.View.Interfaces
{
    public interface ISettingsForm : IForm
    {
        string DataBaseServer { get; set; }
        string DataBaseName { get; set; }
        string CheckPhotoFolder { get; set; }
        string EmployeePhotoFolder { get; set; }
        int MaxShiftInHours { get; set; }
        int CameraIndex { get; set; }
        string PlotCode { get; set; }
        int InterfaceLanguage { get; set; }
        IList<string> CameraList { get; set; }

        event EventHandler OnFormShow;
        event EventHandler ApplySettings;
    }
}
