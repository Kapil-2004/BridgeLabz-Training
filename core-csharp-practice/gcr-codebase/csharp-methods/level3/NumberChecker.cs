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

    static bool IsDuckNumber(int[] digits)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] == 0)
                return true;
        }

        return false;
    }

    static bool IsArmstrongNumber(int number, int[] digits)
    {
        int sum = 0;
        int power = digits.Length;

        for (int i = 0; i < digits.Length; i++)
            sum += (int)Math.Pow(digits[i], power);

        return sum == number;
    }

    static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest)
            {
                secondLargest = digits[i];
            }
        }

        return new int[] { largest, secondLargest };
    }

    static int[] FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;

        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i] < smallest)
            {
                secondSmallest = smallest;
                smallest = digits[i];
            }
            else if (digits[i] < secondSmallest && digits[i] != smallest)
            {
                secondSmallest = digits[i];
            }
        }

        return new int[] { smallest, secondSmallest };
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int digitCount = CountDigits(number);
        int[] digits = StoreDigits(number);

        Console.WriteLine(digitCount);
        Console.WriteLine(IsDuckNumber(digits));
        Console.WriteLine(IsArmstrongNumber(number, digits));

        int[] largest = FindLargestAndSecondLargest(digits);
        Console.WriteLine(largest[0]);
        Console.WriteLine(largest[1]);

        int[] smallest = FindSmallestAndSecondSmallest(digits);
        Console.WriteLine(smallest[0]);
        Console.WriteLine(smallest[1]);
    }
}
