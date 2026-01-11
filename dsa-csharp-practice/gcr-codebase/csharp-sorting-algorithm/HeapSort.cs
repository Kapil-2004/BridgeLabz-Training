using System;

class HeapSortSalaries
{
    static void Main()
    {
        Console.Write("Enter number of job applicants: ");
        int n = int.Parse(Console.ReadLine());

        double[] salaries = new double[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter expected salary of applicant {i + 1}: ");
            salaries[i] = double.Parse(Console.ReadLine());
        }

        // Apply Heap Sort
        HeapSort(salaries, n);

        // Display sorted salaries
        Console.WriteLine("\nSalary Demands in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(salaries[i] + " ");
        }
    }

    // Heap Sort function
    static void HeapSort(double[] arr, int n)
    {
        // Step 1: Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Step 2: Extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            double temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Reheapify reduced heap
            Heapify(arr, i, 0);
        }
    }

    // Heapify a subtree rooted at index i
    static void Heapify(double[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            double swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify affected subtree
            Heapify(arr, n, largest);
        }
    }
}
