using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class ProjectTile
    {
        private int km;
        private ProjectTileImg projectTileImg = new ProjectTileImg();
        public Image Img { get; private set; }

        private int direct_x, direct_y;
        public int X { get; set; }
        public int Y { get; set; }

        public ProjectTile()
        {
            Img = projectTileImg.ProjectTileImage;
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            X = Y = -10;
            DirectX = DirectY = 0;
            km = 0;
        }
        public int DirectX
        {
            get { return direct_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else
                    direct_x = 0;
            }
        }
        public int DirectY
        {
            get { return direct_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else
                    direct_y = 0;
            }
        }

        public void Run()
        {
            if (DirectX == 0 && DirectY == 0)
                return;
            km += 4;
            PutImg();
            X += DirectX * 4;
            Y += DirectY * 4;
            if (km > 140)
                DefaultSettings();
        }

        private void PutImg()
        {
            Img = projectTileImg.ProjectTileImage;
        }
    }
}
