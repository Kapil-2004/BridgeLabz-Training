using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 7: Service Factory Pattern
    /// Demonstrates: Static methods for factory pattern, instanceof operator usage
    /// Factory pattern centralizes object creation and manages instances
    /// </summary>
    public static class ServiceFactory
    {
        // ===== STATIC VARIABLES =====
        private static Dictionary<int, Service> serviceRegistry = new Dictionary<int, Service>();

        // ===== STATIC FACTORY METHODS =====

        /// <summary>
        /// Factory method: Create a standard Healthcare Service
        /// Demonstrates: Static method for object creation
        /// </summary>
        public static HealthcareService CreateStandardHealthcareService(int serviceId)
        {
            HealthcareService service = new HealthcareService(
                serviceId,
                "Standard healthcare center for TechVille",
                500000.0,
                50,
                20,
                "General Medicine"
            );
            RegisterService(serviceId, service);
            return service;
        }

        /// <summary>
        /// Factory method: Create a Premium Healthcare Service
        /// Demonstrates: Static method for specialized object creation
        /// </summary>
        public static PremiumHealthcareService CreatePremiumHealthcareService(int serviceId)
        {
            PremiumHealthcareService service = new PremiumHealthcareService(
                serviceId,
                "Premium healthcare with advanced facilities",
                800000.0,
                5000.0,
                "Advanced Medical Technology & Specialists",
                8,
                true,
                true,
                new string[] { "Cardiology", "Neurology", "Oncology", "Orthopedics" }
            );
            RegisterService(serviceId, service);
            return service;
        }

        /// <summary>
        /// Factory method: Create a standard Education Service
        /// </summary>
        public static EducationService CreateStandardEducationService(int serviceId)
        {
            EducationService service = new EducationService(
                serviceId,
                "Public education system for TechVille",
                800000.0,
                5,
                100,
                new string[] { "Primary", "Secondary", "Higher Secondary" }
            );
            RegisterService(serviceId, service);
            return service;
        }

        /// <summary>
        /// Factory method: Create a Premium Education Service
        /// </summary>
        public static PremiumEducationService CreatePremiumEducationService(int serviceId)
        {
            PremiumEducationService service = new PremiumEducationService(
                serviceId,
                "Premium education with advanced learning methods",
                1200000.0,
                8000.0,
                "Online Learning + 1-on-1 Coaching + Advanced Curriculum",
                9,
                true,
                true,
                15,
                new string[] { "Advanced Mathematics", "Programming", "AI & Robotics", "Digital Art" }
            );
            RegisterService(serviceId, service);
            return service;
        }

        /// <summary>
        /// Factory method: Create a Transportation Service
        /// </summary>
        public static TransportationService CreateTransportationService(int serviceId)
        {
            TransportationService service = new TransportationService(
                serviceId,
                "Public transportation network",
                400000.0,
                20,
                10,
                5.0
            );
            RegisterService(serviceId, service);
            return service;
        }

        /// <summary>
        /// Factory method: Create a Utilities Service
        /// </summary>
        public static UtilitiesService CreateUtilitiesService(int serviceId)
        {
            UtilitiesService service = new UtilitiesService(
                serviceId,
                "Water, electricity, and waste management",
                600000.0,
                5000,
                8000,
                85.5,
                new string[] { "Water Supply", "Electricity", "Waste Management", "Drainage" }
            );
            RegisterService(serviceId, service);
            return service;
        }

        // ===== REGISTRY MANAGEMENT =====

        /// <summary>
        /// Register a service in the factory registry
        /// </summary>
        private static void RegisterService(int serviceId, Service service)
        {
            if (!serviceRegistry.ContainsKey(serviceId))
            {
                serviceRegistry[serviceId] = service;
            }
        }

        /// <summary>
        /// Get a registered service by ID
        /// </summary>
        public static Service GetService(int serviceId)
        {
            if (serviceRegistry.ContainsKey(serviceId))
            {
                return serviceRegistry[serviceId];
            }
            return null;
        }

        // ===== INSTANCEOF-LIKE OPERATIONS =====

        /// <summary>
        /// Check if a service is a premium service using instanceof pattern
        /// In C#, we use 'is' operator (similar to instanceof in Java)
        /// </summary>
        public static bool IsPremiumService(Service service)
        {
            // Using 'is' operator (C# equivalent of instanceof)
            return service is PremiumService;
        }

        /// <summary>
        /// Check if a service is of a specific type
        /// </summary>
        public static bool IsHealthcareService(Service service)
        {
            return service is HealthcareService;
        }

        /// <summary>
        /// Check if a service is premium healthcare
        /// </summary>
        public static bool IsPremiumHealthcareService(Service service)
        {
            return service is PremiumHealthcareService;
        }

        /// <summary>
        /// Check if a service is education type
        /// </summary>
        public static bool IsEducationService(Service service)
        {
            return service is EducationService;
        }

        /// <summary>
        /// Check if a service is premium education
        /// </summary>
        public static bool IsPremiumEducationService(Service service)
        {
            return service is PremiumEducationService;
        }

        /// <summary>
        /// Upgrade a standard service to premium
        /// Demonstrates: Type checking and conditional upgrades
        /// </summary>
        public static void UpgradeServiceToPremium(Service service)
        {
            Console.WriteLine("\n🔄 Attempting Service Upgrade...");

            // Using instanceof pattern to check service type before upgrade
            if (service is HealthcareService && !(service is PremiumHealthcareService))
            {
                Console.WriteLine("✅ Healthcare Service can be upgraded to Premium!");
                Console.WriteLine("   Recommended: Specialist doctors, Private rooms, Advanced equipment");
            }
            else if (service is EducationService && !(service is PremiumEducationService))
            {
                Console.WriteLine("✅ Education Service can be upgraded to Premium!");
                Console.WriteLine("   Recommended: Online learning, 1-on-1 coaching, Advanced curriculum");
            }
            else if (service is PremiumService)
            {
                Console.WriteLine("❌ This service is already Premium!");
            }
            else
            {
                Console.WriteLine("⚠️ This service type does not support premium upgrade yet.");
            }
        }

        /// <summary>
        /// Display service type information
        /// Demonstrates: Multiple instanceof checks
        /// </summary>
        public static void DisplayServiceTypeInfo(Service service)
        {
            Console.WriteLine($"\n📋 Service Type Analysis for '{service.ServiceName}':");
            
            // Multiple instanceof checks
            if (service is PremiumService)
            {
                Console.WriteLine("   ✅ Premium Service");
                
                // Further type checking
                if (service is PremiumHealthcareService)
                    Console.WriteLine("   └─ Premium Healthcare Service");
                else if (service is PremiumEducationService)
                    Console.WriteLine("   └─ Premium Education Service");
            }
            else
            {
                Console.WriteLine("   ✅ Standard Service");
                
                if (service is HealthcareService)
                    Console.WriteLine("   └─ Healthcare Service");
                else if (service is EducationService)
                    Console.WriteLine("   └─ Education Service");
                else if (service is TransportationService)
                    Console.WriteLine("   └─ Transportation Service");
                else if (service is UtilitiesService)
                    Console.WriteLine("   └─ Utilities Service");
            }
        }

        /// <summary>
        /// Get all registered services
        /// </summary>
        public static List<Service> GetAllServices()
        {
            return new List<Service>(serviceRegistry.Values);
        }

        /// <summary>
        /// Get count of premium vs standard services
        /// </summary>
        public static void DisplayServiceRegistry()
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║     SERVICE REGISTRY              ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine($"Total Registered Services: {serviceRegistry.Count}");

            int premiumCount = 0;
            int standardCount = 0;

            foreach (Service service in serviceRegistry.Values)
            {
                if (IsPremiumService(service))
                    premiumCount++;
                else
                    standardCount++;
            }

            Console.WriteLine($"Premium Services: {premiumCount}");
            Console.WriteLine($"Standard Services: {standardCount}");

            Console.WriteLine("\n--- Services List ---");
            foreach (KeyValuePair<int, Service> entry in serviceRegistry)
            {
                string type = IsPremiumService(entry.Value) ? "Premium" : "Standard";
                Console.WriteLine($"{entry.Key}. {entry.Value.ServiceName} [{type}]");
            }
        }
    }
}
