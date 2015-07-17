using System.Threading;
using System.Windows.Forms;

namespace Tanks
{
    public partial class ControllerMainForm : Form
    {
        private View view;
        private Model model;

        private Thread modelPlay;

        public ControllerMainForm() : this(260)
        {
        }
        public ControllerMainForm(int sizeField) : this(sizeField, 5)
        {
        }
        public ControllerMainForm(int sizeField, int amountTanks) : this(sizeField, amountTanks, 5)
        {
        }
        public ControllerMainForm(int sizeField, int amountTanks, int amountAplle)
            : this(sizeField, amountTanks, amountAplle, 40)
        {
        }

        public ControllerMainForm(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            InitializeComponent();
            model = new Model(sizeField, amountTanks, amountApple, speedGame);

            view = new View(model);
            this.Controls.Add(view);
        }

        private void btnStartStop_Click(object sender, System.EventArgs e)
        {
            if (model.gameStatus == GameStatus.Playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.Stoping;
            }
            else
            {
                model.gameStatus = GameStatus.Playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();

                view.Invalidate();
            }
        }

        private void ControllerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                model.gameStatus = GameStatus.Stoping;
                modelPlay.Abort();
            }
           DialogResult dr = MessageBox.Show("Вы уверены?", "Tanks", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void ManipulatePacman(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'ф':
                case 'a':
                    model.Pacman.NextDirectX = -1;
                    model.Pacman.NextDirectY = 0;
                    break;
                case 'в':
                case 'd':
                    model.Pacman.NextDirectX = 1;
                    model.Pacman.NextDirectY = 0;
                    break;
                case 'ц':
                case 'w':
                    model.Pacman.NextDirectY = -1;
                    model.Pacman.NextDirectX = 0;
                    break;
                case 'ы':
                case 's':
                    model.Pacman.NextDirectY = 1;
                    model.Pacman.NextDirectX = 0;
                    break;
                default:
                    model.Tile.X = model.Pacman.X;
                    model.Tile.Y = model.Pacman.Y;
                    model.Tile.DirectX = model.Pacman.DirectX;
                    model.Tile.DirectY = model.Pacman.DirectY;
                    break;

            }
        }
    }
}
