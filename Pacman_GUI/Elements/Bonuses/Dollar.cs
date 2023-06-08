
namespace Cursovoi
{
    internal class Dollar : Bonus // Додає ігрову валюту при зборі
    {
        public Dollar() : base(Symbols.Dollar, ConsoleColor.DarkGreen) { }

        public override void Pick()
        {
            Pacman.Score += 10;
            Pacman.Money++;
        }
    }

}
