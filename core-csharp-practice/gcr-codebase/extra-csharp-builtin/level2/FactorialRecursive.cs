using System;

class FactorialRecursive
{
    static void Main()
    {
        int number = ReadInput();
        long result = Factorial(number);
        DisplayResult(number, result);
    }

    // Function to read input
    static int ReadInput()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine());
    }

    // Recursive function to calculate factorial
    static long Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    // Function to display output
    static void DisplayResult(int n, long result)
    {
        Console.WriteLine($"Factorial of {n} is: {result}");
    }
}
