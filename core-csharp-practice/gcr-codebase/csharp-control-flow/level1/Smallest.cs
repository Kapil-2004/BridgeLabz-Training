using System;

class Smallest
{
    static void Main(String[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        if (a <= b && a <= c)
        {
            Console.WriteLine(a + " is the smallest number.");
        }
        else
        {
            Console.WriteLine(a + " is not the smallest number.");
        }
    }
}