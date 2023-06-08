using System.Diagnostics;

namespace Cursovoi
{
    internal class Energizer : Bonus // енерджайзер, який при зборі переводить привидів у стан переляку. 
    {
        public Energizer() : base(Symbols.Energizer, ConsoleColor.DarkCyan) { }

        public override void Pick()
        {
            Console.Beep(1000, 32);
            IsPicked = true;
            Pacman.Score += 100;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            TimeSpan ts = stopWatch.Elapsed;
            while (ts.TotalSeconds < 10)
            {
                Thread.Sleep((int)(1000 * Settings.GameSpeed));
                ts = stopWatch.Elapsed;
            }
            stopWatch.Stop();
            IsPicked = false;
        }
    }
}
