using System;
using System.Collections.Generic;
using System.Linq;
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