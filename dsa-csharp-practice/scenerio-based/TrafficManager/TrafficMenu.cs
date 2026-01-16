using System;

namespace TrafficManager
{
    public class TrafficMenu
    {
        private TrafficManagerUtility roundabout;

        public TrafficMenu()
        {
            roundabout = new TrafficManagerUtility(5);
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n=== Traffic Manager ===");
                Console.WriteLine("1. Add vehicle to waiting queue");
                Console.WriteLine("2. Move vehicle from queue to roundabout");
                Console.WriteLine("3. Remove vehicle from roundabout");
                Console.WriteLine("4. Display roundabout");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        roundabout.AddCarToQueue();   // ✅ utility handles queue
                        break;

                    case 2:
                        roundabout.MoveCarToRoundabout();  // ✅ no arguments
                        break;

                    case 3:
                        roundabout.RemoveCarFromRoundabout();
                        break;

                    case 4:
                        roundabout.DisplayRoundabout();
                        break;

                    case 0:
                        Console.WriteLine("Exiting Traffic Manager...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }
    }
}

