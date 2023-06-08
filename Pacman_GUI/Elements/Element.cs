
namespace Cursovoi
{
    public abstract class Element // клас від якого наслідуються всі елементи карти
    {
        public Symbols Symbol { get; protected set; }
        public ConsoleColor Color { get; private set; }
        public bool IsWalkable { get; private set; }

        public Element(Symbols symbol, ConsoleColor color, bool isWalkable)
        {
            Symbol = symbol;
            Color = color;
            IsWalkable = isWalkable;
        }

        public override bool Equals(object other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                    return false;
            }
            Element element = (Element)other;
            if (element.Symbol != this.Symbol)
            {
                return false;
            }
            if (element.Color != this.Color) 
            { 
                return false; 
            }
            return true;
        }

        public override int GetHashCode()
        {
            return 213 * Symbol.GetHashCode()/2 + Color.GetHashCode() * 143;
        }
    }
}
