using System;
using System.Reflection;

// Step 1: Define the Todo attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class TodoAttribute : Attribute
{
    public string Task { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; }

    // Constructor with default Priority = "MEDIUM"
    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// Step 2: Apply the attribute to multiple methods
class ProjectFeatures
{
    [Todo("Implement login feature", "Alice", "HIGH")]
    public void Login()
    {
        Console.WriteLine("Login feature placeholder.");
    }

    [Todo("Add payment gateway", "Bob")]
    public void Payment()
    {
        Console.WriteLine("Payment feature placeholder.");
    }

    [Todo("Improve UI design", "Charlie", "LOW")]
    public void UI()
    {
        Console.WriteLine("UI feature placeholder.");
    }

    public void CompletedFeature()
    {
        Console.WriteLine("This feature is already complete.");
    }
}

// Step 3: Retrieve and print all pending tasks
public class TodoAttributeDemo
{
    public static void Main()
    {
        Type type = typeof(ProjectFeatures);

        Console.WriteLine("Pending Tasks:\n");

        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            TodoAttribute[] todos =
                (TodoAttribute[])method.GetCustomAttributes(typeof(TodoAttribute), false);

            foreach (TodoAttribute todo in todos)
            {
                Console.WriteLine($"Method     : {method.Name}");
                Console.WriteLine($"Task       : {todo.Task}");
                Console.WriteLine($"Assigned To: {todo.AssignedTo}");
                Console.WriteLine($"Priority   : {todo.Priority}");
                Console.WriteLine();
            }
        }
    }
}
