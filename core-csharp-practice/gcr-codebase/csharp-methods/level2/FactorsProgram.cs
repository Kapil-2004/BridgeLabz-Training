using System;

class FactorsProgram
{
    static int[] FindFactors(int number)
    {
        int count = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                count++;
        }

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
                factors[index++] = i;
        }

        return factors;
    }

    static int FindSum(int[] factors)
    {
        int sum = 0;

        for (int i = 0; i < factors.Length; i++)
            sum += factors[i];

        return sum;
    }

    static int FindProduct(int[] factors)
    {
        int product = 1;

        for (int i = 0; i < factors.Length; i++)
            product *= factors[i];

        return product;
    }

    static double FindSumOfSquares(int[] factors)
    {
        double sumOfSquares = 0;

        for (int i = 0; i < factors.Length; i++)
            sumOfSquares += Math.Pow(factors[i], 2);

        return sumOfSquares;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        for (int i = 0; i < factors.Length; i++)
            Console.WriteLine(factors[i]);

        Console.WriteLine(FindSum(factors));
        Console.WriteLine(FindSumOfSquares(factors));
        Console.WriteLine(FindProduct(factors));
    }
}
   