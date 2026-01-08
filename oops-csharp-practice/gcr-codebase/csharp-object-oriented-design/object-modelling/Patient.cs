using System;
using System.Collections.Generic;

// Patient class
class Patient
{
    public string Name { get; set; }

    public Patient(string name)
    {
        Name = name;
    }
}

// Doctor class
class Doctor
{
    public string Name { get; set; }
    public List<Patient> Patients { get; set; }

    public Doctor(string name)
    {
        Name = name;
        Patients = new List<Patient>();
    }

    // Communication between Doctor and Patient
    public void Consult(Patient patient)
    {
        if (!Patients.Contains(patient))
            Patients.Add(patient);

        Console.WriteLine($"Doctor {Name} is consulting Patient {patient.Name}");
    }
}

// Hospital class (holds doctors and patients)
class Hospital
{
    public string HospitalName { get; set; }
    public List<Doctor> Doctors { get; set; }
    public List<Patient> Patients { get; set; }

    public Hospital(string name)
    {
        HospitalName = name;
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
    }

    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }

    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }
}

class Program
{
    static void Main()
    {
        Hospital hospital = new Hospital("City Hospital");

        Doctor d1 = new Doctor("Dr. Kumar");
        Doctor d2 = new Doctor("Dr. Verma");

        Patient p1 = new Patient("Rahul");
        Patient p2 = new Patient("Anita");

        hospital.AddDoctor(d1);
        hospital.AddDoctor(d2);

        hospital.AddPatient(p1);
        hospital.AddPatient(p2);

        // Association & Communication
        d1.Consult(p1);
        d1.Consult(p2);

        d2.Consult(p1);

        Console.WriteLine("\nMultiple relationships exist:");
        Console.WriteLine($"{p1.Name} consulted multiple doctors.");
        Console.WriteLine($"{d1.Name} consulted multiple patients.");
    }
}
