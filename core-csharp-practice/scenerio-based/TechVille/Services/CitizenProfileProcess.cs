using System;
using TechVille.Modules;

namespace TechVille.Services
{
    public class CitizenProfileProcess
    {
        public static void DisplayAllCitizens(Citizen[] citizens, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No citizens registered yet!");
                return;
            }

            Console.WriteLine("\n--- Registered Citizens ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nCitizen {i + 1}");
                Console.WriteLine("ID: " + citizens[i].Id);
                Console.WriteLine("Name: " + citizens[i].Name);
                Console.WriteLine("Age: " + citizens[i].Age);
                Console.WriteLine("Income: " + citizens[i].Income);
                Console.WriteLine("Residency Years: " + citizens[i].ResidencyYears);
            }
        }
    }
}
