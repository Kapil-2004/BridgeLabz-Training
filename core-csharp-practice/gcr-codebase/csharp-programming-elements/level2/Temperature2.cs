using System;

class Temperature2
{
    static void Main()
    {
        double fahrenheit;

        // Taking input
        Console.Write("Enter temperature in Fahrenheit: ");
        fahrenheit = Convert.ToDouble(Console.ReadLine());

        // Conversion formula
        double celsius = (fahrenheit - 32) * 5 / 9;

        // Output
        Console.WriteLine(
            "The " + fahrenheit + " Fahrenheit is " + celsius + " Celsius"
        );
    }
}
