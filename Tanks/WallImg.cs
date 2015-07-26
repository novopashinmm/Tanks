using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    class WallImg
    {
        private readonly Image _img = Resources.Wall;

        public Image Img
        {
            get { return _img; }
        }
    }
}
