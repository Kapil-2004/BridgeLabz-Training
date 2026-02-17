using System;
using System.Collections.Generic;
using TechVille.Modules;
using TechVille.Services;
using TechVille.Utilities;

namespace TechVille
{
    class Program
    {
        /// <summary>
        /// Module 7: Advanced Service Architecture (Advanced OOP)
        /// Topics: this and super (base) keywords, instanceof (is operator),
        ///         static variables/methods, factory pattern
        /// 
        /// This program demonstrates:
        /// - this keyword in constructors for clarity
        /// - super (base) keyword to call parent class methods
        /// - Static variables tracking total services globally
        /// - instanceof (is operator) for type checking
        /// - Factory pattern for object creation
        /// - Premium vs Standard service differentiation
        /// </summary>
        static void Main(string[] args)
        {
            // ===== INSTANCE VARIABLES: Collections for objects =====
            List<Citizen> citizens = new List<Citizen>();
            ServiceManagementService serviceManager = new ServiceManagementService();

            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════════╗");
                Console.WriteLine("║   TechVille Smart City System (Module 6)   ║");
                Console.WriteLine("║   OOP Basics - Classes, Objects & Services  ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. City Services");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                try
                {
                    int mainChoice = Convert.ToInt32(Console.ReadLine());

                    switch (mainChoice)
                    {
                        case 1:
                            CitizenManagementMenu(citizens);
                            break;

                        case 2:
                            CityServicesMenu(serviceManager, citizens);
                            break;

                        case 3:
                            Console.WriteLine("\n👋 Thank you for using TechVille! Goodbye!");
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("❌ Please enter a valid number!");
                    CitizenUtility.LogError(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Unexpected error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
                finally
                {
                    Console.WriteLine("---- Operation Completed ----");
                }
            }
        }

        // ===== CITIZEN MANAGEMENT MENU =====

        static void CitizenManagementMenu(List<Citizen> citizens)
        {
            while (true)
            {
                Console.WriteLine("\n--- Citizen Management ---");
                Console.WriteLine("1. Register New Citizen");
                Console.WriteLine("2. Display All Citizens");
                Console.WriteLine("3. Show Population Statistics");
                Console.WriteLine("4. Search Citizen by ID");
                Console.WriteLine("5. Check Citizen Benefits");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CitizenRegistrationService.RegisterCitizen(citizens);
                            break;

                        case 2:
                            CitizenProfileProcess.DisplayAllCitizens(citizens);
                            break;

                        case 3:
                            CitizenPopulationManager.ShowTotalCitizens(citizens);
                            CitizenPopulationManager.ShowCitizenStatistics(citizens);
                            break;

                        case 4:
                            SearchCitizen(citizens);
                            break;

                        case 5:
                            CheckCitizenBenefits(citizens);
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("❌ Please enter a valid number!");
                    CitizenUtility.LogError(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== CITY SERVICES MENU =====

        static void CityServicesMenu(ServiceManagementService serviceManager, List<Citizen> citizens)
        {
            while (true)
            {
                Console.WriteLine("\n--- City Services Management (Module 7) ---");
                Console.WriteLine("1. View All Services (Standard + Premium)");
                Console.WriteLine("2. Service Registry & Statistics");
                Console.WriteLine("3. Check Service Type (instanceof demo)");
                Console.WriteLine("4. Show Premium Benefits");
                Console.WriteLine("5. Attempt Service Upgrade");
                Console.WriteLine("6. Access Healthcare Service");
                Console.WriteLine("7. Access Education Service");
                Console.WriteLine("8. Access Transportation Service");
                Console.WriteLine("9. Access Utilities Service");
                Console.WriteLine("10. Provide Service to Citizen");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            serviceManager.DisplayAllServicesWithTypes();
                            break;

                        case 2:
                            serviceManager.DisplayServiceRegistry();
                            Service.DisplayServiceStatistics();
                            break;

                        case 3:
                            CheckServiceType(serviceManager);
                            break;

                        case 4:
                            ShowPremiumBenefits(serviceManager);
                            break;

                        case 5:
                            AttemptUpgrade(serviceManager);
                            break;

                        case 6:
                            AccessHealthcareService(serviceManager);
                            break;

                        case 7:
                            AccessEducationService(serviceManager);
                            break;

                        case 8:
                            AccessTransportationService(serviceManager);
                            break;

                        case 9:
                            AccessUtilitiesService(serviceManager);
                            break;

                        case 10:
                            ProvideServiceToCitizen(serviceManager, citizens);
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("❌ Please enter a valid number!");
                    CitizenUtility.LogError(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== MODULE 7: ADVANCED OOP FEATURES =====

        /// <summary>
        /// Check service type using instanceof pattern
        /// Demonstrates: 'is' operator (C# instanceof), type checking
        /// </summary>
        static void CheckServiceType(ServiceManagementService serviceManager)
        {
            Console.Write("\nEnter Service ID to check: ");
            try
            {
                int serviceId = Convert.ToInt32(Console.ReadLine());
                serviceManager.CheckServiceDetails(serviceId);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter a valid ID!");
                CitizenUtility.LogError(ex);
            }
        }

        /// <summary>
        /// Display premium service benefits
        /// Demonstrates: Type casting, premium service access
        /// </summary>
        static void ShowPremiumBenefits(ServiceManagementService serviceManager)
        {
            Console.Write("\nEnter Service ID for premium benefits: ");
            try
            {
                int serviceId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter citizen name: ");
                string citizenName = Console.ReadLine() ?? "User";
                serviceManager.ShowPremiumBenefits(serviceId, citizenName);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter valid input!");
                CitizenUtility.LogError(ex);
            }
        }

        /// <summary>
        /// Attempt to upgrade a service to premium
        /// Demonstrates: Type checking, conditional upgrades
        /// </summary>
        static void AttemptUpgrade(ServiceManagementService serviceManager)
        {
            Console.Write("\nEnter Service ID to upgrade: ");
            try
            {
                int serviceId = Convert.ToInt32(Console.ReadLine());
                serviceManager.AttemptServiceUpgrade(serviceId);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter a valid ID!");
                CitizenUtility.LogError(ex);
            }
        }

        // ===== ORIGINAL SERVICE ACCESS METHODS =====

        // ===== ORIGINAL SERVICE ACCESS METHODS =====

        static void AccessHealthcareService(ServiceManagementService serviceManager)
        {
            Service service = serviceManager.FindServiceById(101);
            if (service == null)
            {
                service = serviceManager.FindServiceById(102);
            }

            HealthcareService healthcare = service as HealthcareService;
            if (healthcare == null)
            {
                Console.WriteLine("❌ Healthcare service not available!");
                return;
            }

            while (true)
            {
                // Check if this is a premium service using instanceof pattern
                bool isPremium = ServiceFactory.IsPremiumService(healthcare);
                string serviceType = isPremium ? "PREMIUM" : "STANDARD";

                Console.WriteLine($"\n--- {serviceType} Healthcare Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Check Bed Availability");
                
                if (isPremium)
                {
                    Console.WriteLine("5. View Specialists (Premium Feature)");
                    Console.WriteLine("6. Show Premium Benefits");
                }
                
                Console.WriteLine("0. Back");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            healthcare.DisplayServiceInfo();
                            break;

                        case 2:
                            Console.Write("Enter patient name: ");
                            string patientName = Console.ReadLine() ?? "Patient";
                            healthcare.AdmitPatient(patientName);
                            break;

                        case 3:
                            Console.Write("Enter patient name: ");
                            string dischargePatient = Console.ReadLine() ?? "Patient";
                            healthcare.DischargePatient(dischargePatient);
                            break;

                        case 4:
                            if (healthcare.AreBedAvailable())
                                Console.WriteLine("✅ Beds are available!");
                            else
                                Console.WriteLine("❌ No beds available!");
                            break;

                        case 5:
                            {
                                PremiumHealthcareService premium = healthcare as PremiumHealthcareService;
                                if (isPremium && premium != null)
                                {
                                    premium.DisplaySpecialists();
                                }
                                else
                                {
                                    Console.WriteLine("❌ This feature is only available in Premium services!");
                                }
                            }
                            break;

                        case 6:
                            {
                                PremiumHealthcareService premium = healthcare as PremiumHealthcareService;
                                if (isPremium && premium != null)
                                {
                                    Console.Write("Enter citizen name: ");
                                    string citizenName = Console.ReadLine() ?? "User";
                                    premium.ProvidePremiumBenefits(citizenName);
                                }
                                else
                                {
                                    Console.WriteLine("❌ Premium benefits are only available for Premium services!");
                                }
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== EDUCATION SERVICE SUBMENU =====

        static void AccessEducationService(ServiceManagementService serviceManager)
        {
            Service service = serviceManager.FindServiceById(103);
            if (service == null)
            {
                service = serviceManager.FindServiceById(104);
            }

            EducationService education = service as EducationService;
            if (education == null)
            {
                Console.WriteLine("❌ Education service not available!");
                return;
            }

            while (true)
            {
                // Check if this is a premium service using instanceof pattern
                bool isPremium = ServiceFactory.IsPremiumService(education);
                string serviceType = isPremium ? "PREMIUM" : "STANDARD";

                Console.WriteLine($"\n--- {serviceType} Education Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Enroll Student");
                Console.WriteLine("3. View Programs");
                
                if (isPremium)
                {
                    Console.WriteLine("4. View Advanced Courses (Premium Feature)");
                    Console.WriteLine("5. Show Premium Benefits");
                }
                
                Console.WriteLine("0. Back");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            education.DisplayServiceInfo();
                            break;

                        case 2:
                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine() ?? "Student";
                            education.EnrollStudent(studentName);
                            break;

                        case 3:
                            education.DisplayPrograms();
                            break;

                        case 4:
                            {
                                PremiumEducationService premium = education as PremiumEducationService;
                                if (isPremium && premium != null)
                                {
                                    premium.DisplayAdvancedCourses();
                                }
                                else
                                {
                                    Console.WriteLine("❌ This feature is only available in Premium services!");
                                }
                            }
                            break;

                        case 5:
                            {
                                PremiumEducationService premium = education as PremiumEducationService;
                                if (isPremium && premium != null)
                                {
                                    Console.Write("Enter citizen name: ");
                                    string citizenName = Console.ReadLine() ?? "User";
                                    premium.ProvidePremiumBenefits(citizenName);
                                }
                                else
                                {
                                    Console.WriteLine("❌ Premium benefits are only available for Premium services!");
                                }
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== TRANSPORTATION SERVICE SUBMENU =====

        static void AccessTransportationService(ServiceManagementService serviceManager)
        {
            TransportationService transportation = serviceManager.GetTransportationService();

            if (transportation == null)
            {
                Console.WriteLine("❌ Transportation service not available!");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n--- Transportation Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Record Passenger");
                Console.WriteLine("3. Calculate Fare");
                Console.WriteLine("0. Back");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            transportation.DisplayServiceInfo();
                            break;

                        case 2:
                            Console.Write("Enter passenger name: ");
                            string passengerName = Console.ReadLine();
                            transportation.RecordPassenger(passengerName);
                            break;

                        case 3:
                            Console.Write("Enter distance (km): ");
                            double distance = Convert.ToDouble(Console.ReadLine());
                            double fare = transportation.CalculateFare(distance);
                            Console.WriteLine($"Fare for {distance} km: ₹{fare:F2}");
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("❌ Please enter valid numbers!");
                    CitizenUtility.LogError(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== UTILITIES SERVICE SUBMENU =====

        static void AccessUtilitiesService(ServiceManagementService serviceManager)
        {
            UtilitiesService utilities = serviceManager.GetUtilitiesService();

            if (utilities == null)
            {
                Console.WriteLine("❌ Utilities service not available!");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n--- Utilities Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Check Utility Status");
                Console.WriteLine("3. Add New Connection");
                Console.WriteLine("0. Back");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            utilities.DisplayServiceInfo();
                            break;

                        case 2:
                            utilities.CheckUtilityStatus();
                            break;

                        case 3:
                            Console.Write("Enter utility type (Water/Electricity): ");
                            string utilityType = Console.ReadLine();
                            utilities.AddConnection(utilityType);
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                    CitizenUtility.LogError(ex);
                }
            }
        }

        // ===== HELPER METHODS =====

        static void SearchCitizen(List<Citizen> citizens)
        {
            Console.Write("Enter Citizen ID to search: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Citizen citizen = CitizenUtility.FindCitizenById(citizens, id);

                if (citizen != null)
                {
                    CitizenProfileProcess.DisplayCitizenDetails(citizen);
                }
                else
                {
                    Console.WriteLine("❌ Citizen not found!");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter a valid ID!");
                CitizenUtility.LogError(ex);
            }
        }

        static void CheckCitizenBenefits(List<Citizen> citizens)
        {
            Console.Write("Enter Citizen ID: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Citizen citizen = CitizenUtility.FindCitizenById(citizens, id);

                if (citizen != null)
                {
                    Console.WriteLine($"\n--- Benefits Eligibility for {citizen.Name} ---");
                    Console.WriteLine($"Senior Benefits (Age >= 60): {(citizen.IsEligibleForSeniorBenefits() ? "✅ YES" : "❌ NO")}");
                    Console.WriteLine($"Low-Income Support (Income < ₹25000): {(citizen.IsEligibleForLowIncomeSupport() ? "✅ YES" : "❌ NO")}");
                    Console.WriteLine($"Voting Rights (Age >= 18): {(citizen.IsEligibleToVote() ? "✅ YES" : "❌ NO")}");
                }
                else
                {
                    Console.WriteLine("❌ Citizen not found!");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter a valid ID!");
                CitizenUtility.LogError(ex);
            }
        }

        static void ProvideServiceToCitizen(ServiceManagementService serviceManager, List<Citizen> citizens)
        {
            if (citizens.Count == 0)
            {
                Console.WriteLine("❌ No citizens registered yet!");
                return;
            }

            Console.Write("Enter Citizen ID: ");
            try
            {
                int citizenId = Convert.ToInt32(Console.ReadLine());
                Citizen citizen = CitizenUtility.FindCitizenById(citizens, citizenId);

                if (citizen != null)
                {
                    serviceManager.ShowServiceMenu();
                    Console.Write("Select a service: ");
                    int serviceId = Convert.ToInt32(Console.ReadLine());
                    serviceManager.ProvideCitizenService(citizen.Name, serviceId);
                }
                else
                {
                    Console.WriteLine("❌ Citizen not found!");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Please enter valid numbers!");
                CitizenUtility.LogError(ex);
            }
        }
    }
}
