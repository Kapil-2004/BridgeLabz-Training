using System;
using System.Reflection;

// Step 1: Define MaxLength attribute
[AttributeUsage(AttributeTargets.Field)]
public class MaxLengthAttribute : Attribute
{
    public int Value { get; }

    public MaxLengthAttribute(int value)
    {
        Value = value;
    }
}

// Step 2: User class with Username field
class User
{
    [MaxLength(10)]
    private string Username;

    public User(string username)
    {
        // Validate using Reflection
        FieldInfo field = typeof(User).GetField(
            "Username",
            BindingFlags.NonPublic | BindingFlags.Instance);

        MaxLengthAttribute attr =
            field.GetCustomAttribute<MaxLengthAttribute>();

        if (attr != null && username.Length > attr.Value)
        {
            throw new ArgumentException(
                $"Username exceeds maximum length of {attr.Value} characters.");
        }

        Username = username;
        Console.WriteLine("User created successfully with username: " + Username);
    }
}

// Step 3: Demo class (same as file name)
public class MaxLengthAttributeDemo
{
    public static void Main()
    {
        try
        {
            User user1 = new User("Alice");        // Valid
            User user2 = new User("VeryLongName"); // Invalid (more than 10 chars)
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Validation Error: " + ex.Message);
        }
    }
}
