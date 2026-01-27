using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "OLD_KEY_123";
}

public class StaticFieldAccess
{
    public static void Main()
    {
        Type type = typeof(Configuration);

        FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        Console.WriteLine("Original API_KEY: " + field.GetValue(null));

        // Modify the static field
        field.SetValue(null, "NEW_KEY_456");
        Console.WriteLine("Modified API_KEY: " + field.GetValue(null));
    }
}
