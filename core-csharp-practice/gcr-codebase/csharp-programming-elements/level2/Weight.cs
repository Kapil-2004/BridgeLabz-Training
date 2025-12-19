
using System;

class WeightConversion
{
    static void Main()
    {
        double weightInPounds;

        // Taking input
        Console.Write("Enter weight in pounds: ");
        weightInPounds = Convert.ToDouble(Console.ReadLine());

        // Conversion formula
        double weightInKg = weightInPounds / 2.2;

        // Output
        Console.WriteLine(
            "The weight of the person in pounds is " + weightInPounds +
            " and in kg is " + weightInKg
        );
    }
}
