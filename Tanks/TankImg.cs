using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    public class TankImg
    {
        private readonly Image[] _up =
        {
            Resources.Tank0_1I, 
            Resources.Tank0_1II, 
            Resources.Tank0_1III,
            Resources.Tank0_1IV
        };

        private readonly Image[] _down =
        {
            Resources.Tank01I, 
            Resources.Tank01II, 
            Resources.Tank01III,
            Resources.Tank01IV
        };

        private readonly Image[] _left =
        {
            Resources.Tank_10I, 
            Resources.Tank_10II, 
            Resources.Tank_10III,
            Resources.Tank_10IV
        };

        private readonly Image[] _right =
        {
            Resources.Tank10I, 
            Resources.Tank10II, 
            Resources.Tank10III,
            Resources.Tank10IV
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
