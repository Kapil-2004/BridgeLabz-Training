using System;
using System.Collections.Generic;

class PetrolPump
{
    public int Petrol;
    public int Distance;

    public PetrolPump(int petrol, int distance)
    {
        Petrol = petrol;
        Distance = distance;
    }
}

class CircularTour
{
    static int FindStartPoint(PetrolPump[] pumps, int n)
    {
        int start = 0;
        int surplus = 0;
        int deficit = 0;

        for (int i = 0; i < n; i++)
        {
            surplus += pumps[i].Petrol - pumps[i].Distance;

            if (surplus < 0)
            {
                start = i + 1;
                deficit += surplus;
                surplus = 0;
            }
        }

        return (surplus + deficit >= 0) ? start : -1;
    }

    static void Main()
    {
        Console.Write("Enter number of petrol pumps: ");
        int n = int.Parse(Console.ReadLine());

        PetrolPump[] pumps = new PetrolPump[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter petrol at pump " + (i + 1) + ": ");
            int petrol = int.Parse(Console.ReadLine());

            Console.Write("Enter distance to next pump: ");
            int distance = int.Parse(Console.ReadLine());

            pumps[i] = new PetrolPump(petrol, distance);
        }

        int startPoint = FindStartPoint(pumps, n);

        if (startPoint == -1)
            Console.WriteLine("No possible circular tour");
        else
            Console.WriteLine("Start at petrol pump index: " + startPoint);
    }
}
