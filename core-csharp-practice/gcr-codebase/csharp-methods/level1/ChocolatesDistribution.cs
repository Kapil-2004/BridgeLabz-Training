using System;

class ChocolatesDistribution
{
    public static int[] FindRemainderAndQuotient(int number, int divisor)
    {
        int chocolatesEach = number / divisor;
        int remainingChocolates = number % divisor;

        return new int[] { chocolatesEach, remainingChocolates };
    }

    static void Main()
    {
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int[] result = FindRemainderAndQuotient(numberOfChocolates, numberOfChildren);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
    }
}
