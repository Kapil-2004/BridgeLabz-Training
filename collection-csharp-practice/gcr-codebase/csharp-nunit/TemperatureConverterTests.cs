using NUnit.Framework;
using CSharpNUnit;
using System;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class TemperatureConverterTests
    {
        private TemperatureConverter converter;

        [SetUp]
        public void SetUp()
        {
            converter = new TemperatureConverter();
        }

        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        [TestCase(25, 77)]
        public void CelsiusToFahrenheit_ValidTemperatures_ReturnsCorrectConversion(double celsius, double expectedFahrenheit)
        {
            double result = converter.CelsiusToFahrenheit(celsius);
            Assert.That(result, Is.EqualTo(expectedFahrenheit).Within(0.01));
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        [TestCase(86, 30)]
        public void FahrenheitToCelsius_ValidTemperatures_ReturnsCorrectConversion(double fahrenheit, double expectedCelsius)
        {
            double result = converter.FahrenheitToCelsius(fahrenheit);
            Assert.That(result, Is.EqualTo(expectedCelsius).Within(0.01));
        }

        [TestCase(0, 273.15)]
        [TestCase(100, 373.15)]
        [TestCase(-273.15, 0)]
        public void CelsiusToKelvin_ValidTemperatures_ReturnsCorrectConversion(double celsius, double expectedKelvin)
        {
            double result = converter.CelsiusToKelvin(celsius);
            Assert.That(result, Is.EqualTo(expectedKelvin).Within(0.01));
        }

        [TestCase(273.15, 0)]
        [TestCase(373.15, 100)]
        [TestCase(0, -273.15)]
        public void KelvinToCelsius_ValidTemperatures_ReturnsCorrectConversion(double kelvin, double expectedCelsius)
        {
            double result = converter.KelvinToCelsius(kelvin);
            Assert.That(result, Is.EqualTo(expectedCelsius).Within(0.01));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void KelvinToCelsius_NegativeKelvin_ThrowsException(double kelvin)
        {
            Assert.Throws<ArgumentException>(() => converter.KelvinToCelsius(kelvin));
        }

        [Test]
        public void RoundTripConversion_CelsiusToFahrenheitToCelsius_PreservesValue()
        {
            double originalCelsius = 25;
            double fahrenheit = converter.CelsiusToFahrenheit(originalCelsius);
            double backToCelsius = converter.FahrenheitToCelsius(fahrenheit);

            Assert.That(backToCelsius, Is.EqualTo(originalCelsius).Within(0.01));
        }

        [Test]
        public void RoundTripConversion_CelsiusToKelvinToCelsius_PreservesValue()
        {
            double originalCelsius = 25;
            double kelvin = converter.CelsiusToKelvin(originalCelsius);
            double backToCelsius = converter.KelvinToCelsius(kelvin);

            Assert.That(backToCelsius, Is.EqualTo(originalCelsius).Within(0.01));
        }
    }
}
