using System;

class PowerCalculation
{
    static void Main()
    {
        Console.WriteLine("=== Power Calculation ===");
        
        Console.Write("Enter base number: ");
        double baseNum = double.Parse(Console.ReadLine());
        
        Console.Write("Enter exponent: ");
        double exponent = double.Parse(Console.ReadLine());
        
        double result = Math.Pow(baseNum, exponent);
        
        Console.WriteLine($"{baseNum} raised to the power of {exponent} = {result}");
    }
}