using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: ServiceProvider Abstract Base Class
    /// Demonstrates: Abstract class providing common functionality
    /// Implements IServiceProvider and partial implementation of other interfaces
    /// External service providers extend this class
    /// </summary>
    public abstract class ServiceProvider : IServiceProvider, IReportable
    {
        // ===== PRIVATE ATTRIBUTES (Encapsulation) =====
        private string providerName;
        private string providerType;
        private double budgetAllocated;
        private bool isOperational;
        private DateTime registrationDate;
        private double providerRating;
        private int totalServed;
        private int totalSatisfied;

        // ===== PROTECTED ATTRIBUTES (For derived classes) =====
        protected List<string> serviceHistory;

        // ===== CONSTRUCTOR =====

        /// <summary>
        /// Protected Constructor - can only be called by derived classes
        /// Demonstrates: Encapsulation through access modifiers
        /// </summary>
        protected ServiceProvider(string providerName, string providerType, double budgetAllocated)
        {
            this.providerName = providerName;
            this.providerType = providerType;
            this.budgetAllocated = budgetAllocated;
            this.isOperational = true;
            this.registrationDate = DateTime.Now;
            this.providerRating = 5.0;  // Start with excellent rating
            this.totalServed = 0;
            this.totalSatisfied = 0;
            this.serviceHistory = new List<string>();
        }

        // ===== PUBLIC PROPERTIES =====

        public string ProviderName
        {
            get { return providerName; }
            protected set { providerName = value; }
        }

        public string ProviderType
        {
            get { return providerType; }
            protected set { providerType = value; }
        }

        public double BudgetAllocated
        {
            get { return budgetAllocated; }
            protected set { budgetAllocated = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
        }

        public double ProviderRating
        {
            get { return providerRating; }
            protected set { providerRating = value; }
        }

        public int TotalServed
        {
            get { return totalServed; }
            protected set { totalServed = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Implement IServiceProvider.GetProviderName()
        /// </summary>
        public virtual string GetProviderName()
        {
            return providerName;
        }

        /// <summary>
        /// Implement IServiceProvider.IsOperational()
        /// </summary>
        public virtual bool IsOperational()
        {
            return isOperational;
        }


        /// <summary>
        /// Implement IServiceProvider.GetProviderRating()
        /// </summary>
        public virtual double GetProviderRating()
        {
            return providerRating;
        }

        /// <summary>
        /// Implement IServiceProvider.DisplayProviderInfo()
        /// </summary>
        public virtual void DisplayProviderInfo()
        {
            Console.WriteLine($"\n=== Service Provider: {providerName} ===");
            Console.WriteLine($"Type: {providerType}");
            Console.WriteLine($"Status: {(isOperational ? "✅ Operational" : "❌ Offline")}");
            Console.WriteLine($"Rating: {providerRating:F1}/5.0");
            Console.WriteLine($"Budget: ₹{budgetAllocated:F2}");
            Console.WriteLine($"Registered: {registrationDate:yyyy-MM-dd}");
            Console.WriteLine($"Total Served: {totalServed}");
        }

        /// <summary>
        /// Implement IReportable.GenerateReport()
        /// </summary>
        public virtual string GenerateReport()
        {
            double satisfactionRate = totalServed > 0 ? (totalSatisfied * 100.0 / totalServed) : 0;
            return $"{providerName} Report: {totalServed} served, {satisfactionRate:F1}% satisfaction";
        }

        /// <summary>
        /// Implement IReportable.ExportData()
        /// </summary>
        public virtual void ExportData(string format)
        {
            Console.WriteLine($"Exporting {providerName} data in {format} format...");
            Console.WriteLine($"Total Records: {serviceHistory.Count}");
        }

        /// <summary>
        /// Implement IReportable.DisplayStatistics()
        /// </summary>
        public virtual void DisplayStatistics()
        {
            Console.WriteLine($"\n📊 Statistics for {providerName}:");
            Console.WriteLine($"Total Services: {totalServed}");
            Console.WriteLine($"Satisfied Customers: {totalSatisfied}");
            double satisfactionRate = totalServed > 0 ? (totalSatisfied * 100.0 / totalServed) : 0;
            Console.WriteLine($"Satisfaction Rate: {satisfactionRate:F1}%");
            Console.WriteLine($"Provider Rating: {providerRating:F1}/5.0");
        }

        // ===== PROTECTED HELPER METHODS =====

        /// <summary>
        /// Record service history entry
        /// </summary>
        protected void LogServiceTransaction(string transaction)
        {
            serviceHistory.Add($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {transaction}");
            totalServed++;
        }

        /// <summary>
        /// Update provider rating based on satisfaction
        /// </summary>
        protected void UpdateRating(bool satisfied)
        {
            if (satisfied)
            {
                totalSatisfied++;
                // Increase rating slightly
                if (providerRating < 5.0)
                    providerRating = Math.Min(5.0, providerRating + 0.1);
            }
            else
            {
                // Decrease rating for unsatisfied customers
                if (providerRating > 1.0)
                    providerRating = Math.Max(1.0, providerRating - 0.2);
            }
        }

        /// <summary>
        /// Set operational status
        /// </summary>
        public void SetOperationalStatus(bool status)
        {
            this.isOperational = status;
            Console.WriteLine($"{providerName} is now {(status ? "operational" : "offline")}");
        }

        // ===== ABSTRACT METHODS (Must be implemented by derived classes) =====

        /// <summary>
        /// Abstract method: All providers must implement their own service provision
        /// </summary>
        public abstract void ProvideService(string citizenName);

        /// <summary>
        /// Abstract method: All providers must implement status display
        /// </summary>
        public abstract void DisplayDetailedStatus();
    }
}
