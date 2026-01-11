using System;

class MergeSort
{
    static void Main()
    {
        Console.Write("Enter number of books: ");
        int n = int.Parse(Console.ReadLine());

        double[] prices = new double[n];

        // Taking user input
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter price of book {i + 1}: ");
            prices[i] = double.Parse(Console.ReadLine());
        }

        // Apply Merge Sort
        MergeSort(prices, 0, n - 1);

        // Display sorted prices
        Console.WriteLine("\nBook Prices in Ascending Order:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(prices[i] + " ");
        }
    }

    // Merge Sort function
    static void MergeSort(double[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    // Merge two sorted halves
    static void Merge(double[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        double[] L = new double[n1];
        double[] R = new double[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int iIndex = 0, jIndex = 0, k = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
            {
                arr[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = R[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy remaining elements
        while (iIndex < n1)
        {
            arr[k] = L[iIndex];
            iIndex++;
            k++;
        }

        while (jIndex < n2)
        {
            arr[k] = R[jIndex];
            jIndex++;
            k++;
        }
    }
}
