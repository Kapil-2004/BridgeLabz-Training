using System;

class BubbleSortMarks
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] marks = new int[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter marks of student {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        // Bubble Sort logic
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (marks[j] > marks[j + 1])
                {
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }

        // Display sorted marks
        Console.WriteLine("\nStudent Marks in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(marks[i] + " ");
        }
    }
}
