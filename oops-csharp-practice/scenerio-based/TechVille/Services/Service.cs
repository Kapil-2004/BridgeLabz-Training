using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: Base Service Class
    /// Demonstrates: Classes, Constructors, Access Modifiers, Encapsulation
    /// Topics: Base class with virtual methods for polymorphism
    /// </summary>
    public abstract class Service
    {
        // ===== CLASS VARIABLE (Shared across all service instances) =====
        private static int totalServicesCreated = 0;

        // ===== PRIVATE ATTRIBUTES =====
        private int serviceId;
        private string serviceName;
        private string description;
        private double budgetAllocated;
        private bool isActive;
        private DateTime establishedDate;

        // ===== PUBLIC PROPERTY TO ACCESS CLASS VARIABLE =====
        public static int TotalServicesCreated
        {
            get { return totalServicesCreated; }
        }

        // ===== CONSTRUCTORS =====

        /// <summary>
        /// Protected Constructor (Can only be called by derived classes)
        /// Demonstrates: Access modifiers and inheritance
        /// </summary>
        protected Service(int serviceId, string serviceName, string description, double budgetAllocated)
        {
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
    }
}
