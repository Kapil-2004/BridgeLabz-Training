using System;

class CalendarPrinter
{
    static string GetMonthName(int month)
    {
        string[] monthNames =
        {
            "January", "February", "March", "April",
            "May", "June", "July", "August",
            "September", "October", "November", "December"
        };
        return monthNames[month - 1];
    }

    static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    static int GetDaysInMonth(int month, int year)
    {
        int[] daysInMonth =
        {
            31, 28, 31, 30, 31, 30,
            31, 31, 30, 31, 30, 31
        };

        if (month == 2 && IsLeapYear(year))
            return 29;

        return daysInMonth[month - 1];
    }

    static int GetFirstDayOfMonth(int month, int year)
    {
        int day = 1;
        int adjustedYear = year - (14 - month) / 12;
        int centuryFactor = adjustedYear + adjustedYear / 4 - adjustedYear / 100 + adjustedYear / 400;
        int adjustedMonth = month + 12 * ((14 - month) / 12) - 2;

        return (day + centuryFactor + (31 * adjustedMonth) / 12) % 7;
    }

    static void Main()
    {
        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine(GetMonthName(month) + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int firstDay = GetFirstDayOfMonth(month, year);
        int totalDays = GetDaysInMonth(month, year);

        // indentation before 1st day
        for (int i = 0; i < firstDay; i++)
        {
            Console.Write("    ");
        }

        // print days
        for (int currentDay = 1; currentDay <= totalDays; currentDay++)
        {
            Console.Write($"{currentDay,3} ");

            if ((currentDay + firstDay) % 7 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}
