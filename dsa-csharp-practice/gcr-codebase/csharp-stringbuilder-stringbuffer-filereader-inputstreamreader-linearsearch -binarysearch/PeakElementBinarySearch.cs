using System;

class PeakElementBinarySearch
{
    static void Main()
    {
        int[] arr = { 1, 3, 20, 4, 1, 0 }; // Example array

        int peakIndex = FindPeak(arr);

        Console.WriteLine("Peak element found at index: " + peakIndex);
        Console.WriteLine("Peak element value: " + arr[peakIndex]);
    }

    static int FindPeak(int[] arr)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            bool leftOk = (mid == 0) || (arr[mid] >= arr[mid - 1]);
            bool rightOk = (mid == arr.Length - 1) || (arr[mid] >= arr[mid + 1]);

            if (leftOk && rightOk)
            {
                // arr[mid] is greater than both neighbors
                return mid;
            }
            else if (mid > 0 && arr[mid - 1] > arr[mid])
            {
                // Peak is in left half
                high = mid - 1;
            }
            else
            {
                // Peak is in right half
                low = mid + 1;
            }
        }

        return -1; // Should never happen if array has at least one element
    }
}
