using System;

class HarshadNumber
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int originalNumber = number;
        while (originalNumber != 0)
        {
            int digit = originalNumber % 10;
            sum = sum + digit;
            originalNumber = originalNumber / 10;
        }

        if (number % sum == 0)
        {
            Console.WriteLine("Harshad Number");
        }
        else
        {
            Console.WriteLine("Not a Harshad Number");
        }
    }
}
