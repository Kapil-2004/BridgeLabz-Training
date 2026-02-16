using System;
using TechVille.Modules;
using TechVille.Services;
using TechVille.Utilities;

namespace TechVille
{
    class Program
    {
        /// <summary>
        /// Module 5: This program registers citizens safely using exception handling.
        /// It prevents invalid age and duplicate IDs using custom exceptions.
        /// It also logs errors into a text file without crashing the program.
        /// </summary>
        static void Main(string[] args)
        {
            Citizen[] citizens = new Citizen[100];
            int count = 0;

            while (true)
            {
                Console.WriteLine("\n===== TechVille Smart City System (Module 5) =====");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. Display All Citizens");
                Console.WriteLine("3. Show Total Citizens");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 0)
                    {
                        Console.WriteLine("Exiting TechVille...");
                        break;
                    }

                    switch (choice)
                    {
                        case 1:
                            CitizenRegistrationService.RegisterCitizen(citizens, ref count);
                            break;

                        case 2:
                            CitizenProfileProcess.DisplayAllCitizens(citizens, count);
                            break;

                        case 3:
                            CitizenPopulationManager.ShowTotalCitizens(count);
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
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
    }
}
