using System;

class MaximumOfThree
{
    static void Main()
    {
        int a = ReadNumber("Enter first number: ");
        int b = ReadNumber("Enter second number: ");
        int c = ReadNumber("Enter third number: ");

        int max = FindMaximum(a, b, c);

        Console.WriteLine("Maximum value is: " + max);
    }

    // Function to take integer input
    static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    // Function to find maximum of three numbers
    static int FindMaximum(int x, int y, int z)
    {
        int max = x;

        if (y > max) max = y;
        if (z > max) max = z;

        return max;
    }
}
