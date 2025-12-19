using System;

class AreaTriangle
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter the base of the triangle (in inches):");
        double base_val = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the height of the triangle (in inches):");
        double height = double.Parse(Console.ReadLine());

        double areaSquareInches = 0.5 * base_val * height;
        double areaSquareCm = areaSquareInches * 6.4516;

        Console.WriteLine($"Area of triangle in square inches: {areaSquareInches}");
        Console.WriteLine($"Area of triangle in square centimeters: {areaSquareCm}");
    }   
}