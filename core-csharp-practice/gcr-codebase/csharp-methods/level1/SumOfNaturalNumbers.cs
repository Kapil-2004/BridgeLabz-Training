using System;

class SumOfNaturalNumbers
{
    static int CalculateSum(int number)
    {
        int sum = 0;

        for (int i = 1; i <= number; i++)
            sum += i;

        return sum;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int result = CalculateSum(number);
        Console.WriteLine(result);
    }
}
