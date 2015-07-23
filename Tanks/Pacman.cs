using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Pacman : IRun, ITurn, ITransparent, ICurrentPicture
    {
        PacmanImg pacmanImg = new PacmanImg();
        private Image[] img;
        private Image currentImage;
        private int sizeField;
        private int direct_x;
        private int direct_y;
        public int NextDirectX { get; set; }
        public int NextDirectY { get; set; }
        private int x, y;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Image CurrentImg
        {
            get { return currentImage; }
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

        public Pacman(int sizeField)
        {
            this.sizeField = sizeField;
            this.x = 120;
            this.y = 240;
            this.NextDirectX = 0;
            this.NextDirectY = -1;
            this.DirectX = 0;
            this.DirectY = -1;
            PutImg();
            PutCurrentImage();
            
            this.sizeField = sizeField;
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
            currentImage = img[k];
            k++;
            if (k == 4) k = 0;
        }


        public void Turn()
        {
            DirectX = NextDirectX;
            DirectY = NextDirectY;
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
                img = pacmanImg.Right;
            if (direct_x == -1)
                img = pacmanImg.Left;
            if (direct_y == 1)
                img = pacmanImg.Down;
            if (direct_y == -1)
                img = pacmanImg.Up;
        }
    }
}
