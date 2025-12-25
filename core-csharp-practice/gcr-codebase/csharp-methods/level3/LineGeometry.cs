using System;

class LineGeometry
{
    // Method to calculate Euclidean distance
    public static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        double xDifference = x2 - x1;
        double yDifference = y2 - y1;

        double distance = Math.Sqrt(
            Math.Pow(xDifference, 2) + Math.Pow(yDifference, 2)
        );

        return distance;
    }

    // Method to calculate slope (m) and y-intercept (b)
    public static double[] FindLineEquation(double x1, double y1, double x2, double y2)
    {
        if (x2 == x1)
        {
            // Vertical line, slope is undefined
            return new double[0];
        }

        double slope = (y2 - y1) / (x2 - x1);
        double yIntercept = y1 - (slope * x1);

        return new double[] { slope, yIntercept };
    }

    static void Main()
    {
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        double distance = CalculateDistance(x1, y1, x2, y2);
        Console.WriteLine("\nEuclidean Distance = " + distance);

        double[] lineEquation = FindLineEquation(x1, y1, x2, y2);

        if (lineEquation.Length == 0)
        {
            Console.WriteLine("The line is vertical (slope is undefined).");
        }
        else
        {
            Console.WriteLine("Slope (m) = " + lineEquation[0]);
            Console.WriteLine("Y-Intercept (b) = " + lineEquation[1]);
            Console.WriteLine($"Equation of line: y = {lineEquation[0]}x + {lineEquation[1]}");
        }
    }
}
