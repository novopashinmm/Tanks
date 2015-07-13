using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class PacmanImg
    {
        private Image[] _up =
        {
            Properties.Resources.Tank0_1I1, 
            Properties.Resources.Tank0_1II1, 
            Properties.Resources.Tank0_1III1,
            Properties.Resources.Tank0_1IV1
        };

        private Image[] _down =
        {
            Properties.Resources.Tank01I1, 
            Properties.Resources.Tank01II1, 
            Properties.Resources.Tank01III1,
            Properties.Resources.Tank01IV1
        };

        private Image[] _left =
        {
            Properties.Resources.Tank_10I1, 
            Properties.Resources.Tank_10II1, 
            Properties.Resources.Tank_10III1,
            Properties.Resources.Tank_10IV1
        };

        private Image[] _right =
        {
            Properties.Resources.Tank10I1, 
            Properties.Resources.Tank10II1, 
            Properties.Resources.Tank10III1,
            Properties.Resources.Tank10IV1
        };

        public Image[] Up
        {
            get { return _up; }
        }

        public Image[] Down
        {
            get { return _down; }
        }

        public Image[] Left
        {
            get { return _left; }
        }

        public Image[] Right
        {
            get { return _right; }
        }
    }
}
