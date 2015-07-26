using System.Drawing;

namespace Tanks
{
    public class Wall : IPicture
    {
        readonly WallImg _wallImg = new WallImg();

        private readonly Image _img;

        public Wall()
        {
            _img = _wallImg.Img;
        }

        public Image Img
        {
            get { return _img; }
        }
    }
}
