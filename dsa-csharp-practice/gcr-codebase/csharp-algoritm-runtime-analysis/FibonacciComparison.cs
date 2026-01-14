using System;
using System.Diagnostics;

class FibonacciComparison
{
    // ---------- Recursive Fibonacci (O(2^N)) ----------
    static int FibonacciRecursive(int n)
    {
        if (n <= 1)
            return n;

        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // ---------- Iterative Fibonacci (O(N)) ----------
    static int FibonacciIterative(int n)
    {
        if (n <= 1)
            return n;

        int a = 0, b = 1, sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }

    static void Test(int n, bool runRecursive)
    {
        Stopwatch sw = new Stopwatch();

        Console.WriteLine("Fibonacci N = " + n);

        if (runRecursive)
        {
            sw.Start();
            FibonacciRecursive(n);
            sw.Stop();
            Console.WriteLine("Recursive Time: " + sw.ElapsedMilliseconds + " ms");
        }
        else
        {
            Console.WriteLine("Recursive Time: Unfeasible (>1hr)");
        }

        sw.Restart();
        FibonacciIterative(n);
        sw.Stop();
        Console.WriteLine("Iterative Time: " + sw.ElapsedMilliseconds + " ms");

        Console.WriteLine();
    }

    static void Main()
    {
        Test(10, true);
        Test(30, true);
        Test(50, false);
    }
}
