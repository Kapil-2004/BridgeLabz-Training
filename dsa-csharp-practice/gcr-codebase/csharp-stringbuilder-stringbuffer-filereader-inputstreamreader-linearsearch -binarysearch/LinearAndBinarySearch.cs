using System;

class LinearAndBinarySearch
{
    static void Main()
    {
        int[] arr = { 3, 4, -1, 1, 9 };
        Console.WriteLine("Array: [" + string.Join(", ", arr) + "]");

        // ---------------- Linear Search: First Missing Positive ----------------
        int missing = FindFirstMissingPositive(arr);
        Console.WriteLine("First missing positive integer: " + missing);

        // ---------------- Binary Search: Find Target Index ----------------
        Array.Sort(arr); // Binary search requires sorted array
        Console.WriteLine("Sorted Array: [" + string.Join(", ", arr) + "]");

        Console.Write("Enter target to search: ");
        int target = int.Parse(Console.ReadLine());

        int targetIndex = BinarySearch(arr, target);
        if (targetIndex != -1)
            Console.WriteLine("Target found at index: " + targetIndex);
        else
            Console.WriteLine("Target not found in the array.");
    }

    // ---------------- Linear Search: First Missing Positive ----------------
    static int FindFirstMissingPositive(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            // Mark numbers in range [1..n]
            while (arr[i] > 0 && arr[i] <= n && arr[arr[i] - 1] != arr[i])
            {
                int temp = arr[i];
                arr[i] = arr[temp - 1];
                arr[temp - 1] = temp;
            }
        }

        // Find first index where value is not i+1
        for (int i = 0; i < n; i++)
        {
            if (arr[i] != i + 1)
                return i + 1;
        }

        return n + 1;
    }

    // ---------------- Binary Search: Find Target Index ----------------
    static int BinarySearch(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1; // Not found
    }
}
