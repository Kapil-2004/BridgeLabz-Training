using System;

class StudentScorecard
{
    // b. Generate random PCM scores
    public static int[,] GeneratePCMScores(int studentCount)
    {
        int[,] scores = new int[studentCount, 3];

        for (int i = 0; i < studentCount; i++)
        {
            scores[i, 0] = (int)(Math.Random() * 90) + 10; // Physics
            scores[i, 1] = (int)(Math.Random() * 90) + 10; // Chemistry
            scores[i, 2] = (int)(Math.Random() * 90) + 10; // Maths
        }

        return scores;
    }

    // c. Calculate total, average, percentage
    public static double[,] CalculateResults(int[,] scores)
    {
        int studentCount = scores.GetLength(0);
        double[,] results = new double[studentCount, 3];

        for (int i = 0; i < studentCount; i++)
        {
            int total = scores[i, 0] + scores[i, 1] + scores[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100;

            results[i, 0] = total;
            results[i, 1] = Math.Round(average, 2);
            results[i, 2] = Math.Round(percentage, 2);
        }

        return results;
    }

    // d. Display scorecard
    public static void DisplayScorecard(int[,] scores, double[,] results)
    {
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tTotal\tAverage\tPercentage");

        for (int i = 0; i < scores.GetLength(0); i++)
        {
            Console.WriteLine(
                (i + 1) + "\t" +
                scores[i, 0] + "\t" +
                scores[i, 1] + "\t\t" +
                scores[i, 2] + "\t" +
                results[i, 0] + "\t" +
                results[i, 1] + "\t" +
                results[i, 2]
            );
        }
    }

    static void Main()
    {
        int studentCount = Convert.ToInt32(Console.ReadLine());

        int[,] pcmScores = GeneratePCMScores(studentCount);
        double[,] results = CalculateResults(pcmScores);

        DisplayScorecard(pcmScores, results);
    }
}
