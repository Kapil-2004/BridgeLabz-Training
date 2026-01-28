using System;

namespace CSharpNUnit
{
    public class ExceptionTester
    {
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("Division by zero is not allowed");
            }
            return (double)a / b;
        }
    }
}
