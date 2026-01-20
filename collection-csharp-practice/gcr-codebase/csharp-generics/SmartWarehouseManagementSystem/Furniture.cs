using System;

public class Furniture : WarehouseItem
{
    public string Material { get; set; }

    public Furniture(string name, double price, string material)
        : base(name, price)
    {
        Material = material;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Furniture: " + Name + ", Price: " + Price + ", Material: " + Material);
    }
}
