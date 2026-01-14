using System;
using System.Diagnostics;

class SortingComparison
{
    // ---------- Bubble Sort ----------
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // ---------- Merge Sort ----------
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
                arr[k++] = L[i++];
            else
                arr[k++] = R[j++];
        }

        while (i < n1) arr[k++] = L[i++];
        while (j < n2) arr[k++] = R[j++];
    }

    // ---------- Quick Sort ----------
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swap = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = swap;

        return i + 1;
    }

    // ---------- Test Method ----------
    static void TestSorting(int size, bool runBubble)
    {
        int[] data1 = new int[size];
        int[] data2 = new int[size];
        int[] data3 = new int[size];

        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            int value = rand.Next(size);
            data1[i] = value;
            data2[i] = value;
            data3[i] = value;
        }

        Stopwatch sw = new Stopwatch();

        if (runBubble)
        {
            sw.Start();
            BubbleSort(data1);
            sw.Stop();
            Console.WriteLine("Bubble Sort Time: " + sw.ElapsedMilliseconds + " ms");
        }
        else
        {
            Console.WriteLine("Bubble Sort Time: Unfeasible (>1hr)");
        }

        sw.Restart();
        MergeSort(data2, 0, data2.Length - 1);
        sw.Stop();
        Console.WriteLine("Merge Sort Time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        QuickSort(data3, 0, data3.Length - 1);
        sw.Stop();
        Console.WriteLine("Quick Sort Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static void Main()
    {
        Console.WriteLine("Dataset Size: 1,000");
        TestSorting(1000, true);

        Console.WriteLine("\nDataset Size: 10,000");
        TestSorting(10000, true);

        Console.WriteLine("\nDataset Size: 1,000,000");
        TestSorting(1000000, false);
    }
}
