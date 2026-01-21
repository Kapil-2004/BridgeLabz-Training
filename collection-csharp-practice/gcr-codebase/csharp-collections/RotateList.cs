using System;
using System.Collections.Generic;

class RotateList
{
    static void Main()
    {
        // Input list
        List<int> list = new List<int> { 10, 20, 30, 40, 50 };
        int k = 2; // rotate by 2 positions

        int n = list.Count;

        // Handle cases where k > n
        k = k % n;

        // Temporary list to store rotated result
        List<int> rotated = new List<int>();

        // Add elements from k to end
        for (int i = k; i < n; i++)
        {
            rotated.Add(list[i]);
        }

        // Add first k elements to the end
        for (int i = 0; i < k; i++)
        {
            rotated.Add(list[i]);
        }

        // Print result
        Console.WriteLine("Rotated List:");
        foreach (int item in rotated)
        {
            Console.Write(item + " ");
        }
    }
}
