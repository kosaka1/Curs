using System.Media;


namespace Course
{
    internal class MapCreator // редактор карт
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Element[,] Map { get; private set; }
        public Element SelectedElement { get; private set; }
        public bool CreatingInProcess { get; private set; }
        public bool IsPass = false;
        public Dictionary<ConsoleKey, Action> SelectedCellActions { get; private set; }
        public Dictionary<ConsoleKey, Element> Elements { get; private set; }
        private int pacmanX;
        private int pacmanY;
        private ConsoleKey key;
        private Dictionary<ConsoleKey, int> direction;
        private string path;
        private Dictionary<ConsoleKey, Action> mapActions;
        SoundPlayer player = new SoundPlayer();

        public MapCreator(string mapName, int width, int height, bool isRandom)
        {
            path = mapName;
            if (MapIsExists(mapName))
            {
                Map map = new Map(path);
                Height = map.Height;
                Width = map.Width;
                Map = map.Level;
            }
            else
            {
                Width = width;
                Height = height;
                Map = new Element[Width, Height];
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Map[j, i] = new Space();
                    }
                }
            }
            if (isRandom)
            {
                CreatingInProcess = true;
            }
            keyChanged += HandleKeyforConsole;

            SelectedCellActions = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.W, Move},
                { ConsoleKey.A, Move},
                { ConsoleKey.S, Move},
                { ConsoleKey.D, Move},
                { ConsoleKey.E, PutElement}
            };
            mapActions = new Dictionary<ConsoleKey, Action>
            {
                   { ConsoleKey.Y, CreateRandomMap}
            };
            direction = new Dictionary<ConsoleKey, int>
            {
                {ConsoleKey.W, 0},
                {ConsoleKey.A, 1},
                {ConsoleKey.S, 2},
                {ConsoleKey.D, 3}
            };
            Elements = new Dictionary<ConsoleKey, Element>
            {
                { ConsoleKey.D1,  new Wall() },
                { ConsoleKey.D2, new Coin()},
                { ConsoleKey.Spacebar,  new Space()},
                { ConsoleKey.V, new Pacman()},
                { ConsoleKey.D3, new Enemy(0,0,null)},
                { ConsoleKey.D4, new Energizer()},
                { ConsoleKey.D5, new Web()},
                { ConsoleKey.D6, new Freeze()},
                { ConsoleKey.D8, new Door()},
                { ConsoleKey.D7, new Picklock()}
            };
            SelectedElement = Elements[ConsoleKey.D1];
            player.SoundLocation = "Music/ConstructorPacman.wav";
            if (Settings.MusicIsOn)
            {
                player.PlayLooping();
            }
        }

        public void PressKey(ConsoleKey key)
        {
            this.key = key;
            keyChanged?.Invoke(key);
            if (SelectedCellActions.ContainsKey(key))
            {
                SelectedCellActions[key]();
            }
            else if (Elements.ContainsKey(key))
            {
                ChangeElement();
            }
            else if (mapActions.ContainsKey(key))
            {
                mapActions[key]();
            }
        }

        public void ChangeSize(int width, int height)
        {
            if (width < Width) { Width = width; }
            if (height < Height) { Height = height; }
            Width = width;
            Height = height;
            Element[,] tempMap = new Element[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i > Map.GetLength(1) - 1 || j > Map.GetLength(0) - 1)
                    {
                        tempMap[j, i] = new Space();
                    }
                    else
                    {
                        tempMap[j, i] = Map[j, i];
                    }
                }
            }
            Map = tempMap;
            X = Width / 2;
            Y = Height / 2;
        }

        public void SaveMap()
        {
            StreamWriter sw = new StreamWriter("Maps/" + path + ".txt", false);
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sw.Write(Map[j, i]);
                }
                sw.WriteLine();
            }
            sw.Close();
            sw.Dispose();
            if (MapIsExists(path))
            {
                return;
            }
            sw = new StreamWriter("Settings/Maps.txt", true);
            sw.WriteLine(path);
            sw.Close();
            sw.Dispose();
        }

        public void CheckMap()
        {
            MapChecker checker = new MapChecker(pacmanX, pacmanY, Width, Height, Map);
            IsPass = checker.CheckMap();
        }

        public void CreateRandomMap()
        {
            CreatingInProcess = true;
            int energizers = Width * Height / 200 + 1;
            int doors = Width * Height / 200 + 1;
            int webs = Width * Height / 50 + 1;
            int freezes = Width * Height / 100 + 1;
            MazeGenerator generator = new MazeGenerator(Width - 1, Height - 1, 1, 1, Width, Height, this);
            bool[,] maze = generator.CreateMaze();
            X = 1;
            Y = 1;
            while (Y < Height - 1)
            {
                key = (Y % 2 == 1) ? ConsoleKey.D : ConsoleKey.A;
                Map[X, Y] = GetNewElement(maze[X, Y]);
                for (int i = 0; i < Width - 2; i++)
                {
                    PressKey(key);
                    Map[X, Y] = GetNewElement(maze[X, Y]);
                    Thread.Sleep(25);
                }
                key = ConsoleKey.S;
                PressKey(key);
            }
            ChangePosition(0, 0, true);
            PutUpWalls(ConsoleKey.D, Width);
            PutUpWalls(ConsoleKey.S, Height);
            PutUpWalls(ConsoleKey.A, Width);
            PutUpWalls(ConsoleKey.W, Height);

            InsertBonuses(new Energizer(), energizers);
            InsertBonuses(new Web(), webs);
            InsertBonuses(new Freeze(), freezes);
            InsertBonuses(new Door(), doors);
            InsertBonuses(new Picklock(), doors);
            CreatingInProcess = false;
        }

        public void ChangePosition(int x, int y, bool cell)
        {
            X = x;
            Y = y;
            Map[X, Y] = cell ? Elements[ConsoleKey.D1] : Elements[ConsoleKey.Spacebar];
            Thread.Sleep(25);
        }

        private void HandleKeyforConsole(ConsoleKey key)
        {
            if (this.key == ConsoleKey.Escape || this.key == ConsoleKey.Enter)
            {
                MapChecker checker = new MapChecker(pacmanX, pacmanY, Width, Height, Map);
                IsPass = checker.CheckMap();
            }
        }

        private void Move()
        {
            int delta = direction[key];
            if (delta == 0 && Y == 0)
            {
                Y = Height - 1;
                return;
            }
            else if (delta == 1 && X == 0)
            {
                X = Width - 1;
                return;
            }
            else if (delta == 2 && Y == Height - 1)
            {
                Y = 0;
                return;
            }
            else if (delta == 3 && X == Width - 1)
            {
                X = 0;
                return;
            }
            X += Entity.Delta[delta].x;
            Y += Entity.Delta[delta].y;
        }

        private void PutElement()
        {
            Map[X, Y] = SelectedElement;
            if (SelectedElement.Symbol == Symbols.Pacman)
            {
                pacmanX = X;
                pacmanY = Y;
            }
        }

        private void ChangeElement()
        {
            Element element = Elements[key];
            SelectedElement = element;
        }

        private bool MapIsExists(string path)
        {
            string[] lines = File.ReadAllLines("Settings/Maps.txt");
            foreach (string map in lines)
            {
                if (path == map)
                {
                    return true;
                }
            }
            return false;
        }

        private void PutUpWalls(ConsoleKey key, int length)
        {
            this.key = key;
            for (int i = 0; i < length - 1; i++)
            {
                Map[X, Y] = Elements[ConsoleKey.D1];
                PressKey(this.key);
                Map[X, Y] = Elements[ConsoleKey.D1];
                Thread.Sleep(25);
            }
        }

        private void InsertBonuses(Element element, int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count;)
            {
                int x = rand.Next(0, Width);
                int y = rand.Next(0, Height);
                if (Map[x, y] == Elements[ConsoleKey.D1])
                {
                    continue;
                }
                Map[x, y] = element;
                i++;
                Thread.Sleep(25);
            }
        }

        private Element GetNewElement(bool cell)
        {
            int element = cell ? 0 : 1;
            return Elements.ElementAt(element).Value;
        }

        private delegate void KeyHandler(ConsoleKey key);
        event KeyHandler keyChanged;
    }
}
