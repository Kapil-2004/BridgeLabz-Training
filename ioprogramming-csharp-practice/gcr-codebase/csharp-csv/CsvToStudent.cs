using System;
using System.IO;
using System.Collections.Generic;

class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;
}

class CsvToStudent
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        List<Student> students = new List<Student>();

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            var data = lines[i].Split(',');

            Student s = new Student();
            s.Id = int.Parse(data[0]);
            s.Name = data[1];
            s.Age = int.Parse(data[2]);
            s.Marks = int.Parse(data[3]);

            students.Add(s);
        }

        foreach (Student s in students)
        {
            Console.WriteLine(
                s.Id + " " + s.Name + " " + s.Age + " " + s.Marks
            );
        }
    }
}
