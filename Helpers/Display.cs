using System;
using System.Collections.Generic;
using ZooImitation.Abstract;
using ZooImitation.Enums;

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
            Console.ForegroundColor = ConsoleColor.Red;
            var wordsCount = message.Length + 3;
            Console.WriteLine(new string('-', wordsCount));
            Console.WriteLine($" - {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowQueryResult(this List<IAnimal> animals, string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (animals.Count > 0)
                {
                    foreach (var animal in animals)
                    {
                        Console.WriteLine($"{animal.Name} with name {animal.GetType().Name} is {animal.State}. " +
                            $"He has {animal.CurrentHealth}/{animal.DefaultHealth} point of health");
                    }
                }
                else
                {
                    errorMessage.ConsoleWrite();
                }
                Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
