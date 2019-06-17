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

        public WebCamera(int cameraIndex = 0)
        {
            _capture = new VideoCapture(cameraIndex);
            _mat = new Mat();
        }

        public Bitmap GetImage()
        {
            _capture.Retrieve(_mat);
            return _mat.Bitmap;
        }

        public void SaveImageToFile(string imagePath)
        {
            _mat?.Bitmap.Save(imagePath);
        }
    }
}
