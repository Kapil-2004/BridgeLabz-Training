using System;

class MatrixOperations
{
    // a. Create random matrix
    public static double[,] CreateRandomMatrix(int rows, int cols)
    {
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = Math.Round(Math.Random() * 9 + 1, 2);

        return matrix;
    }

    // b. Matrix addition
    public static double[,] AddMatrices(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    // c. Matrix subtraction
    public static double[,] SubtractMatrices(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    // d. Matrix multiplication
    public static double[,] MultiplyMatrices(double[,] a, double[,] b)
    {
        int rows = a.GetLength(0);
        int cols = b.GetLength(1);
        int common = a.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < common; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }

    // Transpose
    public static double[,] Transpose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j, i] = matrix[i, j];

        return result;
    }

    // e. Determinant of 2x2
    public static double Determinant2x2(double[,] m)
    {
        return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
    }

    // f. Determinant of 3x3
    public static double Determinant3x3(double[,] m)
    {
        return m[0,0]*(m[1,1]*m[2,2]-m[1,2]*m[2,1])
             - m[0,1]*(m[1,0]*m[2,2]-m[1,2]*m[2,0])
             + m[0,2]*(m[1,0]*m[2,1]-m[1,1]*m[2,0]);
    }

    // g. Inverse of 2x2
    public static double[,] Inverse2x2(double[,] m)
    {
        double det = Determinant2x2(m);
        if (det == 0) return null;

        return new double[,]
        {
            {  m[1,1]/det, -m[0,1]/det },
            { -m[1,0]/det,  m[0,0]/det }
        };
    }

    // h. Inverse of 3x3
    public static double[,] Inverse3x3(double[,] m)
    {
        double det = Determinant3x3(m);
        if (det == 0) return null;

        double[,] adj = new double[3,3];

        adj[0,0] =  (m[1,1]*m[2,2]-m[1,2]*m[2,1]);
        adj[0,1] = -(m[0,1]*m[2,2]-m[0,2]*m[2,1]);
        adj[0,2] =  (m[0,1]*m[1,2]-m[0,2]*m[1,1]);

        adj[1,0] = -(m[1,0]*m[2,2]-m[1,2]*m[2,0]);
        adj[1,1] =  (m[0,0]*m[2,2]-m[0,2]*m[2,0]);
        adj[1,2] = -(m[0,0]*m[1,2]-m[0,2]*m[1,0]);

        adj[2,0] =  (m[1,0]*m[2,1]-m[1,1]*m[2,0]);
        adj[2,1] = -(m[0,0]*m[2,1]-m[0,1]*m[2,0]);
        adj[2,2] =  (m[0,0]*m[1,1]-m[0,1]*m[1,0]);

        double[,] inverse = new double[3,3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                inverse[i, j] = adj[i, j] / det;

        return inverse;
    }

    // i. Display matrix
    public static void DisplayMatrix(double[,] matrix)
    {
        if (matrix == null)
        {
            Console.WriteLine("Matrix inverse does not exist");
            return;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        double[,] matrixA = CreateRandomMatrix(3, 3);
        double[,] matrixB = CreateRandomMatrix(3, 3);

        DisplayMatrix(matrixA);
        DisplayMatrix(matrixB);

        DisplayMatrix(AddMatrices(matrixA, matrixB));
        DisplayMatrix(SubtractMatrices(matrixA, matrixB));
        DisplayMatrix(MultiplyMatrices(matrixA, matrixB));
        DisplayMatrix(Transpose(matrixA));

        Console.WriteLine("Determinant: " + Determinant3x3(matrixA));
        DisplayMatrix(Inverse3x3(matrixA));
    }
}
