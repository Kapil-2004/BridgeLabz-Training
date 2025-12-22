using System;

class Calculator
{
    static void Main(string[] args)
    {
        double first = double.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
                Console.WriteLine("Result: " + (first + second));
                break;
            case "-":
                Console.WriteLine("Result: " + (first - second));
                break;
            case "*":
                Console.WriteLine("Result: " + (first * second));
                break;
            case "/":
                if (second != 0)
                    Console.WriteLine("Result: " + (first / second));
                else
                    Console.WriteLine("Cannot divide by zero");
                break;
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
