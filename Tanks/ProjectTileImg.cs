using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class ProjectTileImg
    {
        private Image _projectTileImage = Properties.Resources.Tile;

        public Image ProjectTileImage
        {
            get { return _projectTileImage; }
        }
    }
}
