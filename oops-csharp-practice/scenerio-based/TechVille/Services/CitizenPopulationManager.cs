using System;
using System.Collections.Generic;
using TechVille.Modules;

namespace TechVille.Services
{
    public class CitizenPopulationManager
    {
        public static void ShowTotalCitizens(List<Citizen> citizens)
        {
            Console.WriteLine($"\n👥 Total Registered Citizens: {citizens.Count}");
        }

        public static void ShowCitizenStatistics(List<Citizen> citizens)
        {
            if (citizens.Count == 0)
            {
                Console.WriteLine("No citizens to analyze!");
                return;
            }

            Console.WriteLine("\n===== City Population Statistics =====");
            Console.WriteLine($"Total Citizens: {citizens.Count}");

            // Calculate average age
            double totalAge = 0;
            foreach (Citizen citizen in citizens)
            {
                totalAge += citizen.Age;
            }
            Console.WriteLine($"Average Age: {(totalAge / citizens.Count):F2}");

            // Calculate average income
            double totalIncome = 0;
            foreach (Citizen citizen in citizens)
            {
                totalIncome += citizen.Income;
            }
            Console.WriteLine($"Average Income: ₹{(totalIncome / citizens.Count):F2}");

            // Count eligible voters
            int voters = 0;
            foreach (Citizen citizen in citizens)
            {
                if (citizen.IsEligibleToVote())
                    voters++;
            }
            Console.WriteLine($"Eligible Voters: {voters}");

            // Count senior citizens
            int seniors = 0;
            foreach (Citizen citizen in citizens)
            {
                if (citizen.IsEligibleForSeniorBenefits())
                    seniors++;
            }
            Console.WriteLine($"Senior Citizens: {seniors}");

            // Count low-income citizens
            int lowIncome = 0;
            foreach (Citizen citizen in citizens)
            {
                if (citizen.IsEligibleForLowIncomeSupport())
                    lowIncome++;
            }
            Console.WriteLine($"Low-Income Citizens: {lowIncome}");
        }
    }
}
