using System;
using System.Reflection;
using System.Text;

// Step 1: Define JsonField attribute
[AttributeUsage(AttributeTargets.Field)]
public class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

// Step 2: User class with JsonField attributes
class User
{
    [JsonField(Name = "user_name")]
    public string Username;

    [JsonField(Name = "user_age")]
    public int Age;

    [JsonField(Name = "user_email")]
    public string Email;

    public User(string username, int age, string email)
    {
        Username = username;
        Age = age;
        Email = email;
    }
}

// Step 3: Demo class (same as file name)
public class JsonFieldDemo
{
    public static void Main()
    {
        User user = new User("alice", 25, "alice@example.com");

        string json = ToJson(user);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
    }

    // Convert object to JSON-like string using Reflection
    public static string ToJson(object obj)
    {
        Type type = obj.GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.Append("{\n");

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];
            JsonFieldAttribute attr =
                field.GetCustomAttribute<JsonFieldAttribute>();

            if (attr != null)
            {
                string jsonKey = attr.Name;
                object value = field.GetValue(obj);

                string jsonValue =
                    value is string ? $"\"{value}\"" : value.ToString();

                sb.Append($"  \"{jsonKey}\": {jsonValue}");

                if (i < fields.Length - 1)
                    sb.Append(",");

                sb.Append("\n");
            }
        }

        sb.Append("}");
        return sb.ToString();
    }
}
