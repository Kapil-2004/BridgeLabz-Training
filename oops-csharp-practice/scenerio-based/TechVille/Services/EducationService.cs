using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: EducationService Class
    /// Demonstrates: Inheritance, Method overriding, Polymorphism
    /// </summary>
    public class EducationService : Service
    {
        // ===== PRIVATE ATTRIBUTES (Specific to Education) =====
        private int totalSchools;
        private int totalStudents;
        private int teachersAvailable;
        private string[] programs;

        // ===== CONSTRUCTOR =====
        public EducationService(int serviceId, string description, double budgetAllocated,
                               int totalSchools, int teachersAvailable, string[] programs)
            : base(serviceId, "Education", description, budgetAllocated)
        {
            this.totalSchools = totalSchools;
            this.totalStudents = 0;
            this.teachersAvailable = teachersAvailable;
            this.programs = programs;
        }

        // ===== PUBLIC PROPERTIES =====

        public int TotalSchools
        {
            get { return totalSchools; }
            set { totalSchools = value; }
        }

        public int TotalStudents
        {
            get { return totalStudents; }
            set { totalStudents = value; }
        }

        public int TeachersAvailable
        {
            get { return teachersAvailable; }
            set { teachersAvailable = value; }
        }

        public string[] Programs
        {
            get { return programs; }
            set { programs = value; }
        }

        // ===== PRIVATE METHOD =====
        private double GetStudentTeacherRatio()
        {
            return teachersAvailable > 0 ? (double)totalStudents / teachersAvailable : 0;
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Enroll a student
        /// </summary>
        public void EnrollStudent(string studentName)
        {
            totalStudents++;
            Console.WriteLine($"✅ {studentName} has been enrolled. Total students: {totalStudents}");
        }

        /// <summary>
        /// Get available programs
        /// </summary>
        public void DisplayPrograms()
        {
            Console.WriteLine("\n📚 Available Programs:");
            for (int i = 0; i < programs.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {programs[i]}");
            }
        }

        /// <summary>
        /// Override: ProvideService method
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"📖 Providing education service to {citizenName}...");
            Console.WriteLine($"Schools: {totalSchools}, Teachers: {teachersAvailable}");
            Console.WriteLine($"Student-Teacher Ratio: {GetStudentTeacherRatio():F2}");
        }

        /// <summary>
        /// Override: DisplayServiceInfo
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Total Schools: {totalSchools}");
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Teachers Available: {teachersAvailable}");
            Console.WriteLine($"Student-Teacher Ratio: {GetStudentTeacherRatio():F2}");
            Console.Write("Programs: ");
            Console.WriteLine(string.Join(", ", programs));
        }
    }
}
