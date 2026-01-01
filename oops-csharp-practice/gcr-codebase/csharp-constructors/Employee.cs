using System;

// Base class
class Employee
{
    public int employeeID;        // Public
    protected string department;  // Protected
    private double salary;        // Private

    // Constructor
    public Employee(int id, string dept, double salary)
    {
        this.employeeID = id;
        this.department = dept;
        this.salary = salary;
    }

    // Public method to update salary
    public void UpdateSalary(double newSalary)
    {
        if (newSalary > 0)
        {
            salary = newSalary;
            Console.WriteLine("Salary updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid salary amount.");
        }
    }

    // Public method to get salary
    public double GetSalary()
    {
        return salary;
    }
}

// Derived class
class Manager : Employee
{
    public Manager(int id, string dept, double salary)
        : base(id, dept, salary)
    {
    }

    // Access public and protected members
    public void DisplayManagerDetails()
    {
        Console.WriteLine("Employee ID : " + employeeID);   // Public
        Console.WriteLine("Department  : " + department);   // Protected
        Console.WriteLine("Salary      : " + GetSalary());  // Private via method
        Console.WriteLine("----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Manager manager = new Manager(id, dept, salary);

        manager.DisplayManagerDetails();

        Console.Write("\nEnter New Salary: ");
        double newSalary = Convert.ToDouble(Console.ReadLine());
        manager.UpdateSalary(newSalary);

        Console.WriteLine("\nUpdated Employee Details:");
        manager.DisplayManagerDetails();
    }
}
