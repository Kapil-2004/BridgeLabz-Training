using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        // Skip header row
        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');

            int id = int.Parse(data[0]);
            string name = data[1];
            int age = int.Parse(data[2]);
            int marks = int.Parse(data[3]);

            Console.WriteLine("Student Details");
            Console.WriteLine($"ID    : {id}");
            Console.WriteLine($"Name  : {name}");
            Console.WriteLine($"Age   : {age}");
            Console.WriteLine($"Marks : {marks}");
            Console.WriteLine("----------------------");
        }
    }
}
