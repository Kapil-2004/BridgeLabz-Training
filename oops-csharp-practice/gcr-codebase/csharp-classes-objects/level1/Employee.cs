using System;

// Class Definition
public class Employee
{
    // Fields (Attributes)
    private string name;
    private int id;
    private double salary;

    // Constructor
    public Employee(string name, int id, double salary)
    {
        this.name = name;
        this.id = id;
        this.salary = salary;
    }

    // Method to display employee details
    public void DisplayDetails()
    {
        Console.WriteLine("Employee Name : " + name);
        Console.WriteLine("Employee ID   : " + id);
        Console.WriteLine("Salary        : " + salary);
    }

    public static void Main(string[] args)
    {
        // Create Employee objects
        Employee emp1 = new Employee("Rahul", 101, 50000);
        Employee emp2 = new Employee("Anita", 102, 60000);

        // Display employee details
        Console.WriteLine("=== Employee 1 ===");
        emp1.DisplayDetails();

        Console.WriteLine("\n=== Employee 2 ===");
        emp2.DisplayDetails();
    }
}
