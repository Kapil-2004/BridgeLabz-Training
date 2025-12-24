using System;

class FriendsComparison
{
    static string FindYoungest(string[] names, int[] ages)
    {
        int index = 0;

        for (int i = 1; i < ages.Length; i++)
        {
            if (ages[i] < ages[index])
                index = i;
        }

        return names[index];
    }

    static string FindTallest(string[] names, double[] heights)
    {
        int index = 0;

        for (int i = 1; i < heights.Length; i++)
        {
            if (heights[i] > heights[index])
                index = i;
        }

        return names[index];
    }

    static void Main()
    {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
            ages[i] = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < 3; i++)
            heights[i] = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine(FindYoungest(names, ages));
        Console.WriteLine(FindTallest(names, heights));
    }
}
