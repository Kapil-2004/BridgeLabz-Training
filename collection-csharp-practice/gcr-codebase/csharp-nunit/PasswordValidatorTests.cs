using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        private PasswordValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new PasswordValidator();
        }

        [TestCase("ValidPass1")]
        [TestCase("MyPassword123")]
        [TestCase("SecurePass99")]
        public void IsValidPassword_ValidPasswords_ReturnsTrue(string password)
        {
            Assert.IsTrue(validator.IsValidPassword(password));
        }

        [TestCase("short1A")]
        public void IsValidPassword_LessThanEightCharacters_ReturnsFalse(string password)
        {
            Assert.IsFalse(validator.IsValidPassword(password));
        }

        [TestCase("alllowercase123")]
        public void IsValidPassword_NoUppercaseLetters_ReturnsFalse(string password)
        {
            Assert.IsFalse(validator.IsValidPassword(password));
        }

        [TestCase("NOLOWERCASE123")]
        public void IsValidPassword_NoLowercaseLetters_ReturnsFalse(string password)
        {
            Assert.IsFalse(validator.IsValidPassword(password));
        }

        [TestCase("NoDigitsHere")]
        public void IsValidPassword_NoDigits_ReturnsFalse(string password)
        {
            Assert.IsFalse(validator.IsValidPassword(password));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void IsValidPassword_EmptyOrWhitespace_ReturnsFalse(string password)
        {
            Assert.IsFalse(validator.IsValidPassword(password));
        }

        [TestCase("ValidPass1", "Fair")]
        [TestCase("MyPassword123", "Good")]
        [TestCase("SecurePass123!", "Strong")]
        public void GetPasswordStrength_ValidPasswords_ReturnsCorrectStrength(string password, string expectedStrength)
        {
            string strength = validator.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }

        [TestCase("weak")]
        [TestCase("Short1")]
        public void GetPasswordStrength_WeakPasswords_ReturnsWeak(string password)
        {
            string strength = validator.GetPasswordStrength(password);
            Assert.AreEqual("Weak", strength);
        }
    }
}
