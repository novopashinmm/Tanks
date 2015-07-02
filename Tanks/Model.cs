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

        private Random r;

        private List<Tank> tanks;
        internal List<Tank> Tanks
        {
            get { return tanks; }
        }


        public Wall wall;
        public Model(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            r = new Random();

            tanks = new List<Tank>();

            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApple = amountApple;
            this.speedGame = speedGame;

            CreateTanks();
            wall = new Wall();

            gameStatus = GameStatus.Stoping;
        }

        private void CreateTanks()
        {
            int x, y;
            while (tanks.Count < amountTanks)
            {
                x = r.Next(6)*40;
                y = r.Next(6)*40;
                bool flag = tanks.All(tank => tank.X != x || tank.Y != y);

                if (flag)
                    tanks.Add(new Tank(sizeField,x,y));
            }
        }

        public void Play()
        {
            while (gameStatus == GameStatus.Playing)
            {
                Thread.Sleep(speedGame);
                foreach (var tank in tanks)
                    tank.Run();
            }
        }
    }
}
