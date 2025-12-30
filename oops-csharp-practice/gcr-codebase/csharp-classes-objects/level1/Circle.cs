using System;

// Class Definition
class Circle
{
    // Attribute
    private double radius;

    // Constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }

    // Method to calculate area
    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    // Method to calculate circumference
    public double CalculateCircumference()
    {
        return 2 * Math.PI * radius;
    }

    // Method to display results
    public void Display()
    {
        Console.WriteLine("Radius        : " + radius);
        Console.WriteLine("Area          : " + CalculateArea());
        Console.WriteLine("Circumference : " + CalculateCircumference());
    }
}

class Program
{
    static void Main()
    {
        // Create Circle object
        Circle c = new Circle(7);

        // Display area and circumference
        c.Display();
    }
}
