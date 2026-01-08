using System;
using System.Collections.Generic;

// Course class
class Course
{
    public string CourseName { get; set; }
    public Professor AssignedProfessor { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public Course(string name)
    {
        CourseName = name;
        EnrolledStudents = new List<Student>();
    }

    // Communication: assigning professor to course
    public void AssignProfessor(Professor professor)
    {
        AssignedProfessor = professor;
        Console.WriteLine($"Professor {professor.Name} assigned to course {CourseName}");
    }
}

// Student class
class Student
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; }

    public Student(string name)
    {
        Name = name;
        Courses = new List<Course>();
    }

    // Communication: student enrolling in a course
    public void EnrollCourse(Course course)
    {
        Courses.Add(course);
        course.EnrolledStudents.Add(this);
        Console.WriteLine($"Student {Name} enrolled in course {course.CourseName}");
    }
}

// Professor class
class Professor
{
    public string Name { get; set; }
    public List<Course> TeachingCourses { get; set; }

    public Professor(string name)
    {
        Name = name;
        TeachingCourses = new List<Course>();
    }
}

class Program
{
    static void Main()
    {
        // Creating courses
        Course c1 = new Course("Data Structures");
        Course c2 = new Course("Operating Systems");

        // Creating students
        Student s1 = new Student("Rahul");
        Student s2 = new Student("Anita");

        // Creating professors
        Professor p1 = new Professor("Dr. Sharma");

        // Assign professor to course
        c1.AssignProfessor(p1);
        c2.AssignProfessor(p1);

        // Students enrolling in courses
        s1.EnrollCourse(c1);
        s2.EnrollCourse(c1);
        s1.EnrollCourse(c2);

        Console.WriteLine("\nUniversity Management System simulation completed.");
    }
}
