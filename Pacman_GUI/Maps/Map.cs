
namespace Cursovoi
{
    internal class Map // у цьому класі зберігається карта
    {
        public string Name;
        public Element[,] Level { get; private set; }
        public (int X, int Y) StartPacmanPosition { get; private set; } = (0, 0);
        public (int X, int Y)[] StartEnemiesPosition { get; private set; } = new (int X, int Y)[0];
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int NeedableCoins { get; private set; } = 0;
        public Picklock picklock = new Picklock();
        public Energizer energizer = new Energizer();
        public Web web = new Web();
        public Freeze freeze = new Freeze();
        private Dictionary<Symbols, Element> elements;
        private Dictionary<char, Symbols> symbols;

        public Map(string name)
        {
            elements = new Dictionary<Symbols, Element>
            {
                { Symbols.Pacman, new Space() },
                { Symbols.Ghost, new Space() },
                { Symbols.Space, new Space()},
                { Symbols.Wall, new Wall()},
                { Symbols.Coin, new Coin()},
                { Symbols.Energizer, new Energizer()},
                { Symbols.Web, new Web()},
                { Symbols.Freeze, new Freeze()},
                { Symbols.Door, new Door()},
                { Symbols.Picklock, new Picklock() },
            };
            symbols = new Dictionary<char, Symbols>
            {
                { ' ', Symbols.Space },
                { '#', Symbols.Wall },
                { '@', Symbols.Pacman },
                { 'A', Symbols.Ghost },
                { 'V', Symbols.AfraidGhost },
                { 'O', Symbols.Energizer },
                { '.', Symbols.Coin },
                { '|', Symbols.Door },
                { '*', Symbols.Web },
                { '%', Symbols.Freeze },
                { '&', Symbols.Picklock },
                { '$', Symbols.Dollar }
            };
            StartPacmanPosition = (0, 0);
            Name = name;
            Level = ReadMap(name + ".txt");
            Width = Level.GetLength(0);
            Height = Level.GetLength(1);
        }

        public int Count(Element searchElement)
        {
            int count = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Level[i, j].Symbol == searchElement.Symbol)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int[] FindPositions(Element element)
        {
            int[] positions = new int[Count(element) * 2];
            int index = 0;

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (Level[i, j].Symbol == element.Symbol)
                    {
                        positions[index++] = i;
                        positions[index++] = j;
                    }
                }
            }
            return positions;
        }

        private Element[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines($"Maps/{path}");
            Element[,] map = new Element[GetMaxLengthOfLine(file), file.Length];
            int n = 0;
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    Symbols symbol = symbols[file[y][x]];
                    map[x, y] = elements[symbol];
                    switch (symbol)
                    {
                        case Symbols.Pacman:
                            StartPacmanPosition = (x, y);
                            break;
                        case Symbols.Ghost:
                            AddNewEnemy();
                            StartEnemiesPosition[n++] = (x, y);
                            break;
                        case Symbols.Coin:
                            NeedableCoins++;
                            break;
                        case Symbols.Energizer:
                            energizer = (Energizer)map[x, y];
                            break;
                        case Symbols.Web:
                            web = (Web)map[x, y];
                            break;
                        case Symbols.Freeze:
                            freeze = (Freeze)map[x, y];
                            break;
                        case Symbols.Picklock:
                            picklock = (Picklock)map[x, y];
                            break;
                    }
                }
            }
            return map;
        }

        private int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;
            foreach (string line in lines)
            {
                if (line.Length > maxLength)
                    maxLength = line.Length;
            }
            return maxLength;
        }

        private void AddNewEnemy()
        {
            (int x, int y)[] enemiesPisition = new (int x, int y)[StartEnemiesPosition.Length + 1];
            for (int i = 0; i < StartEnemiesPosition.Length; i++)
            {
                enemiesPisition[i] = StartEnemiesPosition[i];
            }
            StartEnemiesPosition = enemiesPisition;
        }
    }
}
