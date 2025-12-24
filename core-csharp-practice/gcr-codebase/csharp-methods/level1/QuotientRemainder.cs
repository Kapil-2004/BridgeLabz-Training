using System;

class QuotientRemainder
{
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int quotient = number / divisor;
        int remainder = number % divisor;

        return new int[] { quotient, remainder };
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(number, divisor);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
    }
}

