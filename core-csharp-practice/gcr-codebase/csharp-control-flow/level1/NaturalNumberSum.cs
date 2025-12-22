using System;

class NaturalNumberSum
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        if (n >= 0)
        {
            Console.WriteLine(n+"is a natural number");
            Console.WriteLine("sum of n natural numbers is" + (n*(n+1)/2));
        }
        else
        {
            Console.WriteLine(n+"is not a natural number");
        }
    }
}