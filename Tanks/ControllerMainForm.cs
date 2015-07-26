using System;
using System.Threading;
using System.Windows.Forms;
using Tanks.Properties;
using System.Media;

namespace Tanks
{
    internal delegate void Invoker();
    public partial class ControllerMainForm : Form
    {
        private readonly View _view;
        private readonly Model _model;
        private bool _isSound;
        private Thread _modelPlay;
        private readonly SoundPlayer _sp;
        private readonly string infoAboutMe = "Игра \"Пакмен\" версии 1.0\n" +
                            "Разработчик Новопашин Михаил\n" +
                            "Для управления используйте w,s,a,d и выстрел f";

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
            _model = new Model(sizeField, amountTanks, amountApple, speedGame);
            _model.ChangeStreep += ChangerStatusStripLbl;
            _view = new View(_model);
            Controls.Add(_view);

            _sp = new SoundPlayer(Resources.AudioTanks);

            _isSound = true;
        }

        void ChangerStatusStripLbl(object sender, EventArgs e)
        {
            Invoke(new Invoker(SetValueToStrLbl));
        }

        private void SetValueToStrLbl()
        {
            GameStatus_lbl_ststrp.Text = _model.Status.ToString();
            if (_isSound)
            {
                if (_model.Status == GameStatus.Playing)
                    _sp.PlayLooping();
                else
                    _sp.Stop();
            }
            else
            {
                _sp.Stop();
            }
        }

        private void StartPause_btn_Click(object sender, EventArgs e)
        {
            if (_model.Status == GameStatus.Playing)
            {
                StartStop_pcbx.Focus();
                _modelPlay.Abort();
                _model.Status = GameStatus.Stoping;
                ChangerStatusStripLbl(this, null);
            }
            else
            {
                StartStop_pcbx.Focus();
                _model.Status = GameStatus.Playing;
                _modelPlay = new Thread(_model.Play);
                _modelPlay.Start();
                ChangerStatusStripLbl(this, null);
                _view.Invalidate();
            }
        }

        private void ControllerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modelPlay != null)
            {
                _model.Status = GameStatus.Stoping;
                _modelPlay.Abort();
            }
            if (Resources.ControllerMainForm_ControllerMainForm_FormClosing_Вы_уверены_ != null)
            {
                DialogResult dr = MessageBox.Show(Resources.ControllerMainForm_ControllerMainForm_FormClosing_Вы_уверены_, Resources.ControllerMainForm_ControllerMainForm_FormClosing_Tanks, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                e.Cancel = dr != DialogResult.Yes;
            }
        }

        private void StartStop_pcbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    _model.Pacman.NextDirectX = -1;
                    _model.Pacman.NextDirectY = 0;
                    break;
                case "D":
                    _model.Pacman.NextDirectX = 1;
                    _model.Pacman.NextDirectY = 0;
                    break;
                case "W":
                    _model.Pacman.NextDirectY = -1;
                    _model.Pacman.NextDirectX = 0;
                    break;
                case "S":
                    _model.Pacman.NextDirectY = 1;
                    _model.Pacman.NextDirectX = 0;
                    break;
                case "F":
                    SetProjectTileFromStart();
                    break;
            }
        }

        private void SetProjectTileFromStart()
        {
            _model.Tile.DirectX = _model.Pacman.DirectX;
            _model.Tile.DirectY = _model.Pacman.DirectY;

            if (_model.Pacman.DirectY == -1)
            {
                _model.Tile.X = _model.Pacman.X + 5;
                _model.Tile.Y = _model.Pacman.Y;
            }
            if (_model.Pacman.DirectY == 1)
            {
                _model.Tile.X = _model.Pacman.X + 5;
                _model.Tile.Y = _model.Pacman.Y + 20;
            }
            if (_model.Pacman.DirectX == -1)
            {
                _model.Tile.X = _model.Pacman.X;
                _model.Tile.Y = _model.Pacman.Y + 5;
            }
            if (_model.Pacman.DirectX == 1)
            {
                _model.Tile.X = _model.Pacman.X + 20;
                _model.Tile.Y = _model.Pacman.Y + 5;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _model.NewGame();
            _view.Refresh();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(infoAboutMe, Resources.ControllerMainForm_ControllerMainForm_FormClosing_Tanks, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void SoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSound = !_isSound;
            soundToolStripMenuItem.Image = _isSound ? Resources.Ok : Resources.NotOk;
        }
    }
}
