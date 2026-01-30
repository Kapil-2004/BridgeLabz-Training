using System;
using System.Collections.Generic;

public class EngagementUtility : IEngagementBoard
{
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
        Console.WriteLine("Creator registered successfully");
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var creator in records)
        {
            int count = 0;
            for (int i = 0; i < creator.WeeklyLikes.Length; i++)
            {
                if (creator.WeeklyLikes[i] >= likeThreshold)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    public double CalculateAverageLikes()
    {
        double total = 0;
        int totalWeeks = 0;

        foreach (var creator in CreatorStats.EngagementBoard)
        {
            for (int i = 0; i < creator.WeeklyLikes.Length; i++)
            {
                total += creator.WeeklyLikes[i];
                totalWeeks++;
            }
        }

        if (totalWeeks > 0)
            return total / totalWeeks;
        else
            return 0;
    }
}
