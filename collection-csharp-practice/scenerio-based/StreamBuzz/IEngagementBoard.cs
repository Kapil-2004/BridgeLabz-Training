using System.Collections.Generic;

public interface IEngagementBoard
{
    void RegisterCreator(CreatorStats record);
    Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold);
    double CalculateAverageLikes();
}
