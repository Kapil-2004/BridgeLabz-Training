using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class ExceptionTesterTests
    {
        private ExceptionTester exceptionTester;

        [SetUp]
        public void SetUp()
        {
            exceptionTester = new ExceptionTester();
        }

        [Test]
        public void Divide_ValidNumbers_ReturnsCorrectResult()
        {
            double result = exceptionTester.Divide(10, 2);
            Assert.AreEqual(5.0, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.Throws<System.ArithmeticException>(() => exceptionTester.Divide(10, 0));
        }

        [Test]
        public void Divide_ByZero_ExceptionMessageIsCorrect()
        {
            var ex = Assert.Throws<System.ArithmeticException>(() => exceptionTester.Divide(10, 0));
            Assert.AreEqual("Division by zero is not allowed", ex.Message);
        }

        [Test]
        public void Divide_NegativeNumbers_ThrowsArithmeticException()
        {
            Assert.Throws<System.ArithmeticException>(() => exceptionTester.Divide(10, 0));
        }

        [Test]
        public void Divide_ZeroNumerator_ReturnsZero()
        {
            double result = exceptionTester.Divide(0, 5);
            Assert.AreEqual(0.0, result);
        }
    }
}
