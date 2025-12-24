using System;

class LeapYearCheck
{
    static bool IsLeapYear(int year)
    {
        if (year < 1582)
            return false;

        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            return true;

        return false;
    }

    static void Main()
    {
        int year = Convert.ToInt32(Console.ReadLine());

        bool result = IsLeapYear(year);

        if (result)
            Console.WriteLine("Year is a Leap Year");
        else
            Console.WriteLine("Year is not a Leap Year");
    }
}
