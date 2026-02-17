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
                Console.WriteLine("║   TechVille Smart City System (Module 8)   ║");
                Console.WriteLine("║ Inheritance, Overriding, Overloading       ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. City Services");
                Console.WriteLine("3. Emergency Services (Module 8)");
                Console.WriteLine("4. Routine Services (Module 8)");
                Console.WriteLine("5. Service Booking Demo (Overloading)");
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
                            {
                                if (healthcare is PremiumHealthcareService premium)
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
                                if (healthcare is PremiumHealthcareService premium)
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
                                if (education is PremiumEducationService premium)
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
                                if (education is PremiumEducationService premium)
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
    }
}
