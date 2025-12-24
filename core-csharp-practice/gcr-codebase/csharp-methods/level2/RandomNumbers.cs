using System;

class RandomNumbers
{
    static int[] Generate4DigitRandomArray(int size)
    {
        int[] numbers = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
            numbers[i] = random.Next(1000, 10000);

        return numbers;
    }

    static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
            min = Math.Min(min, numbers[i]);
            max = Math.Max(max, numbers[i]);
        }

        double average = (double)sum / numbers.Length;

        return new double[] { average, min, max };
    }

    static void Main()
    {
        int[] numbers = Generate4DigitRandomArray(5);

        for (int i = 0; i < numbers.Length; i++)
            Console.WriteLine(numbers[i]);

        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
        Console.WriteLine(result[2]);
    }
}
