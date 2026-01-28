using NUnit.Framework;
using CSharpNUnit;
using System;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class UserRegistrationTests
    {
        private UserRegistration registration;

        [SetUp]
        public void SetUp()
        {
            registration = new UserRegistration();
        }

        [TestCase("validUser", "user@example.com", "Password123")]
        [TestCase("john_doe", "john@test.org", "SecurePass99")]
        [TestCase("test123", "test@domain.co.uk", "MyPassword1")]
        public void RegisterUser_ValidInputs_SucceedsWithoutException(string username, string email, string password)
        {
            Assert.DoesNotThrow(() => registration.RegisterUser(username, email, password));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("ab")]
        [TestCase("a")]
        public void RegisterUser_InvalidUsername_ThrowsArgumentException(string username)
        {
            Assert.Throws<ArgumentException>(() => registration.RegisterUser(username, "valid@email.com", "Password123"));
        }

        [TestCase("username_toolong_for_validation_exceeds_twenty")]
        public void RegisterUser_UsernameTooLong_ThrowsArgumentException(string username)
        {
            Assert.Throws<ArgumentException>(() => registration.RegisterUser(username, "valid@email.com", "Password123"));
        }

        [TestCase("user@name")]
        [TestCase("invalid-user")]
        [TestCase("user name")]
        public void RegisterUser_InvalidUsernameCharacters_ThrowsArgumentException(string username)
        {
            Assert.Throws<ArgumentException>(() => registration.RegisterUser(username, "valid@email.com", "Password123"));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("invalidemail")]
        [TestCase("invalid@")]
        [TestCase("@invalid.com")]
        [TestCase("invalid@.com")]
        public void RegisterUser_InvalidEmail_ThrowsArgumentException(string email)
        {
            Assert.Throws<ArgumentException>(() => registration.RegisterUser("validUser", email, "Password123"));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("short")]
        [TestCase("password123")]
        [TestCase("PASSWORD123")]
        [TestCase("Nodigits")]
        public void RegisterUser_InvalidPassword_ThrowsArgumentException(string password)
        {
            Assert.Throws<ArgumentException>(() => registration.RegisterUser("validUser", "valid@email.com", password));
        }

        [TestCase("validUser", "user@example.com", "Password123")]
        public void IsValidUsername_ValidUsername_ReturnsTrue(string username, string email, string password)
        {
            bool result = registration.IsValidUsername(username);
            Assert.IsTrue(result);
        }

        [TestCase("ab")]
        [TestCase("")]
        public void IsValidUsername_InvalidUsername_ReturnsFalse(string username)
        {
            bool result = registration.IsValidUsername(username);
            Assert.IsFalse(result);
        }

        [TestCase("user@example.com")]
        [TestCase("test@domain.org")]
        public void IsValidEmail_ValidEmail_ReturnsTrue(string email)
        {
            bool result = registration.IsValidEmail(email);
            Assert.IsTrue(result);
        }

        [TestCase("invalidemail")]
        [TestCase("@invalid.com")]
        public void IsValidEmail_InvalidEmail_ReturnsFalse(string email)
        {
            bool result = registration.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestCase("Password123")]
        [TestCase("SecurePass99")]
        public void IsValidPassword_ValidPassword_ReturnsTrue(string password)
        {
            bool result = registration.IsValidPassword(password);
            Assert.IsTrue(result);
        }

        [TestCase("password")]
        [TestCase("PASSWORD123")]
        [TestCase("short")]
        public void IsValidPassword_InvalidPassword_ReturnsFalse(string password)
        {
            bool result = registration.IsValidPassword(password);
            Assert.IsFalse(result);
        }
    }
}
