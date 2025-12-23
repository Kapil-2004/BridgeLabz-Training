using System;

class LargestSecond
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int index = 0;

        while (number != 0)
        {
            if (index == maxDigit)
                break;

            int lastDigit = number % 10;
            digits[index] = lastDigit;
            index++;

            number = number / 10;
        }

        int largest = 0;
        int secondLargest = 0;

        for (int i = 0; i < index; i++)
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

        Console.WriteLine("\nLargest Digit: " + largest);
        Console.WriteLine("Second Largest Digit: " + secondLargest);
    }
}
