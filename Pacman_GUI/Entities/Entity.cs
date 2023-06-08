
namespace Cursovoi
{
    internal abstract class Entity : Element // сутність, наслідують всі рухомі елементи
    {
        public int HealthPoints { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        protected Map map;
        private int startX;
        private int startY;
        static public (int x, int y)[] Delta = new (int x, int y)[]
        {
            (0, -1),
            (-1, 0),
            (0, 1),
            (1, 0)
        };

        public Entity(int x, int y, Map map, Symbols symbol, ConsoleColor color) : base(symbol, color, true)
        {
            X = x;
            Y = y;
            startX = x;
            startY = y;
            this.map = map;
        }

        public virtual void Move(int pacmanX, int pacmanY) { }

        public void CheckPosition(Enemy enemy)
        {
            if (X == enemy.X && Y == enemy.Y)
            {
                if (map.energizer.IsPicked)
                {
                    enemy.ReturnToStartPosition();
                }
                else
                {
                    HealthPoints--;
                    ReturnToStartPosition();
                }
            }
        }

        protected void ReturnToStartPosition()
        {
            X = startX;
            Y = startY;
        }
    }
}
