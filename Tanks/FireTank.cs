using System.Drawing;

namespace Tanks
{
    public class FireTank
    {
        readonly FireTankImage _ftImg = new FireTankImage();
        public Image CurrenImage { get; private set; }

        private readonly Image _img;

        public int X { get; private set; }
        public int Y { get; private set; }

        public FireTank(int x, int y)
        {
            X = x;
            Y = y;
            _img = _ftImg.Img;
            PutCurrentImage();
        }

        public void Fire()
        {
            PutCurrentImage();
        }

        protected void PutCurrentImage()
        {
            CurrenImage = _img;
        }
    }
}
