using System;

// Base class
class Student
{
    public int rollNumber;      // Public
    protected string name;      // Protected
    private double CGPA;        // Private

    // Constructor
    public Student(int rollNumber, string name, double CGPA)
    {
        this.rollNumber = rollNumber;
        this.name = name;
        this.CGPA = CGPA;
    }

    // Public method to access CGPA
    public double GetCGPA()
    {
        return CGPA;
    }

    // Public method to modify CGPA
    public void SetCGPA(double newCGPA)
    {
        if (newCGPA >= 0 && newCGPA <= 10)
        {
            CGPA = newCGPA;
        }
        else
        {
            Console.WriteLine("Invalid CGPA value!");
        }
    }
}

// Subclass
class PostgraduateStudent : Student
{
    public PostgraduateStudent(int rollNumber, string name, double CGPA)
        : base(rollNumber, name, CGPA)
    {
    }

    // Method using protected member
    public void DisplayPGStudent()
    {
        Console.WriteLine("Roll Number : " + rollNumber);
        Console.WriteLine("Name        : " + name); // Accessing protected member
        Console.WriteLine("CGPA        : " + GetCGPA());
        Console.WriteLine("----------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Roll Number: ");
        int roll = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter CGPA: ");
        double cgpa = Convert.ToDouble(Console.ReadLine());

        PostgraduateStudent pg = new PostgraduateStudent(roll, name, cgpa);

        Console.WriteLine("\nStudent Details:");
        pg.DisplayPGStudent();

        Console.Write("\nEnter new CGPA: ");
        double newCgpa = Convert.ToDouble(Console.ReadLine());

        pg.SetCGPA(newCgpa);

        Console.WriteLine("\nUpdated Student Details:");
        pg.DisplayPGStudent();
    }
}
