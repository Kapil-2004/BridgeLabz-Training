using System;

class TemperatureConverter
{
    static void Main()
    {
        Console.WriteLine("Choose conversion:");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter temperature in Celsius: ");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Temperature in Fahrenheit: " + CelsiusToFahrenheit(c));
        }
        else if (choice == 2)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double f = double.Parse(Console.ReadLine());
            Console.WriteLine("Temperature in Celsius: " + FahrenheitToCelsius(f));
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    // Function to convert Celsius to Fahrenheit
    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    // Function to convert Fahrenheit to Celsius
    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }
}
