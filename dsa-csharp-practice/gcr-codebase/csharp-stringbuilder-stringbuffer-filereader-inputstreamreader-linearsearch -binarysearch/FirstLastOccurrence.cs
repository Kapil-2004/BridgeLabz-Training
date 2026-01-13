using System;

class FirstLastOccurrence
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5, 5, 6 };
        Console.Write("Enter target element: ");
        int target = int.Parse(Console.ReadLine());

        int first = FindFirstOccurrence(arr, target);
        int last = FindLastOccurrence(arr, target);

        if (first != -1)
        {
            Console.WriteLine("First occurrence index: " + first);
            Console.WriteLine("Last occurrence index: " + last);
        }
        else
        {
            Console.WriteLine("Element not found in the array.");
        }
    }

    static int FindFirstOccurrence(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        int result = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                high = mid - 1; // Continue searching left half
            }
            else if (arr[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return result;
    }

    static int FindLastOccurrence(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        int result = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                low = mid + 1; // Continue searching right half
            }
            else if (arr[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return result;
    }
}
