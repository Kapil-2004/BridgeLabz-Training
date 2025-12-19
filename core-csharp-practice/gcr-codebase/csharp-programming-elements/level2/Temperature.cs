using System;

class Temperature
{
    static void Main()
    {
        double celsius;

        Console.Write("Enter temperature in Celsius: ");
        celsius = Convert.ToDouble(Console.ReadLine());

        double fahrenheit = (celsius * 9 / 5) + 32;

        // Output
        Console.WriteLine(
            "The " + celsius + " Celsius is " + fahrenheit + " Fahrenheit"
        );
    }
}
