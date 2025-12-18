using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 2, 3, 4, 4, 5 };
        int[] result = RemoveDuplicates(array);
        
        Console.WriteLine("Array after removing duplicates: " + string.Join(", ", result));
    }

    static int[] RemoveDuplicates(int[] array)
    {
        HashSet<int> uniqueElements = new HashSet<int>(array);
        int[] result = new int[uniqueElements.Count];
        uniqueElements.CopyTo(result);
        return result;
    }
}