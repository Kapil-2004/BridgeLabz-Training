using System;

class ZaraBonus
{
    static void Main()
    {
        double[] salary = new double[10];
        double[] years = new double[10];
        double[] bonus = new double[10];
        double[] newSalary = new double[10];

        double totalBonus = 0.0;
        double totalOldSalary = 0.0;
        double totalNewSalary = 0.0;

        int i = 0;
        while (i < 10)
        {
            double sal = Convert.ToDouble(Console.ReadLine());
            double yrs = Convert.ToDouble(Console.ReadLine());
            salary[i] = sal;
            years[i] = yrs;
            i++;
        }

        // Calculation loop
        for (i = 0; i < 10; i++)
        {
            if (years[i] > 5)
            {
                bonus[i] = salary[i] * 0.05;
            }
            else
            {
                bonus[i] = salary[i] * 0.02;
            }

            newSalary[i] = salary[i] + bonus[i];

            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];
        }

        Console.WriteLine("Total Old Salary  : INR " + totalOldSalary);
        Console.WriteLine("Total Bonus Paid  : INR " + totalBonus);
        Console.WriteLine("Total New Salary  : INR " + totalNewSalary);
    }
}
