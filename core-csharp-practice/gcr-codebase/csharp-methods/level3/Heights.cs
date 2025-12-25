using System;

class Heights
{
    static int FindSum(int[] heights)
    {
        int sum = 0;

        for (int i = 0; i < heights.Length; i++)
            sum += heights[i];

        return sum;
    }

    static double FindMean(int[] heights)
    {
        return (double)FindSum(heights) / heights.Length;
    }

    static int FindShortest(int[] heights)
    {
        int shortest = heights[0];

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] < shortest)
                shortest = heights[i];
        }

        return shortest;
    }

    static int FindTallest(int[] heights)
    {
        int tallest = heights[0];

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > tallest)
                tallest = heights[i];
        }

        return tallest;
    }

    static void Main()
    {
        int[] heights = new int[11];
        Random random = new Random();

        for (int i = 0; i < heights.Length; i++)
            heights[i] = random.Next(150, 251);

        for (int i = 0; i < heights.Length; i++)
            Console.WriteLine(heights[i]);

        Console.WriteLine(FindShortest(heights));
        Console.WriteLine(FindTallest(heights));
        Console.WriteLine(FindMean(heights));
    }
}
