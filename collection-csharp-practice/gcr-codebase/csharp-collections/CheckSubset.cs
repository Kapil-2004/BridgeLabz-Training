using System;
using System.Collections.Generic;

class CheckSubset
{
    static void Main()
    {
        // Input sets
        HashSet<int> set1 = new HashSet<int> { 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 1, 2, 3, 4 };

        bool isSubset = IsSubset(set1, set2);

        Console.WriteLine("Is Set1 a subset of Set2? " + isSubset);
    }

    static bool IsSubset(HashSet<int> set1, HashSet<int> set2)
    {
        // Check if every element of set1 exists in set2
        foreach (int item in set1)
        {
            if (!set2.Contains(item))
                return false;
        }

        return true;
    }
}
