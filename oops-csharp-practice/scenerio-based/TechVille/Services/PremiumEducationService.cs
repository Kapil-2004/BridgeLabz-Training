using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 7: Premium Education Service
    /// Demonstrates: Inheritance from PremiumService, super (base keyword), instanceof support
    /// Extends basic education with premium features
    /// </summary>
    public class PremiumEducationService : PremiumService
    {
        // ===== PREMIUM-SPECIFIC ATTRIBUTES =====
        private bool hasOnlineLearning;
        private bool hasOneOneTuition;
        private int maxClassSize;
        private string[] advancedCourses;

        // ===== CONSTRUCTOR =====

        /// <summary>
        /// Premium Education Constructor
        /// Demonstrates: Using base keyword to call parent constructor chain
        /// this keyword for instance attributes
        /// </summary>
        public PremiumEducationService(int serviceId, string description, double budgetAllocated,
                                      double premiumCost, string premiumFeature, int priorityLevel,
                                      bool hasOnlineLearning, bool hasOneOneTuition,
                                      int maxClassSize, string[] advancedCourses)
            : base(serviceId, "Premium Education", description, budgetAllocated,
                   premiumCost, premiumFeature, priorityLevel)
        {
            // Using 'this' to reference instance variables
            this.hasOnlineLearning = hasOnlineLearning;
            this.hasOneOneTuition = hasOneOneTuition;
            this.maxClassSize = maxClassSize;
            this.advancedCourses = advancedCourses;
        }

        // ===== PUBLIC PROPERTIES =====

        public bool HasOnlineLearning
        {
            get { return hasOnlineLearning; }
            set { hasOnlineLearning = value; }
        }

        public bool HasOneOneTuition
        {
            get { return hasOneOneTuition; }
            set { hasOneOneTuition = value; }
        }

        public int MaxClassSize
        {
            get { return maxClassSize; }
            set { maxClassSize = value; }
        }

        public string[] AdvancedCourses
        {
            get { return advancedCourses; }
            set { advancedCourses = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Display advanced courses available
        /// </summary>
        public void DisplayAdvancedCourses()
        {
            if (advancedCourses != null && advancedCourses.Length > 0)
            {
                Console.WriteLine("\n📚 Advanced Courses Available:");
                for (int i = 0; i < advancedCourses.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {advancedCourses[i]}");
                }
            }
            else
            {
                Console.WriteLine("No advanced courses available.");
            }
        }

        /// <summary>
        /// Override ProvideService from Service abstract class
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"📖 Providing PREMIUM education service to {citizenName}...");
            Console.WriteLine($"Premium Feature: {PremiumFeature}");
            Console.WriteLine($"Online Learning: {(hasOnlineLearning ? "✅" : "❌")} | 1-on-1 Tuition: {(hasOneOneTuition ? "✅" : "❌")}");
            Console.WriteLine($"Max Class Size: {maxClassSize} students");
        }

        /// <summary>
        /// Override DisplayServiceInfo to show premium education details
        /// Calls base class method first using base keyword
        /// </summary>
        public override void DisplayServiceInfo()
        {
            // base keyword calls parent class (PremiumService) method
            base.DisplayServiceInfo();
            
            Console.WriteLine($"--- Premium Education Specific ---");
            Console.WriteLine($"Online Learning: {(hasOnlineLearning ? "✅ YES" : "❌ NO")}");
            Console.WriteLine($"1-on-1 Tuition: {(hasOneOneTuition ? "✅ YES" : "❌ NO")}");
            Console.WriteLine($"Maximum Class Size: {maxClassSize} students");
            Console.Write("Advanced Courses: ");
            Console.WriteLine(string.Join(", ", advancedCourses));
        }
    }
}
