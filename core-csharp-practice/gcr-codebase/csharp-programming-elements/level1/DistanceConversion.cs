using System;

class DistanceConversion
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter distance in feet:");
        double distanceInFeet = Convert.ToDouble(Console.ReadLine());

        double distanceInYards = distanceInFeet / 3;
        double distanceInMiles = distanceInYards / 1760;

        Console.WriteLine(
            $"The distance in yards is {distanceInYards} and in miles is {distanceInMiles}"
        );
    }
}
