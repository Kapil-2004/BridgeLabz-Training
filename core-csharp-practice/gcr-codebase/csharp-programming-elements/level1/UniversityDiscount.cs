using System;

class UniversityDiscount
{
    static void Main(string[] args)
    {
        int originalFee = 125000;
        double discountPercentage = 10.0;
        double discountAmount = (originalFee * discountPercentage) / 100;
        double discountedFee = originalFee - discountAmount;
        Console.WriteLine($"The discount amount is INR {discountAmount} and final discounted fee is INR {discountedFee}");

    }
}