using System;

class CountingSort
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        int[] ages = new int[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter age of student {i + 1} (10-18): ");
            ages[i] = int.Parse(Console.ReadLine());
        }

        // Apply Counting Sort
        CountingSort(ages, n);

        // Display sorted ages
        Console.WriteLine("\nStudent Ages in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(ages[i] + " ");
        }
    }

    static void CountingSort(int[] arr, int n)
    {
        int minAge = 10;
        int maxAge = 18;
        int range = maxAge - minAge + 1;

        int[] count = new int[range];
        int[] output = new int[n];

        // Step 1: Store frequency of each age
        for (int i = 0; i < n; i++)
        {
            count[arr[i] - minAge]++;
        }

        // Step 2: Compute cumulative frequencies
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }

        // Step 3: Place elements in correct positions
        for (int i = n - 1; i >= 0; i--)
        {
            int age = arr[i];
            int position = count[age - minAge] - 1;
            output[position] = age;
            count[age - minAge]--;
        }

        // Copy output to original array
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }
}
