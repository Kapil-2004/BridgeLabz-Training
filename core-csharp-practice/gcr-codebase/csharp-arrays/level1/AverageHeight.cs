using System;

class AverageHeight
{
    static void Main(string[] args)
    {
        double[] heights = new double[11];
        double sum = 0.0;


        for (int i = 0; i < 10; i++)
        {
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < 10; i++)
        {
            sum += heights[i];
            count++;
        }

        double average = sum / 11;
        Console.WriteLine("Average Height = " + average);
    }
}