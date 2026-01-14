using System;
using System.Diagnostics;

class SearchPerformance
{
    // Linear Search
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1;
    }

    // Binary Search
    static int BinarySearch(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }

    static void TestDataset(int size)
    {
        int[] data = new int[size];

        for (int i = 0; i < size; i++)
            data[i] = i;

        int target = size - 1; // worst case

        Stopwatch sw = new Stopwatch();

        // Linear Search
        sw.Start();
        LinearSearch(data, target);
        sw.Stop();
        Console.WriteLine("Linear Search Time: " + sw.ElapsedMilliseconds + " ms");

        // Binary Search
        sw.Restart();
        BinarySearch(data, target);
        sw.Stop();
        Console.WriteLine("Binary Search Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static void Main()
    {
        Console.WriteLine("Dataset Size: 1,000");
        TestDataset(1000);

        Console.WriteLine("\nDataset Size: 10,000");
        TestDataset(10000);

        Console.WriteLine("\nDataset Size: 1,000,000");
        TestDataset(1000000);
    }
}
