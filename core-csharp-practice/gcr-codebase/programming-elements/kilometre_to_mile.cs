using System;

class KilometreToMile
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter distance in kilometres:");
        double kilometres = Convert.ToDouble(Console.ReadLine());
        double miles = kilometres * 0.621371;
        Console.WriteLine($"{kilometres} kilometres is equal to {miles} miles.");
    }
}