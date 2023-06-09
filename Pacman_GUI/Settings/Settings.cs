
namespace Course
{
    internal class Settings // налаштування, задають швидкість гри, складність
    {
        public static bool MusicIsOn { get; private set; } = false;

        public static double GameSpeed { get; private set; } = 1;

        public static int Difficulty { get; private set; } = 1;

        public static void ChangeSettings(ConsoleKey pressedKey, double value)
        {

            switch (pressedKey)
            {
                case ConsoleKey.D1:

                    if (value == 1)
                    {
                        MusicIsOn = false;
                    }
                    else if (value == 2)
                    {
                        MusicIsOn = true;
                    }

                    break;
                case ConsoleKey.D2:

                    GameSpeed = value;

                    break;
                case ConsoleKey.D3:

                    Difficulty = (int)value;

                    break;
            }
        }
    }
}
