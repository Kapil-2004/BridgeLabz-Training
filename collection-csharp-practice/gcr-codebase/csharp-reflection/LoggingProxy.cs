using System;
using System.Reflection;

public interface IGreeting
{
    void SayHello(string name);
}

public class Greeting : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

public class LoggingProxy : DispatchProxy
{
    public object Target { get; set; }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        Console.WriteLine($"[LOG] Executing method: {targetMethod.Name}");
        var result = targetMethod.Invoke(Target, args);
        return result;
    }

    public static T Create<T>(T target) where T : class
    {
        var proxy = DispatchProxy.Create<T, LoggingProxy>() as LoggingProxy;
        proxy.Target = target;
        return proxy as T;
    }
}

public class LoggingProxyDemo
{
    public static void Main()
    {
        IGreeting greeting = new Greeting();
        IGreeting proxy = LoggingProxy.Create(greeting);

        proxy.SayHello("Alice");
    }
}
