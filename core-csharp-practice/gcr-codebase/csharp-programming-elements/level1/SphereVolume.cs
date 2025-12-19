using System;

class SphereVolume
{
    static void Main(string[] args)
    {
        int radius = 6378;
        double kmvolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
        double milevolume = (4.0 / 3.0) * Math.PI * Math.Pow(radius*1.6, 3);
        Console.WriteLine("The volume of earth in cubic kilometers is " + kmvolume + " and cubic miles is " + milevolume);

    }
}