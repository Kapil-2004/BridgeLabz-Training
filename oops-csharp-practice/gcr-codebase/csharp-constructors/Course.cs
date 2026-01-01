using System;

class Course
{
    // Instance variables
    private string courseName;
    private int duration;   // in months
    private double fee;

    // Class variable (shared)
    private static string instituteName = "ABC Institute";

    // Constructor
    public Course(string courseName, int duration, double fee)
    {
        this.courseName = courseName;
        this.duration = duration;
        this.fee = fee;
    }

    // Instance method
    public void DisplayCourseDetails()
    {
        Console.WriteLine("Course Name    : " + courseName);
        Console.WriteLine("Duration       : " + duration + " months");
        Console.WriteLine("Fee            : Rs. " + fee);
        Console.WriteLine("Institute Name : " + instituteName);
        Console.WriteLine("-------------------------------");
    }

    // Class (static) method
    public static void UpdateInstituteName(string newInstituteName)
    {
        instituteName = newInstituteName;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter Institute Name: ");
        string instName = Console.ReadLine();
        Course.UpdateInstituteName(instName);

        Console.Write("Enter number of courses: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"\nEnter details for Course {i}");

            Console.Write("Course Name: ");
            string name = Console.ReadLine();

            Console.Write("Duration (in months): ");
            int duration = Convert.ToInt32(Console.ReadLine());

            Console.Write("Fee: ");
            double fee = Convert.ToDouble(Console.ReadLine());

            Course c = new Course(name, duration, fee);
            c.DisplayCourseDetails();
        }
    }
}
