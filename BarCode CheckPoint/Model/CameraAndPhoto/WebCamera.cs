using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Emgu.CV;

namespace CheckPoint.Model.CameraAndPhoto
{
    class WebCamera
    {
        private readonly VideoCapture _capture;
        private readonly Mat _mat;
        private Bitmap _snapshot;
        private Image _cameraImage;
        private Timer _cameraTimer;
        public event EventHandler<EventImageArgs> CameraImageChanged;

        public WebCamera(int cameraIndex = 0)
        {
            _capture = new VideoCapture(cameraIndex);
            _mat = new Mat();
        }

        public Bitmap Snapshot => _snapshot;

        public Bitmap GetImage()
        {
            _capture.Retrieve(_mat);
            return _mat.Bitmap;
        }

        public void SaveImageToFile(string imagePath)
        {
            _snapshot = _mat.Bitmap;
            _mat?.Bitmap.Save(imagePath);
        }

        public async void SaveImageToFileAsync(string imagePath)
        {
            _snapshot = _mat.Bitmap;
            await Task.Run(() => _mat?.Bitmap.Save(imagePath));
        }

        public void StartShowCameraImage()
        {
            _cameraTimer = new Timer((obj) =>
                {
                    _cameraImage = GetImage();
                    CameraImageChanged?.Invoke(this, new EventImageArgs(_cameraImage));
                },
                null, 500, 50);
        }
    }

    class EventImageArgs : EventArgs
    {
        public Image Image { get; }

        public EventImageArgs(Image image)
        {
            Image = image;
        }
    }
}