using System;
using System.Drawing;

namespace Tanks
{
    public class Tank : IRun, ITurn, ITransparent
    {
        TankImg tankImg = new TankImg();
        private Image[] img;
        private Image currentImg;

        private int x, y;
        private int direct_x;
        private int direct_y;
        private int sizeField;

        private static Random r;

        public Tank(int sizeField)
        {
            r = new Random();
            DirectX = 0;
            DirectY = 1;
            PutImg();
            PutCurrentImage();
            x = 80;
            y = 80;
            this.sizeField = sizeField;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int DirectX
        {
            get { return direct_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else
                    direct_x = 0;
            }
        }

        public int DirectY
        {
            get { return direct_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else
                    direct_y = 0;
            }
        }

        public Image CurrentImg
        {
            get { return currentImg; }
        }

        
        public void Run()
        {
            x += direct_x;
            y += direct_y;
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn();

            PutCurrentImage();

            Transparent();
        }

        private int k;
        private void PutCurrentImage()
        {
            currentImg = img[k];
            k++;
            if (k == 4) k = 0;
        }

        public void Turn()
        {
            if (r.Next(5000) < 2500) // двигаемся далее по вертикали
            {
                if (DirectY == 0)
                {
                    direct_x = 0;
                    while (DirectY == 0)
                        DirectY = r.Next(-1, 2);
                }
            }
            else // двигаемся по горизонтали
            {
                if (DirectX == 0)
                {
                    DirectY = 0;
                    while (DirectX == 0)
                        DirectX = r.Next(-1, 2);
                }
            }
            PutImg();
        }

        public void Transparent()
        {
            if (x == -1)
                x = sizeField - 21;
            if (x == sizeField - 19)
                x = 1;
            if (y == -1)
                y = sizeField - 21;
            if (y == sizeField - 19)
                y = 1;
        }

        public void PutImg()
        {
            if (direct_x == 1)
                img = tankImg.Right;
            if (direct_x == -1)
                img = tankImg.Left;
            if (direct_y == 1)
                img = tankImg.Down;
            if (direct_y == -1)
                img = tankImg.Up;
        }
    }
}
