using System;

class SimpleInterest
{
    static void Main()
    {
        double principal = Convert.ToDouble(Console.ReadLine());
        double rate = Convert.ToDouble(Console.ReadLine());
        double time = Convert.ToDouble(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine($"The Simple Interest is {simpleInterest} for Principal {principal}, Rate of Interest {rate} and Time {time}");
    }
}