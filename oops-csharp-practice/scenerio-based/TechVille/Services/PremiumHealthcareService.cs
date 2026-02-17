using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 7: Premium Healthcare Service
    /// Demonstrates: Inheritance from PremiumService, super (base keyword)
    /// Extends HealthcareService with premium features
    /// </summary>
    public class PremiumHealthcareService : PremiumService
    {
        // ===== PREMIUM-SPECIFIC ATTRIBUTES =====
        private bool hasPrivateRooms;
        private bool hasSpecialists;
        private string[] specialistTypes;

        // ===== CONSTRUCTOR =====

        /// <summary>
        /// Premium Healthcare Constructor
        /// Demonstrates: Using base keyword to call parent constructor
        /// and this keyword for new attributes
        /// </summary>
        public PremiumHealthcareService(int serviceId, string description, double budgetAllocated,
                                       double premiumCost, string premiumFeature, int priorityLevel,
                                       bool hasPrivateRooms, bool hasSpecialists,
                                       string[] specialistTypes)
            : base(serviceId, "Premium Healthcare", description, budgetAllocated,
                   premiumCost, premiumFeature, priorityLevel)
        {
            // Using 'this' for instance-specific attributes
            this.hasPrivateRooms = hasPrivateRooms;
            this.hasSpecialists = hasSpecialists;
            this.specialistTypes = specialistTypes;
        }

        // ===== PUBLIC PROPERTIES =====

        public bool HasPrivateRooms
        {
            get { return hasPrivateRooms; }
            set { hasPrivateRooms = value; }
        }

        public bool HasSpecialists
        {
            get { return hasSpecialists; }
            set { hasSpecialists = value; }
        }

        public string[] SpecialistTypes
        {
            get { return specialistTypes; }
            set { specialistTypes = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Display available specialists
        /// </summary>
        public void DisplaySpecialists()
        {
            if (hasSpecialists && specialistTypes != null && specialistTypes.Length > 0)
            {
                Console.WriteLine("\n🏥 Available Specialists:");
                for (int i = 0; i < specialistTypes.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {specialistTypes[i]}");
                }
            }
            else
            {
                Console.WriteLine("No specialists available in this plan.");
            }
        }

        /// <summary>
        /// Override ProvideService from Service abstract class
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"💊 Providing PREMIUM healthcare service to {citizenName}...");
            Console.WriteLine($"Premium Feature: {PremiumFeature}");
            Console.WriteLine($"Private Rooms: {(hasPrivateRooms ? "✅" : "❌")} | Specialists: {(hasSpecialists ? "✅" : "❌")}");
        }

        /// <summary>
        /// Override DisplayServiceInfo to show premium healthcare details
        /// Calls base class method first using base keyword
        /// </summary>
        public override void DisplayServiceInfo()
        {
            // base keyword calls parent class (PremiumService) method
            base.DisplayServiceInfo();
            
            Console.WriteLine($"--- Premium Healthcare Specific ---");
            Console.WriteLine($"Private Rooms: {(hasPrivateRooms ? "✅ YES" : "❌ NO")}");
            Console.WriteLine($"Specialists Available: {(hasSpecialists ? "✅ YES" : "❌ NO")}");
            if (hasSpecialists)
            {
                Console.Write("Specialist Types: ");
                Console.WriteLine(string.Join(", ", specialistTypes));
            }
        }
    }
}
