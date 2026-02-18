using System;

namespace TechVille.Utilities
{
    public class InputHelper
    {
        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("❌ Invalid number. Try again.");
            }
        }

        public static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("❌ Invalid number. Try again.");
            }
        }

        public static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("❌ Input cannot be empty.");
            }
        }
    }
}
