using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.Model;
using CheckPoint.View.Forms;
using CheckPoint.View.Interfaces;
using CheckPoint.View.Services;

namespace CheckPoint.Presenter
{
    class ApplicationPresenter
    {
        private readonly MainFormPresenter _mainFormPresenter;
        private readonly IMessageService _messageService;
        private readonly ApplicationContext _context;

        private static ApplicationPresenter _applicationPresenter;

        private ApplicationPresenter()
        {
            _messageService = new MessageService();
            _context = new ApplicationContext();
            _mainFormPresenter = new MainFormPresenter(new MainForm(), _messageService, _context);
            _mainFormPresenter.SettingsFormShow += _mainFormPresenter_SettingsFormShow;
            _mainFormPresenter.PostListFormShow += _mainFormPresenter_PostListFormShow;
            _mainFormPresenter.EmployeeListFormShow += _mainFormPresenter_EmployeeListFormShow;
            _mainFormPresenter.ReportsFormShow += _mainFormPresenter_ReportsFormShow;
        }

        private void _mainFormPresenter_ReportsFormShow(object sender, EventArgs e)
        {
            if (!IsDataBaseConnected())
                return;
            ReportsFormPresenter reportsFormPresenter = new ReportsFormPresenter(_messageService, _context);
            reportsFormPresenter.View.ShowForm();
        }

        private void _mainFormPresenter_EmployeeListFormShow(object sender, EventArgs e)
        {
            if (!IsDataBaseConnected())
                return;
            EmployeeListFormPresenter employeeListFormPresenter = new EmployeeListFormPresenter(_messageService, _context);
            employeeListFormPresenter.View.ShowForm();
        }

        private void _mainFormPresenter_PostListFormShow(object sender, EventArgs e)
        {
            if (!IsDataBaseConnected())
                return;
            PostListFormPresenter postListFormPresenter = new PostListFormPresenter(_messageService, _context);
            postListFormPresenter.View.ShowForm();
        }

        private void _mainFormPresenter_SettingsFormShow(object sender, EventArgs e)
        {
            SettingsFormPresenter settingsFormPresenter = new SettingsFormPresenter(_messageService);
            settingsFormPresenter.View.ShowForm();
        }

        public static ApplicationPresenter GetInstance()
        {
            if (_applicationPresenter == null)
                _applicationPresenter = new ApplicationPresenter();
            return _applicationPresenter;
        }

        public IMainForm GetMainForm()
        {
            _mainFormPresenter.View.ProcessStatus = "DataBase connecting...";
            Task checkDataBase = new Task(() =>
            {
                if (_context.Database.Exists())
                {
                    _context.IsConnected = true;
                    _mainFormPresenter.View.ProcessStatus = "DataBase connected.";
                }
            });
            checkDataBase.Start();
            return _mainFormPresenter.View;
        }

        private bool IsDataBaseConnected()
        {
            if (!_context.IsConnected)
            {
                _messageService.ShowError("Database not connected");
                return false;
            }

            return true;
        }
    }
}