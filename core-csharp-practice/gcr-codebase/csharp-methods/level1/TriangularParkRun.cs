using System;

class TriangularParkRun
{
    static double CalculateRounds(double side1, double side2, double side3)
    {
        double perimeter = side1 + side2 + side3;
        return 5000 / perimeter;
    }

    static void Main()
    {
        double side1 = Convert.ToDouble(Console.ReadLine());
        double side2 = Convert.ToDouble(Console.ReadLine());
        double side3 = Convert.ToDouble(Console.ReadLine());

        double rounds = CalculateRounds(side1, side2, side3);
        Console.WriteLine(rounds);
    }
}
