using System;

namespace TechVille
{
    class Program
    {
        /// <summary>
        /// Module 1 Summary:
        /// This module implements a basic citizen registration system for TechVille.
        /// It accepts single-user input such as name, age, income, and residency years.
        /// An eligibility score is calculated using arithmetic operators.
        /// Conditional statements are used to determine service eligibility.
        /// This module focuses on core programming concepts like variables, I/O, and operators.
        /// </summary>
        static void Main(string[] args)
        {
            // Taking Citizen Data/Details From The User
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid Name!");
                return;
            }

            Console.Write("Enter Age : ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
            {
                Console.WriteLine("Invalid Age!");
                return;
            }

            Console.Write("Enter Income : ");
            if (!double.TryParse(Console.ReadLine(), out double income) || income < 0)
            {
                Console.WriteLine("Invalid Income!");
                return;
            }

            Console.Write("Enter Residency Years : ");
            if (!int.TryParse(Console.ReadLine(), out int years) || years < 0)
            {
                Console.WriteLine("Invalid Residency Years!");
                return;
            }

            // Calculating Eligibility Score Based On Citizen Data.
            double eligibilityScore = (age * 3) + (years * 2) + (income / 10000);

            // Checking If The Citizen is Eligible for Service or Not.
            if (eligibilityScore > 70)
            {
                Console.WriteLine("Citizen Is Eligible");
                Console.WriteLine("\n--- Citizen Details ---");
                Console.WriteLine("Name : " + name);
                Console.WriteLine("Age : " + age);
                Console.WriteLine("Income : " + income);
                Console.WriteLine("Residency Years : " + years);
                Console.WriteLine("Eligibility Score : " + eligibilityScore);
            }
            else
            {
                Console.WriteLine("Citizen is not eligible");
            }
        }
    }
}
