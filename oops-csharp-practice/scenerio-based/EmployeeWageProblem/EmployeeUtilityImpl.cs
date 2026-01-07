using System;
using System.Collections.Generic;

public class EmployeeUtilityImpl : IEmployee
{
    List<Employee> employees = new List<Employee>();
    Random random = new Random();

    public void AddEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Employee emp = new Employee(id, name);
        employees.Add(emp);

        Console.WriteLine("Employee Added Successfully\n");
    }

    public void CheckEmployeeStatus()
{
    Console.Write("Enter Employee ID: ");
    int id = int.Parse(Console.ReadLine());

    foreach (Employee emp in employees)
    {
        if (emp.EmpId == id)
        {
            int attendance = random.Next(0, 2);

            if (attendance == 1)
            {
                emp.IsPresent = true;
                Console.WriteLine("Employee " + emp.Name + " is PRESENT");
            }
            else
            {
                emp.IsPresent = false;
                Console.WriteLine("Employee " + emp.Name + " is ABSENT");
            }
            return;
        }
    }

    Console.WriteLine("Employee Not Found");
}
}
