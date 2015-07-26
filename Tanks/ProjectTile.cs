using System.Drawing;

namespace Tanks
{
    public class ProjectTile
    {
        private int _km;
        private readonly ProjectTileImg _projectTileImg = new ProjectTileImg();
        public Image Img { get; private set; }

        private int _directX, _directY;
        public int X { get; set; }
        public int Y { get; set; }

        public ProjectTile()
        {
            Img = _projectTileImg.ProjectTileImage;
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            X = Y = -10;
            DirectX = DirectY = 0;
            _km = 0;
        }
        public int DirectX
        {
            get { return _directX; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    _directX = value;
                else
                    _directX = 0;
            }
        }
        public int DirectY
        {
            get { return _directY; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    _directY = value;
                else
                    _directY = 0;
            }
        }

        public void Run()
        {
            if (DirectX == 0 && DirectY == 0)
                return;
            _km += 4;
            PutImg();
            X += DirectX * 4;
            Y += DirectY * 4;
            if (_km > 140)
                DefaultSettings();
        }

        private void PutImg()
        {
            Img = _projectTileImg.ProjectTileImage;
        }
    }
}
