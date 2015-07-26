using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    public class ProjectTileImg
    {
        private readonly Image _projectTileImage = Resources.Tile;

        public Image ProjectTileImage
        {
            get { return _projectTileImage; }
        }
    }
}
