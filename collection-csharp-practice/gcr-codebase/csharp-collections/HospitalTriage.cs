using System;
using System.Collections.Generic;

class HospitalTriage
{
    static void Main()
    {
        // Create a priority queue (higher severity = higher priority)
        PriorityQueue<Patient, int> triageQueue = new PriorityQueue<Patient, int>();

        // Add patients (Name, Severity)
        triageQueue.Enqueue(new Patient("John", 3), -3);
        triageQueue.Enqueue(new Patient("Alice", 5), -5);
        triageQueue.Enqueue(new Patient("Bob", 2), -2);

        Console.WriteLine("Treatment Order:");

        // Treat patients based on severity
        while (triageQueue.Count > 0)
        {
            Patient p = triageQueue.Dequeue();
            Console.WriteLine(p.Name);
        }
    }
}

// Patient class
class Patient
{
    public string Name { get; set; }
    public int Severity { get; set; }

    public Patient(string name, int severity)
    {
        Name = name;
        Severity = severity;
    }
}
