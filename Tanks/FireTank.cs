using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class FireTank
    {
        FireTankImage ftImg = new FireTankImage();
        public Image CurrenImage { get; private set; }

        private Image img;

        public int X { get; private set; }
        public int Y { get; private set; }

        public FireTank(int x, int y)
        {
            X = x;
            Y = y;
            img = ftImg.Img;
            PutCurrentImage();
        }

        public void Fire()
        {
            PutCurrentImage();
        }

        protected void PutCurrentImage()
        {
            CurrenImage = img;
        }
    }
}
