using System;
using TechVille.Interface;
using TechVille.Modules;
using TechVille.Utilities;

namespace TechVille.Services
{
    public class ServiceManager : IService
    {
        private static readonly ServicePlan[] plans =
        {
            new ServicePlan("Basic", 0, 49),
            new ServicePlan("Silver", 50, 69),
            new ServicePlan("Gold", 70, 89),
            new ServicePlan("Platinum", 90, 200)
        };

        public void AssignPlan()
        {
            AssignServicePlan();
        }

        public void ShowPlanDetails()
        {
            Console.WriteLine("\n=== Service Plans ===");
            foreach (ServicePlan p in plans)
            {
                Console.WriteLine($"{p.PlanName} : {p.MinScore} - {p.MaxScore}");
            }
        }

        public static void AssignServicePlan()
        {
            Console.Clear();
            Console.WriteLine("=== Assign Service Plan ===");

            string id = InputHelper.ReadString("Enter Citizen ID: ");
            Citizen c = CitizenService.FindCitizen(id);

            if (c == null)
            {
                Console.WriteLine("❌ Citizen not found!");
                return;
            }

            int score = Service.CalculateEligibilityScore(c.Age, c.Income, c.ResidencyYears);

            string assignedPlan = GetPlanFromScore(score);
            c.ServicePlan = assignedPlan;

            Console.WriteLine("\n✅ Service Plan Assigned!");
            Console.WriteLine($"Eligibility Score: {score}");
            Console.WriteLine($"Plan Assigned: {assignedPlan}");
        }

        private static string GetPlanFromScore(int score)
        {
            foreach (ServicePlan p in plans)
            {
                if (score >= p.MinScore && score <= p.MaxScore)
                    return p.PlanName;
            }
            return "Basic";
        }
    }
}
