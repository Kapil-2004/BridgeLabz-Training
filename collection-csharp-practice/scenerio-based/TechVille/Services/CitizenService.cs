using System;
using System.Collections.Generic;
using TechVille.Exceptions;
using TechVille.Modules;
using TechVille.Utilities;

namespace TechVille.Services
{
    public class CitizenService
    {
        private static List<Citizen> citizens = new List<Citizen>();

        public static void LoadFromFile()
        {
            citizens = FileHandler.Load();
        }

        public static void SaveToFile()
        {
            FileHandler.Save(citizens);
        }

        public static int GetCitizenCount()
        {
            return citizens.Count;
        }

        public static int CountPlans(string plan)
        {
            int count = 0;
            foreach (Citizen c in citizens)
            {
                if (c.ServicePlan == plan)
                    count++;
            }
            return count;
        }

        public static void AddCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== Add Citizen ===");

            string id = InputHelper.ReadString("Enter Citizen ID: ");

            if (FindCitizen(id) != null)
                throw new DuplicateCitizenException("Citizen ID already exists!");

            string name = InputHelper.ReadString("Enter Name: ");
            int age = InputHelper.ReadInt("Enter Age: ");
            double income = InputHelper.ReadDouble("Enter Income: ");
            int residency = InputHelper.ReadInt("Enter Residency Years: ");

            Validator.ValidateAge(age);
            Validator.ValidateIncome(income);
            Validator.ValidateResidency(residency);

            Citizen citizen = new Citizen(id, name, age, income, residency);
            citizens.Add(citizen);

            Console.WriteLine("✅ Citizen Added Successfully!");
        }

        public static void DisplayAllCitizens()
        {
            Console.Clear();
            Console.WriteLine("=== All Citizens ===\n");

            if (citizens.Count == 0)
            {
                Console.WriteLine("No citizens found.");
                return;
            }

            foreach (Citizen c in citizens)
            {
                Console.WriteLine(c);
                Console.WriteLine("----------------------------------------");
            }
        }

        public static void SearchCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== Search Citizen ===");

            string id = InputHelper.ReadString("Enter Citizen ID: ");
            Citizen c = FindCitizen(id);

            if (c == null)
            {
                Console.WriteLine("❌ Citizen not found!");
                return;
            }

            Console.WriteLine("\n✅ Citizen Found:\n");
            Console.WriteLine(c);
        }

        public static void UpdateCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== Update Citizen ===");

            string id = InputHelper.ReadString("Enter Citizen ID: ");
            Citizen c = FindCitizen(id);

            if (c == null)
            {
                Console.WriteLine("❌ Citizen not found!");
                return;
            }

            Console.WriteLine("\nCitizen Found:\n");
            Console.WriteLine(c);
            Console.WriteLine("\nEnter new values:");

            string name = InputHelper.ReadString("Enter Name: ");
            int age = InputHelper.ReadInt("Enter Age: ");
            double income = InputHelper.ReadDouble("Enter Income: ");
            int residency = InputHelper.ReadInt("Enter Residency Years: ");

            Validator.ValidateAge(age);
            Validator.ValidateIncome(income);
            Validator.ValidateResidency(residency);

            c.Name = name;
            c.Age = age;
            c.Income = income;
            c.ResidencyYears = residency;

            Console.WriteLine("✅ Citizen Updated Successfully!");
        }

        public static void DeleteCitizen()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Citizen ===");

            string id = InputHelper.ReadString("Enter Citizen ID: ");
            Citizen c = FindCitizen(id);

            if (c == null)
            {
                Console.WriteLine("❌ Citizen not found!");
                return;
            }

            citizens.Remove(c);
            Console.WriteLine("✅ Citizen Deleted Successfully!");
        }

        public static Citizen FindCitizen(string id)
        {
            foreach (Citizen c in citizens)
            {
                if (c.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    return c;
            }
            return null;
        }

        public static List<Citizen> GetCitizens()
        {
            return citizens;
        }
    }
}
