
namespace Cursovoi
{
    internal class Wall : Obslacle // стіна, є непрохідною
    {
        public Wall() : base(Symbols.Wall, ConsoleColor.Red, false) { }
    }
}
