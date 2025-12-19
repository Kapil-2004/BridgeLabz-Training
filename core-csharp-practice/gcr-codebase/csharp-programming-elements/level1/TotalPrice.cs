using System;

class TotalPurchasePrice
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter unit price:");
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter quantity:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        double totalPrice = unitPrice * quantity;

        Console.WriteLine($"The total purchase price is INR {totalPrice} if the quantity {quantity} and unit price is INR {unitPrice}");
    }
}
