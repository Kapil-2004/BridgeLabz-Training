using System;
using System.Collections.Generic;

class CheckSetEquality
{
    static void Main()
    {
        // Input sets
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };

        bool areEqual = AreSetsEqual(set1, set2);

        Console.WriteLine("Are both sets equal? " + areEqual);
    }

    static bool AreSetsEqual(HashSet<int> set1, HashSet<int> set2)
    {
        // If counts differ, sets are not equal
        if (set1.Count != set2.Count)
            return false;

        // Check if all elements of set1 exist in set2
        foreach (int item in set1)
        {
            if (!set2.Contains(item))
                return false;
        }

        return true;
    }
}
