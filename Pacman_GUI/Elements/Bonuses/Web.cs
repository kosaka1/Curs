
namespace Course
{
    internal class Web : Bonus //павутина, записняє Пекмена
    {
        public Web() : base(Symbols.Web, ConsoleColor.Gray) { }

        public override void Pick()
        {
            IsPicked = true;
            Thread.Sleep((int)(240 * Settings.GameSpeed * 3));
            IsPicked = false;
        }
    }
}
