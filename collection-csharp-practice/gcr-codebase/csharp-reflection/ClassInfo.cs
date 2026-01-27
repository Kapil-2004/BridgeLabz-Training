using System;
using System.Reflection;

public class ClassInfo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter full class name (e.g., System.String):");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);
        if (type == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        Console.WriteLine($"\nClass: {type.FullName}");

        Console.WriteLine("\nConstructors:");
        foreach (var ctor in type.GetConstructors())
        {
            Console.WriteLine(ctor);
        }

        Console.WriteLine("\nMethods:");
        foreach (var method in type.GetMethods())
        {
            Console.WriteLine(method);
        }

        Console.WriteLine("\nFields:");
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        {
            Console.WriteLine(field);
        }
    }
}
