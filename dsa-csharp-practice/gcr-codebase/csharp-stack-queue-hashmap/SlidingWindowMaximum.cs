using System;
using System.Collections.Generic;

class SlidingWindowMaximum
{
    static void FindMaxInWindows(int[] arr, int n, int k)
    {
        if (k > n || k <= 0)
            return;

        LinkedList<int> dq = new LinkedList<int>();

        for (int i = 0; i < n; i++)
        {
            if (dq.Count > 0 && dq.First.Value <= i - k)
            {
                dq.RemoveFirst();
            }

            while (dq.Count > 0 && arr[dq.Last.Value] <= arr[i])
            {
                dq.RemoveLast();
            }

            dq.AddLast(i);

            if (i >= k - 1)
            {
                Console.Write(arr[dq.First.Value] + " ");
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

        Console.Write("Enter window size k: ");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("\nMaximum in each sliding window:");
        FindMaxInWindows(arr, n, k);
    }
}
