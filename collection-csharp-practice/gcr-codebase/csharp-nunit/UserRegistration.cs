using System;
using System.Text.RegularExpressions;

namespace CSharpNUnit
{
    public class UserRegistration
    {
        public void RegisterUser(string username, string email, string password)
        {
            ValidateUsername(username);
            ValidateEmail(email);
            ValidatePassword(password);
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty");

            if (username.Length < 3)
                throw new ArgumentException("Username must be at least 3 characters long");

            if (username.Length > 20)
                throw new ArgumentException("Username must not exceed 20 characters");

            if (!Regex.IsMatch(username, "^[a-zA-Z0-9_]+$"))
                throw new ArgumentException("Username can only contain letters, numbers, and underscores");
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            // Simple email validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
                throw new ArgumentException("Invalid email format");
        }

        private void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty");

            if (password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long");

            if (!Regex.IsMatch(password, "[A-Z]"))
                throw new ArgumentException("Password must contain at least one uppercase letter");

            if (!Regex.IsMatch(password, "[0-9]"))
                throw new ArgumentException("Password must contain at least one digit");
        }

        public bool IsValidUsername(string username)
        {
            try
            {
                ValidateUsername(username);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                ValidateEmail(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            try
            {
                ValidatePassword(password);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
