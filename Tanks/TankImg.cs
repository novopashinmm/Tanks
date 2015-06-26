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
        private Image[] _up =
        {
            Properties.Resources.Tank0_1I, 
            Properties.Resources.Tank0_1II, 
            Properties.Resources.Tank0_1III,
            Properties.Resources.Tank0_1IV
        };

        private Image[] _down =
        {
            Properties.Resources.Tank01I, 
            Properties.Resources.Tank01II, 
            Properties.Resources.Tank01III,
            Properties.Resources.Tank01IV
        };

        private Image[] _left =
        {
            Properties.Resources.Tank_10I, 
            Properties.Resources.Tank_10II, 
            Properties.Resources.Tank_10III,
            Properties.Resources.Tank_10IV
        };

        private Image[] _right =
        {
            Properties.Resources.Tank10I, 
            Properties.Resources.Tank10II, 
            Properties.Resources.Tank10III,
            Properties.Resources.Tank10IV
        };

        public Image[] Up
        {
            get { return _up; }
            set { _up = value; }
        }

        public Image[] Down
        {
            get { return _down; }
            set { _down = value; }
        }

        public Image[] Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Image[] Right
        {
            get { return _right; }
            set { _right = value; }
        }
    }
}
