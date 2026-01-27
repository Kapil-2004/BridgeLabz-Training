using System;
using System.Reflection;

public class DynamicObjectCreation
{
    class Student
    {
        public string Name;
        public int Age;

        public Student() { }

        public override string ToString() => $"Name: {Name}, Age: {Age}";
    }

    public static void Main()
    {
        Type type = typeof(Student);

        // Create object dynamically without new keyword
        object obj = Activator.CreateInstance(type);

        // Set fields using reflection
        type.GetField("Name").SetValue(obj, "John");
        type.GetField("Age").SetValue(obj, 20);

        Console.WriteLine("Student Details: " + obj);
    }
}
