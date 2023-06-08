
namespace Cursovoi
{
    internal class NaiveEnemy : Enemy // привид, який рухається у тій області що й Пекмен
    {
        public NaiveEnemy(int x, int y, Map map) : base(x, y, map) { }

        public override void Move(int pacmanX, int pacmanY)
        {
            if (!CanMove())
            {
                return;
            }
            if (pacmanX > map.Width / 2 && X < map.Width / 2)
            {
                direction = Direction.Right;
            }
            else if (pacmanX < map.Width / 2 && X > map.Width / 2)
            {
                direction = Direction.Left;
            }
            else if (pacmanY > map.Height / 2 && Y < map.Height / 2)
            {
                direction = Direction.Down;
            }
            else if (pacmanY < map.Height / 2 && Y > map.Height / 2)
            {
                direction = Direction.Up;
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
    }
}
