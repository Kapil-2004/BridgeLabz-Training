using System;

class PositiveOrNegative
{
    static void Main(String[] args)
    {
        int number = int.Parse(Console.ReadLine());
        if (number > 0)
        {
            Console.WriteLine("The number " + number + " is Positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("The number " + number + " is Negative");
        }
        else
        {
            Console.WriteLine("The number " + number + " is Zero");
        }
    }
}