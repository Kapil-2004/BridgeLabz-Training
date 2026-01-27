using System;
using System.Reflection;

// Define custom attribute
[AttributeUsage(AttributeTargets.Class)]
class AuthorAttribute : Attribute
{
    public string Name { get; }
    public AuthorAttribute(string name) => Name = name;
}

// Apply attribute to a class
[Author("John Doe")]
class SampleClass
{
}

public class RetrieveAttributes
{
    public static void Main()
    {
        Type type = typeof(SampleClass);

        object[] attrs = type.GetCustomAttributes(typeof(AuthorAttribute), false);

        if (attrs.Length > 0)
        {
            AuthorAttribute author = (AuthorAttribute)attrs[0];
            Console.WriteLine($"Author Name: {author.Name}");
        }
        else
        {
            Console.WriteLine("No Author attribute found.");
        }
    }
}
