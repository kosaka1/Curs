
namespace Course
{
    internal class AppearingBonus   // клас для бонусу який буде з'являтися у випадковому місці у бонусному рівні
    {
        private int positionX;
        private int positionY;
        private Map map;
        private Random randomPlace;
        private Random randomElement;

        public AppearingBonus(Map map)
        {
            this.map = map;
            randomPlace = new Random();
            randomElement = new Random();
        }

        public (int x, int y) Appear()
        {
            while (!map.Level[positionX, positionY].Equals(new Space()))
            {
                positionX = randomPlace.Next(map.Width);
                positionY = randomPlace.Next(map.Height);
            }
            Bonus bonus = (randomElement.Next(11) < 8) ? new Dollar() : new Energizer();
            map.Level[positionX, positionY] = bonus;
            return(positionX, positionY);
        }
    }
}
