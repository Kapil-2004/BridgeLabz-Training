using System;

class Trip
{
    static void Main()
    {
        string name, fromCity, viaCity, toCity;

        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter starting city: ");
        fromCity = Console.ReadLine();

        Console.Write("Enter via city: ");
        viaCity = Console.ReadLine();

        Console.Write("Enter destination city: ");
        toCity = Console.ReadLine();

        double fromToVia, viaToFinalCity, timeTaken;

        Console.Write("Enter distance from start to via city (in miles): ");
        fromToVia = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter distance from via city to destination (in miles): ");
        viaToFinalCity = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter total time taken (in hours): ");
        timeTaken = Convert.ToDouble(Console.ReadLine());

        double totalDistance = fromToVia + viaToFinalCity;   
        double averageSpeed = totalDistance / timeTaken;     
        double distanceDifference = fromToVia - viaToFinalCity; 

        Console.WriteLine(
            "The results of the trip are: " +
            totalDistance + " miles, " +
            averageSpeed + " miles/hour, and " +
            distanceDifference + " miles"
        );
    }
}
