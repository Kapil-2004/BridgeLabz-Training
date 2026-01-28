using System;
using System.Text.RegularExpressions;

namespace CSharpNUnit
{
    public class PasswordValidator
    {
        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // Check minimum length
            if (password.Length < 8)
                return false;

            // Check for at least one uppercase letter
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Check for at least one digit
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            return true;
        }

        public string GetPasswordStrength(string password)
        {
            if (!IsValidPassword(password))
                return "Weak";

            int strength = 0;
            if (password.Length >= 12) strength++;
            if (Regex.IsMatch(password, "[a-z]")) strength++;
            if (Regex.IsMatch(password, "[!@#$%^&*]")) strength++;

            return strength switch
            {
                0 => "Fair",
                1 => "Good",
                2 => "Very Good",
                3 => "Strong",
                _ => "Strong"
            };
        }
    }
}
