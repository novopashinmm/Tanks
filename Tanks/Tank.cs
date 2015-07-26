using System;
using System.Drawing;

namespace Tanks
{
    public class Tank : IRun, ITurn, ITurnAround, ITransparent, ICurrentPicture
    {
        private void PutImg()
        {
            if (_directX == 1)
                Img = _tankImg.Right;
            if (_directX == -1)
                Img = _tankImg.Left;
            if (_directY == 1)
                Img = _tankImg.Down;
            if (_directY == -1)
                Img = _tankImg.Up;
        }
        private readonly TankImg _tankImg = new TankImg();
        
        protected Image[] Img;
        private Image _currentImg;
        private int _x;
        private int _y;
        private int _directX;
        private int _directY;
        protected int SizeField { get; set; }
        protected int K { get; set; }

        protected void PutCurrentImage()
        {
            _currentImg = Img[K];
            K++;
            if (K == 4) K = 0;
        }
        protected static Random R;
        
        public Tank(int sizeField, int x, int y)
        {
            R = new Random();
            DirectX = R.Next(-1, 2);
            if (DirectX == 0)
                while (DirectY == 0)
                    DirectY = R.Next(-1, 2);
            else
                DirectY = 0;
            PutImg();
            PutCurrentImage();
            _x = x;
            _y = y;
            SizeField = sizeField;
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
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
        public Image CurrentImg
        {
            get { return _currentImg; }
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
        public void Turn()
        {
            if (R.Next(5000) < 2500) // двигаемся далее по вертикали
            {
                if (DirectY == 0)
                {
                    _directX = 0;
                    while (DirectY == 0)
                        DirectY = R.Next(-1, 2);
                }
            }
            else // двигаемся по горизонтали
            {
                if (DirectX == 0)
                {
                    DirectY = 0;
                    while (DirectX == 0)
                        DirectX = R.Next(-1, 2);
                }
            }
            PutImg();
        }
        public void Transparent()
        {
            if (_x == -1)
                _x = SizeField - 21;
            if (_x == SizeField - 19)
                _x = 1;
            if (_y == -1)
                _y = SizeField - 21;
            if (_y == SizeField - 19)
                _y = 1;
        }
        public void TurnAround()
        {
            DirectX = -1*DirectX;
            DirectY = -1*DirectY;
            PutImg();
        }
    }
}
