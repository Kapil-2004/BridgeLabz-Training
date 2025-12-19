using System;

class KilometerToMiles2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter kilometers to convert to miles:");
        double kilometer = Convert.ToDouble(Console.ReadLine());

        double miles = kilometer / 1.6;

        Console.WriteLine($"The total miles is {miles} mile for the given {kilometer} km");
    }
}
