using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class TankImg
    {
        private Image img = Properties.Resources.Tank;


        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
    }
}
