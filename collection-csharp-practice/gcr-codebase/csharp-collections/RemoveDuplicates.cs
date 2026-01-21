using System;
using System.Collections.Generic;

class RemoveDuplicates
{
    static void Main()
    {
        // Input list
        List<int> list = new List<int> { 3, 1, 2, 2, 3, 4 };

        // HashSet to track seen elements
        HashSet<int> seen = new HashSet<int>();

        // List to store result
        List<int> result = new List<int>();

        // Remove duplicates while preserving order
        foreach (int item in list)
        {
            if (!seen.Contains(item))
            {
                seen.Add(item);
                result.Add(item);
            }
        }

        // Print result
        Console.WriteLine("List after removing duplicates:");
        foreach (int item in result)
        {
            Console.Write(item + " ");
        }
    }
}
