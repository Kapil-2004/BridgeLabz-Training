using System;

class StudentScoreManager
{
    static void Main()
    {
        int n;

        // Input number of students
        while (true)
        {
            try
            {
                Console.Write("Enter number of students: ");
                n = int.Parse(Console.ReadLine());

                if (n <= 0)
                {
                    Console.WriteLine("Number of students must be greater than 0.");
                    continue;
                }
                break;
            }
            catch
            {
                Console.WriteLine("Invalid input. Enter a valid number.");
            }
        }

        int[] scores = new int[n];
        int sum = 0;

        // Input scores
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Enter score of student {i + 1}: ");
                    int score = int.Parse(Console.ReadLine());

                    if (score < 0)
                    {
                        Console.WriteLine("Score cannot be negative.");
                        continue;
                    }

                    scores[i] = score;
                    sum += score;
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Enter numeric value only.");
                }
            }
        }

        // Calculate average
        double average = (double)sum / n;

        // Find highest and lowest
        int highest = scores[0];
        int lowest = scores[0];

        for (int i = 1; i < n; i++)
        {
            if (scores[i] > highest)
                highest = scores[i];

            if (scores[i] < lowest)
                lowest = scores[i];
        }

        // Output results
        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Average Score: {average}");
        Console.WriteLine($"Highest Score: {highest}");
        Console.WriteLine($"Lowest Score: {lowest}");

        Console.WriteLine("\nScores above average:");
        for (int i = 0; i < n; i++)
        {
            if (scores[i] > average)
                Console.WriteLine(scores[i]);
        }
    }
}
