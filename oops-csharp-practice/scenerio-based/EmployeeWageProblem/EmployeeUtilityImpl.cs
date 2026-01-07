using System;
using System.Collections.Generic;

public class EmployeeUtilityImpl : IEmployee
{
    List<Employee> employees = new List<Employee>();
    Random random = new Random();

    int WAGE_PER_HOUR = 20;
    int FULL_TIME_HOURS = 8;
    int PART_TIME_HOURS = 8;
    int WORKING_DAYS_PER_MONTH = 20;

    public void AddEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        employees.Add(new Employee(id, name));
        Console.WriteLine("Employee Added Successfully");
    }

    // Existing centralized attendance logic (UNCHANGED)
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

                Console.WriteLine(
                    emp.IsPresent
                    ? "Employee " + emp.Name + " is PRESENT"
                    : "Employee " + emp.Name + " is ABSENT"
                );
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
                        Console.WriteLine("Employee " + emp.Name + " is FULL TIME");
                        break;

                    case 2:
                        hoursWorked = PART_TIME_HOURS;
                        Console.WriteLine("Employee " + emp.Name + " is PART TIME");
                        break;

                    default:
                        Console.WriteLine("Employee " + emp.Name + " is ABSENT");
                        break;
                }

                int dailyWage = hoursWorked * WAGE_PER_HOUR;
                Console.WriteLine("Daily Wage: Rs " + dailyWage);
                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }

    // ✅ UC-5: Monthly Wage Calculation (20 Working Days)
    public void CalculateMonthlyWage()
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (Employee emp in employees)
        {
            if (emp.EmpId == id)
            {
                int totalMonthlyWage = 0;

                for (int day = 1; day <= WORKING_DAYS_PER_MONTH; day++)
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

                    totalMonthlyWage += hoursWorked * WAGE_PER_HOUR;
                }

                Console.WriteLine("Monthly Wage for " + emp.Name +
                    " : Rs " + totalMonthlyWage);
                return;
            }
        }
        Console.WriteLine("Employee Not Found");
    }
}
