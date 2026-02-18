using System;
using TechVille.Services;
using TechVille.Utilities;

namespace TechVille
{
    public class TechVilleMain
    {
        public static void Start()
        {
            Console.Title = "TechVille Smart City Management System";

            // Load citizens on start
            CitizenService.LoadFromFile();

            while (true)
            {
                TechVilleMenu.ShowMenu();
                int choice = InputHelper.ReadInt("Enter your choice: ");

                try
                {
                    switch (choice)
                    {
                        case 1:
                            CitizenService.AddCitizen();
                            break;

                        case 2:
                            CitizenService.DisplayAllCitizens();
                            break;

                        case 3:
                            CitizenService.SearchCitizen();
                            break;

                        case 4:
                            CitizenService.UpdateCitizen();
                            break;

                        case 5:
                            CitizenService.DeleteCitizen();
                            break;

                        case 6:
                            ServiceManager.AssignServicePlan();
                            break;

                        case 7:
                            Summary.ShowSummary();
                            break;

                        case 8:
                            CitizenService.SaveToFile();
                            Console.WriteLine("\n✅ Data Saved! Exiting...");
                            return;

                        default:
                            Console.WriteLine("❌ Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    Console.WriteLine("❌ ERROR: " + ex.Message);
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
