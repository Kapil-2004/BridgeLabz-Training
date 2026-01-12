public interface ICuttingStrategy
{
    int GetMaxRevenue(int rodLength, int[] price);
    int GetRevenueWithWaste(int rodLength, int[] price, int maxWaste);
    void GetBestRevenueWithMinWaste(int rodLength, int[] price);
}