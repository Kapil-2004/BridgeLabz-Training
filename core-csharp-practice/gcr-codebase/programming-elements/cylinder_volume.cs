using System;

class CylinderVolume
{
    static void Main(string[] args)
    {
        Console.Write("Enter the radius of the cylinder: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the height of the cylinder: ");
        double height = Convert.ToDouble(Console.ReadLine());

        double volume = CalculateVolume(radius, height);
        Console.WriteLine($"The volume of the cylinder is: {volume}");
    }

    static double CalculateVolume(double radius, double height)
    {
        return Math.PI * Math.Pow(radius, 2) * height;
    }
}