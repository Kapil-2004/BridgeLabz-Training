using System;
using System.Collections.Generic;
using System.Reflection;

public class CustomObjectMapper
{
    public class Person
    {
        public string Name;
        public int Age;
        public string City;
    }

    public static T ToObject<T>(Type clazz, Dictionary<string, object> properties) where T : new()
    {
        T obj = (T)Activator.CreateInstance(clazz);

        foreach (var prop in properties)
        {
            FieldInfo field = clazz.GetField(prop.Key, BindingFlags.Public | BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(obj, Convert.ChangeType(prop.Value, field.FieldType));
            }
        }

        return obj;
    }

    public static void Main()
    {
        var props = new Dictionary<string, object>
        {
            { "Name", "Alice" },
            { "Age", 28 },
            { "City", "New York" }
        };

        Person person = ToObject<Person>(typeof(Person), props);

        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, City: {person.City}");
    }
}
