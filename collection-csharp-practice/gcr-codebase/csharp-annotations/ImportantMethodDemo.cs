using System;
using System.Reflection;

// Step 1: Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class ImportantMethodAttribute : Attribute
{
    public string Level { get; set; }

    // Optional parameter with default value
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

// Step 2: Apply attribute to methods
class BusinessLogic
{
    [ImportantMethod]  // Uses default level = "HIGH"
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment...");
    }

    [ImportantMethod("MEDIUM")]
    public void GenerateReport()
    {
        Console.WriteLine("Generating report...");
    }

    public void NormalMethod()
    {
        Console.WriteLine("This is a normal method.");
    }
}

public class ImportantMethodDemo
{
    public static void Main()
    {
        Type type = typeof(BusinessLogic);

        Console.WriteLine("Important Methods:\n");

        // Step 3: Retrieve and print annotated methods
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            ImportantMethodAttribute attr =
                method.GetCustomAttribute<ImportantMethodAttribute>();

            if (attr != null)
            {
                Console.WriteLine($"Method: {method.Name}, Level: {attr.Level}");
            }
        }
    }
}
