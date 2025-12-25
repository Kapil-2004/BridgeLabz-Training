using System;

class NumberChecker
{
    // a. Find factors and return as array
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

    // b. Greatest factor
    static int FindGreatestFactor(int[] factors)
    {
        int max = int.MinValue;

        foreach (int f in factors)
        {
            if (f > max)
                max = f;
        }

        return max;
    }

    // c. Sum of factors
    static int FindSumOfFactors(int[] factors)
    {
        int sum = 0;

        foreach (int f in factors)
            sum += f;

        return sum;
    }

    // d. Product of factors
    static long FindProductOfFactors(int[] factors)
    {
        long product = 1;

        foreach (int f in factors)
            product *= f;

        return product;
    }

    // e. Product of cube of factors
    static double FindProductOfCubeOfFactors(int[] factors)
    {
        double product = 1;

        foreach (int f in factors)
            product *= Math.Pow(f, 3);

        return product;
    }

    // f. Perfect number
    static bool IsPerfectNumber(int number, int[] factors)
    {
        int sum = 0;

        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }

        return sum == number;
    }

    // g. Abundant number
    static bool IsAbundantNumber(int number, int[] factors)
    {
        int sum = 0;

        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }

        return sum > number;
    }

    // h. Deficient number
    static bool IsDeficientNumber(int number, int[] factors)
    {
        int sum = 0;

        foreach (int f in factors)
        {
            if (f != number)
                sum += f;
        }

        return sum < number;
    }

    // i. Strong number
    static bool IsStrongNumber(int number)
    {
        int temp = number;
        int sum = 0;

        while (temp != 0)
        {
            int digit = temp % 10;
            sum += Factorial(digit);
            temp /= 10;
        }

        return sum == number;
    }

    static int Factorial(int n)
    {
        int fact = 1;

        for (int i = 1; i <= n; i++)
            fact *= i;

        return fact;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("Factors:");
        foreach (int f in factors)
            Console.Write(f + " ");
        Console.WriteLine();

        Console.WriteLine("Greatest Factor: " + FindGreatestFactor(factors));
        Console.WriteLine("Sum of Factors: " + FindSumOfFactors(factors));
        Console.WriteLine("Product of Factors: " + FindProductOfFactors(factors));
        Console.WriteLine("Product of Cube of Factors: " + FindProductOfCubeOfFactors(factors));
        Console.WriteLine("Perfect Number: " + IsPerfectNumber(number, factors));
        Console.WriteLine("Abundant Number: " + IsAbundantNumber(number, factors));
        Console.WriteLine("Deficient Number: " + IsDeficientNumber(number, factors));
        Console.WriteLine("Strong Number: " + IsStrongNumber(number));
    }
}
