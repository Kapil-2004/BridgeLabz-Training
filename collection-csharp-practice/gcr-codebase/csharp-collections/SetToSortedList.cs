using System;
using System.Collections.Generic;

class SetToSortedList
{
    static void Main()
    {
        // Input set
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };

        // Convert set to list
        List<int> list = new List<int>(set);

        // Sort the list in ascending order
        list.Sort();

        // Print result
        Console.WriteLine("Sorted List:");
        foreach (int item in list)
        {
            Console.Write(item + " ");
        }
    }
}
