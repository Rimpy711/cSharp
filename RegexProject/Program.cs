using System;
using System.Text.RegularExpressions;

namespace RegexProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The default regular expression checks for at least one letter.");

            while (true)
            {
                Console.Write("\nEnter a regular expression (or press ENTER to use the default): ");

                ConsoleKeyInfo cki = Console.ReadKey();
                string pattern = string.Empty;
                string userInput = string.Empty;

                if (cki.Key == ConsoleKey.Enter)
                {
                    pattern = @"^[a-z]+$";
                    Console.Write("\n^[a-z]+$");
                }

                if (string.IsNullOrEmpty(pattern))
                {
                    pattern = Console.ReadLine();
                    pattern = cki.KeyChar + pattern;
                }

                Console.Write("\nEnter some input: ");

                userInput = Console.ReadLine();

                PrintIsMatch(userInput, pattern);

                Console.WriteLine("Press ESC to end or any key to try again.");

                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.Escape)
                {
                    break;
                }

            }

            Console.WriteLine("H" + "Have a nice day!");
        }

        public static void PrintIsMatch(string value, string pattern)
        {
            Match m = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
            Console.WriteLine($"{value} and {pattern}: {m.Success}");

        }
    }
}