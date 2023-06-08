
namespace Cursovoi
{
    internal class Enemy : Entity // привид, який рухається випадково
    {
        protected Direction direction;
        private Random random = new Random();

        public Enemy(int x, int y, Map map) : base(x, y, map, Symbols.Ghost, ConsoleColor.White)
        {
            ChangeDirection();
        }

        public override void Move(int pacmanX, int pacmanY)
        {
            if (!CanMove())
            {
                return;
            }
            if (map.energizer.IsPicked)
            {
                Symbol = Symbols.AfraidGhost;
                ChangeDirection();
            }
            GetDirection();
            switch (direction)
            {
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Left:
                    X--;
                    break;
            }
        }

        protected bool CanMove()
        {
            if (map.freeze.IsPicked)
            {
                return false;
            }
            Symbol = Symbols.Ghost;
            return true;
        }

        protected void GetDirection()
        {
            switch (direction)
            {
                case Direction.Up:
                    if (Y != 0 && map.Level[X, Y - 1].IsWalkable)
                    {
                        break;
                    }
                    ChangeDirection();
                    GetDirection();
                    break;
                case Direction.Down:
                    if (Y != map.Height - 1 && map.Level[X, Y + 1].IsWalkable)
                    {
                        break;
                    }
                    ChangeDirection();
                    GetDirection();
                    break;
                case Direction.Right:
                    if (X != map.Width - 1 && map.Level[X + 1, Y].IsWalkable)
                    {
                        break;
                    }
                    ChangeDirection();
                    GetDirection();
                    break;
                case Direction.Left:
                    if (X != 0 && map.Level[X - 1, Y].IsWalkable)
                    {
                        break;
                    }
                    ChangeDirection();
                    GetDirection();
                    break;
            }
        }

        protected void ChangeDirection()
        {
            direction = (Direction)random.Next(1, 5);
        }
    }
}
