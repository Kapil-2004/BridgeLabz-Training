using System;

class DigitFrequency
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        int temp = number;
        int count = 0;
        while (temp != 0)
        {
            count++;
            temp = temp / 10;
        }

        int[] digits = new int[count];
        int[] frequency = new int[10];

        temp = number;

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp = temp / 10;
        }

        for (int i = 0; i < count; i++)
        {
            frequency[digits[i]]++;
        }
        Console.WriteLine("Digit Frequency:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine("Digit " + i + " occurs " + frequency[i] + " times");
            }
        }
    }
}
