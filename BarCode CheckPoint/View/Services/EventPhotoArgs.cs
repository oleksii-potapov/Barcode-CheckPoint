using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.View.Services
{
    public class EventPhotoArgs : EventArgs
    {
        public string PhotoPath { get; }

        public EventPhotoArgs(string photoPath)
        {
            PhotoPath = photoPath;
        }
    }
}
