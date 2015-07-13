using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Hunter : Tank
    {
        private int target_x, target_y;

        HunterImg hunterImg = new HunterImg();
        private void PutImg()
        {
            if (direct_x == 1)
                img = hunterImg.Right;
            if (direct_x == -1)
                img = hunterImg.Left;
            if (direct_y == 1)
                img = hunterImg.Down;
            if (direct_y == -1)
                img = hunterImg.Up;
        }

        public void Run(int target_x, int target_y)
        {
            this.target_x = target_x;
            this.target_y = target_y;

            x += direct_x;
            y += direct_y;
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn(target_x, target_y);

            PutCurrentImage();

            Transparent();
        }

        new public void Turn(int target_x, int target_y)
        {
            if (X > target_x)
                DirectX = -1;
            if (X < target_x)
                DirectX = 1;
            if (Y > target_y)
                DirectY = -1;
            if (Y < target_y)
                DirectY = 1;

            if (DirectX != 0 && DirectY != 0)
                if (r.Next(5000) < 2500)
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
