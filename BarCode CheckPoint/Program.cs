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

            IMainForm mainForm = new MainForm();
            IMessageService messageService = new MessageService();
            CheckPoint.Model.ApplicationContext context = new CheckPoint.Model.ApplicationContext();
            MainPresenter presenter = new MainPresenter(mainForm, messageService, context);
            Application.Run((Form) mainForm);
        }
    }
}
