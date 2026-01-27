using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class InjectAttribute : Attribute { }

public class Service
{
    public void Serve() => Console.WriteLine("Service is serving...");
}

public class Client
{
    [Inject]
    public Service MyService;

    public void Start()
    {
        MyService?.Serve();
    }
}

public class SimpleDIContainer
{
    public static void InjectDependencies(object obj)
    {
        Type type = obj.GetType();
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
        {
            if (field.GetCustomAttribute<InjectAttribute>() != null)
            {
                object dependency = Activator.CreateInstance(field.FieldType);
                field.SetValue(obj, dependency);
            }
        }
    }

    public static void Main()
    {
        Client client = new Client();
        InjectDependencies(client);
        client.Start();
    }
}
