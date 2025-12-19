using System;

class Athlete
{
    static void Main()
    {
        double side1, side2, side3;

        Console.Write("Enter side1 (in meters): ");
        side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side2 (in meters): ");
        side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side3 (in meters): ");
        side3 = Convert.ToDouble(Console.ReadLine());

        double perimeter = side1 + side2 + side3;

        double totalDistance = 5000;

        double rounds = totalDistance / perimeter;

        Console.WriteLine(
            "The total number of rounds the athlete will run is " +
            rounds + " to complete 5 km"
        );
    }
}
