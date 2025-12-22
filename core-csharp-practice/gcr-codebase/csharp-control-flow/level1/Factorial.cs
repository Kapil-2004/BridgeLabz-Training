using System;

class Factoral
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
        int i=1;
        while(i<=n)
        {
            fact = fact * i;
            i++;
        }   
        Console.WriteLine("Factorial of " + n + " is: " + fact);
    }
}