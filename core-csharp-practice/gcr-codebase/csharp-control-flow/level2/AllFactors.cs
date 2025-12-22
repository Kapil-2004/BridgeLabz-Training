using System;

class AllFactors
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("All factors of " + n + " are:");
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}