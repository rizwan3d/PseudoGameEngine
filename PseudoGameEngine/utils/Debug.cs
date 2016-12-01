using System;

namespace PseudoGameEngine
{
    public static class Debue
    {
        public static void Log(string mas)
        {
            Console.WriteLine(mas);
        }

        public static void Error(string error)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = c;
        }

        public static void Warning(string warning)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(warning);
            Console.ForegroundColor = c;
        }
    }
}
