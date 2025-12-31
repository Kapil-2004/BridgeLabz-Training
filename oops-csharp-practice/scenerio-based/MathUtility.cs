using System;

public class MathUtility
{
    // 1. Factorial of a number
    public static long Factorial(int n)
    {
        if (n < 0)
            return -1; // Invalid input

        long fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }

    // 2. Check if a number is prime
    public static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    // 3. Find GCD of two numbers
    public static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // 4. Find nth Fibonacci number
    public static int Fibonacci(int n)
    {
        if (n < 0)
            return -1; // Invalid input
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;

        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}

class Program
{
    static void Main()
    {
        // Testing Factorial
        Console.WriteLine("Factorial Tests:");
        Console.WriteLine(MathUtility.Factorial(5));   // 120
        Console.WriteLine(MathUtility.Factorial(0));   // 1
        Console.WriteLine(MathUtility.Factorial(-3));  // -1

        // Testing Prime Check
        Console.WriteLine("\nPrime Tests:");
        Console.WriteLine(MathUtility.IsPrime(7));     // True
        Console.WriteLine(MathUtility.IsPrime(1));     // False
        Console.WriteLine(MathUtility.IsPrime(-5));    // False

        // Testing GCD
        Console.WriteLine("\nGCD Tests:");
        Console.WriteLine(MathUtility.GCD(48, 18));    // 6
        Console.WriteLine(MathUtility.GCD(0, 5));      // 5
        Console.WriteLine(MathUtility.GCD(-12, -8));   // 4

        // Testing Fibonacci
        Console.WriteLine("\nFibonacci Tests:");
        Console.WriteLine(MathUtility.Fibonacci(6));   // 8
        Console.WriteLine(MathUtility.Fibonacci(0));   // 0
        Console.WriteLine(MathUtility.Fibonacci(-4));  // -1
    }
}
