using System;

class EmployeeBonus
{
    // b. Generate salary and years of service
    public static int[,] GenerateEmployeeData(int employeeCount)
    {
        int[,] employeeData = new int[employeeCount, 2];

        for (int i = 0; i < employeeCount; i++)
        {
            int salary = (int)(Math.Random() * 90000) + 10000; // 5-digit salary
            int yearsOfService = (int)(Math.Random() * 10) + 1;

            employeeData[i, 0] = salary;
            employeeData[i, 1] = yearsOfService;
        }

        return employeeData;
    }

    // c. Calculate bonus and new salary
    public static double[,] CalculateBonusAndNewSalary(int[,] employeeData)
    {
        int count = employeeData.GetLength(0);
        double[,] updatedData = new double[count, 2];

        for (int i = 0; i < count; i++)
        {
            int salary = employeeData[i, 0];
            int years = employeeData[i, 1];

            double bonusRate = years > 5 ? 0.05 : 0.02;
            double bonus = salary * bonusRate;
            double newSalary = salary + bonus;

            updatedData[i, 0] = newSalary;
            updatedData[i, 1] = bonus;
        }

        return updatedData;
    }

    // d. Calculate totals and display
    public static void DisplaySummary(int[,] oldData, double[,] newData)
    {
        double totalOldSalary = 0;
        double totalNewSalary = 0;
        double totalBonus = 0;

        Console.WriteLine("Emp\tOldSalary\tYears\tBonus\t\tNewSalary");

        for (int i = 0; i < oldData.GetLength(0); i++)
        {
            int oldSalary = oldData[i, 0];
            int years = oldData[i, 1];
            double bonus = newData[i, 1];
            double newSalary = newData[i, 0];

            totalOldSalary += oldSalary;
            totalNewSalary += newSalary;
            totalBonus += bonus;

            Console.WriteLine(
                (i + 1) + "\t" +
                oldSalary + "\t\t" +
                years + "\t" +
                bonus + "\t" +
                newSalary
            );
        }

        Console.WriteLine("\nTotal Old Salary: " + totalOldSalary);
        Console.WriteLine("Total Bonus Paid: " + totalBonus);
        Console.WriteLine("Total New Salary: " + totalNewSalary);
    }

    static void Main()
    {
        int employeeCount = 10;

        int[,] employeeData = GenerateEmployeeData(employeeCount);
        double[,] updatedData = CalculateBonusAndNewSalary(employeeData);

        DisplaySummary(employeeData, updatedData);
    }
}
