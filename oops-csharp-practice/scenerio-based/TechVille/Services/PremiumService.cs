using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 7: Premium Service Abstract Class
    /// Demonstrates: Inheritance, super (base) keyword, static method calls
    /// Premium services extend basic services with additional features
    /// </summary>
    public abstract class PremiumService : Service
    {
        // ===== PREMIUM-SPECIFIC ATTRIBUTES =====
        private double premiumCost;
        private string premiumFeature;
        private int priorityLevel;
        private bool hasCustomerSupport;

        // ===== CONSTRUCTOR =====

        /// <summary>
        /// Premium Service Constructor
        /// Demonstrates: Using base (super in C#) to call parent constructor
        /// and this keyword for instance variables
        /// </summary>
        protected PremiumService(int serviceId, string serviceName, string description,
                                double budgetAllocated, double premiumCost,
                                string premiumFeature, int priorityLevel)
            : base(serviceId, serviceName, description, budgetAllocated)
        {
            // Using 'this' to reference instance variables
            this.premiumCost = premiumCost;
            this.premiumFeature = premiumFeature;
            this.priorityLevel = priorityLevel;
            this.hasCustomerSupport = true;

            // Call static method from parent class (could use Service.IncrementPremiumCounter())
            IncrementPremiumCounter();
        }

        // ===== PUBLIC PROPERTIES =====

        public double PremiumCost
        {
            get { return premiumCost; }
            set { premiumCost = value; }
        }

        public string PremiumFeature
        {
            get { return premiumFeature; }
            set { premiumFeature = value; }
        }

        public int PriorityLevel
        {
            get { return priorityLevel; }
            set { priorityLevel = value; }
        }

        public bool HasCustomerSupport
        {
            get { return hasCustomerSupport; }
            set { hasCustomerSupport = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Get premium service fee
        /// </summary>
        public double GetPremiumFee()
        {
            return premiumCost;
        }

        /// <summary>
        /// Provide premium benefits
        /// </summary>
        public void ProvidePremiumBenefits(string userName)
        {
            Console.WriteLine($"\n🌟 ===== PREMIUM SERVICE ===== 🌟");
            Console.WriteLine($"User: {userName}");
            Console.WriteLine($"Premium Feature: {premiumFeature}");
            Console.WriteLine($"Priority Level: {priorityLevel}/10");
            Console.WriteLine($"Cost: ₹{premiumCost:F2}");
            Console.WriteLine($"24/7 Customer Support: {(hasCustomerSupport ? "✅ YES" : "❌ NO")}");
        }

        /// <summary>
        /// Override DisplayServiceInfo from base class using base keyword
        /// Demonstrates: Calling parent class method and extending it
        /// </summary>
        public override void DisplayServiceInfo()
        {
            // base keyword calls parent class method
            base.DisplayServiceInfo();
            
            Console.WriteLine($"--- Premium Features ---");
            Console.WriteLine($"Premium Cost: ₹{premiumCost:F2}");
            Console.WriteLine($"Featured Benefit: {premiumFeature}");
            Console.WriteLine($"Priority Level: {priorityLevel}/10");
            Console.WriteLine($"Customer Support Available: {(hasCustomerSupport ? "✅ YES" : "❌ NO")}");
        }
    }
}
