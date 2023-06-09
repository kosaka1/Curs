using System.Diagnostics;


namespace Course
{
    internal class Freeze : Bonus //заморожуваня, зупиняє привидів
    {
        public Freeze() : base(Symbols.Freeze, ConsoleColor.Blue) { }

        public override void Pick()
        {
            IsPicked = true;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            while (ts.TotalSeconds < 5)
            {
                ts = stopWatch.Elapsed;
                Thread.Sleep((int)(1000 * Settings.GameSpeed));
            }
            IsPicked = false;
        }
    }
}
