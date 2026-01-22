using System;
using System.IO;

class StudentBinaryDataStore
{
    static void Main()
    {
        string filePath = "students.dat";

        try
        {
            // --------- Write Student Data to Binary File ---------
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                Console.Write("Enter Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter GPA: ");
                double gpa = double.Parse(Console.ReadLine());

                // Write primitive data
                writer.Write(rollNumber);
                writer.Write(name);
                writer.Write(gpa);

                Console.WriteLine("\nStudent details stored successfully in binary file.");
            }

            // --------- Read Student Data from Binary File ---------
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int rollNumber = reader.ReadInt32();
                string name = reader.ReadString();
                double gpa = reader.ReadDouble();

                Console.WriteLine("\nRetrieved Student Details:");
                Console.WriteLine("Roll Number: " + rollNumber);
                Console.WriteLine("Name       : " + name);
                Console.WriteLine("GPA        : " + gpa);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input format:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
