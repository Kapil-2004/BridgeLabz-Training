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
        /// Module 8: City Service Hierarchy (Inheritance & Polymorphism)
        /// Topics: Inheritance, Object class methods, method overriding & overloading
        /// 
        /// This program demonstrates:
        /// - this keyword in constructors for clarity
        /// - super (base) keyword to call parent class methods
        /// - Static variables tracking total services globally
        /// - instanceof (is operator) for type checking
        /// - Factory pattern for object creation
        /// - Premium vs Standard service differentiation
        /// - Inheritance hierarchies with Service base class
        /// - Object class overrides (ToString, Equals, GetHashCode)
        /// - Method overriding for specialized behaviors
        /// - Method overloading for flexible service booking
        /// </summary>
        static void Main(string[] args)
        {
            // ===== INSTANCE VARIABLES: Collections for objects =====
            List<Citizen> citizens = new List<Citizen>();
            ServiceManagementService serviceManager = new ServiceManagementService();

            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════════╗");
                Console.WriteLine("║  TechVille Smart City System (Module 9)    ║");
                Console.WriteLine("║ Interfaces, Abstract Classes, Polymorphism ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. City Services");
                Console.WriteLine("3. Emergency Services (Module 8)");
                Console.WriteLine("4. Routine Services (Module 8)");
                Console.WriteLine("5. Service Booking Demo (Overloading)");
                Console.WriteLine("6. Service Providers & Plugin System (Module 9)");
                Console.WriteLine("0. Exit");
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
                            EmergencyServicesMenu();
                            break;

                        case 4:
                            RoutineServicesMenu();
                            break;

                        case 5:
                            ServiceBookingDemo();
                            break;

                        case 6:
                            ServiceProviderPluginMenu();
                            break;

                        case 0:
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
                            Console.WriteLine("✨ Specialist consultation feature is available in Premium Healthcare services!");
                            break;

                        case 6:
                            Console.WriteLine("✨ Premium benefits feature is available in Premium Healthcare services!");
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
                            Console.WriteLine("✨ Advanced courses feature is available in Premium Education services!");
                            break;

                        case 5:
                            Console.WriteLine("✨ Premium benefits feature is available in Premium Education services!");
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

        // ===== MODULE 8: EMERGENCY SERVICES MENU =====

        static void EmergencyServicesMenu()
        {
            // Create emergency services
            EmergencyService fireService = new EmergencyService(
                201, "Fire Department", "Emergency fire response and rescue",
                1000000, 5, true, "Fire");

            EmergencyService ambulanceService = new EmergencyService(
                202, "Ambulance Service", "Medical emergency response",
                800000, 10, true, "Medical");

            EmergencyService policeService = new EmergencyService(
                203, "Police Service", "Law enforcement and public safety",
                1200000, 8, false, "Police");

            List<EmergencyService> emergencyServices = new List<EmergencyService> 
            { 
                fireService, ambulanceService, policeService 
            };

            while (true)
            {
                Console.WriteLine("\n🚨 ===== EMERGENCY SERVICES (Module 8) ===== 🚨");
                Console.WriteLine("Demonstrates: Inheritance, Method Overriding, Specialized Behavior");
                Console.WriteLine("\n1. View All Emergency Services");
                Console.WriteLine("2. Respond to Fire Emergency");
                Console.WriteLine("3. Request Ambulance");
                Console.WriteLine("4. Contact Police");
                Console.WriteLine("5. Service Comparison (Object equals method)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n🚨 All Emergency Services:");
                            foreach (EmergencyService service in emergencyServices)
                            {
                                Console.WriteLine($"\n{service.ToString()}");
                                service.DisplayServiceInfo();
                            }
                            break;

                        case 2:
                            Console.Write("Enter location: ");
                            string fireLocation = Console.ReadLine() ?? "Unknown";
                            fireService.RespondToEmergencyCall(fireLocation, "High");
                            break;

                        case 3:
                            Console.Write("Enter location: ");
                            string medicalLocation = Console.ReadLine() ?? "Unknown";
                            ambulanceService.RespondToEmergencyCall(medicalLocation, "High");
                            break;

                        case 4:
                            Console.Write("Enter location: ");
                            string crimeLocation = Console.ReadLine() ?? "Unknown";
                            policeService.RespondToEmergencyCall(crimeLocation, "Medium");
                            break;

                        case 5:
                            // Demonstrate Equals() method from Object class
                            Console.WriteLine("\n📊 Service Comparison (using Equals override):");
                            Console.WriteLine($"Fire Service equals Fire Service: {fireService.Equals(fireService)}");
                            Console.WriteLine($"Fire Service equals Ambulance: {fireService.Equals(ambulanceService)}");
                            
                            // Create another fire service with same ID
                            EmergencyService fireService2 = new EmergencyService(
                                201, "Fire Department Alt", "Alternative fire response",
                                1000000, 5, true, "Fire");
                            Console.WriteLine($"Fire Service (ID:201) equals Fire Service Alt (ID:201): {fireService.Equals(fireService2)}");
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
            }
        }

        // ===== MODULE 8: ROUTINE SERVICES MENU =====

        static void RoutineServicesMenu()
        {
            // Create routine services
            RoutineService polyclinicService = new RoutineService(
                301, "City Polyclinic", "General medical services",
                500000, "9 AM - 5 PM", 30, "Healthcare", true);

            RoutineService libraryService = new RoutineService(
                302, "Public Library", "Reading and reference services",
                200000, "10 AM - 6 PM", 100, "Education", false);

            RoutineService busService = new RoutineService(
                303, "City Bus Transport", "Daily public transportation",
                600000, "6 AM - 10 PM", 500, "Transportation", false);

            List<RoutineService> routineServices = new List<RoutineService> 
            { 
                polyclinicService, libraryService, busService 
            };

            while (true)
            {
                Console.WriteLine("\n📋 ===== ROUTINE SERVICES (Module 8) ===== 📋");
                Console.WriteLine("Demonstrates: Inheritance, Standard Procedures, Appointment Booking");
                Console.WriteLine("\n1. View All Routine Services");
                Console.WriteLine("2. Book Polyclinic Appointment");
                Console.WriteLine("3. Check Library Availability");
                Console.WriteLine("4. Check Bus Service Status");
                Console.WriteLine("5. Service Details (Object toString method)");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n📋 All Routine Services:");
                            foreach (RoutineService service in routineServices)
                            {
                                Console.WriteLine($"\n{service.ToString()}");
                                service.DisplayServiceInfo();
                            }
                            break;

                        case 2:
                            Console.Write("Enter citizen name: ");
                            string citizenName = Console.ReadLine() ?? "Citizen";
                            if (polyclinicService.BookAppointment(citizenName))
                            {
                                Console.WriteLine($"   Appointment booked at: {DateTime.Now.AddDays(1):yyyy-MM-dd 10:00}");
                            }
                            break;

                        case 3:
                            libraryService.CheckStatus();
                            break;

                        case 4:
                            busService.CheckStatus();
                            break;

                        case 5:
                            // Demonstrate ToString() override from Object class
                            Console.WriteLine("\n📊 Routine Service Details (using ToString override):");
                            foreach (RoutineService service in routineServices)
                            {
                                Console.WriteLine(service.ToString());
                            }
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
            }
        }

        // ===== MODULE 8: SERVICE BOOKING DEMO (Method Overloading) =====

        static void ServiceBookingDemo()
        {
            // Create a routine service for booking
            RoutineService hospitalService = new RoutineService(
                401, "City Hospital", "Hospital services",
                1500000, "24/7", 100, "Healthcare", true);

            ServiceBooking booking = new ServiceBooking(hospitalService);

            while (true)
            {
                Console.WriteLine("\n📅 ===== SERVICE BOOKING DEMO (Module 8) ===== 📅");
                Console.WriteLine("Demonstrates: Method Overloading with different parameter combinations");
                Console.WriteLine("\n1. Book with Name Only");
                Console.WriteLine("2. Book with Name and Date");
                Console.WriteLine("3. Book with Name, Date, and Priority");
                Console.WriteLine("4. Book with Name, Date, Priority, and Duration");
                Console.WriteLine("5. Book with Citizen ID and Details");
                Console.WriteLine("6. Book with Complete Details (ID, Name, Date, Priority, Notes)");
                Console.WriteLine("7. Cancel Booking by Name");
                Console.WriteLine("8. Cancel Booking by Citizen ID");
                Console.WriteLine("9. View All Bookings");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter citizen name: ");
                            string name1 = Console.ReadLine() ?? "Patient";
                            booking.BookService(name1);
                            break;

                        case 2:
                            Console.Write("Enter citizen name: ");
                            string name2 = Console.ReadLine() ?? "Patient";
                            Console.Write("Enter booking date (yyyy-MM-dd HH:mm): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date2))
                            {
                                booking.BookService(name2, date2);
                            }
                            else
                            {
                                Console.WriteLine("❌ Invalid date format!");
                            }
                            break;

                        case 3:
                            Console.Write("Enter citizen name: ");
                            string name3 = Console.ReadLine() ?? "Patient";
                            Console.Write("Enter booking date (yyyy-MM-dd HH:mm): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date3))
                            {
                                Console.Write("Enter priority (High/Normal/Low): ");
                                string priority3 = Console.ReadLine() ?? "Normal";
                                booking.BookService(name3, date3, priority3);
                            }
                            else
                            {
                                Console.WriteLine("❌ Invalid date format!");
                            }
                            break;

                        case 4:
                            Console.Write("Enter citizen name: ");
                            string name4 = Console.ReadLine() ?? "Patient";
                            Console.Write("Enter booking date (yyyy-MM-dd HH:mm): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime date4))
                            {
                                Console.Write("Enter priority (High/Normal/Low): ");
                                string priority4 = Console.ReadLine() ?? "Normal";
                                Console.Write("Enter duration (minutes): ");
                                if (int.TryParse(Console.ReadLine(), out int duration4))
                                {
                                    booking.BookService(name4, date4, priority4, duration4);
                                }
                            }
                            break;

                        case 5:
                            Console.Write("Enter citizen ID: ");
                            if (int.TryParse(Console.ReadLine(), out int id5))
                            {
                                Console.Write("Enter citizen name: ");
                                string name5 = Console.ReadLine() ?? "Patient";
                                Console.Write("Enter booking date (yyyy-MM-dd HH:mm): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime date5))
                                {
                                    booking.BookService(id5, name5, date5);
                                }
                            }
                            break;

                        case 6:
                            Console.Write("Enter citizen ID: ");
                            if (int.TryParse(Console.ReadLine(), out int id6))
                            {
                                Console.Write("Enter citizen name: ");
                                string name6 = Console.ReadLine() ?? "Patient";
                                Console.Write("Enter booking date (yyyy-MM-dd HH:mm): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime date6))
                                {
                                    Console.Write("Enter priority (High/Normal/Low): ");
                                    string priority6 = Console.ReadLine() ?? "Normal";
                                    Console.Write("Enter notes: ");
                                    string notes6 = Console.ReadLine() ?? "";
                                    booking.BookService(id6, name6, date6, priority6, notes6);
                                }
                            }
                            break;

                        case 7:
                            Console.Write("Enter citizen name to cancel: ");
                            string cancelName = Console.ReadLine() ?? "";
                            booking.CancelBooking(cancelName);
                            break;

                        case 8:
                            Console.Write("Enter citizen ID to cancel: ");
                            if (int.TryParse(Console.ReadLine(), out int cancelId))
                            {
                                booking.CancelBooking(cancelId);
                            }
                            break;

                        case 9:
                            booking.DisplayAllBookings();
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
                    Console.WriteLine("❌ Invalid input!");
                    CitizenUtility.LogError(ex);
                }
            }
        }

        /// <summary>
        /// Module 9: Service Provider Plugin System
        /// Demonstrates: Interfaces, Abstract Classes, Polymorphism
        /// Shows interface-based plugin architecture with external service providers
        /// </summary>
        static void ServiceProviderPluginMenu()
        {
            ServicePluginManager pluginManager = new ServicePluginManager();

            // Register service providers (plugins)
            CityHealthcareProvider healthProvider = new CityHealthcareProvider("TechVille Healthcare", 500000, 50);
            PrivateTransportProvider transportProvider = new PrivateTransportProvider("Express Transport Co.", 300000, 30);
            ExternalUtilitiesProvider electricityProvider = new ExternalUtilitiesProvider("PowerGrid Solutions", 200000, "Electricity");
            ExternalUtilitiesProvider waterProvider = new ExternalUtilitiesProvider("AquaFlow Services", 150000, "Water");

            pluginManager.RegisterProvider("HC001", healthProvider);
            pluginManager.RegisterProvider("TR001", transportProvider);
            pluginManager.RegisterProvider("EL001", electricityProvider);
            pluginManager.RegisterProvider("WR001", waterProvider);

            while (true)
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
                Console.WriteLine("║  Module 9: Service Provider Plugin System   ║");
                Console.WriteLine("║  Interfaces & Polymorphism Demo             ║");
                Console.WriteLine("╚═══════════════════════════════════════════════╝");
                Console.WriteLine("\n--- Service Provider Menu ---");
                Console.WriteLine("1. Display All Registered Providers");
                Console.WriteLine("2. Display Provider Performance Comparison");
                Console.WriteLine("3. Book Service through Provider");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("5. Track Service");
                Console.WriteLine("6. Generate Provider Report");
                Console.WriteLine("7. Service Provider Demonstration");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            // ===== DEMONSTRATE: IServiceProvider Interface =====
                            pluginManager.DisplayAllProviders();
                            break;

                        case 2:
                            // ===== DEMONSTRATE: Polymorphic Behavior (ITrackable) =====
                            pluginManager.DisplayPerformanceComparison();
                            break;

                        case 3:
                            // ===== DEMONSTRATE: Polymorphic Booking (IBookable) =====
                            Console.WriteLine("\n📋 Available Providers for Booking:");
                            Console.WriteLine("HC001 - Healthcare (IBookable, ICancellable, ITrackable)");
                            Console.WriteLine("TR001 - Transport (IBookable, ITrackable)");
                            Console.Write("\nEnter Provider ID: ");
                            string bookProviderId = Console.ReadLine();

                            Console.Write("Enter Citizen Name: ");
                            string bookCitizen = Console.ReadLine();

                            pluginManager.BookServiceThroughProvider(bookProviderId, bookCitizen);
                            break;

                        case 4:
                            // ===== DEMONSTRATE: Polymorphic Cancellation (ICancellable) =====
                            Console.WriteLine("\n❌ Cancel Service (Only Healthcare supports cancellation)");
                            Console.Write("Enter Provider ID: ");
                            string cancelProviderId = Console.ReadLine();

                            Console.Write("Enter Booking ID to Cancel: ");
                            string bookingToCancel = Console.ReadLine();

                            pluginManager.CancelServiceThroughProvider(cancelProviderId, bookingToCancel);
                            break;

                        case 5:
                            // ===== DEMONSTRATE: Polymorphic Tracking (ITrackable) =====
                            Console.WriteLine("\n🔍 Track Service (All providers support tracking)");
                            Console.Write("Enter Provider ID: ");
                            string trackProviderId = Console.ReadLine();

                            Console.Write("Enter Booking/Connection ID: ");
                            string trackingId = Console.ReadLine();

                            pluginManager.TrackServiceThroughProvider(trackProviderId, trackingId);
                            break;

                        case 6:
                            // ===== DEMONSTRATE: Polymorphic Reporting (IReportable) =====
                            Console.WriteLine("\n📊 Generate Report (Healthcare & Utilities support reporting)");
                            Console.Write("Enter Provider ID: ");
                            string reportProviderId = Console.ReadLine();

                            pluginManager.GenerateReportFromProvider(reportProviderId);
                            break;

                        case 7:
                            // ===== FULL DEMONSTRATION: Multiple Providers with Different Interfaces =====
                            DemonstrateServiceProviders(pluginManager, healthProvider, transportProvider, electricityProvider);
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("❌ Invalid option!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Invalid input!");
                }
            }
        }

        /// <summary>
        /// Comprehensive demonstration of Module 9 concepts
        /// Shows polymorphic behavior across different interface implementations
        /// </summary>
        static void DemonstrateServiceProviders(ServicePluginManager manager, 
            CityHealthcareProvider healthcare, 
            PrivateTransportProvider transport,
            ExternalUtilitiesProvider electricity)
        {
            Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║  Full Polymorphism Demonstration               ║");
            Console.WriteLine("║  Same code, different provider implementations  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");

            // Sample citizens to serve
            string[] citizens = { "Raj Kumar", "Priya Singh", "Ahmed Hassan", "Lisa Wong" };

            // ===== POLYMORPHIC SERVICE PROVISION =====
            Console.WriteLine("\n🎯 Step 1: Polymorphic Service Provision");
            Console.WriteLine("(All providers implement ProvideService() differently)");
            foreach (var citizen in citizens)
            {
                healthcare.ProvideService(citizen);
            }
            for (int i = 0; i < 3; i++)
            {
                transport.ProvideService(citizens[i]);
            }

            // ===== POLYMORPHIC BOOKING (IBookable) =====
            Console.WriteLine("\n\n📅 Step 2: Polymorphic Interface - IBookable");
            Console.WriteLine("(Different providers with same interface, different implementations)");
            
            if (healthcare is IBookable healthBookable)
            {
                Console.WriteLine($"\n🏥 Healthcare Provider Slots:");
                Console.WriteLine($"   Available: {healthBookable.GetAvailableSlots()}");
                Console.WriteLine($"   Capacity: {healthBookable.GetMaxCapacity()}");
            }

            if (transport is IBookable transportBookable)
            {
                Console.WriteLine($"\n🚕 Transport Provider Slots:");
                Console.WriteLine($"   Available: {transportBookable.GetAvailableSlots()}");
                Console.WriteLine($"   Capacity: {transportBookable.GetMaxCapacity()}");
            }

            // ===== POLYMORPHIC CANCELLATION (ICancellable) =====
            Console.WriteLine("\n\n❌ Step 3: Polymorphic Interface - ICancellable");
            Console.WriteLine("(Not all providers implement this!)");
            
            if (healthcare is ICancellable healthCancellable)
            {
                Console.WriteLine($"\n✅ Healthcare supports cancellation!");
                Console.WriteLine($"   Deadline: {healthCancellable.GetCancellationDeadlineHours()} hours");
                Console.WriteLine($"   Cancellation allowed: {healthCancellable.IsCancellationAllowed()}");
            }

            if (transport is ICancellable transportCancellable)
            {
                Console.WriteLine($"\n🚕 Transport supports cancellation!");
            }
            else
            {
                Console.WriteLine($"\n🚕 Transport does NOT implement ICancellable");
            }

            if (electricity is ICancellable utilityCancellable)
            {
                Console.WriteLine($"\n⚡ Utilities support cancellation!");
            }
            else
            {
                Console.WriteLine($"\n⚡ Utilities do NOT implement ICancellable");
            }

            // ===== POLYMORPHIC TRACKING (ITrackable) =====
            Console.WriteLine("\n\n🔍 Step 4: Polymorphic Interface - ITrackable");
            Console.WriteLine("(All providers implement tracking differently)");
            
            List<ServiceProvider> trackables = new List<ServiceProvider> { healthcare, transport, electricity };
            foreach (var provider in trackables)
            {
                if (provider is ITrackable trackable)
                {
                    Console.WriteLine($"\n✓ {provider.GetProviderName()}");
                    Console.WriteLine($"  Status: {trackable.GetServiceStatus()}");
                }
            }

            // ===== POLYMORPHIC REPORTING (IReportable) =====
            Console.WriteLine("\n\n📊 Step 5: Polymorphic Interface - IReportable");
            Console.WriteLine("(Service implementations for analytics)");
            
            if (healthcare is IReportable healthReportable)
            {
                Console.WriteLine($"\n🏥 {healthcare.GetProviderName()} Report:");
                Console.WriteLine($"   {healthReportable.GenerateReport()}");
            }

            if (electricity is IReportable utilReportable)
            {
                Console.WriteLine($"\n⚡ {electricity.GetProviderName()} Report:");
                Console.WriteLine($"   {utilReportable.GenerateReport()}");
            }

            // ===== ABSTRACT CLASS IMPLEMENTATION =====
            Console.WriteLine("\n\n🏛️  Step 6: Abstract Class - Encapsulation & Common Functionality");
            Console.WriteLine("(ServiceProvider base class provides shared implementation)");
            
            Console.WriteLine($"\n📌 All providers share these features:");
            foreach (var provider in trackables)
            {
                Console.WriteLine($"\n  • {provider.GetProviderName()}");
                Console.WriteLine($"    Status: {(provider.IsOperational() ? "✅ Online" : "❌ Offline")}");
                Console.WriteLine($"    Rating: {provider.GetProviderRating():F1}/5.0");
                provider.DisplayDetailedStatus();
            }

            Console.WriteLine("\n\n✅ Module 9 Demonstration Complete!");
            Console.WriteLine("Key Concepts Shown:");
            Console.WriteLine("  ✓ Interfaces define contracts (IBookable, ICancellable, ITrackable, IReportable)");
            Console.WriteLine("  ✓ Abstract base class provides common functionality (ServiceProvider)");
            Console.WriteLine("  ✓ Polymorphism allows different implementations of same interface");
            Console.WriteLine("  ✓ Optional interface implementation (not all providers implement all)");
            Console.WriteLine("  ✓ Plugin architecture - providers can be swapped dynamically");
            Console.WriteLine("  ✓ Encapsulation - private attributes with public properties");
        }
    }
}
