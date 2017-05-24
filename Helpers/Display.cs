using System;

namespace ZooImitation
{
    public static class Display
    {
        /// <summary>
        /// Logs string messages in Console
        /// </summary>
        /// <param name="message">Message to log in console</param>
        public static void ConsoleWrite(this string message)
        {
            var wordsCount = message.Length + 3;
            Console.WriteLine(new string('-',wordsCount));
            Console.WriteLine($" - {message}");
        }
    }
}
