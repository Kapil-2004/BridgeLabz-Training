using System;

class NumberChecker
{
    static int CountDigits(int number)
    {
        int count = 0;

        while (number != 0)
        {
            count++;
            number /= 10;
        }

        return count;
    }

    static int[] StoreDigits(int number)
    {
        int count = CountDigits(number);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = number % 10;
            number /= 10;
        }

        return digits;
    }

    static int FindSumOfDigits(int[] digits)
    {
        int sum = 0;

        for (int i = 0; i < digits.Length; i++)
            sum += digits[i];

        return sum;
    }

    static double FindSumOfSquares(int[] digits)
    {
        double sumOfSquares = 0;

        for (int i = 0; i < digits.Length; i++)
            sumOfSquares += Math.Pow(digits[i], 2);

        return sumOfSquares;
    }

    static bool IsHarshadNumber(int number, int[] digits)
    {
        int sum = FindSumOfDigits(digits);
        return number % sum == 0;
    }

    static int[,] FindDigitFrequency(int[] digits)
    {
        int[,] frequency = new int[10, 2];

        for (int i = 0; i < 10; i++)
        {
            frequency[i, 0] = i;
            frequency[i, 1] = 0;
        }

        for (int i = 0; i < digits.Length; i++)
            frequency[digits[i], 1]++;

        return frequency;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = StoreDigits(number);

        Console.WriteLine(CountDigits(number));
        Console.WriteLine(FindSumOfDigits(digits));
        Console.WriteLine(FindSumOfSquares(digits));
        Console.WriteLine(IsHarshadNumber(number, digits));

        int[,] frequency = FindDigitFrequency(digits);

        for (int i = 0; i < 10; i++)
        {
            if (frequency[i, 1] > 0)
            {
                Console.WriteLine(frequency[i, 0]);
                Console.WriteLine(frequency[i, 1]);
            }
        }
    }
}
