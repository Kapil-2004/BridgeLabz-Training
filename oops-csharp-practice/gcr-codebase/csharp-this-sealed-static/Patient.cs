using System;

class Patient
{
    // static variable (shared among all patients)
    public static string HospitalName = "City Care Hospital";
    private static int totalPatients = 0;

    // readonly variable
    public readonly int PatientID;

    // instance variables
    public string Name;
    public int Age;
    public string Ailment;

    // constructor using 'this'
    public Patient(string Name, int Age, int PatientID, string Ailment)
    {
        this.Name = Name;
        this.Age = Age;
        this.PatientID = PatientID;   // readonly assigned once
        this.Ailment = Ailment;

        totalPatients++;
    }

    // static method to get total patients
    public static void GetTotalPatients()
    {
        Console.WriteLine("Total Patients Admitted: " + totalPatients);
    }

    // method to display patient details
    public void DisplayDetails()
    {
        Console.WriteLine("Hospital Name : " + HospitalName);
        Console.WriteLine("Patient Name  : " + Name);
        Console.WriteLine("Patient ID    : " + PatientID);
        Console.WriteLine("Age           : " + Age);
        Console.WriteLine("Ailment       : " + Ailment);
    }
}

class Program
{
    static void Main()
    {
        Patient p1 = new Patient("Suresh", 45, 701, "Diabetes");
        Patient p2 = new Patient("Meena", 32, 702, "Migraine");

        // is operator usage
        if (p1 is Patient)
        {
            Console.WriteLine("\nPatient 1 Details:");
            p1.DisplayDetails();
        }

        if (p2 is Patient)
        {
            Console.WriteLine("\nPatient 2 Details:");
            p2.DisplayDetails();
        }

        Console.WriteLine();
        Patient.GetTotalPatients();
    }
}
