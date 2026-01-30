using System;
using System.Collections.Generic;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    // Constructor
    public CreatorStats(string name, double[] likes)
    {
        CreatorName = name;
        WeeklyLikes = likes;
    }

    // Static EngagementBoard initialized in static constructor
    public static List<CreatorStats> EngagementBoard;

    static CreatorStats()
    {
        EngagementBoard = new List<CreatorStats>();
    }
}
