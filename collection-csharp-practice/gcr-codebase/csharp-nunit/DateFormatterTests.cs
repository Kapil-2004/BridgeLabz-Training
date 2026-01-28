using NUnit.Framework;
using CSharpNUnit;
using System;

namespace CSharpNUnitTests
{
    [TestFixture]
    public class DateFormatterTests
    {
        private DateFormatter formatter;

        [SetUp]
        public void SetUp()
        {
            formatter = new DateFormatter();
        }

        [TestCase("2023-01-15", "15-01-2023")]
        [TestCase("2024-12-31", "31-12-2024")]
        [TestCase("2020-06-30", "30-06-2020")]
        [TestCase("2023-03-03", "03-03-2023")]
        public void FormatDate_ValidDates_ReturnsCorrectFormat(string inputDate, string expectedOutput)
        {
            string result = formatter.FormatDate(inputDate);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestCase("2023/01/15")]
        [TestCase("01-15-2023")]
        [TestCase("2023-13-01")]
        [TestCase("2023-02-30")]
        public void FormatDate_InvalidDateFormats_ThrowsFormatException(string inputDate)
        {
            Assert.Throws<FormatException>(() => formatter.FormatDate(inputDate));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void FormatDate_EmptyOrWhitespace_ThrowsArgumentException(string inputDate)
        {
            Assert.Throws<ArgumentException>(() => formatter.FormatDate(inputDate));
        }

        [TestCase("2023-01-15", true)]
        [TestCase("2024-12-31", true)]
        [TestCase("2023-02-28", true)]
        public void IsValidDate_ValidDates_ReturnsTrue(string inputDate, bool expected)
        {
            bool result = formatter.IsValidDate(inputDate);
            Assert.AreEqual(expected, result);
        }

        [TestCase("2023/01/15", false)]
        [TestCase("01-15-2023", false)]
        [TestCase("invalid", false)]
        [TestCase("2023-13-01", false)]
        [TestCase("2023-02-30", false)]
        public void IsValidDate_InvalidDates_ReturnsFalse(string inputDate, bool expected)
        {
            bool result = formatter.IsValidDate(inputDate);
            Assert.AreEqual(expected, result);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        public void IsValidDate_EmptyOrWhitespace_ReturnsFalse(string inputDate)
        {
            bool result = formatter.IsValidDate(inputDate);
            Assert.IsFalse(result);
        }

        [Test]
        public void FormatDate_LeapYearDate_ReturnsCorrectFormat()
        {
            string result = formatter.FormatDate("2020-02-29");
            Assert.AreEqual("29-02-2020", result);
        }
    }
}
