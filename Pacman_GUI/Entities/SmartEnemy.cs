
namespace Course
{
    internal class SmartEnemy : Enemy
    {
        public SmartEnemy(int x, int y, Map map) : base(x, y, map) { }

        public override void Move(int pacmanX, int pacmanY)
        {
            if (!CanMove())
            {
                return;
            }
            Move(FindWave(X, Y, pacmanX, pacmanY));
        }

        protected int[,] FindWave(int startX, int startY, int targetX, int targetY)
        {
            bool wayFound = false;
            int width = map.Width;
            int height = map.Height;
            int[,] WavesMap = new int[width, height];

            int y, x, step = 0;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    if (!map.Level[x, y].IsWalkable) // заповнення з урахуванням стін
                    {
                        WavesMap[x, y] = -2;
                    }
                    else
                    {
                        WavesMap[x, y] = -1;
                    }
                }
            }

            Queue<(int x, int y)> points = new Queue<(int x, int y)>();
            WavesMap[targetX, targetY] = 0;
            points.Enqueue((targetX, targetY)); // будемо рухатись з кінця
            int count = points.Count;
            while (!wayFound && points.Count > 0)
            {
                for (int steps = 0; steps < count; steps++)
                {
                    var coordinates = points.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        if (coordinates.x - 1 >= 0 && coordinates.y - 1 >= 0 &&
                            coordinates.x + 1 < width && coordinates.y + 1 < height &&
                            WavesMap[coordinates.x + Delta[i].x, coordinates.y + Delta[i].y] == -1)
                        {
                            WavesMap[coordinates.x + Delta[i].x, coordinates.y + Delta[i].y] = step + 1;
                            points.Enqueue((coordinates.x + Delta[i].x, coordinates.y + Delta[i].y));
                        }
                    }
                }
                if (WavesMap[startX, startY] != -1)
                {
                    wayFound = true;
                }
                count = points.Count;
                step++;
            }
            return WavesMap;
        }

        private void Move(int[,] wMap)
        {
            for (int i = 0; i < 4; i++) // перевіряємо сусідні клітинки 
            {
                if (wMap[X + Delta[i].x, Y + Delta[i].y] == wMap[X, Y] - 1)
                {
                    X += Delta[i].x;
                    Y += Delta[i].y;
                }
            }
        }
    }
}
