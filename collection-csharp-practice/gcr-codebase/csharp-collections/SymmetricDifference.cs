using System;
using System.Collections.Generic;

class SymmetricDifference
{
    static void Main()
    {
        // Input sets
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        HashSet<int> symmetricDiff = GetSymmetricDifference(set1, set2);

        // Print result
        Console.WriteLine("Symmetric Difference:");
        foreach (int item in symmetricDiff)
        {
            Console.Write(item + " ");
        }
    }

    static HashSet<int> GetSymmetricDifference(HashSet<int> set1, HashSet<int> set2)
    {
        HashSet<int> result = new HashSet<int>();

        // Add elements in set1 but not in set2
        foreach (int item in set1)
        {
            if (!set2.Contains(item))
                result.Add(item);
        }

        // Add elements in set2 but not in set1
        foreach (int item in set2)
        {
            if (!set1.Contains(item))
                result.Add(item);
        }

        return result;
    }
}
