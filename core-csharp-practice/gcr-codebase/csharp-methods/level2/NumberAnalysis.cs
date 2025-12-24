using System;

class NumberAnalysis
{
    static bool IsPositive(int number)
    {
        return number > 0;
    }

    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    static int Compare(int number1, int number2)
    {
        if (number1 > number2) return 1;
        if (number1 < number2) return -1;
        return 0;
    }

    static void Main()
    {
        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsPositive(numbers[i]))
            {
                if (IsEven(numbers[i]))
                    Console.WriteLine("Positive Even");
                else
                    Console.WriteLine("Positive Odd");
            }
            else
            {
                Console.WriteLine("Negative");
            }
        }

        int comparisonResult = Compare(numbers[0], numbers[4]);

        if (comparisonResult == 0)
            Console.WriteLine("Equal");
        else if (comparisonResult == 1)
            Console.WriteLine("Greater");
        else
            Console.WriteLine("Less");
    }
}
