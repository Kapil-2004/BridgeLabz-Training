using System;

class RocketLaunch2
{
    static void Main()
    {
        Console.Write("Enter the countdown starting number: ");
        int counter = int.Parse(Console.ReadLine());
        
        for (; counter >= 1; counter--)
        {
            Console.WriteLine(counter);
        }
        
        Console.WriteLine("Launch !");
    }
}