using System;

class YoungestTallest
{
    static void Main()
    {
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        int youngestIndex = 0;
        int tallestIndex = 0;

        for (int i = 1; i < 3; i++)
        {
            if (ages[i] < ages[youngestIndex])
            {
                youngestIndex = i;
            }
            if (heights[i] > heights[tallestIndex])
            {
                tallestIndex = i;
            }
        }

        Console.WriteLine("Youngest Age: " + ages[youngestIndex]);
        Console.WriteLine("Tallest Height: " + heights[tallestIndex]);
    }
}