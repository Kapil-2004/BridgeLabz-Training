using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 7: Base Service Class (Advanced OOP)
    /// Demonstrates: Static variables, Static methods, this keyword, Abstract methods
    /// Topics: Base class with virtual methods for polymorphism, factory pattern support
    /// </summary>
    public abstract class Service
    {
        // ===== STATIC VARIABLES (Shared across all service instances) =====
        /// <summary>
        /// Total count of all services created in the system
        /// Demonstrates: Static variable for class-level tracking
        /// </summary>
        private static int totalServicesCreated = 0;

        /// <summary>
        /// Total count of premium services created
        /// Demonstrates: Separate static counter for premium services
        /// </summary>
        private static int totalPremiumServices = 0;

        // ===== PRIVATE ATTRIBUTES =====
        private int serviceId;
        private string serviceName;
        private string description;
        private double budgetAllocated;
        private bool isActive;
        private DateTime establishedDate;

        // ===== PUBLIC STATIC PROPERTY =====
        /// <summary>
        /// Access total services count (read-only)
        /// </summary>
        public static int TotalServicesCreated
        {
            get { return totalServicesCreated; }
        }

        /// <summary>
        /// Access total premium services count (read-only)
        /// </summary>
        public static int TotalPremiumServices
        {
            get { return totalPremiumServices; }
        }

        // ===== CONSTRUCTORS =====

        /// <summary>
        /// Protected Constructor (Can only be called by derived classes)
        /// Demonstrates: Access modifiers, inheritance, and this keyword
        /// Uses 'this.' to explicitly reference instance variables
        /// </summary>
        protected Service(int serviceId, string serviceName, string description, double budgetAllocated)
        {
            // Using 'this' keyword to reference instance variables
            // This avoids confusion between parameters and attributes
            this.serviceId = serviceId;
            this.serviceName = serviceName;
            this.description = description;
            this.budgetAllocated = budgetAllocated;
            this.isActive = true;
            this.establishedDate = DateTime.Now;

            // Increment class variable
            totalServicesCreated++;
        }

        // ===== PUBLIC PROPERTIES =====

        public int ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double BudgetAllocated
        {
            get { return budgetAllocated; }
            set { budgetAllocated = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public DateTime EstablishedDate
        {
            get { return establishedDate; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Virtual method for activation (can be overridden in derived classes)
        /// </summary>
        public virtual void ActivateService()
        {
            isActive = true;
            Console.WriteLine($"✅ {serviceName} has been activated.");
        }

        /// <summary>
        /// Virtual method for deactivation (can be overridden in derived classes)
        /// </summary>
        public virtual void DeactivateService()
        {
            isActive = false;
            Console.WriteLine($"❌ {serviceName} has been deactivated.");
        }

        /// <summary>
        /// Abstract method - MUST be implemented by derived classes
        /// </summary>
        public abstract void ProvideService(string citizenName);

        /// <summary>
        /// Virtual method - Get service details (can be overridden)
        /// </summary>
        public virtual void DisplayServiceInfo()
        {
            Console.WriteLine($"\n--- {serviceName} Service ---");
            Console.WriteLine($"Service ID: {serviceId}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Budget: ₹{budgetAllocated:F2}");
            Console.WriteLine($"Status: {(isActive ? "Active" : "Inactive")}");
            Console.WriteLine($"Established: {establishedDate:yyyy-MM-dd}");
        }

        /// <summary>
        /// Virtual method - Update budget
        /// </summary>
        public virtual void UpdateBudget(double newBudget)
        {
            if (newBudget > 0)
            {
                budgetAllocated = newBudget;
                Console.WriteLine($"✅ Budget updated to ₹{newBudget:F2}");
            }
            else
            {
                Console.WriteLine("❌ Budget must be positive!");
            }
        }

        public override string ToString()
        {
            return $"{serviceName} (ID: {serviceId}, Budget: ₹{budgetAllocated:F2}, Status: {(isActive ? "Active" : "Inactive")})";
        }

        /// <summary>
        /// Module 8: Override Equals from Object class
        /// Compares two services based on their ID
        /// Demonstrates: Object class method overriding
        /// </summary>
        public override bool Equals(object obj)
        {
            // Check if obj is null
            if (obj == null)
                return false;

            // Check if obj is of type Service
            if (!(obj is Service))
                return false;

            // Cast and compare serviceId
            Service other = (Service)obj;
            return this.serviceId == other.serviceId;
        }

        /// <summary>
        /// Module 8: Override GetHashCode from Object class
        /// Returns hash code based on service ID
        /// Must be overridden when Equals() is overridden
        /// Demonstrates: Object class method overriding
        /// </summary>
        public override int GetHashCode()
        {
            return serviceId.GetHashCode();
        }

        // ===== STATIC METHODS =====

        /// <summary>
        /// Static method: Increment premium service counter
        /// Only called by premium service subclasses
        /// </summary>
        protected static void IncrementPremiumCounter()
        {
            totalPremiumServices++;
        }

        /// <summary>
        /// Static method: Get all service statistics
        /// </summary>
        public static void DisplayServiceStatistics()
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║   TOTAL SERVICE STATISTICS         ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine($"Total Services Created: {totalServicesCreated}");
            Console.WriteLine($"Premium Services: {totalPremiumServices}");
            Console.WriteLine($"Standard Services: {totalServicesCreated - totalPremiumServices}");
        }
    }
}