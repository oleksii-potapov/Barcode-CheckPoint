using System;
using System.Drawing;

namespace CheckPoint.View.Interfaces
{
    public interface IMainForm
    {
        string BarCode { get; set; }
        string FullName { get; set; }
        string Post { get; set; }
        DateTime? DateTimeEntry { get; set; }
        DateTime? DateTimeExit { get; set; }
        bool IsEntry { get; set; }
        Image Camera { get; set; }
        Image CheckPhoto { get; set; }
        Image EmployeePhoto { get; set; }

        void CloseForm();

        event EventHandler EmployeeChecked;
        event EventHandler SettingsClick;
        event EventHandler ReportsClick;
        event EventHandler AboutClick;
        event EventHandler CheckFormClick;
        event EventHandler FormShow;
        event EventHandler FormClose;
    }
}