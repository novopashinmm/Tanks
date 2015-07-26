using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    class HunterImg
    {
        private readonly Image[] _up =
        {
            Resources.Hunter01I, 
            Resources.Hunter0_1II, 
            Resources.Hunter0_1III,
            Resources.Hunter0_1IV
        };

        private readonly Image[] _down =
        {
            Resources.Hunter01I, 
            Resources.Hunter01II, 
            Resources.Hunter01III,
            Resources.Hunter01IV
        };

        private readonly Image[] _left =
        {
            Resources.Hunter_10I, 
            Resources.Hunter_10II, 
            Resources.Hunter_10III,
            Resources.Hunter_10IV
        };

        private readonly Image[] _right =
        {
            Resources.Hunter10I, 
            Resources.Hunter10II, 
            Resources.Hunter10III,
            Resources.Hunter10IV
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
