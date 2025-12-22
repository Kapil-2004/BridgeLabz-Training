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

        // Sum using for loop
        int sumfor=0;
        for(int i =1 ; i <= n; i++)
        {
            sumfor += i;
        }

        // Sum using formula
        int sumFormula = n * (n + 1) / 2;

        Console.WriteLine("Sum using for loop: " + sumfor);
        Console.WriteLine("Sum using formula: " + sumFormula);

        // Compare results
        if (sumfor == sumFormula)
        {
            Console.WriteLine("Both computations are correct");
        }
        else
        {
            Console.WriteLine("Results do not match");
        }
    }
}
