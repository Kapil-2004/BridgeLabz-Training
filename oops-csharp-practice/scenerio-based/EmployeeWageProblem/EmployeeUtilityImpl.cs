using System;
using System.Collections.Generic;

public class EmployeeUtilityImpl : IEmployee
{
    List<Employee> employees = new List<Employee>();
    Random random = new Random();

    int WAGE_PER_HOUR = 20;
    int FULL_TIME_HOURS = 8;
    int PART_TIME_HOURS = 8;   // As assumed

    public void AddEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        employees.Add(new Employee(id, name));
        Console.WriteLine("Employee Added Successfully");
    }

    // Attendance marked ONCE and stored
    private int MarkAttendance(Employee emp)
    {
        int attendance = random.Next(0, 3); // 0-Absent, 1-Full, 2-Part

        if (attendance == 0)
            emp.IsPresent = false;
        else
            emp.IsPresent = true;

        return attendance;
    }

    public void CheckEmployeeStatus()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (Employee emp in employees)
        {
            if (emp.EmpId == id)
            {
                MarkAttendance(emp);

                if (emp.IsPresent)
                    Console.WriteLine("Employee " + emp.Name + " is PRESENT");
                else
                    Console.WriteLine("Employee " + emp.Name + " is ABSENT");

                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }

    public void CalculateDailyWage()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (Employee emp in employees)
        {
            if (emp.EmpId == id)
            {
                int attendanceType = MarkAttendance(emp);
                int hoursWorked = 0;

                if (attendanceType == 1)
                {
                    hoursWorked = FULL_TIME_HOURS;
                    Console.WriteLine("Employee " + emp.Name + " is FULL TIME");
                }
                else if (attendanceType == 2)
                {
                    hoursWorked = PART_TIME_HOURS;
                    Console.WriteLine("Employee " + emp.Name + " is PART TIME");
                }
                else
                {
                    Console.WriteLine("Employee " + emp.Name + " is ABSENT");
                }

                int dailyWage = hoursWorked * WAGE_PER_HOUR;
                Console.WriteLine("Daily Wage: Rs " + dailyWage);
                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }
}
