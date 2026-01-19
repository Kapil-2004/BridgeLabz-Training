using System;

public abstract class WarehouseItem
{
    public string Name { get; set; }
    public double Price { get; set; }

    protected WarehouseItem(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public abstract void DisplayInfo();
}
