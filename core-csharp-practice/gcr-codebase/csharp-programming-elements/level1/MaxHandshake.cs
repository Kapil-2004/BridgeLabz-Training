using System;

class MaxHandshake
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int maxHandshakes = (n * (n - 1)) / 2;
        Console.WriteLine($"The maximum number of handshakes possible in a group of {n} people is {maxHandshakes}");
    }
}