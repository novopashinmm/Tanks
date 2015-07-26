using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    class FireTankImage
    {
        private readonly Image _img = Resources.FireTank;

        public Image Img
        {
            get { return _img; }
        }
    }
}
