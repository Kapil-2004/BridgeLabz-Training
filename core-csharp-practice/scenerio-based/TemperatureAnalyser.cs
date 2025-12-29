using System;

class TemperatureAnalyzer
{
    static void AnalyzeTemperature(float[,] temp)
    {
        float maxAvg = float.MinValue;
        float minAvg = float.MaxValue;
        int hottestDay = 0;
        int coldestDay = 0;

        for (int i = 0; i < 7; i++)
        {
            float sum = 0;
            for (int j = 0; j < 24; j++)
            {
                sum += temp[i, j];
            }

            float avg = sum / 24;
            Console.WriteLine($"Day {i + 1} Average Temperature: {avg}");

            if (avg > maxAvg)
            {
                maxAvg = avg;
                hottestDay = i + 1;
            }

            if (avg < minAvg)
            {
                minAvg = avg;
                coldestDay = i + 1;
            }
        }

        Console.WriteLine($"\nHottest Day: Day {hottestDay}");
        Console.WriteLine($"Coldest Day: Day {coldestDay}");
    }

    static void Main() 
    {
        float[,] temperatures = new float[7, 24];

        // Sample data
        Random r = new Random();
        for (int i = 0; i < 7; i++)
            for (int j = 0; j < 24; j++)
                temperatures[i, j] = r.Next(15, 40);

        AnalyzeTemperature(temperatures);
    }
}
