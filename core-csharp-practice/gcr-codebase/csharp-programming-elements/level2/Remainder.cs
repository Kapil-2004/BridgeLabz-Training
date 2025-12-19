using System;

class Reaminder
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int remainder = a % b;
        Console.WriteLine("The Quotient is {0} and Remainder is {1} of two numbers {2} and {3}", a / b, remainder, a, b);
    }
}