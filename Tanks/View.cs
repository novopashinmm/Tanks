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
            DrawApple(e);
            DrawTank(e);
            DrawPacman(e);
            DrawProjectTile(e);

            if (model.gameStatus != GameStatus.Playing)
                return;

            Thread.Sleep(model.speedGame);
            Invalidate();
        }

        private void DrawProjectTile(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Tile.Img, new Point(model.Tile.X, model.Tile.Y));
        }

        private void DrawPacman(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Pacman.CurrentImg, new Point(model.Pacman.X, model.Pacman.Y));
        }

        private void DrawTank(PaintEventArgs e)
        {
            foreach (var tank in model.Tanks)
                e.Graphics.DrawImage(tank.CurrentImg, new Point(tank.X, tank.Y));
        }

        private void DrawApple(PaintEventArgs e)
        {
            for (int i = 0; i < model.Apples.Count; i++)
            {
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));
            }
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
