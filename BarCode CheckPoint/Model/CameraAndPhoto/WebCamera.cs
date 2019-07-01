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
        private Image _snapshot;
        private Image _cameraImage;
        private Timer _cameraTimer;
        public event EventHandler<EventImageArgs> CameraImageChanged;

        public WebCamera(int cameraIndex = 0)
        {
            _capture = new VideoCapture(cameraIndex);
            _mat = new Mat();
        }

        public Image Snapshot => _snapshot;

        public Bitmap GetImage()
        {
            _capture.Retrieve(_mat);
            return _mat.Bitmap;
        }

        public void SaveImageToFile(string imagePath, string textOnImage = default, Color colorOfTextBackground = default)
        {
            _snapshot = _mat.Bitmap;
            if (textOnImage != default)
                PutTextOnSnapshot(textOnImage, colorOfTextBackground);
            _snapshot.Save(imagePath);
        }

        private void PutTextOnSnapshot(string textOnImage, Color colorOfTextBackground)
        {
            using (Graphics g = Graphics.FromImage(_snapshot))
            {
                Rectangle rectangleText = new Rectangle(0, 0, _snapshot.Width, 30);
                using (SolidBrush brush = new SolidBrush(colorOfTextBackground),
                                    textBrush = new SolidBrush(Color.Black))
                {
                    g.FillRectangle(brush, rectangleText);
                    using (Font font = new Font(FontFamily.GenericSerif, 20))
                    {
                        g.DrawString(textOnImage, font, textBrush, rectangleText);
                    }
                }
            }
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