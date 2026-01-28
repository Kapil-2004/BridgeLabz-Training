using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class EvenNumberCheckerTests
    {
        private EvenNumberChecker checker;

        [SetUp]
        public void SetUp()
        {
            checker = new EvenNumberChecker();
        }

        [TestCase(2)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(100)]
        public void IsEven_EvenNumbers_ReturnsTrue(int number)
        {
            bool result = checker.IsEven(number);
            Assert.IsTrue(result);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(9)]
        [TestCase(99)]
        public void IsEven_OddNumbers_ReturnsFalse(int number)
        {
            bool result = checker.IsEven(number);
            Assert.IsFalse(result);
        }

        [TestCase(0)]
        public void IsEven_Zero_ReturnsTrue(int number)
        {
            bool result = checker.IsEven(number);
            Assert.IsTrue(result);
        }

        [TestCase(-2)]
        [TestCase(-4)]
        [TestCase(-100)]
        public void IsEven_NegativeEvenNumbers_ReturnsTrue(int number)
        {
            bool result = checker.IsEven(number);
            Assert.IsTrue(result);
        }

        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-99)]
        public void IsEven_NegativeOddNumbers_ReturnsFalse(int number)
        {
            bool result = checker.IsEven(number);
            Assert.IsFalse(result);
        }
    }
}
