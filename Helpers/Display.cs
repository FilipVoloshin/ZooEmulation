using System;

namespace ZooImitation
{
    public static class Display
    {
        public static void ConsoleWrite(this string message)
        {
            var wordsCount = message.Length + 3;
            Console.WriteLine(new string('-',wordsCount));
            Console.WriteLine($" - {message}");
        }
    }
}
