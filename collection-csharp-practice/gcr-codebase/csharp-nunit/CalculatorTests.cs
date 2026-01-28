using NUnit.Framework;
using CSharpNUnit;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            int result = calculator.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            int result = calculator.Add(-5, -3);
            Assert.AreEqual(-8, result);
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            int result = calculator.Subtract(10, 3);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Subtract_NegativeResult_ReturnsCorrectDifference()
        {
            int result = calculator.Subtract(3, 10);
            Assert.AreEqual(-7, result);
        }

        [Test]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            int result = calculator.Multiply(5, 3);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Multiply_WithZero_ReturnsZero()
        {
            int result = calculator.Multiply(5, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Divide_TwoNumbers_ReturnsCorrectQuotient()
        {
            double result = calculator.Divide(10, 2);
            Assert.AreEqual(5.0, result);
        }

        [Test]
        public void Divide_WithFraction_ReturnsCorrectQuotient()
        {
            double result = calculator.Divide(10, 3);
            Assert.That(result, Is.EqualTo(10.0 / 3).Within(0.0001));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }

        [Test]
        public void Divide_ByZero_ThrowsExceptionWithCorrectMessage()
        {
            var ex = Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
            Assert.AreEqual("Cannot divide by zero", ex.Message);
        }
    }
}
