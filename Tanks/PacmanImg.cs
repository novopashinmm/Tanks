using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    class PacmanImg
    {
        private readonly Image[] _up =
        {
            Resources.Tank0_1I1, 
            Resources.Tank0_1II1, 
            Resources.Tank0_1III1,
            Resources.Tank0_1IV1
        };

        private readonly Image[] _down =
        {
            Resources.Tank01I1, 
            Resources.Tank01II1, 
            Resources.Tank01III1,
            Resources.Tank01IV1
        };

        private readonly Image[] _left =
        {
            Resources.Tank_10I1, 
            Resources.Tank_10II1, 
            Resources.Tank_10III1,
            Resources.Tank_10IV1
        };

        private readonly Image[] _right =
        {
            Resources.Tank10I1, 
            Resources.Tank10II1, 
            Resources.Tank10III1,
            Resources.Tank10IV1
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
