using System;

class OperatorExample
{
    static void Main()
    {
        // ------------------------------
        // Arithmetic Operations
        // ------------------------------
        Console.WriteLine("Arithmetic Operations");
        int num1 = 12, num2 = 4;
        Console.WriteLine("Sum: " + (num1 + num2));
        Console.WriteLine("Difference: " + (num1 - num2));
        Console.WriteLine("Product: " + (num1 * num2));
        Console.WriteLine("Quotient: " + (num1 / num2));
        Console.WriteLine("Remainder: " + (num1 % num2));

        // ------------------------------
        // Comparison Operations
        // ------------------------------
        Console.WriteLine("\nComparison Operations");
        Console.WriteLine("num1 > num2 : " + (num1 > num2));
        Console.WriteLine("num1 < num2 : " + (num1 < num2));
        Console.WriteLine("num1 == num2 : " + (num1 == num2));
        Console.WriteLine("num1 != num2 : " + (num1 != num2));

        // ------------------------------
        // Assignment Shortcuts
        // ------------------------------
        Console.WriteLine("\nAssignment Shortcuts");
        int value = 20;
        value += 10;
        Console.WriteLine("After += 10 : " + value);
        value -= 5;
        Console.WriteLine("After -= 5 : " + value);

        // ------------------------------
        // Unary Operations
        // ------------------------------
        Console.WriteLine("\nUnary Operations");
        int counter = 7;
        Console.WriteLine("Counter++ : " + (counter++));
        Console.WriteLine("++Counter : " + (++counter));

        // ------------------------------
        // Conditional (Ternary) Operator
        // ------------------------------
        Console.WriteLine("\nConditional Operator");
        int checkNum = 15;
        string type = (checkNum % 2 == 0) ? "Even Number" : "Odd Number";
        Console.WriteLine("Result: " + type);

        // ------------------------------
        // Bitwise Operations
        // ------------------------------
        Console.WriteLine("\nBitwise Operations");
        int m = 6, n = 2;
        Console.WriteLine("m & n : " + (m & n));
        Console.WriteLine("m | n : " + (m | n));
        Console.WriteLine("m ^ n : " + (m ^ n));

        // ------------------------------
        // Type Checking using is
        // ------------------------------
        Console.WriteLine("\nType Checking");
        object language = "C# Programming";
        Console.WriteLine(language is string);

        Console.WriteLine("\nExecution Completed");
    }
}
