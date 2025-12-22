using System;

class SpringSeason
{
    static void Main(string[] args)
    {
        int month = int.Parse(Console.ReadLine());
        int day = int.Parse(Console.ReadLine());

        if ((month == 3 && day >= 20) ||
            (month == 4) ||
            (month == 5) ||
            (month == 6 && day <= 20))
        {
            Console.WriteLine("Its a Spring Season");
        }
        else
        {
            Console.WriteLine("Not a Spring Season");
        }
    }
}