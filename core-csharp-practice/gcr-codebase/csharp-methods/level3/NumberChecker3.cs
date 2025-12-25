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

    static int[] ReverseDigits(int[] digits)
    {
        int[] reversed = new int[digits.Length];

        for (int i = 0; i < digits.Length; i++)
            reversed[i] = digits[digits.Length - 1 - i];

        return reversed;
    }

    static bool AreArraysEqual(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }

    static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseDigits(digits);
        return AreArraysEqual(digits, reversed);
    }

    static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] != 0)
                return true;
        }

        return false;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = StoreDigits(number);

        Console.WriteLine(CountDigits(number));
        Console.WriteLine(IsPalindrome(digits));
        Console.WriteLine(IsDuckNumber(digits));
    }
}
