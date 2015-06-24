using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class View : UserControl
    {
        private Model model;
        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
        }

        void Draw(PaintEventArgs e)
        {
            DrawWall(e);
            DrawTank(e);

            if (model.gameStatus != GameStatus.Playing)
                return;

            Thread.Sleep(model.speedGame);
            Invalidate();
        }

        private void DrawTank(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.tank.Img, new Point(model.tank.X, model.tank.Y));
        }

        private void DrawWall(PaintEventArgs e)
        {
            for (int y = 20; y < 260; y += 40)
                for (int x = 20; x < 260; x += 40)
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
