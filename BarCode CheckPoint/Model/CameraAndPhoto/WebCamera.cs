using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace CheckPoint.Model.CameraAndPhoto
{
    class WebCamera
    {
        private readonly VideoCapture _capture;
        private readonly Mat _mat;
        private Bitmap _snapshot;

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
    }
}
