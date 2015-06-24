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
    }
}
