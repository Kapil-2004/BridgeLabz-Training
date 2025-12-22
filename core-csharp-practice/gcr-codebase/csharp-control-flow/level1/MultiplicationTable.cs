using System;

class MultiplicationTable
{
    static void Main(string[] args)
    {
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine($"{number} * {i} = {number * i}");
        }
    }
}