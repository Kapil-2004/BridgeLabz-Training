using System;
using System.Collections.Generic;

class TwoSum
{
    static void FindTwoSum(int[] arr, int n, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int needed = target - arr[i];

            if (map.ContainsKey(needed))
            {
                Console.WriteLine("Indices found: " + map[needed] + " and " + i);
                return;
            }

            if (!map.ContainsKey(arr[i]))
                map[arr[i]] = i;
        }

        Console.WriteLine("No valid pair found");
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

        Console.Write("Enter target sum: ");
        int target = int.Parse(Console.ReadLine());

        FindTwoSum(arr, n, target);
    }
}
