using System;

class ArmstrongNumber
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int originalNumber = number;
        int sum = 0;

        while (originalNumber != 0)
        {
            int remainder = originalNumber % 10;

            sum = sum + (remainder * remainder * remainder);

            originalNumber = originalNumber / 10;
        }

        if (sum == number)
        {
            Console.WriteLine("Armstrong Number");
        }
        else
        {
            Console.WriteLine("Not an Armstrong Number");
        }
    }
}
