using System;
using System.Reflection;

public class DynamicMethodInvocation
{
    class MathOperations
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
    }

    public static void Main()
    {
        MathOperations math = new MathOperations();
        Type type = typeof(MathOperations);

        Console.WriteLine("Enter method to call (Add, Subtract, Multiply):");
        string methodName = Console.ReadLine();

        MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);

        if (method == null)
        {
            Console.WriteLine("Method not found.");
            return;
        }

        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine());

        object result = method.Invoke(math, new object[] { a, b });
        Console.WriteLine($"Result: {result}");
    }
}
