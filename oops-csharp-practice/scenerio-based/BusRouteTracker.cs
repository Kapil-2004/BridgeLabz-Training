using System;

class BusRouteTracker
{
    static void Main()
    {
        int totalDistance = 0;
        int stop = 1;
        string choice = "no";

        Console.WriteLine("Welcome to Bus Route Distance Tracker");
        Console.WriteLine("Bus has started its journey...\n");

        while (choice != "yes")
        {
            Console.Write("Enter distance covered till stop " + stop + " (in km): ");
            int distance = Convert.ToInt32(Console.ReadLine());

            totalDistance += distance;

            Console.WriteLine("Stop " + stop + " reached");
            Console.WriteLine("Total distance so far: " + totalDistance + " km");

            Console.Write("Do you want to get off here? (yes/no): ");
            choice = Console.ReadLine().ToLower();

            Console.WriteLine(); // for clean spacing
            stop++;
        }

        Console.WriteLine("Passenger got off the bus.");
        Console.WriteLine("Total distance travelled: " + totalDistance + " km");
        Console.WriteLine("Thank you for using the tracker!");
    }
}
