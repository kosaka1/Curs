
namespace Course
{
    enum CellStatus
    {
        None = 1,
        Stepped,
        Wall
    }

    internal class MapChecker // перевірка карт на можливість пройти 
    {
        private int width;
        private int height;
        private int startX;
        private int startY;
        private CellStatus[,] copyMap;
        private List<(int x, int y)> coins;
        private bool IsPassable;

        public MapChecker(int startX, int startY, int width, int height, Element[,] map)
        {
            coins = new List<(int x, int y)>();
            this.startX = startX;
            this.startY = startY;
            this.width = width;
            this.height = height;
            copyMap = TranslateMap(map);
            IsPassable = true;
        }

        public bool CheckMap()
        {
            Step(startX, startY);
            SetUnreachedCoins();
            return IsPassable;
        }

        private CellStatus[,] TranslateMap(Element[,] map)
        {
            CellStatus[,] copyMap = new CellStatus[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y].Symbol == Symbols.Wall) // перетворюемо карту з урахуванням стін
                    {
                        copyMap[x, y] = CellStatus.Wall;
                    }
                    else
                    {
                        copyMap[x, y] = CellStatus.None;
                        if (map[x, y].Symbol == Symbols.Coin) // запам'ятовуємо клітинку з монеткою
                        {
                            coins.Add((x, y));
                        }
                    }
                }
            }

            return copyMap;
        }

        private void Step(int x, int y)
        {
            copyMap[x, y] = CellStatus.Stepped;// ходимо де можливо
            for (int i = 0; i < 4; i++)
            {
                if (i == 0 && y == 0)
                {
                    continue;
                }
                if (i == 1 && x == 0)
                {
                    continue;
                }
                if (i == 2 && y == height - 1)
                {
                    continue;
                }
                if (i == 3 && x == width - 1)
                {
                    continue;
                }
                if (copyMap[x + Entity.Delta[i].x, y + Entity.Delta[i].y] == CellStatus.None)
                {
                    Step(x + Entity.Delta[i].x, y + Entity.Delta[i].y);
                }
            }
        }

        private void SetUnreachedCoins()
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (copyMap[coins[i].x, coins[i].y] == CellStatus.None) // перевірка чи були ми на цій клітинці
                {
                    IsPassable = false;
                    return;
                }
            }
        }

    }
}
