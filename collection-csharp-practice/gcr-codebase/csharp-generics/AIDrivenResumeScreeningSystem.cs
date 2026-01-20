using System;
using System.Collections.Generic;

//
// Abstract base class for job roles
//
public abstract class JobRole
{
    public string RoleName { get; set; }

    protected JobRole(string roleName)
    {
        RoleName = roleName;
    }

    public abstract void EvaluateSkills();
}

//
// Concrete job roles
//
public class SoftwareEngineer : JobRole
{
    public SoftwareEngineer() : base("Software Engineer") { }

    public override void EvaluateSkills()
    {
        Console.WriteLine("Evaluating coding, problem-solving, and system design skills.");
    }
}

public class DataScientist : JobRole
{
    public DataScientist() : base("Data Scientist") { }

    public override void EvaluateSkills()
    {
        Console.WriteLine("Evaluating statistics, machine learning, and data analysis skills.");
    }
}

//
// Generic Resume class with constraint
//
public class Resume<T> where T : JobRole
{
    public string CandidateName { get; set; }
    public int ExperienceYears { get; set; }
    public T AppliedRole { get; set; }

    public Resume(string candidateName, int experienceYears, T appliedRole)
    {
        CandidateName = candidateName;
        ExperienceYears = experienceYears;
        AppliedRole = appliedRole;
    }

    public void DisplayResume()
    {
        Console.WriteLine(
            $"Candidate: {CandidateName}, Experience: {ExperienceYears} years, Role: {AppliedRole.RoleName}"
        );
        AppliedRole.EvaluateSkills();
    }
}

//
// Generic methods for resume screening
//
public static class ScreeningService
{
    public static void ScreenResume<T>(Resume<T> resume)
        where T : JobRole
    {
        if (resume.ExperienceYears < 1)
        {
            Console.WriteLine($"{resume.CandidateName} rejected due to insufficient experience.");
            return;
        }

        Console.WriteLine($"{resume.CandidateName} shortlisted for {resume.AppliedRole.RoleName}.");
        resume.DisplayResume();
    }
}

//
// Main Program
//
class AIDrivenResumeScreeningSystem
{
    static void Main()
    {
        // Resume lists for different job roles
        List<Resume<SoftwareEngineer>> softwareResumes =
            new List<Resume<SoftwareEngineer>>
            {
                new Resume<SoftwareEngineer>("Alice", 3, new SoftwareEngineer()),
                new Resume<SoftwareEngineer>("Bob", 0, new SoftwareEngineer())
            };

        List<Resume<DataScientist>> dataScienceResumes =
            new List<Resume<DataScientist>>
            {
                new Resume<DataScientist>("Charlie", 2, new DataScientist())
            };

        Console.WriteLine("=== Software Engineer Screening ===");
        foreach (var resume in softwareResumes)
        {
            ScreeningService.ScreenResume(resume);
            Console.WriteLine();
        }

        Console.WriteLine("=== Data Scientist Screening ===");
        foreach (var resume in dataScienceResumes)
        {
            ScreeningService.ScreenResume(resume);
            Console.WriteLine();
        }
    }
}
