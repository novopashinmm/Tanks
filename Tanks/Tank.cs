using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Tank
    {
        public Image img = Properties.Resources.Tank;

        public int x, y;

        public void Run()
        {
            x = ++y;
        }
    }
}
