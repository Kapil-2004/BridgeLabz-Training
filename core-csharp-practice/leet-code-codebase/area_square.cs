using System;

class AreaSquare
{
    static void Main()
    {
        Console.Write("Enter the side length of the square: ");
        double side = double.Parse(Console.ReadLine());
        
        double area = side * side;
        
        Console.WriteLine($"Area of the square: {area}");
    }
}