using System;
using System.IO;

class SearchEmployee
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        Console.Write("Enter employee name: ");
        string searchName = Console.ReadLine();

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');

            if (data[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Department: " + data[2]);
                Console.WriteLine("Salary: " + data[3]);
                return;
            }
        }

        Console.WriteLine("Employee not found.");
    }
}
