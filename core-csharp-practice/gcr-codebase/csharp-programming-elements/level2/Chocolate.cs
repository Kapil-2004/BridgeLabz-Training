using System;

class Chocolate
{
    static void Main()
    {
        int numberOfChocolates, numberOfChildren;

        Console.Write("Enter number of chocolates: ");
        numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int chocolatesEachChildGets = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;

        Console.WriteLine(
            "The number of chocolates each child gets is " +
            chocolatesEachChildGets +
            " and the number of remaining chocolates is " +
            remainingChocolates
        );
    }
}
