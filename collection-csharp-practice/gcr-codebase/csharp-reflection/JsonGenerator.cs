using System;
using System.Reflection;

public class JsonGenerator
{
    public class Student
    {
        public string Name = "John";
        public int Age = 20;
        public string Course = "C#";
    }

    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        string json = "{ ";
        foreach (var field in fields)
        {
            object value = field.GetValue(obj);
            json += $"\"{field.Name}\": \"{value}\", ";
        }
        json = json.TrimEnd(',', ' ') + " }";
        return json;
    }

    public static void Main()
    {
        Student student = new Student();
        string json = ToJson(student);
        Console.WriteLine(json);
    }
}
