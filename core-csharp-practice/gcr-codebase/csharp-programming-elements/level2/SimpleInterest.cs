using System;

class SimpleInterest
{
    static void Main()
    {
        double principal, rate, time;


        Console.Write("Enter Principal: ");
        principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest: ");
        rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time: ");
        time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine(
            "The Simple Interest is " + simpleInterest +
            " for Principal " + principal +
            ", Rate of Interest " + rate +
            " and Time " + time
        );
    }
}
