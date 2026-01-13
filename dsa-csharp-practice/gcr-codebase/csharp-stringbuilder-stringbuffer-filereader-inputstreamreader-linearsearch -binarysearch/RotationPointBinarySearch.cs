using System;

class RotationPointBinarySearch
{
    static void Main()
    {
        int[] arr = { 15, 18, 2, 3, 6, 12 }; // Example rotated sorted array

        int rotationIndex = FindRotationPoint(arr);

        Console.WriteLine("Index of the smallest element (rotation point): " + rotationIndex);
        Console.WriteLine("Smallest element: " + arr[rotationIndex]);
    }

    static int FindRotationPoint(int[] arr)
    {
        int low = 0;
        int high = arr.Length - 1;

        // If the array is not rotated
        if (arr[low] <= arr[high])
            return 0;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            // Check if mid+1 is the smallest
            if (mid < high && arr[mid] > arr[mid + 1])
                return mid + 1;

            // Check if mid is the smallest
            if (mid > low && arr[mid - 1] > arr[mid])
                return mid;

            // Decide which half to go
            if (arr[mid] >= arr[low])
                low = mid + 1;
            else
                high = mid - 1;
        }

        return 0; // Default case (array not rotated)
    }
}
