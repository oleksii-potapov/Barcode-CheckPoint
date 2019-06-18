using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPoint.View.Interfaces;

namespace CheckPoint.Presenter
{
    class SettingsPresenter
    {
        private readonly ISettingsForm _view;
        private readonly IMessageService _messageService;

        public SettingsPresenter(ISettingsForm view, IMessageService messageService)
        {
            _view = view;
            _messageService = messageService;
        }


    }
}
