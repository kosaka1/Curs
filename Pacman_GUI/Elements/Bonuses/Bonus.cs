namespace Cursovoi
{
    internal abstract class Bonus : Element  // абстрактний клас для, який будуть наслідувати бонуси
    {
        public bool IsPicked { get; protected set; }

        public Bonus(Symbols symbol, ConsoleColor color) : base(symbol, color, true)
        {
            IsPicked = false;
        }

        public abstract void Pick();
    }
}
