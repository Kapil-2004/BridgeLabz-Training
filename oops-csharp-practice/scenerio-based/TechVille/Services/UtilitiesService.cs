using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: UtilitiesService Class
    /// Demonstrates: Inheritance, Method overriding, Polymorphism
    /// </summary>
    public class UtilitiesService : Service
    {
        // ===== PRIVATE ATTRIBUTES (Specific to Utilities) =====
        private double waterConnections;
        private double electricityConnections;
        private double wasteManagementCoverage;
        private string[] utilities;

        // ===== CONSTRUCTOR =====
        public UtilitiesService(int serviceId, string description, double budgetAllocated,
                               double waterConnections, double electricityConnections,
                               double wasteManagementCoverage, string[] utilities)
            : base(serviceId, "Utilities", description, budgetAllocated)
        {
            this.waterConnections = waterConnections;
            this.electricityConnections = electricityConnections;
            this.wasteManagementCoverage = wasteManagementCoverage;
            this.utilities = utilities;
        }

        // ===== PUBLIC PROPERTIES =====

        public double WaterConnections
        {
            get { return waterConnections; }
            set { waterConnections = value; }
        }

        public double ElectricityConnections
        {
            get { return electricityConnections; }
            set { electricityConnections = value; }
        }

        public double WasteManagementCoverage
        {
            get { return wasteManagementCoverage; }
            set { wasteManagementCoverage = value; }
        }

        public string[] Utilities
        {
            get { return utilities; }
            set { utilities = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Check utility status
        /// </summary>
        public void CheckUtilityStatus()
        {
            Console.WriteLine("\n⚡ Utility Status:");
            Console.WriteLine($"  Water Connections: {waterConnections:F0}");
            Console.WriteLine($"  Electricity Connections: {electricityConnections:F0}");
            Console.WriteLine($"  Waste Management Coverage: {wasteManagementCoverage:F1}%");
        }

        /// <summary>
        /// Add new utility connection
        /// </summary>
        public void AddConnection(string utilityType)
        {
            if (utilityType.ToLower() == "water")
            {
                waterConnections++;
                Console.WriteLine($"✅ New water connection added. Total: {waterConnections}");
            }
            else if (utilityType.ToLower() == "electricity")
            {
                electricityConnections++;
                Console.WriteLine($"✅ New electricity connection added. Total: {electricityConnections}");
            }
            else
            {
                Console.WriteLine("❌ Unknown utility type!");
            }
        }

        /// <summary>
        /// Override: ProvideService method
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"💧 Providing utilities service to {citizenName}...");
            Console.WriteLine($"Water: {waterConnections:F0}, Electricity: {electricityConnections:F0}");
        }

        /// <summary>
        /// Override: DisplayServiceInfo
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Water Connections: {waterConnections:F0}");
            Console.WriteLine($"Electricity Connections: {electricityConnections:F0}");
            Console.WriteLine($"Waste Management Coverage: {wasteManagementCoverage:F1}%");
            Console.Write("Utilities: ");
            Console.WriteLine(string.Join(", ", utilities));
        }
    }
}
