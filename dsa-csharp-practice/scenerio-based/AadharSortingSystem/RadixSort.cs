using System;

namespace AadharSortingSystem
{
    class RadixSort
    {
        // Main Radix Sort method
        public static void Sort(long[] arr)
        {
            long max = GetMax(arr);

            // Perform counting sort for each digit (LSD → MSD)
            for (long exp = 1; max / exp > 0; exp *= 10)
                CountingSort(arr, exp);
        }

        // Stable Counting Sort (important for same prefix order)
        static void CountingSort(long[] arr, long exp)
        {
            int n = arr.Length;
            long[] output = new long[n];
            int[] count = new int[10];

            // Count digit occurrences
            for (int i = 0; i < n; i++)
                count[(int)((arr[i] / exp) % 10)]++;

            // Cumulative count
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build output array (right to left → STABLE)
            for (int i = n - 1; i >= 0; i--)
            {
                int digit = (int)((arr[i] / exp) % 10);
                output[count[digit] - 1] = arr[i];
                count[digit]--;
            }

            // Copy back
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }

        static long GetMax(long[] arr)
        {
            long max = arr[0];
            foreach (long num in arr)
                if (num > max)
                    max = num;
            return max;
        }

        // Scenario B: Binary Search (after sorting)
        public static int BinarySearch(long[] arr, long key)
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] < key)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
    }
}
