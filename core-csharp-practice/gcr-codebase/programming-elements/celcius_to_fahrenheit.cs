using System;

class CelsiusToFahrenheit
{
    static void Main(string[] args)
    {
        Console.Write("Enter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());
        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine($"{celsius} Celsius is equal to {fahrenheit} Fahrenheit.");
    }
}