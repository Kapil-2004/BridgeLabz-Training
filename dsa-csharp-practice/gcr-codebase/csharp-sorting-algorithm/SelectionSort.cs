using System;

class SelectionSort
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] scores = new int[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter exam score of student {i + 1}: ");
            scores[i] = int.Parse(Console.ReadLine());
        }

        // Selection Sort logic
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            // Find minimum element in unsorted part
            for (int j = i + 1; j < n; j++)
            {
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap with first unsorted element
            if (minIndex != i)
            {
                int temp = scores[i];
                scores[i] = scores[minIndex];
                scores[minIndex] = temp;
            }
        }

        // Display sorted exam scores
        Console.WriteLine("\nExam Scores in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(scores[i] + " ");
        }
    }
}
