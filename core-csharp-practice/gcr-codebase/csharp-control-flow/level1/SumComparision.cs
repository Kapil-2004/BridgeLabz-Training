using System;

class SumOfNaturalNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("The number is not a natural number");
            return;
        }

        // Sum using while loop
        int sumWhile = 0;
        int i = 1;

        while (i <= n)
        {
            sumWhile += i;
            i++;
        }

        // Sum using formula
        int sumFormula = n * (n + 1) / 2;

        Console.WriteLine("Sum using while loop: " + sumWhile);
        Console.WriteLine("Sum using formula: " + sumFormula);

        // Compare results
        if (sumWhile == sumFormula)
        {
            Console.WriteLine("Both computations are correct");
        }
        else
        {
            Console.WriteLine("Results do not match");
        }
    }
}
