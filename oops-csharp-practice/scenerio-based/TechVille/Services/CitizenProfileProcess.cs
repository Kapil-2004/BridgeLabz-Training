using System;
using System.Collections.Generic;
using TechVille.Modules;

namespace TechVille.Services
{
    public class CitizenProfileProcess
    {
        public static void DisplayAllCitizens(List<Citizen> citizens)
        {
            if (citizens.Count == 0)
            {
                Console.WriteLine("No citizens registered yet!");
                return;
            }

            Console.WriteLine("\n--- Registered Citizens ---");
            for (int i = 0; i < citizens.Count; i++)
            {
                Console.WriteLine($"\n[Citizen {i + 1}]");
                citizens[i].DisplayInfo();
            }
        }

        public static void DisplayCitizenDetails(Citizen citizen)
        {
            if (citizen != null)
            {
                citizen.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Citizen not found!");
            }
        }
    }
}
