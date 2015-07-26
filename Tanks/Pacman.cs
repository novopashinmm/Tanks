using System;
using System.Drawing;

namespace Tanks
{
    public class Pacman : IRun, ITurn, ITransparent, ICurrentPicture
    {
        readonly PacmanImg _pacmanImg = new PacmanImg();
        private Image[] _img;
        private Image _currentImage;
        private readonly int _sizeField;
        private int _directX;
        private int _directY;
        public int NextDirectX { get; set; }
        public int NextDirectY { get; set; }
        private int _x, _y;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public Image CurrentImg
        {
            get { return _currentImage; }
        }

        public int DirectX
        {
            get { return _directX; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    _directX = value;
                else
                    _directX = 0;
            }
        }

        public int DirectY
        {
            get { return _directY; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    _directY = value;
                else
                    _directY = 0;
            }
        }

        public Pacman(int sizeField)
        {
            _sizeField = sizeField;
            _x = 120;
            _y = 240;
            NextDirectX = 0;
            NextDirectY = -1;
            DirectX = 0;
            DirectY = -1;
            PutImg();
            PutCurrentImage();
            
            _sizeField = sizeField;
        }

        public void Run()
        {
            _x += _directX;
            _y += _directY;
            if (Math.IEEERemainder(_x, 40) == 0 && Math.IEEERemainder(_y, 40) == 0)
                Turn();

            PutCurrentImage();

            Transparent();
        }


        private int _k;
        private void PutCurrentImage()
        {
            _currentImage = _img[_k];
            _k++;
            if (_k == 4) _k = 0;
        }


        public void Turn()
        {
            DirectX = NextDirectX;
            DirectY = NextDirectY;
            PutImg();
        }


        public void Transparent()
        {
            if (_x == -1)
                _x = _sizeField - 21;
            if (_x == _sizeField - 19)
                _x = 1;

            if (_y == -1)
                _y = _sizeField - 21;
            if (_y == _sizeField - 19)
                _y = 1;
        }


        public void PutImg()
        {
            if (_directX == 1)
                _img = _pacmanImg.Right;
            if (_directX == -1)
                _img = _pacmanImg.Left;
            if (_directY == 1)
                _img = _pacmanImg.Down;
            if (_directY == -1)
                _img = _pacmanImg.Up;
        }
    }
}
