using System;

namespace AadharSortingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] aadharNumbers =
            {
                234567890123,
                123456789012,
                234567123456,
                123456000999,
                234567890111
            };

            Console.WriteLine("Original Aadhar Numbers:");
            Print(aadharNumbers);

            // Scenario A: Radix Sort
            RadixSort.Sort(aadharNumbers);

            Console.WriteLine("\nSorted Aadhar Numbers:");
            Print(aadharNumbers);

            // Scenario B: Binary Search
            long searchKey = 234567890123;
            int index = RadixSort.BinarySearch(aadharNumbers, searchKey);

            if (index != -1)
            {
                Console.WriteLine("\nAadhar " + searchKey + " found at index " + index);
            }
            else
            {
                Console.WriteLine("\nAadhar " + searchKey + " not found");
            }
        }

        static void Print(long[] arr)
        {
            foreach (long num in arr)
                Console.WriteLine(num);
        }
    }
}
