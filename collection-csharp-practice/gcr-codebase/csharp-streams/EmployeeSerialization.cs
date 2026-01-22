using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary}";
    }
}

class EmployeeSerialization
{
    static string filePath = "employees.json";

    static void Main()
    {
        try
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("How many employees do you want to enter? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\nEnter details for employee " + (i + 1));

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    Id = id,
                    Name = name,
                    Department = department,
                    Salary = salary
                });
            }

            // --------- Serialize to File ---------
            SerializeEmployees(employees);
            Console.WriteLine("\nEmployees serialized and saved to file successfully.");

            // --------- Deserialize from File ---------
            List<Employee> loadedEmployees = DeserializeEmployees();
            Console.WriteLine("\nEmployees loaded from file:");

            foreach (Employee emp in loadedEmployees)
            {
                Console.WriteLine(emp);
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

    static void SerializeEmployees(List<Employee> employees)
    {
        string jsonData = JsonSerializer.Serialize(employees, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, jsonData);
    }

    static List<Employee> DeserializeEmployees()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Employee data file not found.");
            return new List<Employee>();
        }

        string jsonData = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Employee>>(jsonData);
    }
}
