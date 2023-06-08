
namespace Cursovoi
{
    internal abstract class Goods // Клас для наслідування товарів у магазині
    {
        public int Price { get; protected set; }

        public Goods(int price)
        {
            Price = price;
        }
    }
}
