using System;
using System.Collections.Generic;
using TechVille.Modules;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: ServiceManagementService
    /// Demonstrates: Working with multiple objects, polymorphism, collection management
    /// </summary>
    public class ServiceManagementService
    {
        // ===== INSTANCE VARIABLE: Collection of services =====
        private List<Service> services;

        // ===== CONSTRUCTOR =====
        public ServiceManagementService()
        {
            services = new List<Service>();
            InitializeServices();
        }

        // ===== PRIVATE METHODS =====

        /// <summary>
        /// Initialize default services using Factory Pattern
        /// Demonstrates: Static factory methods for object creation
        /// </summary>
        private void InitializeServices()
        {
            // Using factory methods to create services
            ServiceFactory.CreateStandardHealthcareService(101);
            ServiceFactory.CreatePremiumHealthcareService(102);
            
            ServiceFactory.CreateStandardEducationService(103);
            ServiceFactory.CreatePremiumEducationService(104);
            
            ServiceFactory.CreateTransportationService(105);
            ServiceFactory.CreateUtilitiesService(106);

            // Get all services from factory
            services = ServiceFactory.GetAllServices();

            Console.WriteLine($"✅ {Service.TotalServicesCreated} services initialized!");
            Console.WriteLine($"   └─ Premium Services: {Service.TotalPremiumServices}");
            Console.WriteLine($"   └─ Standard Services: {Service.TotalServicesCreated - Service.TotalPremiumServices}\n");
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Display all services
        /// Demonstrates: Polymorphism - calling overridden methods
        /// </summary>
        public void DisplayAllServices()
        {
            Console.WriteLine("\n===== TechVille Smart City Services =====");
            Console.WriteLine($"Total Services: {Service.TotalServicesCreated}\n");

            for (int i = 0; i < services.Count; i++)
            {
                Console.WriteLine($"\n[Service {i + 1}]");
                services[i].DisplayServiceInfo();
            }
        }

        /// <summary>
        /// Find service by ID
        /// </summary>
        public Service FindServiceById(int serviceId)
        {
            foreach (Service service in services)
            {
                if (service.ServiceId == serviceId)
                {
                    return service;
                }
            }
            return null;
        }

        /// <summary>
        /// Provide service to a citizen
        /// Demonstrates: Polymorphism - different implementations for each service
        /// </summary>
        public void ProvideCitizenService(string citizenName, int serviceId)
        {
            Service service = FindServiceById(serviceId);
            if (service != null)
            {
                if (service.IsActive)
                {
                    service.ProvideService(citizenName);
                }
                else
                {
                    Console.WriteLine($"❌ Service {service.ServiceName} is currently inactive!");
                }
            }
            else
            {
                Console.WriteLine("❌ Service not found!");
            }
        }

        /// <summary>
        /// Get specific service object
        /// </summary>
        public HealthcareService GetHealthcareService()
        {
            foreach (Service service in services)
            {
                if (service is HealthcareService)
                {
                    return (HealthcareService)service;
                }
            }
            return null;
        }

        public EducationService GetEducationService()
        {
            foreach (Service service in services)
            {
                if (service is EducationService)
                {
                    return (EducationService)service;
                }
            }
            return null;
        }

        public TransportationService GetTransportationService()
        {
            foreach (Service service in services)
            {
                if (service is TransportationService)
                {
                    return (TransportationService)service;
                }
            }
            return null;
        }

        public UtilitiesService GetUtilitiesService()
        {
            foreach (Service service in services)
            {
                if (service is UtilitiesService)
                {
                    return (UtilitiesService)service;
                }
            }
            return null;
        }

        /// <summary>
        /// Activate a service
        /// </summary>
        public void ActivateService(int serviceId)
        {
            Service service = FindServiceById(serviceId);
            if (service != null)
            {
                service.ActivateService();
            }
            else
            {
                Console.WriteLine("❌ Service not found!");
            }
        }

        /// <summary>
        /// Deactivate a service
        /// </summary>
        public void DeactivateService(int serviceId)
        {
            Service service = FindServiceById(serviceId);
            if (service != null)
            {
                service.DeactivateService();
            }
            else
            {
                Console.WriteLine("❌ Service not found!");
            }
        }

        /// <summary>
        /// Show service menu
        /// </summary>
        public void ShowServiceMenu()
        {
            Console.WriteLine("\n===== City Services =====");
            Console.WriteLine("101. Healthcare Service (Standard)");
            Console.WriteLine("102. Healthcare Service (Premium)");
            Console.WriteLine("103. Education Service (Standard)");
            Console.WriteLine("104. Education Service (Premium)");
            Console.WriteLine("105. Transportation Service");
            Console.WriteLine("106. Utilities Service");
            Console.WriteLine("0. Back to Main Menu");
        }

        /// <summary>
        /// Check service type and provide information
        /// Demonstrates: instanceof pattern (C# 'is' operator)
        /// </summary>
        public void CheckServiceDetails(int serviceId)
        {
            Service service = FindServiceById(serviceId);
            if (service != null)
            {
                ServiceFactory.DisplayServiceTypeInfo(service);
            }
            else
            {
                Console.WriteLine("❌ Service not found!");
            }
        }

        /// <summary>
        /// Upgrade service to premium
        /// Demonstrates: Type checking and conditional logic based on service type
        /// </summary>
        public void AttemptServiceUpgrade(int standardServiceId)
        {
            Service service = FindServiceById(standardServiceId);
            if (service != null)
            {
                ServiceFactory.UpgradeServiceToPremium(service);
            }
            else
            {
                Console.WriteLine("❌ Service not found!");
            }
        }

        /// <summary>
        /// Display all services with premium/standard indicators
        /// </summary>
        public void DisplayAllServicesWithTypes()
        {
            Console.WriteLine("\n===== All City Services (Module 7) =====");
            Console.WriteLine($"Total Services: {Service.TotalServicesCreated}");
            Console.WriteLine($"Premium Services: {Service.TotalPremiumServices}");
            Console.WriteLine($"Standard Services: {Service.TotalServicesCreated - Service.TotalPremiumServices}\n");

            for (int i = 0; i < services.Count; i++)
            {
                Service service = services[i];
                string serviceType = ServiceFactory.IsPremiumService(service) ? "🌟 PREMIUM" : "📋 STANDARD";
                Console.WriteLine($"\n[{i + 1}] {serviceType} - {service.ServiceName}");
                service.DisplayServiceInfo();
            }
        }

        /// <summary>
        /// Demonstrate premium service benefits
        /// Uses instanceof to check if service is premium
        /// </summary>
        public void ShowPremiumBenefits(int serviceId, string userName)
        {
            Service service = FindServiceById(serviceId);
            
            if (service == null)
            {
                Console.WriteLine("❌ Service not found!");
                return;
            }

            // Using instanceof operator to check if premium
            if (ServiceFactory.IsPremiumService(service))
            {
                PremiumService premiumService = (PremiumService)service;
                premiumService.ProvidePremiumBenefits(userName);
            }
            else
            {
                Console.WriteLine($"❌ {service.ServiceName} is not a Premium service!");
            }
        }

        /// <summary>
        /// Display factory-created service registry
        /// </summary>
        public void DisplayServiceRegistry()
        {
            ServiceFactory.DisplayServiceRegistry();
        }    }
}