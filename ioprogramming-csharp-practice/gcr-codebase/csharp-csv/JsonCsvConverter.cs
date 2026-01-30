using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}

class JsonCsvConverter
{
    static void Main()
    {
        string jsonFile = "students.json";
        string csvFile = "students.csv";

        // --- JSON to CSV ---
        string jsonData = File.ReadAllText(jsonFile);
        List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonData);

        using (StreamWriter sw = new StreamWriter(csvFile))
        {
            sw.WriteLine("ID,Name,Age,Marks"); // header
            foreach (var s in students)
            {
                sw.WriteLine($"{s.Id},{s.Name},{s.Age},{s.Marks}");
            }
        }

        Console.WriteLine("JSON converted to CSV successfully.");

        // --- CSV to JSON ---
        var csvLines = File.ReadAllLines(csvFile);
        List<Student> studentsFromCsv = new List<Student>();

        for (int i = 1; i < csvLines.Length; i++) // skip header
        {
            var data = csvLines[i].Split(',');
            Student s = new Student();
            s.Id = int.Parse(data[0]);
            s.Name = data[1];
            s.Age = int.Parse(data[2]);
            s.Marks = int.Parse(data[3]);
            studentsFromCsv.Add(s);
        }

        string jsonOutput = JsonSerializer.Serialize(studentsFromCsv, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students_from_csv.json", jsonOutput);

        Console.WriteLine("CSV converted back to JSON successfully.");
    }
}
