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
        private int collectedApples;

        public GameStatus gameStatus;

        private Random r;

        public ProjectTile Tile { get; private set; }

        public Pacman Pacman { get; private set; }

        private List<Tank> tanks;
        internal List<Tank> Tanks
        {
            get { return tanks; }
        }

        public List<FireTank> FireTanks { get; private set; }

        public List<Apple> Apples { get; private set; }

        public Wall wall;
        public Model(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            r = new Random();
            

            Tile = new ProjectTile();
            Pacman = new Pacman(sizeField);
            tanks = new List<Tank>();
            FireTanks = new List<FireTank>();
            Apples = new List<Apple>();

            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApple = amountApple;
            this.speedGame = speedGame;

            CreateTanks();
            CreateApples();
            wall = new Wall();

            gameStatus = GameStatus.Stoping;
        }


        private void CreateApples(int newApples = 0)
        {
            int x, y;
            while (Apples.Count < amountApple + newApples)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;
                bool flag = Apples.All(apple => apple.X != x || apple.Y != y);

                if (flag)
                    Apples.Add(new Apple(x, y));
            }
        }

        private void CreateTanks()
        {
            int x, y;
            while (tanks.Count < amountTanks + 1)
            {
                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, r.Next(6) * 40, r.Next(6) * 40));
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

                Tile.Run();
                Pacman.Run();
                ((Hunter)tanks[0]).Run(Pacman.X,Pacman.Y);
                for (int i = 1; i < tanks.Count; i++)
                    tanks[i].Run();

                foreach (var fireTank in FireTanks)
                    fireTank.Fire();

                for (int i = 1; i < tanks.Count; i++)
                {
                    if (
                        (Tile.X - tanks[i].X) < 19 &&
                        (Tile.Y - tanks[i].Y) < 19 &&
                        (Tile.X - tanks[i].X) > -9 &&
                        (Tile.Y - tanks[i].Y) > -9
                        )
                    {
                        FireTanks.Add(new FireTank(tanks[i].X, tanks[i].Y));
                        tanks.RemoveAt(i);
                        Tile.DefaultSettings();
                    }
                }

                for (int i = 0; i < tanks.Count; i++)
                {
                    for (int j = i + 1; j < tanks.Count; j++)
                        if (
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20 && (tanks[i].Y == tanks[j].Y))
                            ||
                            (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20 && (tanks[i].X == tanks[j].X))
                            ||
                            (Math.Abs(tanks[i].X - tanks[j].X) <= 20 && Math.Abs(tanks[i].Y - tanks[j].Y) <= 20)
                            ) 
                        {
                            if (i == 0)
                                ((Hunter) tanks[i]).TurnAround();
                            else
                                tanks[i].TurnAround();
                        
                            tanks[j].TurnAround();
                        }
                }

                for (int i = 0; i < Tanks.Count; i++)
                {
                    if (
                        (Math.Abs(tanks[i].X - Pacman.X) <= 19 && (tanks[i].Y == Pacman.Y))
                        ||
                        (Math.Abs(tanks[i].Y - Pacman.Y) <= 19 && (tanks[i].X == Pacman.X))
                        ||
                        (Math.Abs(tanks[i].X - Pacman.X) <= 19 && Math.Abs(tanks[i].Y - Pacman.Y) <= 19)
                        )
                    {
                        gameStatus = GameStatus.Looser;
                    }
                }

                for (int z = 0; z < Apples.Count; z++)
                    {
                        if (Math.Abs(Pacman.X - Apples[z].X) < 3 && Math.Abs(Pacman.Y - Apples[z].Y) < 3)
                        {
                            Apples[z] = new Apple(step += 30, 280);
                            collectedApples++;
                            CreateApples(collectedApples);
                        }
                    }
                if (collectedApples > 4)
                {
                    gameStatus = GameStatus.Winner;
                }
            }
        }

        private int step = -30;
    }
}
