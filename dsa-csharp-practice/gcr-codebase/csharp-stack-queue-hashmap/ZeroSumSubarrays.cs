using System;
using System.Collections.Generic;

class ZeroSumSubarrays
{
    static void FindZeroSumSubarrays(int[] arr, int n)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int sum = 0;

        // Initialize for sum = 0 at index -1
        map[0] = new List<int> { -1 };

        for (int i = 0; i < n; i++)
        {
            sum += arr[i];

            if (map.ContainsKey(sum))
            {
                foreach (int startIndex in map[sum])
                {
                    Console.WriteLine("Subarray found from index " + (startIndex + 1) + " to " + i);
                }
                map[sum].Add(i);
            }
            else
            {
                map[sum] = new List<int> { i };
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nZero Sum Subarrays:");
        FindZeroSumSubarrays(arr, n);
    }
}
