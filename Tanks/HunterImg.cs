using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class HunterImg
    {
        private Image[] _up =
        {
            Properties.Resources.Hunter01I, 
            Properties.Resources.Hunter0_1II, 
            Properties.Resources.Hunter0_1III,
            Properties.Resources.Hunter0_1IV
        };

        private Image[] _down =
        {
            Properties.Resources.Hunter01I, 
            Properties.Resources.Hunter01II, 
            Properties.Resources.Hunter01III,
            Properties.Resources.Hunter01IV
        };

        private Image[] _left =
        {
            Properties.Resources.Hunter_10I, 
            Properties.Resources.Hunter_10II, 
            Properties.Resources.Hunter_10III,
            Properties.Resources.Hunter_10IV
        };

        private Image[] _right =
        {
            Properties.Resources.Hunter10I, 
            Properties.Resources.Hunter10II, 
            Properties.Resources.Hunter10III,
            Properties.Resources.Hunter10IV
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
