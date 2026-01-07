using System;
using System.Collections.Generic;

public class EmployeeUtilityImpl : IEmployee
{
    List<Employee> employees = new List<Employee>();
    Random random = new Random();

    int WAGE_PER_HOUR = 20;
    int FULL_TIME_HOURS = 8;
    int PART_TIME_HOURS = 8;

    int MAX_WORKING_DAYS = 20;
    int MAX_WORKING_HOURS = 100;

    public void AddEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        employees.Add(new Employee(id, name));
        Console.WriteLine("Employee Added Successfully");
    }

    // Attendance logic (UNCHANGED)
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
                Console.WriteLine(emp.IsPresent
                    ? "Employee " + emp.Name + " is PRESENT"
                    : "Employee " + emp.Name + " is ABSENT");
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

                switch (attendanceType)
                {
                    case 1:
                        hoursWorked = FULL_TIME_HOURS;
                        break;
                    case 2:
                        hoursWorked = PART_TIME_HOURS;
                        break;
                    default:
                        hoursWorked = 0;
                        break;
                }

                int dailyWage = hoursWorked * WAGE_PER_HOUR;
                Console.WriteLine("Daily Wage: Rs " + dailyWage);
                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }

    // ✅ UC-6: Wage till max hours OR days reached
    public void CalculateWageTillCondition()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (Employee emp in employees)
        {
            if (emp.EmpId == id)
            {
                int totalHours = 0;
                int totalDays = 0;
                int totalWage = 0;

                while (totalHours < MAX_WORKING_HOURS &&
                       totalDays < MAX_WORKING_DAYS)
                {
                    totalDays++;
                    int attendanceType = MarkAttendance(emp);
                    int hoursWorked = 0;

                    switch (attendanceType)
                    {
                        case 1:
                            hoursWorked = FULL_TIME_HOURS;
                            break;
                        case 2:
                            hoursWorked = PART_TIME_HOURS;
                            break;
                        default:
                            hoursWorked = 0;
                            break;
                    }

                    totalHours += hoursWorked;
                    totalWage += hoursWorked * WAGE_PER_HOUR;
                }

                Console.WriteLine("Employee Name : " + emp.Name);
                Console.WriteLine("Total Working Days : " + totalDays);
                Console.WriteLine("Total Working Hours : " + totalHours);
                Console.WriteLine("Total Wage : Rs " + totalWage);
                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }
}
