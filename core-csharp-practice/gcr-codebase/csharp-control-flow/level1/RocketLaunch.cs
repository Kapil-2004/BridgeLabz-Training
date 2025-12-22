using System;

class RocketLaunch
{
    static void Main()
    {
        Console.Write("Enter a number to start countdown: ");
        int counter = int.Parse(Console.ReadLine());
        
        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }
        
        Console.WriteLine("Launch!");
    }
}