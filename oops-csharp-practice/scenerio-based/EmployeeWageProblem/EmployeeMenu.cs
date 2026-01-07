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
            Console.WriteLine("3. Calculate Daily Wage");
            Console.WriteLine("4. Exit");
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
                    emp.CalculateDailyWage();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
