using System;
using System.Collections.Generic;

class PairWithGivenSum
{
    static bool HasPairWithSum(int[] arr, int n, int target)
    {
        HashSet<int> visited = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            int needed = target - arr[i];

            if (visited.Contains(needed))
            {
                Console.WriteLine("Pair found: " + needed + " + " + arr[i] + " = " + target);
                return true;
            }

            visited.Add(arr[i]);
        }

        return false;
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

        if (!HasPairWithSum(arr, n, target))
        {
            Console.WriteLine("No pair with given sum found");
        }
    }
}
