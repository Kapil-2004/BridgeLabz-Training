using System;

public class Electronics : WarehouseItem
{
    public int WarrantyYears { get; set; }

    public Electronics(string name, double price, int warrantyYears)
        : base(name, price)
    {
        WarrantyYears = warrantyYears;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Electronics: " + Name + ", Price: " + Price + ", Warranty: " + WarrantyYears + " years");
    }
}
