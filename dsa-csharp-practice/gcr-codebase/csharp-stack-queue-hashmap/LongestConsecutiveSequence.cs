using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static int FindLongestConsecutive(int[] arr, int n)
    {
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < n; i++)
        {
            set.Add(arr[i]);
        }

        int longest = 0;

        foreach (int num in set)
        {
            // check if it is the start of a sequence
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int count = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    count++;
                }

                if (count > longest)
                    longest = count;
            }
        }

        return longest;
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

        int result = FindLongestConsecutive(arr, n);
        Console.WriteLine("\nLength of Longest Consecutive Sequence: " + result);
    }
}
