using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

public class TestClass
{
    public void Method1()
    {
        Thread.Sleep(500);
        Console.WriteLine("Method1 executed");
    }

    public void Method2()
    {
        Thread.Sleep(300);
        Console.WriteLine("Method2 executed");
    }
}

public class MethodTiming
{
    public static void Main()
    {
        TestClass obj = new TestClass();
        Type type = typeof(TestClass);

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Stopwatch sw = Stopwatch.StartNew();
            method.Invoke(obj, null);
            sw.Stop();
            Console.WriteLine($"{method.Name} execution time: {sw.ElapsedMilliseconds} ms\n");
        }
    }
}
