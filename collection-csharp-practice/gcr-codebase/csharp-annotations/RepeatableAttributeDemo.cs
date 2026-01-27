using System;
using System.Reflection;

// Step 1: Define repeatable attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
    public string Description { get; set; }

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// Step 2: Apply attribute multiple times on a method
class IssueTracker
{
    [BugReport("NullReferenceException occurs on login")]
    [BugReport("UI freezes when clicking submit")]
    public void SubmitForm()
    {
        Console.WriteLine("Form submitted.");
    }
}

public class RepeatableAttributeDemo
{
    public static void Main()
    {
        Type type = typeof(IssueTracker);

        MethodInfo method = type.GetMethod("SubmitForm");

        // Step 3: Retrieve all BugReport attributes
        BugReportAttribute[] bugReports =
            (BugReportAttribute[])method.GetCustomAttributes(typeof(BugReportAttribute), false);

        Console.WriteLine("Bug Reports for SubmitForm():");

        foreach (var bug in bugReports)
        {
            Console.WriteLine("- " + bug.Description);
        }
    }
}
