using System;

namespace AmbulanceRoute
{
    public class AmbulanceRouteMenu
    {
        private AmbulanceRouteUtility util;

        public AmbulanceRouteMenu()
        {
            util = new AmbulanceRouteUtility();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Ambulance Route Menu ===");
                Console.WriteLine("1. Redirect Patient");
                Console.WriteLine("2. Add Hospital Unit");
                Console.WriteLine("3. Remove Unit (Maintenance)");
                Console.WriteLine("4. Show All Units");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        util.RedirectPatient();
                        break;
                    case 2:
                        util.AddUnit();
                        break;
                    case 3:
                        util.RemoveUnit();
                        break;
                    case 4:
                        util.ShowUnits();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
