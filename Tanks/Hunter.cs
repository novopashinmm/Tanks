using System;

namespace Tanks
{
    class Hunter : Tank
    {
        readonly HunterImg _hunterImg = new HunterImg();
        private void PutImg()
        {
            if (DirectX == 1)
                Img = _hunterImg.Right;
            if (DirectX == -1)
                Img = _hunterImg.Left;
            if (DirectY == 1)
                Img = _hunterImg.Down;
            if (DirectY == -1)
                Img = _hunterImg.Up;
        }

        public void Run(int targetX, int targetY)
        {
            X = X + DirectX;
            Y = Y + DirectY;
            if (System.Math.IEEERemainder(X, 40) == 0 && Math.IEEERemainder(Y, 40) == 0)
                Turn(targetX, targetY);

            PutCurrentImage();

            Transparent();
        }

        public void Turn(int targetX, int targetY)
        {
            DirectX = DirectY = 0;
            if (X > targetX)
                DirectX = -1;
            if (X < targetX)
                DirectX = 1;
            if (Y > targetY)
                DirectY = -1;
            if (Y < targetY)
                DirectY = 1;

            if (DirectX != 0 && DirectY != 0)
                if (R.Next(5000) < 2500)
                    DirectX = 0;
                else 
                    DirectY = 0;
            PutImg();
        }

        new public void TurnAround()
        {
            DirectX = -1*DirectX;
            DirectY = -1*DirectY;
            PutImg();
        }

        public Hunter(int sizeField, int x, int y)
            : base(sizeField, x, y)
        {
            PutImg();
            PutCurrentImage();
        }
    }
}
