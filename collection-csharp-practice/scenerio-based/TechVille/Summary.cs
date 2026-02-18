using System;
using TechVille.Services;

namespace TechVille
{
    public class Summary
    {
        public static void ShowSummary()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("           TECHVILLE SYSTEM SUMMARY");
            Console.WriteLine("==============================================\n");

            int total = CitizenService.GetCitizenCount();
            Console.WriteLine($"Total Citizens: {total}\n");

            if (total == 0)
            {
                Console.WriteLine("No citizens in the system.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("--- Service Plan Distribution ---\n");

            int basicCount = CitizenService.CountPlans("Basic");
            int silverCount = CitizenService.CountPlans("Silver");
            int goldCount = CitizenService.CountPlans("Gold");
            int platinumCount = CitizenService.CountPlans("Platinum");
            int unassignedCount = CitizenService.CountPlans(null);

            Console.WriteLine($"Basic Plan:       {basicCount} citizens ({GetPercentage(basicCount, total)}%)");
            Console.WriteLine($"Silver Plan:      {silverCount} citizens ({GetPercentage(silverCount, total)}%)");
            Console.WriteLine($"Gold Plan:        {goldCount} citizens ({GetPercentage(goldCount, total)}%)");
            Console.WriteLine($"Platinum Plan:    {platinumCount} citizens ({GetPercentage(platinumCount, total)}%)");
            Console.WriteLine($"Unassigned:       {unassignedCount} citizens ({GetPercentage(unassignedCount, total)}%)");

            Console.WriteLine("\n==============================================");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static double GetPercentage(int count, int total)
        {
            if (total == 0) return 0;
            return Math.Round((double)count / total * 100, 2);
        }
    }
}
