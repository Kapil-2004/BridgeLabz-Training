using System;

namespace MetalFactory
{
    class RodCutting
{
    // Scenario A & B: Optimized revenue using Dynamic Programming
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

    // Scenario C: Non-optimized revenue (no cutting)
    public int GetDirectRevenue(int rodLength, int[] price)
    {
        return price[rodLength];
    }
}
}