using System;

class QuickSort
{
    static void Main()
    {
        Console.Write("Enter number of products: ");
        int n = int.Parse(Console.ReadLine());

        double[] prices = new double[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter price of product {i + 1}: ");
            prices[i] = double.Parse(Console.ReadLine());
        }

        // Apply Quick Sort
        QuickSort(prices, 0, n - 1);

        // Display sorted prices
        Console.WriteLine("\nProduct Prices in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(prices[i] + " ");
        }
    }

    // Quick Sort function
    static void QuickSort(double[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    // Partition logic (last element as pivot)
    static int Partition(double[] arr, int low, int high)
    {
        double pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                double temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // Place pivot in correct position
        double tempPivot = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = tempPivot;

        return i + 1;
    }
}
