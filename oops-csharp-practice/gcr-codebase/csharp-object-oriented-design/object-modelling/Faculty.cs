using System;
using System.Collections.Generic;

// Faculty class (Aggregation: can exist independently)
class Faculty
{
    public string Name { get; set; }
    public string Subject { get; set; }

    public Faculty(string name, string subject)
    {
        Name = name;
        Subject = subject;
    }

    public void Display()
    {
        Console.WriteLine($"Faculty Name: {Name}, Subject: {Subject}");
    }
}

// Department class (Composition: depends on University)
class Department
{
    public string DepartmentName { get; set; }

    public Department(string name)
    {
        DepartmentName = name;
    }

    public void Display()
    {
        Console.WriteLine($"Department: {DepartmentName}");
    }
}

// University class
class University
{
    public string UniversityName { get; set; }
    public List<Department> Departments { get; set; }
    public List<Faculty> Faculties { get; set; }

    public University(string name)
    {
        UniversityName = name;
        Departments = new List<Department>();
        Faculties = new List<Faculty>();
    }

    // Composition: University creates and owns Departments
    public void AddDepartment(string deptName)
    {
        Departments.Add(new Department(deptName));
    }

    // Aggregation: Faculty passed from outside
    public void AddFaculty(Faculty faculty)
    {
        Faculties.Add(faculty);
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"\nUniversity: {UniversityName}");

        Console.WriteLine("Departments:");
        foreach (Department d in Departments)
            d.Display();

        Console.WriteLine("Faculties:");
        foreach (Faculty f in Faculties)
            f.Display();
    }
}

class Program
{
    static void Main()
    {
        // Faculty exists independently (Aggregation)
        Faculty f1 = new Faculty("Dr. Sharma", "Computer Science");
        Faculty f2 = new Faculty("Dr. Mehta", "Mathematics");

        // Creating University
        University uni = new University("Tech University");

        // Composition: Departments created inside University
        uni.AddDepartment("CSE");
        uni.AddDepartment("ECE");

        // Aggregation: Faculty added from outside
        uni.AddFaculty(f1);
        uni.AddFaculty(f2);

        uni.DisplayDetails();

        // Deleting University
        Console.WriteLine("\nDeleting University...");
        uni = null;

        // Faculty still exists
        Console.WriteLine("\nFaculty still exists independently:");
        f1.Display();
        f2.Display();
    }
}
