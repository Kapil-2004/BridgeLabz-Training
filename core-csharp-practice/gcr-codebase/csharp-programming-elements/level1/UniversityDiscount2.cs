using System;

class UniversityDiscount
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter original fee: ");
        int originalFee = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter discount percentage: ");
        double discountPercentage = double.Parse(Console.ReadLine());
        double discountAmount = (originalFee * discountPercentage) / 100;
        double discountedFee = originalFee - discountAmount;
        Console.WriteLine($"The discount amount is INR {discountAmount} and final discounted fee is INR {discountedFee}");
    }
}
