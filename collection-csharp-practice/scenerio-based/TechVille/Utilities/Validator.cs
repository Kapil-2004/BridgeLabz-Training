using TechVille.Exceptions;

namespace TechVille.Utilities
{
    public class Validator
    {
        public static void ValidateAge(int age)
        {
            if (age <= 0 || age > 120)
                throw new InvalidAgeException("Age must be between 1 and 120.");
        }

        public static void ValidateIncome(double income)
        {
            if (income < 0)
                throw new InvalidIncomeException("Income cannot be negative.");
        }

        public static void ValidateResidency(int years)
        {
            if (years < 0)
                throw new TechVilleCustomException("Residency years cannot be negative.");
        }
    }
}
