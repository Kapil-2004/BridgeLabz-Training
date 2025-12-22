using System;

class Largest
{
    static void Main(String[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        if (a >= b && a >= c)
        {
            Console.WriteLine(a + " is the largest number.");
        }
        else if (b >= a && b >= c)
        {
            Console.WriteLine(b + " is the largest number.");
        }
        else
        {
            Console.WriteLine(c + " is not the largest number.");
        }
    }
}