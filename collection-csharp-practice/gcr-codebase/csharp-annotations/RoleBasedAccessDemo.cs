using System;
using System.Reflection;

// Step 1: Define RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method)]
public class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

// Step 2: Create a service class with restricted methods
class AdminService
{
    [RoleAllowed("ADMIN")]
    public void DeleteAllUsers()
    {
        Console.WriteLine("All users deleted successfully.");
    }

    public void ViewUsers()
    {
        Console.WriteLine("Displaying all users.");
    }
}

// Step 3: Demo class (same as file name)
public class RoleBasedAccessDemo
{
    // Simulate current user role
    static string currentUserRole = "USER"; // Change to "ADMIN" to allow access

    public static void Main()
    {
        AdminService service = new AdminService();
        Type type = typeof(AdminService);

        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
        {
            RoleAllowedAttribute attr =
                method.GetCustomAttribute<RoleAllowedAttribute>();

            if (attr != null)
            {
                Console.WriteLine($"Trying to execute: {method.Name}");
                Console.WriteLine($"Required Role: {attr.Role}");
                Console.WriteLine($"Current Role : {currentUserRole}");

                if (currentUserRole == attr.Role)
                {
                    method.Invoke(service, null);
                }
                else
                {
                    Console.WriteLine("Access Denied!");
                }

                Console.WriteLine();
            }
        }
    }
}
