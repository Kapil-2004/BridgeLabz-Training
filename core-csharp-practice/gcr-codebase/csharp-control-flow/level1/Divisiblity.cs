using System;

class Divisiblity
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        if (n % 5 == 0 )
        {
            Console.WriteLine("Divisible by 5");
        }
        else
        {
            Console.WriteLine("Not Divisible by 5");
        }   
    }
}