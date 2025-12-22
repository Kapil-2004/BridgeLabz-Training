using System;

class CountDigit
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int count = 0;

        while (number != 0)
        {
            number = number / 10;  
            count++;              
        }

        Console.WriteLine("Number of digits: " + count);
    }
}
