using System.Drawing;

namespace Tanks
{
    public class Apple : IPicture
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        AppleImg appleImg = new AppleImg();

            private Image img;

            public Apple(int x, int y)
            {
                img = appleImg.Img;
                X = x;
                Y = y;
            }

            public Image Img
            {
                get { return img; }
            }
    }
}
