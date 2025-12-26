using System;

class BasicCalculator
{
    static void Main()
    {
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Result: " + Add(a, b));
                break;
            case 2:
                Console.WriteLine("Result: " + Subtract(a, b));
                break;
            case 3:
                Console.WriteLine("Result: " + Multiply(a, b));
                break;
            case 4:
                if (b != 0)
                    Console.WriteLine("Result: " + Divide(a, b));
                else
                    Console.WriteLine("Error: Division by zero");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Addition
    static double Add(double x, double y)
    {
        return x + y;
    }

    // Subtraction
    static double Subtract(double x, double y)
    {
        return x - y;
    }

    // Multiplication
    static double Multiply(double x, double y)
    {
        return x * y;
    }

    // Division
    static double Divide(double x, double y)
    {
        return x / y;
    }
}
