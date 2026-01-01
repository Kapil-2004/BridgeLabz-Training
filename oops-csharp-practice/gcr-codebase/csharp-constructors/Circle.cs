using System;

class Circle
{
    double radius;


    public Circle()
    {
        radius = 5;
    }

    public Circle(double r)
    {
        radius = r;
    }

    public void DisplayCircle()
    {
        Console.WriteLine("Radius of Circle: " + radius);
        Console.WriteLine("Area of Circle: " + (Math.PI * radius * radius));
        Console.WriteLine("Circumference of Circle: " + (2 * Math.PI * radius));
        Console.WriteLine("-----------------------");
    }

    static void Main(string[] args)
    {
        // Using default constructor
        Circle circle1 = new Circle();
        circle1.DisplayCircle();

        // Using parameterized constructor
        Circle circle2 = new Circle(int.Parse(Console.ReadLine()));
        circle2.DisplayCircle();
    }   
}