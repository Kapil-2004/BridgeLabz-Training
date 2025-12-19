using System;
class Height
{
    static void Main()
    {
        Console.WriteLine("Enter your height in centimeters:");
        double heightInCm = double.Parse(Console.ReadLine());
        
        double totalInches = heightInCm / 2.54;
        int feet = (int)(totalInches / 12);
        double inches = totalInches % 12;
        
        Console.WriteLine($"Your Height in cm is {heightInCm} while in feet is {feet} and inches is {inches:F2}");
    }

}