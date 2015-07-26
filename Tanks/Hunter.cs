using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Hunter : Tank
    {
        HunterImg hunterImg = new HunterImg();
        private void PutImg()
        {
            if (DirectX == 1)
                Img = hunterImg.Right;
            if (DirectX == -1)
                Img = hunterImg.Left;
            if (DirectY == 1)
                Img = hunterImg.Down;
            if (DirectY == -1)
                Img = hunterImg.Up;
        }

        public void Run(int target_x, int target_y)
        {
            X = X + DirectX;
            Y = Y + DirectY;
            if (Math.IEEERemainder(X, 40) == 0 && Math.IEEERemainder(Y, 40) == 0)
                Turn(target_x, target_y);

            PutCurrentImage();

            Transparent();
        }

        public void Turn(int target_x, int target_y)
        {
            DirectX = DirectY = 0;
            if (X > target_x)
                DirectX = -1;
            if (X < target_x)
                DirectX = 1;
            if (Y > target_y)
                DirectY = -1;
            if (Y < target_y)
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
