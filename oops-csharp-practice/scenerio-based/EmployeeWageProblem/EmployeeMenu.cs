using System;

public class EmployeeMenu
{
    public static void ShowMenu(IEmployee emp)
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Wage System ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Check Employee Attendance");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    emp.AddEmployee();
                    break;
                case 2:
                    emp.CheckEmployeeStatus();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
