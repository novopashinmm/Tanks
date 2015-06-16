using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class Model
    {
        private int sizeField;
        private int amountTanks;
        private int amountApple;
        private int speedGame;

        private Tank tank;
        public Model(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApple = amountApple;
            this.speedGame = speedGame;

            tank = new Tank();
        }

        public void Play()
        {
            while (true)
            {
                tank.Run();
            }
        }
    }
}
