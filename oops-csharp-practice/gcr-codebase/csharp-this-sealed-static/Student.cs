using System;

class Student
{
    // static variable (shared across all students)
    public static string UniversityName = "National Institute of Technology";
    private static int totalStudents = 0;

    // readonly variable
    public readonly int RollNumber;

    // instance variables
    public string Name;
    public char Grade;

    // constructor using 'this'
    public Student(string Name, int RollNumber, char Grade)
    {
        this.Name = Name;
        this.RollNumber = RollNumber;   // readonly assigned once
        this.Grade = Grade;

        totalStudents++;
    }

    // static method
    public static void DisplayTotalStudents()
    {
        Console.WriteLine("Total Students Enrolled: " + totalStudents);
    }

    // method to update grade
    public void UpdateGrade(char newGrade)
    {
        Grade = newGrade;
    }

    // method to display student details
    public void DisplayDetails()
    {
        Console.WriteLine("University Name: " + UniversityName);
        Console.WriteLine("Student Name   : " + Name);
        Console.WriteLine("Roll Number    : " + RollNumber);
        Console.WriteLine("Grade          : " + Grade);
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student("Rohit", 301, 'A');
        Student s2 = new Student("Sneha", 302, 'B');

        // is operator usage
        if (s1 is Student)
        {
            Console.WriteLine("\nStudent 1 Details:");
            s1.DisplayDetails();

            // updating grade after validation
            s1.UpdateGrade('A');
        }

        if (s2 is Student)
        {
            Console.WriteLine("\nStudent 2 Details:");
            s2.DisplayDetails();
        }

        Console.WriteLine();
        Student.DisplayTotalStudents();
    }
}
