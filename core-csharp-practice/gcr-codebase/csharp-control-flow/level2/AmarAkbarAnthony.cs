using System;

class FriendsComparison
{
    static void Main(string[] args)
    {
        int amarAge = int.Parse(Console.ReadLine());
        int akbarAge = int.Parse(Console.ReadLine());
        int anthonyAge = int.Parse(Console.ReadLine());

        double amarHeight = double.Parse(Console.ReadLine());
        double akbarHeight = double.Parse(Console.ReadLine());
        double anthonyHeight = double.Parse(Console.ReadLine());

        if (amarAge <= akbarAge && amarAge <= anthonyAge)
        {
            Console.WriteLine("Youngest friend is Amar");
        }
        else if (akbarAge <= amarAge && akbarAge <= anthonyAge)
        {
            Console.WriteLine("Youngest friend is Akbar");
        }
        else
        {
            Console.WriteLine("Youngest friend is Anthony");
        }

        if (amarHeight >= akbarHeight && amarHeight >= anthonyHeight)
        {
            Console.WriteLine("Tallest friend is Amar");
        }
        else if (akbarHeight >= amarHeight && akbarHeight >= anthonyHeight)
        {
            Console.WriteLine("Tallest friend is Akbar");
        }
        else
        {
            Console.WriteLine("Tallest friend is Anthony");
        }
    }
}
