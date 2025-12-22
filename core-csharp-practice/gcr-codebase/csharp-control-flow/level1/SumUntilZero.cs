using System;

class SumUntilZero
{
    static void Main()
    {
        double total = 0.0;
        double userInput;

        while (true)
        {
            Console.Write("Enter a number (0 to exit): ");
            userInput = double.Parse(Console.ReadLine());

            if (userInput == 0)
            {
                break;
            }

            total += userInput;
        }

        Console.WriteLine($"Sum of all numbers: {total}");
    }
}