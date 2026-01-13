using System;

class Search2DSortedMatrix
{
    static void Main()
    {
        int[,] matrix = {
            { 1, 4, 7, 11 },
            { 2, 5, 8, 12 },
            { 3, 6, 9, 16 },
            { 10, 13, 14, 17 }
        };

        Console.Write("Enter target value: ");
        int target = int.Parse(Console.ReadLine());

        (int row, int col) = SearchMatrix(matrix, target);

        if (row != -1)
        {
            Console.WriteLine("Target found at: (" + row + ", " + col + ")");
        }
        else
        {
            Console.WriteLine("Target not found in the matrix.");
        }
    }

    static (int, int) SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int left = 0;
            int right = cols - 1;

            // Binary Search in the i-th row
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (matrix[i, mid] == target)
                    return (i, mid);
                else if (matrix[i, mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }

        return (-1, -1); // Target not found
    }
}
