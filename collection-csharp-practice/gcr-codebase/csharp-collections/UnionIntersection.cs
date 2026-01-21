using System;
using System.Collections.Generic;

class UnionIntersection
{
    static void Main()
    {
        // Input sets
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Compute union and intersection
        HashSet<int> union = GetUnion(set1, set2);
        HashSet<int> intersection = GetIntersection(set1, set2);

        // Print results
        Console.WriteLine("Union:");
        foreach (int item in union)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\n\nIntersection:");
        foreach (int item in intersection)
        {
            Console.Write(item + " ");
        }
    }

    static HashSet<int> GetUnion(HashSet<int> set1, HashSet<int> set2)
    {
        HashSet<int> result = new HashSet<int>();

        // Add all elements from set1
        foreach (int item in set1)
            result.Add(item);

        // Add all elements from set2
        foreach (int item in set2)
            result.Add(item);

        return result;
    }

    static HashSet<int> GetIntersection(HashSet<int> set1, HashSet<int> set2)
    {
        HashSet<int> result = new HashSet<int>();

        // Add elements that exist in both sets
        foreach (int item in set1)
        {
            if (set2.Contains(item))
                result.Add(item);
        }

        return result;
    }
}
