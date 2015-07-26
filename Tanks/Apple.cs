using System.Drawing;

namespace Tanks
{
    public class Apple : IPicture
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        readonly AppleImg _appleImg = new AppleImg();

            private readonly Image _img;

            public Apple(int x, int y)
            {
                _img = _appleImg.Img;
                X = x;
                Y = y;
            }

            public Image Img
            {
                get { return _img; }
            }
    }
}
