using System;
using System.Globalization;

namespace CSharpNUnit
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                throw new ArgumentException("Date cannot be empty");

            // Try to parse the input date in yyyy-MM-dd format
            if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                throw new FormatException($"Invalid date format. Expected yyyy-MM-dd, got: {inputDate}");
            }

            // Return the date in dd-MM-yyyy format
            return date.ToString("dd-MM-yyyy");
        }

        public bool IsValidDate(string inputDate)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                return false;

            return DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
