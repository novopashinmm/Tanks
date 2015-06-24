using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tanks
{
    public class Model
    {
        private int sizeField;
        private int amountTanks;
        private int amountApple;
        public int speedGame;

        public GameStatus gameStatus;

        public Tank tank;
        public Wall wall;
        public Model(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApple = amountApple;
            this.speedGame = speedGame;

            tank = new Tank(sizeField);
            wall = new Wall();

            gameStatus = GameStatus.Stoping;
        }

        public void Play()
        {
            while (gameStatus == GameStatus.Playing)
            {
                Thread.Sleep(speedGame);
                tank.Run();
            }
        }
    }
}
