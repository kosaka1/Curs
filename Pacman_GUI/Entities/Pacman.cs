

namespace Cursovoi
{
    internal class Pacman : Entity // Пекмен, управляється гравцем, може збирати елементи на карті. 
    {
        public static int Money;
        public static int Score;
        public static int PickedCoins;
        public Inventory Inventory;
        protected Dictionary<ConsoleKey, Action<int>> move;
        protected Dictionary<ConsoleKey, int> direction;
        protected ConsoleKey key;

        public Pacman(int x = 0, int y = 0, Map map = null) : base(x, y, map, Symbols.Pacman, ConsoleColor.DarkYellow)
        {
            Score = 0;
            PickedCoins = 0;
            SetStats();
            direction = new Dictionary<ConsoleKey, int>
            {
                {ConsoleKey.W, 0},
                {ConsoleKey.A, 1},
                {ConsoleKey.S, 2},
                {ConsoleKey.D, 3}
            };
            move = new Dictionary<ConsoleKey, Action<int>>
            {
                {ConsoleKey.W, Move},
                {ConsoleKey.A, Move},
                {ConsoleKey.S, Move},
                {ConsoleKey.D, Move}
            };
        }

        public void Move(ConsoleKey pressedKey)
        {
            PacmanMove(pressedKey);
        }

        public virtual void PacmanMove(ConsoleKey pressedKey)
        {
            CheckPressedKey(pressedKey);
            if (move.TryGetValue(key, out Action<int> value))
            {
                value(direction[key]);
            }
            switch (map.Level[X, Y])
            {
                case Bonus:
                    PickUpBonus((Bonus)map.Level[X, Y]);
                    break;
                case Door:
                    map.Level[X, Y] = new Space();
                    break;
                case Item:
                    Inventory.AddItem((Item)map.Level[X, Y]);
                    if (Inventory.ItemIsAdded)
                    {
                        map.Level[X, Y] = new Space();
                    }
                    break;
            }
        }

        static public bool Buy(Goods stats)
        {
            if (Money >= stats.Price)
            {
                Money -= stats.Price;
                string[] Stats = File.ReadAllLines("Settings/Accountstats.txt");
                string line = null;

                line += Stats[0].Split(' ')[0] + $" {Money}\n";
                for (int i = 1; i < Stats.Length; i++)
                {
                    if (Stats[i].Split(' ')[0].ToLower() == stats.ToString().Split('.')[1].ToLower())
                    {
                        line += Stats[i].Split(' ')[0] + $" {Convert.ToInt32(Stats[i].Split(' ')[1]) + 1}\n";
                    }
                    else
                    {
                        line += $"{Stats[i].Split(' ')[0]} {Stats[i].Split(' ')[1]}\n";
                    }
                }
                File.WriteAllText("Settings/Accountstats.txt", line);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Move(int delta)
        {
            if ( key == ConsoleKey.W && Y == 0 && map.Level[X, map.Height - 1].IsWalkable)
            {
                Y = map.Height - 1;
            }
            else if (key == ConsoleKey.A && X == 0 && map.Level[map.Width - 1, Y].IsWalkable)
            {
                X = map.Width - 1;
            }
            else if (key == ConsoleKey.S && Y == map.Height - 1 && map.Level[X, 0].IsWalkable)
            {
                Y = 0;
            }
            else if (key == ConsoleKey.D && X == map.Width - 1 && map.Level[0, Y].IsWalkable)
            {
                X = 0;
            }
            else if (CanMove(X + Delta[delta].x, Y + Delta[delta].y))
            {
                X += Delta[delta].x;
                Y += Delta[delta].y;
            }
        }

        protected void PickUpBonus(Bonus bonus)
        {
            Task.Run(bonus.Pick);
            map.Level[X, Y] = new Space();
        }

        private bool CanMove(int x, int y)
        {
            if (map.web.IsPicked)
            {
                return false;
            }
            switch (map.Level[x, y])
            {
                case Wall:
                    return false;
                case Door:
                    if (Inventory.Contents.Contains(map.picklock))
                    {
                        Inventory.Contents.Remove(map.picklock);
                        return true;
                    }
                    return false;
            }
            return true;
        }

        private void CheckPressedKey(ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.W:
                    if (Y == 0 || map.Level[X, Y - 1].IsWalkable)
                    {
                        key = pressedKey;
                    }
                    break;
                case ConsoleKey.A:
                    if (X == 0 || map.Level[X - 1, Y].IsWalkable)
                    {
                        key = pressedKey;
                    }
                    break;
                case ConsoleKey.S:
                    if (Y == map.Height - 1 || map.Level[X, Y + 1].IsWalkable)
                    {
                        key = pressedKey;
                    }
                    break;
                case ConsoleKey.D:
                    if (X == map.Width - 1 || map.Level[X + 1, Y].IsWalkable)
                    {
                        key = pressedKey;
                    }
                    break;
            }
        }

        private void SetStats()
        {
            string[] Stats = File.ReadAllLines("Settings/Accountstats.txt");
            Money = Convert.ToInt32(Stats[0].Split(' ')[1]);
            HealthPoints = Convert.ToInt32(Stats[1].Split(' ')[1]);
            Inventory = new Inventory(Convert.ToInt32(Stats[2].Split(' ')[1]));
        }
    }
}
