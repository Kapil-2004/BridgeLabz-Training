using System;

class ProfitLoss
{
    static void Main(string[] args)
    {
        int cp = 129;
        int sp = 191;
        int profit = sp - cp;
        double profitPercentage = (profit * 100.0) / cp;
        Console.WriteLine($"The Cost Price is INR {cp} and Selling Price is INR {sp}");
        Console.WriteLine($"The Profit is INR {profit} and the Profit Percentage is {profitPercentage}");
    }
}