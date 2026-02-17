using System;
using TechVille.Exceptions;
using TechVille.Modules;
using TechVille.Utilities;

namespace TechVille.Services
{
    public class CitizenRegistrationService
    {
        public static void RegisterCitizen(List<Citizen> citizens)
        {
            try
            {
                Console.Write("\nEnter Citizen ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                if (IsDuplicateCitizen(citizens, id))
                {
                    throw new DuplicateCitizenException("Citizen ID already exists!");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                if (!InputValidator.IsValidName(name))
                {
                    Console.WriteLine("Invalid name! Must not be empty.");
                    return;
                }

                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                if (age <= 0 || age > 120)
                {
                    throw new InvalidAgeException("Age must be between 1 and 120.");
                }

                Console.Write("Enter Income: ");
                double income = Convert.ToDouble(Console.ReadLine());

                if (income < 0)
                {
                    Console.WriteLine("Income cannot be negative!");
                    return;
                }

                Console.Write("Enter Residency Years: ");
                int years = Convert.ToInt32(Console.ReadLine());

                // Create new Citizen object using parameterized constructor
                Citizen newCitizen = new Citizen(id, CitizenUtility.FormatName(name), age, income, years);
                citizens.Add(newCitizen);

                Console.WriteLine("✅ Citizen registered successfully!");
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine("❌ Invalid Age: " + ex.Message);
                CitizenUtility.LogError(ex);
            }
            catch (DuplicateCitizenException ex)
            {
                Console.WriteLine("❌ Duplicate Citizen: " + ex.Message);
                CitizenUtility.LogError(ex);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("❌ Invalid input format! Please enter correct numbers.");
                CitizenUtility.LogError(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Unknown error: " + ex.Message);
                CitizenUtility.LogError(ex);
            }
            finally
            {
                Console.WriteLine("---- Registration Finished ----");
            }
        }

        // ===== HELPER METHODS =====

        private static bool IsDuplicateCitizen(List<Citizen> citizens, int id)
        {
            foreach (Citizen citizen in citizens)
            {
                if (citizen.Id == id)
                    return true;
            }
            return false;
        }
    }
}
