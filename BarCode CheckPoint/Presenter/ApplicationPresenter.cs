﻿using System;
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
            _mainFormPresenter = new MainFormPresenter(new MainForm(), _messageService);
            _mainFormPresenter.SettingsFormShow += _mainFormPresenter_SettingsFormShow;
            _mainFormPresenter.PostListFormShow += _mainFormPresenter_PostListFormShow;
            _mainFormPresenter.EmployeeListFormShow += _mainFormPresenter_EmployeeListFormShow;
            _mainFormPresenter.ReportsFormShow += _mainFormPresenter_ReportsFormShow;
        }

        private void _mainFormPresenter_ReportsFormShow(object sender, EventArgs e)
        {
            ReportsFormPresenter reportsFormPresenter = new ReportsFormPresenter(_messageService);
            reportsFormPresenter.View.ShowForm();
        }

        private void _mainFormPresenter_EmployeeListFormShow(object sender, EventArgs e)
        {
            EmployeeListFormPresenter employeeListFormPresenter = new EmployeeListFormPresenter(_messageService);
            employeeListFormPresenter.View.ShowForm();
        }

        private void _mainFormPresenter_PostListFormShow(object sender, EventArgs e)
        {
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
            return _mainFormPresenter.View;
        }

    }
}