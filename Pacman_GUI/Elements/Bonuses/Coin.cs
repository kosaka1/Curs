namespace Cursovoi
{
    internal class Coin : Bonus // монетка, яка додає очки і є обов'язковою для проходження рівня
    {
        public Coin() : base(Symbols.Coin, ConsoleColor.Green) { }

        public override void Pick()
        {
            Console.Beep(345, 20);
            Pacman.Score += 10;
            Pacman.PickedCoins++;
        }
    }
}
