using System;

namespace TechVille
{
    public class TechVilleMenu
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("     TECHVILLE SMART CITY MANAGEMENT SYSTEM");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Add Citizen");
            Console.WriteLine("2. Display All Citizens");
            Console.WriteLine("3. Search Citizen by ID");
            Console.WriteLine("4. Update Citizen");
            Console.WriteLine("5. Delete Citizen");
            Console.WriteLine("6. Assign Service Plan");
            Console.WriteLine("7. Show Summary");
            Console.WriteLine("8. Save & Exit");
            Console.WriteLine("==============================================");
        }
    }
}
