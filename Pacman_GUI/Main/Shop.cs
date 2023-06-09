
namespace Course
{
    internal class Shop // клас для здійснення покупок
    {
        private List<Goods> stats = new List<Goods>();
        private BagSize bagSize;
        private Health health;

        public Shop()
        {
            bagSize = new BagSize();
            health = new Health();
            stats.Add(health);
            stats.Add(bagSize);
        }

        public bool ChoseProduct(ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                    return Pacman.Buy(health);
                case ConsoleKey.D2:
                    return Pacman.Buy(bagSize);
                default: 
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
