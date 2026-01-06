using System;

class CallLog
{
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }

    public CallLog(string phoneNumber, string message, DateTime timestamp)
    {
        PhoneNumber = phoneNumber;
        Message = message;
        Timestamp = timestamp;
    }

    public void Display()
    {
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Message: {Message}");
        Console.WriteLine($"Time: {Timestamp}");
        Console.WriteLine("---------------------------");
    }
}

class CallLogManager
{
    private CallLog[] logs;
    private int count;

    public CallLogManager(int size)
    {
        logs = new CallLog[size];
        count = 0;
    }

    // Add a call log
    public void AddCallLog(string phoneNumber, string message, DateTime timestamp)
    {
        if (count >= logs.Length)
        {
            Console.WriteLine("Call log storage is full.");
            return;
        }

        logs[count++] = new CallLog(phoneNumber, message, timestamp);
    }

    // Search logs by keyword in message
    public void SearchByKeyword(string keyword)
    {
        Console.WriteLine($"Searching for keyword: {keyword}");
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (logs[i].Message.Contains(keyword))
            {
                logs[i].Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No matching logs found.");
    }

    // Filter logs by time range
    public void FilterByTime(DateTime start, DateTime end)
    {
        Console.WriteLine($"Logs between {start} and {end}");
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (logs[i].Timestamp >= start && logs[i].Timestamp <= end)
            {
                logs[i].Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No logs found in this time range.");
    }
}

class Program
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager(5);

        manager.AddCallLog("9876543210", "Network issue reported", DateTime.Now.AddHours(-5));
        manager.AddCallLog("9123456780", "Recharge related query", DateTime.Now.AddHours(-2));
        manager.AddCallLog("9988776655", "Call drop complaint", DateTime.Now);

        Console.WriteLine("\n--- Search By Keyword ---");
        manager.SearchByKeyword("issue");

        Console.WriteLine("\n--- Filter By Time ---");
        manager.FilterByTime(DateTime.Now.AddHours(-3), DateTime.Now);
    }
}
