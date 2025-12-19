using System;

class Income
{
    static void Main()
    {
        double salary, bonus;

        // Taking input
        Console.Write("Enter salary: ");
        salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter bonus: ");
        bonus = Convert.ToDouble(Console.ReadLine());

        // Calculation
        double totalIncome = salary + bonus;

        // Output
        Console.WriteLine(
            "The salary is INR " + salary +
            " and bonus is INR " + bonus +
            ". Hence Total Income is INR " + totalIncome
        );
    }
}
