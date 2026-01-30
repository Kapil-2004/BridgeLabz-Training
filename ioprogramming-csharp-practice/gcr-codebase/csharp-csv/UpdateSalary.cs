using System;
using System.IO;

class UpdateSalary
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        string[] updatedLines = new string[lines.Length];
        updatedLines[0] = lines[0]; // header

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');

            if (data[2] == "IT")
            {
                int salary = int.Parse(data[3]);
                salary = salary + (salary * 10 / 100);
                data[3] = salary.ToString();
            }

            updatedLines[i] = string.Join(",", data);
        }

        File.WriteAllLines("updated_employees.csv", updatedLines);

        Console.WriteLine("Updated CSV file created successfully.");
    }
}
