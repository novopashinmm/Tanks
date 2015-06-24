using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall
    {
        WallImg wallImg = new WallImg();

        private Image img;

        public Wall()
        {
            img = wallImg.Img;
        }

        public Image Img
        {
            get { return img; }
        }
    }
}
