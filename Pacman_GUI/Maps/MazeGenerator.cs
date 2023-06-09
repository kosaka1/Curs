


namespace Course
{
    internal class MazeGenerator // генерує карту за алгоритмом
    {
        public bool[,] Grid;
        private int maxX;
        private int maxY;
        private int minX;
        private int minY;
        private MapCreator creator;

        public MazeGenerator(int maxX, int maxY, int minX, int minY, int width, int height, MapCreator mapCreator)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.minX = minX;
            this.minY = minY;
            creator = mapCreator;
            Grid = CreateGrid(width, height);
        }

        public bool[,] CreateMaze()
        {
            int dx = minX;
            Random random = new Random();
            for (int y = minY; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++)
                {
                    if (y != minY) // якщо перший ряд то заповнюємо постотою
                    {
                        if (random.Next(2) == 0 && x != maxX - 1) // вирішуємо чи прибирати стіну праворуч
                        {
                            Grid[x, y] = false;           // прибираємо стіну
                            creator.ChangePosition(x, y, false);
                        }
                        else // залишаємо стіну справа та робимо прохід нагору
                        {
                            if (!CanComeOut(dx, x, y - 1)) // якщо у зробленій пустоті немає проходу нагору
                            {
                                int randomX = random.Next(dx, x); // обираємо над якою клітинкою будемо робити прохід
                                Grid[randomX, y - 1] = false;              // прибираємо стіну зверху
                                creator.ChangePosition(randomX, y - 1, false);
                            }
                            if (x != maxX - 1)
                            {
                                dx = x + 1; // запам'ятовуємо стіну яка потенціально може бути перед початком пустоти
                            }
                            else
                            {
                                dx = minX;
                            }
                        }
                    }
                    else   // робимо пустоту в першому ряду
                    {
                        Grid[x, y] = false;
                        creator.ChangePosition(x, y, false);
                    }
                }
            }
            creator.ChangePosition(1, 1, false);
            return Grid;
        }

        private bool[,] CreateGrid(int width, int height)
        {
            bool[,] mazeGrid = new bool[width, height];
            for (int y = minY; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++) // заповнення стінами
                {
                    mazeGrid[x, y] = true;
                }
            }
            return mazeGrid;
        }

        private bool CanComeOut(int start, int end, int row)
        {
            for (int i = start; i < end; i++)
            {
                if (!Grid[i, row])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
