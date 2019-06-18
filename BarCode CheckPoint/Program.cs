using System;
using System.Windows.Forms;
using CheckPoint.Presenter;
using CheckPoint.View;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;
using CheckPoint.View.Services;

namespace CheckPoint
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationPresenter presenter = ApplicationPresenter.GetInstance();
            Application.Run((Form) presenter.GetMainForm());
        }
    }
}
