using System;

class FirstNegativeSearch
{
    static void Main()
    {
        int[] numbers = { 4, 7, 0, 3, -5, 9, -2 }; // Example array

        int firstNegativeIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                firstNegativeIndex = i;
                break; // Stop at the first negative number
            }
        }

        if (firstNegativeIndex != -1)
        {
            Console.WriteLine("First negative number: " + numbers[firstNegativeIndex]);
            Console.WriteLine("Index: " + firstNegativeIndex);
        }
        else
        {
            Console.WriteLine("No negative numbers found in the array.");
        }
    }
}
