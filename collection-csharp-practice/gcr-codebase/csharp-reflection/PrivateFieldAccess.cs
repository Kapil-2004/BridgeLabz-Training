using System;
using System.Reflection;

public class PrivateFieldAccess
{
    class Person
    {
        private int age = 25;
    }

    public static void Main()
    {
        Person person = new Person();

        FieldInfo field = typeof(Person).GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

        // Get current value
        Console.WriteLine("Original age: " + field.GetValue(person));

        // Modify value
        field.SetValue(person, 35);
        Console.WriteLine("Modified age: " + field.GetValue(person));
    }
}
