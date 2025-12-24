using System;

class TrigonometricFunctions
{
    public static double[] calculateTrigonometricFunctions(double angle)
    {
        double radians = angle * Math.PI / 180;

        double sine = Math.Sin(radians);
        double cosine = Math.Cos(radians);
        double tangent = Math.Tan(radians);

        return new double[] { sine, cosine, tangent };
    }

    static void Main()
    {
        double angle = Convert.ToDouble(Console.ReadLine());

        double[] result = calculateTrigonometricFunctions(angle);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
        Console.WriteLine(result[2]);
    }
}
