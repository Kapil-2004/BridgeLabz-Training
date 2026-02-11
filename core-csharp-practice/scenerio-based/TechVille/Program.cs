using System;

namespace TechVille
{
    class Program
    {
        /// Module 2 Summary:
        /// This module extends the citizen registration system to handle multiple
        /// family members using loops. It calculates eligibility scores and assigns
        /// service packages using conditional logic, switch statements, and control
        /// flow statements like break and continue.
        static void Main(string[] args)
        {
            Console.Write("Enter number of family members to register: ");

            if (!int.TryParse(Console.ReadLine(), out int members) || members <= 0)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            for (int i = 1; i <= members; i++)
            {
                Console.WriteLine($"\n===== Registering Member {i} =====");

                Console.Write("Enter Name : ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid Name! Skipping this member...");
                    continue;
                }

                Console.Write("Enter Age : ");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Invalid Age! Skipping this member...");
                    continue;
                }

                Console.Write("Enter Income : ");
                if (!double.TryParse(Console.ReadLine(), out double income) || income < 0)
                {
                    Console.WriteLine("Invalid Income! Skipping this member...");
                    continue;
                }

                Console.Write("Enter Residency Years : ");
                if (!int.TryParse(Console.ReadLine(), out int years) || years < 0)
                {
                    Console.WriteLine("Invalid Residency Years! Skipping this member...");
                    continue;
                }

                if (years > age)
                {
                    Console.WriteLine("Residency years cannot be greater than age! Skipping...");
                    continue;
                }

                // Eligibility Score
                double score = (age * 3) + (years * 2) + (income / 10000);

                // Ternary Operator
                string eligibilityStatus = (score > 70) ? "Eligible ✅" : "Not Eligible ❌";

                Console.WriteLine("\n--- Citizen Details ---");
                Console.WriteLine("Name : " + name);
                Console.WriteLine("Age : " + age);
                Console.WriteLine("Income : " + income);
                Console.WriteLine("Residency Years : " + years);
                Console.WriteLine("Eligibility Score : " + score);
                Console.WriteLine("Status : " + eligibilityStatus);

                // Multi-level eligibility checks (nested if-else)
                string servicePackage = "";

                if (score >= 90)
                {
                    servicePackage = "Platinum";
                }
                else if (score >= 80)
                {
                    servicePackage = "Gold";
                }
                else if (score >= 70)
                {
                    servicePackage = "Silver";
                }
                else
                {
                    servicePackage = "Basic";
                }

                Console.WriteLine("\nRecommended Package: " + servicePackage);

                // Switch for package selection
                Console.WriteLine("\nSelect a Package:");
                Console.WriteLine("1. Basic");
                Console.WriteLine("2. Silver");
                Console.WriteLine("3. Gold");
                Console.WriteLine("4. Platinum");
                Console.Write("Enter choice (1-4): ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice! Moving to next member...");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You selected: Basic Package");
                        break;

                    case 2:
                        Console.WriteLine("You selected: Silver Package");
                        break;

                    case 3:
                        Console.WriteLine("You selected: Gold Package");
                        break;

                    case 4:
                        Console.WriteLine("You selected: Platinum Package");
                        break;

                    default:
                        Console.WriteLine("Invalid option! Moving to next member...");
                        continue;
                }

                // break example: allow early stop
                Console.Write("\nDo you want to stop registration early? (yes/no): ");
                string stop = Console.ReadLine();

                if (stop.ToLower() == "yes")
                {
                    Console.WriteLine("Stopping registration...");
                    break;
                }
            }

            Console.WriteLine("\n✅ Registration Session Completed!");
        }
    }
}
