using System;

class AverageOfThree
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter three numbers:");

        Console.Write("Number 1: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Number 2: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Number 3: ");
        double num3 = Convert.ToDouble(Console.ReadLine());

        double average = (num1 + num2 + num3) / 3;

        Console.WriteLine($"The average of {num1}, {num2}, and {num3} is {average}");
    }
}