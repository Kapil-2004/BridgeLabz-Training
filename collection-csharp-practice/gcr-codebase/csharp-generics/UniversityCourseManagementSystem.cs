using System;
using System.Collections.Generic;

//
// Abstract base class for course types
//
public abstract class CourseType
{
    public string EvaluationType { get; set; }

    protected CourseType(string evaluationType)
    {
        EvaluationType = evaluationType;
    }

    public abstract void Evaluate();
}

//
// Concrete course types
//
public class ExamCourse : CourseType
{
    public ExamCourse() : base("Written Exam") { }

    public override void Evaluate()
    {
        Console.WriteLine("Evaluation through final written exam.");
    }
}

public class AssignmentCourse : CourseType
{
    public AssignmentCourse() : base("Assignments") { }

    public override void Evaluate()
    {
        Console.WriteLine("Evaluation through assignments and projects.");
    }
}

//
// Generic Course class with constraint
//
public class Course<T> where T : CourseType
{
    public string CourseName { get; set; }
    public string Department { get; set; }
    public T CourseEvaluation { get; set; }

    public Course(string courseName, string department, T courseEvaluation)
    {
        CourseName = courseName;
        Department = department;
        CourseEvaluation = courseEvaluation;
    }

    public void DisplayCourse()
    {
        Console.WriteLine(
            $"Course: {CourseName}, Department: {Department}, Evaluation: {CourseEvaluation.EvaluationType}"
        );
        CourseEvaluation.Evaluate();
    }
}

//
// Main Program
//
class UniversityCourseManagementSystem
{
    static void Main()
    {
        // Exam-based courses
        List<Course<ExamCourse>> examCourses = new List<Course<ExamCourse>>
        {
            new Course<ExamCourse>(
                "Data Structures",
                "Computer Science",
                new ExamCourse()
            ),
            new Course<ExamCourse>(
                "Operating Systems",
                "Computer Science",
                new ExamCourse()
            )
        };

        // Assignment-based courses
        List<Course<AssignmentCourse>> assignmentCourses = new List<Course<AssignmentCourse>>
        {
            new Course<AssignmentCourse>(
                "Software Engineering",
                "Information Technology",
                new AssignmentCourse()
            )
        };

        Console.WriteLine("=== Exam Based Courses ===");
        foreach (var course in examCourses)
        {
            course.DisplayCourse();
            Console.WriteLine();
        }

        Console.WriteLine("=== Assignment Based Courses ===");
        foreach (var course in assignmentCourses)
        {
            course.DisplayCourse();
            Console.WriteLine();
        }

        //
        // Variance example (read-only)
        //
        IEnumerable<CourseType> evaluations =
            new List<CourseType> { new ExamCourse(), new AssignmentCourse() };

        Console.WriteLine("=== Variance Example ===");
        foreach (var eval in evaluations)
        {
            eval.Evaluate();
        }
    }
}
