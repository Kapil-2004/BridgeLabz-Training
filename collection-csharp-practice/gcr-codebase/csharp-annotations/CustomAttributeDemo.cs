using System;
using System.Reflection;

// Step 1: Define custom attribute
[AttributeUsage(AttributeTargets.Method)]
public class TaskInfoAttribute : Attribute
{
    public int Priority { get; set; }
    public string AssignedTo { get; set; }

    public TaskInfoAttribute(int priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

// Step 2: Apply attribute to a method
class TaskManager
{
    [TaskInfo(1, "Alice")]
    public void CompleteReport()
    {
        Console.WriteLine("Report completed.");
    }
}

public class CustomAttributeDemo
{
    public static void Main()
    {
        Type type = typeof(TaskManager);

        // Step 3: Retrieve attribute using Reflection
        MethodInfo method = type.GetMethod("CompleteReport");

        TaskInfoAttribute attr =
            method.GetCustomAttribute<TaskInfoAttribute>();

        if (attr != null)
        {
            Console.WriteLine("Task Information:");
            Console.WriteLine("Priority: " + attr.Priority);
            Console.WriteLine("Assigned To: " + attr.AssignedTo);
        }
        else
        {
            Console.WriteLine("No TaskInfo attribute found.");
        }
    }
}

