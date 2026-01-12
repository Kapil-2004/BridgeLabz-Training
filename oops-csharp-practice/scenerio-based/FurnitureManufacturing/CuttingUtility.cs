using System;

class CuttingUtility : ICuttingStrategy
{
    // Scenario A
    public int GetMaxRevenue(int rodLength, int[] price)
    {
        int[] dp = new int[rodLength + 1];

        for (int i = 1; i <= rodLength; i++)
        {
            int max = 0;
            for (int j = 1; j <= i; j++)
            {
                int value = price[j] + dp[i - j];
                if (value > max)
                    max = value;
            }
            dp[i] = max;
        }
        return dp[rodLength];
    }

    // Scenario B
    public int GetRevenueWithWaste(int rodLength, int[] price, int maxWaste)
    {
        int best = 0;

        for (int i = 1; i <= rodLength; i++)
        {
            int waste = rodLength - i;
            if (waste <= maxWaste)
            {
                if (price[i] > best)
                    best = price[i];
            }
        }
        return best;
    }

    // Scenario C
    public void GetBestRevenueWithMinWaste(int rodLength, int[] price)
    {
        int bestRevenue = 0;
        int usedLength = 0;

        for (int i = 1; i <= rodLength; i++)
        {
            if (price[i] > bestRevenue)
            {
                bestRevenue = price[i];
                usedLength = i;
            }
        }

        Console.WriteLine("Best Revenue: ₹" + bestRevenue);
        Console.WriteLine("Used Length: " + usedLength + " ft");
        Console.WriteLine("Waste: " + (rodLength - usedLength) + " ft");
    }
}
