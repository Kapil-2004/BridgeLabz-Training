namespace TechVille.Modules
{
    public class ServicePlan
    {
        public string PlanName { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }

        public ServicePlan(string planName, int minScore, int maxScore)
        {
            PlanName = planName;
            MinScore = minScore;
            MaxScore = maxScore;
        }
    }
}
