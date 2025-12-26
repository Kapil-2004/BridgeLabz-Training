using System;

class TimeZonesDemo
{
    static void Main()
    {
        // Current time in local system
        DateTimeOffset localTime = DateTimeOffset.Now;
        Console.WriteLine("Local Time: " + localTime);

        // GMT
        TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(localTime, gmtZone);
        Console.WriteLine("GMT Time: " + gmtTime);

        // IST (Indian Standard Time)
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(localTime, istZone);
        Console.WriteLine("IST Time: " + istTime);

        // PST (Pacific Standard Time)
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(localTime, pstZone);
        Console.WriteLine("PST Time: " + pstTime);
    }
}
