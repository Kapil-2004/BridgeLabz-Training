namespace TechVille.Modules
{
    public class Service
    {
        public static int CalculateEligibilityScore(int age, double income, int residencyYears)
        {
            int score = 0;

            // Age points
            if (age >= 18) score += 30;
            if (age >= 60) score += 10;

            // Income points
            if (income < 300000) score += 30;
            else if (income < 700000) score += 20;
            else score += 10;

            // Residency points
            if (residencyYears >= 5) score += 40;
            else if (residencyYears >= 2) score += 20;
            else score += 10;

            return score;
        }
    }
}
