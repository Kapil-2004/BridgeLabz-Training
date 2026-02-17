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
        /// Initialize default services
        /// </summary>
        private void InitializeServices()
        {
            // Create Healthcare Service
            HealthcareService healthcare = new HealthcareService(
                101,
                "Primary health center for TechVille",
                500000.0,
                50,
                20,
                "General Medicine"
            );
            services.Add(healthcare);

            // Create Education Service
            EducationService education = new EducationService(
                102,
                "Public education system for TechVille",
                800000.0,
                5,
                100,
                new string[] { "Primary", "Secondary", "Higher Secondary" }
            );
            services.Add(education);

            // Create Transportation Service
            TransportationService transportation = new TransportationService(
                103,
                "Public transportation network",
                400000.0,
                20,
                10,
                5.0
            );
            services.Add(transportation);

            // Create Utilities Service
            UtilitiesService utilities = new UtilitiesService(
                104,
                "Water, electricity, and waste management",
                600000.0,
                5000,
                8000,
                85.5,
                new string[] { "Water Supply", "Electricity", "Waste Management", "Drainage" }
            );
            services.Add(utilities);

            Console.WriteLine($"✅ {Service.TotalServicesCreated} services initialized!\n");
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
            Console.WriteLine("101. Healthcare Service");
            Console.WriteLine("102. Education Service");
            Console.WriteLine("103. Transportation Service");
            Console.WriteLine("104. Utilities Service");
            Console.WriteLine("0. Back to Main Menu");
        }
    }
}
