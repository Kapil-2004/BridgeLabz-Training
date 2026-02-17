using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: HealthcareService Class
    /// Demonstrates: Inheritance, Method overriding, Polymorphism
    /// </summary>
    public class HealthcareService : Service
    {
        // ===== PRIVATE ATTRIBUTES (Specific to Healthcare) =====
        private int totalBeds;
        private int occupiedBeds;
        private int doctorsAvailable;
        private string specialization;

        // ===== CONSTRUCTOR =====
        public HealthcareService(int serviceId, string description, double budgetAllocated,
                                 int totalBeds, int doctorsAvailable, string specialization)
            : base(serviceId, "Healthcare", description, budgetAllocated)
        {
            this.totalBeds = totalBeds;
            this.occupiedBeds = 0;
            this.doctorsAvailable = doctorsAvailable;
            this.specialization = specialization;
        }

        // ===== PUBLIC PROPERTIES =====

        public int TotalBeds
        {
            get { return totalBeds; }
            set { totalBeds = value; }
        }

        public int OccupiedBeds
        {
            get { return occupiedBeds; }
            set { occupiedBeds = value; }
        }

        public int DoctorsAvailable
        {
            get { return doctorsAvailable; }
            set { doctorsAvailable = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        // ===== PRIVATE METHOD =====
        private int GetAvailableBeds()
        {
            return totalBeds - occupiedBeds;
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Check bed availability
        /// </summary>
        public bool AreBedAvailable()
        {
            return GetAvailableBeds() > 0;
        }

        /// <summary>
        /// Admit a patient
        /// </summary>
        public void AdmitPatient(string patientName)
        {
            if (AreBedAvailable())
            {
                occupiedBeds++;
                Console.WriteLine($"✅ {patientName} has been admitted. Available beds: {GetAvailableBeds()}");
            }
            else
            {
                Console.WriteLine("❌ No beds available!");
            }
        }

        /// <summary>
        /// Discharge a patient
        /// </summary>
        public void DischargePatient(string patientName)
        {
            if (occupiedBeds > 0)
            {
                occupiedBeds--;
                Console.WriteLine($"✅ {patientName} has been discharged. Available beds: {GetAvailableBeds()}");
            }
            else
            {
                Console.WriteLine("❌ No patients to discharge!");
            }
        }

        /// <summary>
        /// Override: ProvideService method
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"💊 Providing healthcare service to {citizenName}...");
            Console.WriteLine($"Specialization: {specialization}, Doctors: {doctorsAvailable}");
        }

        /// <summary>
        /// Override: DisplayServiceInfo
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Specialization: {specialization}");
            Console.WriteLine($"Total Beds: {totalBeds}");
            Console.WriteLine($"Occupied Beds: {occupiedBeds}");
            Console.WriteLine($"Available Beds: {GetAvailableBeds()}");
            Console.WriteLine($"Doctors Available: {doctorsAvailable}");
        }
    }
}
