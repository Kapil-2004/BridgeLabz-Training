using System;
using System.Diagnostics.Contracts;

namespace FitnessTracker
{
    public class FitnessTrackerMenu
    {
        public void ShowMenu()
        {
            FitnessTrackerUtility utility = new FitnessTrackerUtility();
            bool exit = true;
            do
            {
                Console.WriteLine("Welcome to the Fitness Tracker!");
                Console.WriteLine("1. Add a Runner");
                Console.WriteLine("2. Show Rankings");
                Console.WriteLine("3. Sort Users by Steps");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.AddRunner();
                        break;
                    case 2:
                        utility.ShowRankings();
                        break;              
                    case 3:
                        utility.SortUsersBySteps();
                        break;
                    case 4:
                        exit = false;   
                        Console.WriteLine("Exiting Fitness Tracker...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again."); 
                        break;
                }
                
                
            } while (exit);
        }
    }
}