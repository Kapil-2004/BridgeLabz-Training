using System;

class Employee
{
    // static variable (shared by all employees)
    public static string CompanyName = "Tech Solutions Pvt Ltd";
    private static int totalEmployees = 0;

    // readonly variable
    public readonly int Id;

    // instance variables
    public string Name;
    public string Designation;

    // constructor using 'this'
    public Employee(string Name, int Id, string Designation)
    {
        this.Name = Name;
        this.Id = Id;              // readonly value assigned once
        this.Designation = Designation;

        totalEmployees++;
    }

    // static method
    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    // method to display employee details
    public void DisplayDetails()
    {
        Console.WriteLine("Company Name : " + CompanyName);
        Console.WriteLine("Employee Name: " + Name);
        Console.WriteLine("Employee ID  : " + Id);
        Console.WriteLine("Designation  : " + Designation);
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee("Amit", 201, "Software Engineer");
        Employee emp2 = new Employee("Neha", 202, "QA Analyst");

        // is operator usage
        if (emp1 is Employee)
        {
            Console.WriteLine("\nEmployee 1 Details:");
            emp1.DisplayDetails();
        }

        if (emp2 is Employee)
        {
            Console.WriteLine("\nEmployee 2 Details:");
            emp2.DisplayDetails();
        }

        Console.WriteLine();
        Employee.DisplayTotalEmployees();
    }
}
