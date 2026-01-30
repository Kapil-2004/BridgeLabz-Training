using System;
using System.IO;

class SortBySalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        // Bubble sort (excluding header)
        for (int i = 1; i < lines.Length - 1; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                int salary1 = int.Parse(lines[i].Split(',')[3]);
                int salary2 = int.Parse(lines[j].Split(',')[3]);

                if (salary2 > salary1)
                {
                    string temp = lines[i];
                    lines[i] = lines[j];
                    lines[j] = temp;
                }
            }
        }

        Console.WriteLine("Top 5 Highest Paid Employees:");

        for (int i = 1; i <= 5 && i < lines.Length; i++)
        {
            Console.WriteLine(lines[i]);
        }
    }
}
