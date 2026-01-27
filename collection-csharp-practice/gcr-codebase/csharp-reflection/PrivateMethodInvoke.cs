using System;
using System.Reflection;

public class PrivateMethodInvoke
{
    class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    public static void Main()
    {
        Calculator calc = new Calculator();

        MethodInfo method = typeof(Calculator).GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

        object result = method.Invoke(calc, new object[] { 5, 6 });
        Console.WriteLine("Result of Multiply: " + result);
    }
}
