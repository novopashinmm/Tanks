using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Tanks
{
    public delegate void Streep();
    public class Model
    {
        public event Streep ChangeStreep;


        private readonly int _sizeField;
        private readonly int _amountTanks;
        private readonly int _amountApple;
        public int SpeedGame;
        private int _collectedApples;

        public GameStatus GameStatus;

        private readonly Random _r;

        public ProjectTile Tile { get; private set; }

        public Pacman Pacman { get; private set; }

        private List<Tank> _tanks;
        internal List<Tank> Tanks
        {
            get { return _tanks; }
        }

        public List<FireTank> FireTanks { get; private set; }

        public List<Apple> Apples { get; private set; }

        public Wall wall;
        public Model(int sizeField, int amountTanks, int amountApple, int speedGame)
        {
            _r = new Random();
            
            _sizeField = sizeField;
            _amountTanks = amountTanks;
            _amountApple = amountApple;
            SpeedGame = speedGame;

            NewGame();
        }


        private void CreateApples(int newApples = 0)
        {
            int x, y;
            while (Apples.Count < _amountApple + newApples)
            {
                x = _r.Next(6) * 40;
                y = _r.Next(6) * 40;
                bool flag = Apples.All(apple => apple.X != x || apple.Y != y);

                if (flag)
                    Apples.Add(new Apple(x, y));
            }
        }

        private void CreateTanks()
        {
            int x, y;
            while (_tanks.Count < _amountTanks + 1)
            {
                if (_tanks.Count == 0)
                    _tanks.Add(new Hunter(_sizeField, _r.Next(6) * 40, _r.Next(6) * 40));
                x = _r.Next(6)*40;
                y = _r.Next(6)*40;
                bool flag = _tanks.All(tank => tank.X != x || tank.Y != y);

                if (flag)
                    _tanks.Add(new Tank(_sizeField,x,y));
            }
        }

        private bool abilitKillHunter = true;
        public void Play()
        {
            while (GameStatus == GameStatus.Playing)
            {
                Thread.Sleep(SpeedGame);

                Tile.Run();
                Pacman.Run();
                if (_tanks.Count>0 && _tanks[0] is Hunter)
                    ((Hunter)_tanks[0]).Run(Pacman.X,Pacman.Y);
                if(_tanks.Count > 0)
                if (_tanks[0] is Hunter)
                    for (int i = 1; i < _tanks.Count; i++)
                        _tanks[i].Run();
                else
                    foreach (Tank t in _tanks)
                        t.Run();

                foreach (var fireTank in FireTanks)
                    fireTank.Fire();

                for (int i = 0; i < _tanks.Count; i++)
                {
                    if (
                        (Tile.X - _tanks[i].X) < 19 &&
                        (Tile.Y - _tanks[i].Y) < 19 &&
                        (Tile.X - _tanks[i].X) > -9 &&
                        (Tile.Y - _tanks[i].Y) > -9
                        )
                    {
                        if (i != 0 || abilitKillHunter)
                        {
                            FireTanks.Add(new FireTank(_tanks[i].X, _tanks[i].Y));
                            _tanks.RemoveAt(i);
                        }
                        Tile.DefaultSettings();
                    }
                }

                for (int i = 0; i < _tanks.Count; i++)
                {
                    for (int j = i + 1; j < _tanks.Count; j++)
                        if (
                            (Math.Abs(_tanks[i].X - _tanks[j].X) <= 20 && (_tanks[i].Y == _tanks[j].Y))
                            ||
                            (Math.Abs(_tanks[i].Y - _tanks[j].Y) <= 20 && (_tanks[i].X == _tanks[j].X))
                            ||
                            (Math.Abs(_tanks[i].X - _tanks[j].X) <= 20 && Math.Abs(_tanks[i].Y - _tanks[j].Y) <= 20)
                            ) 
                        {
                            if (i == 0 && _tanks[i] is Hunter)
                                ((Hunter) _tanks[i]).TurnAround();
                            else
                                _tanks[i].TurnAround();
                        
                            _tanks[j].TurnAround();
                        }
                }

                for (int i = 0; i < Tanks.Count; i++)
                {
                    if (
                        (Math.Abs(_tanks[i].X - Pacman.X) <= 19 && (_tanks[i].Y == Pacman.Y))
                        ||
                        (Math.Abs(_tanks[i].Y - Pacman.Y) <= 19 && (_tanks[i].X == Pacman.X))
                        ||
                        (Math.Abs(_tanks[i].X - Pacman.X) <= 19 && Math.Abs(_tanks[i].Y - Pacman.Y) <= 19)
                        )
                    {
                        GameStatus = GameStatus.Looser;
                        if (ChangeStreep != null)
                            ChangeStreep();
                    }
                }

                for (int z = 0; z < Apples.Count; z++)
                    {
                        if (Math.Abs(Pacman.X - Apples[z].X) < 3 && Math.Abs(Pacman.Y - Apples[z].Y) < 3)
                        {
                            Apples[z] = new Apple(_step += 30, 280);
                            _collectedApples++;
                            CreateApples(_collectedApples);
                        }
                    }
                if (_collectedApples > 4)
                {
                    GameStatus = GameStatus.Winner;
                    if (ChangeStreep != null)
                        ChangeStreep();
                }
            }
        }

        private int _step;

        internal void NewGame()
        {
            _collectedApples = 0;
            _step = -30;

            Tile = new ProjectTile();
            Pacman = new Pacman(_sizeField);
            _tanks = new List<Tank>();
            FireTanks = new List<FireTank>();
            Apples = new List<Apple>();

            CreateTanks();
            CreateApples();
            wall = new Wall();

            GameStatus = GameStatus.Stoping;
            if (ChangeStreep != null)
                ChangeStreep();
        }
    }
}
