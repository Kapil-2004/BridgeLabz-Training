using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils stringUtils;

        [SetUp]
        public void SetUp()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = stringUtils.Reverse("Hello");
            Assert.AreEqual("olleH", result);
        }

        [Test]
        public void Reverse_SingleCharacter_ReturnsSameCharacter()
        {
            string result = stringUtils.Reverse("A");
            Assert.AreEqual("A", result);
        }

        [Test]
        public void Reverse_EmptyString_ReturnsEmptyString()
        {
            string result = stringUtils.Reverse("");
            Assert.AreEqual("", result);
        }

        [Test]
        public void Reverse_NullString_ReturnsNull()
        {
            string result = stringUtils.Reverse(null);
            Assert.IsNull(result);
        }

        [Test]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("racecar");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_ValidPalindromeWithSpaces_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("A man a plan a canal Panama");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_NotPalindrome_ReturnsFalse()
        {
            bool result = stringUtils.IsPalindrome("hello");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPalindrome_SingleCharacter_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("a");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_EmptyString_ReturnsTrue()
        {
            bool result = stringUtils.IsPalindrome("");
            Assert.IsTrue(result);
        }

        [Test]
        public void ToUpperCase_ValidString_ReturnsUpperCase()
        {
            string result = stringUtils.ToUpperCase("hello");
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void ToUpperCase_MixedCase_ReturnsAllUpperCase()
        {
            string result = stringUtils.ToUpperCase("HeLLo WoRLd");
            Assert.AreEqual("HELLO WORLD", result);
        }

        [Test]
        public void ToUpperCase_AlreadyUpperCase_ReturnsSame()
        {
            string result = stringUtils.ToUpperCase("HELLO");
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void ToUpperCase_EmptyString_ReturnsEmptyString()
        {
            string result = stringUtils.ToUpperCase("");
            Assert.AreEqual("", result);
        }
    }
}
