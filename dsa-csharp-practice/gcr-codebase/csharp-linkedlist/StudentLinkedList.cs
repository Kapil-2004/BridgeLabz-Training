using System;

class StudentNode
{
    public int roll;
    public string name;
    public int age;
    public string grade;
    public StudentNode next;

    public StudentNode(int roll, string name, int age, string grade)
    {
        this.roll = roll;
        this.name = name;
        this.age = age;
        this.grade = grade;
        next = null;
    }
}

class StudentLinkedList
{
    private StudentNode head;

    // Add at beginning
    public void AddAtBeginning(int roll, string name, int age, string grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);
        newNode.next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int roll, string name, int age, string grade)
    {
        StudentNode newNode = new StudentNode(roll, name, age, grade);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StudentNode temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        temp.next = newNode;
    }

    // Add at specific position (1-based index)
    public void AddAtPosition(int pos, int roll, string name, int age, string grade)
    {
        if (pos <= 1)
        {
            AddAtBeginning(roll, name, age, grade);
            return;
        }

        StudentNode newNode = new StudentNode(roll, name, age, grade);
        StudentNode temp = head;

        for (int i = 1; i < pos - 1 && temp != null; i++)
        {
            temp = temp.next;
        }

        if (temp == null)
        {
            Console.WriteLine("Invalid position!");
            return;
        }

        newNode.next = temp.next;
        temp.next = newNode;
    }

    // Delete by roll number
    public void DeleteByRoll(int roll)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        if (head.roll == roll)
        {
            head = head.next;
            Console.WriteLine("Student deleted.");
            return;
        }

        StudentNode temp = head;
        while (temp.next != null && temp.next.roll != roll)
        {
            temp = temp.next;
        }

        if (temp.next == null)
        {
            Console.WriteLine("Student not found!");
        }
        else
        {
            temp.next = temp.next.next;
            Console.WriteLine("Student deleted.");
        }
    }

    // Search by roll number
    public void SearchByRoll(int roll)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.roll == roll)
            {
                Console.WriteLine($"Roll: {temp.roll}, Name: {temp.name}, Age: {temp.age}, Grade: {temp.grade}");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Student not found!");
    }

    // Update grade
    public void UpdateGrade(int roll, string newGrade)
    {
        StudentNode temp = head;

        while (temp != null)
        {
            if (temp.roll == roll)
            {
                temp.grade = newGrade;
                Console.WriteLine("Grade updated successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Student not found!");
    }

    // Display all records
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No student records.");
            return;
        }

        StudentNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"Roll: {temp.roll}, Name: {temp.name}, Age: {temp.age}, Grade: {temp.grade}");
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentLinkedList list = new StudentLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management ---");
            Console.WriteLine("1. Add at Beginning");
            Console.WriteLine("2. Add at End");
            Console.WriteLine("3. Add at Position");
            Console.WriteLine("4. Delete by Roll Number");
            Console.WriteLine("5. Search by Roll Number");
            Console.WriteLine("6. Update Grade");
            Console.WriteLine("7. Display All");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            int roll, age, pos;
            string name, grade;

            switch (choice)
            {
                case 1:
                    Console.Write("Roll: ");
                    roll = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("Grade: ");
                    grade = Console.ReadLine();
                    list.AddAtBeginning(roll, name, age, grade);
                    break;

                case 2:
                    Console.Write("Roll: ");
                    roll = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("Grade: ");
                    grade = Console.ReadLine();
                    list.AddAtEnd(roll, name, age, grade);
                    break;

                case 3:
                    Console.Write("Position: ");
                    pos = int.Parse(Console.ReadLine());
                    Console.Write("Roll: ");
                    roll = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("Grade: ");
                    grade = Console.ReadLine();
                    list.AddAtPosition(pos, roll, name, age, grade);
                    break;

                case 4:
                    Console.Write("Enter Roll Number to delete: ");
                    roll = int.Parse(Console.ReadLine());
                    list.DeleteByRoll(roll);
                    break;

                case 5:
                    Console.Write("Enter Roll Number to search: ");
                    roll = int.Parse(Console.ReadLine());
                    list.SearchByRoll(roll);
                    break;

                case 6:
                    Console.Write("Enter Roll Number: ");
                    roll = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Grade: ");
                    grade = Console.ReadLine();
                    list.UpdateGrade(roll, grade);
                    break;

                case 7:
                    list.Display();
                    break;
            }

        } while (choice != 0);
    }
}
