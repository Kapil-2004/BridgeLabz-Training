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
        /// Module 6: City Services Framework (OOP Basics)
        /// Topics: Classes, Objects, Constructors, Access Modifiers, Inheritance, Polymorphism
        /// 
        /// This program demonstrates:
        /// - Design of Citizen class with private attributes and public methods
        /// - Service base class with abstract methods
        /// - Specific service implementations (Healthcare, Education, Transportation, Utilities)
        /// - Difference between classes and objects (multiple Citizen objects from one class)
        /// - Instance variables (unique to each Citizen object)
        /// - Class variables (shared across all Service objects)
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
                Console.WriteLine("\n--- City Services Management ---");
                Console.WriteLine("1. View All Services");
                Console.WriteLine("2. Access Healthcare Service");
                Console.WriteLine("3. Access Education Service");
                Console.WriteLine("4. Access Transportation Service");
                Console.WriteLine("5. Access Utilities Service");
                Console.WriteLine("6. Provide Service to Citizen");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            serviceManager.DisplayAllServices();
                            break;

                        case 2:
                            AccessHealthcareService(serviceManager);
                            break;

                        case 3:
                            AccessEducationService(serviceManager);
                            break;

                        case 4:
                            AccessTransportationService(serviceManager);
                            break;

                        case 5:
                            AccessUtilitiesService(serviceManager);
                            break;

                        case 6:
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

        // ===== HEALTHCARE SERVICE SUBMENU =====

        static void AccessHealthcareService(ServiceManagementService serviceManager)
        {
            HealthcareService healthcare = serviceManager.GetHealthcareService();

            if (healthcare == null)
            {
                Console.WriteLine("❌ Healthcare service not available!");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n--- Healthcare Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Check Bed Availability");
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
                            string patientName = Console.ReadLine();
                            healthcare.AdmitPatient(patientName);
                            break;

                        case 3:
                            Console.Write("Enter patient name: ");
                            string dischargePatient = Console.ReadLine();
                            healthcare.DischargePatient(dischargePatient);
                            break;

                        case 4:
                            if (healthcare.AreBedAvailable())
                                Console.WriteLine("✅ Beds are available!");
                            else
                                Console.WriteLine("❌ No beds available!");
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
            EducationService education = serviceManager.GetEducationService();

            if (education == null)
            {
                Console.WriteLine("❌ Education service not available!");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n--- Education Service ---");
                Console.WriteLine("1. View Service Details");
                Console.WriteLine("2. Enroll Student");
                Console.WriteLine("3. View Programs");
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
                            string studentName = Console.ReadLine();
                            education.EnrollStudent(studentName);
                            break;

                        case 3:
                            education.DisplayPrograms();
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
