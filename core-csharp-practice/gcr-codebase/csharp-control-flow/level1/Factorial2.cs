using System;

class Factoral2
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        if(n<0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
            return;
        }
        int fact = 1;
        for(int i=1; i<=n; i++)
        {
            fact = fact * i;
        }   
        Console.WriteLine("Factorial of " + n + " is: " + fact);
    }
}