using System;

class InsertionSort
{
    static void Main()
    {
        Console.Write("Enter number of employees: ");
        int n = int.Parse(Console.ReadLine());

        int[] empIds = new int[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter Employee ID {i + 1}: ");
            empIds[i] = int.Parse(Console.ReadLine());
        }

        // Insertion Sort logic
        for (int i = 1; i < n; i++)
        {
            int key = empIds[i];
            int j = i - 1;

            // Move elements greater than key one position ahead
            while (j >= 0 && empIds[j] > key)
            {
                empIds[j + 1] = empIds[j];
                j--;
            }

            empIds[j + 1] = key;
        }

        // Display sorted employee IDs
        Console.WriteLine("\nEmployee IDs in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(empIds[i] + " ");
        }
    }
}
