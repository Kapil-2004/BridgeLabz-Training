using System;

namespace SmartCheckout
{
    public class Item
    {
        public int Price { get; set; }
        public int Stock { get; set; }

        public Item(int price, int stock)
        {
            Price = price;
            Stock = stock;
        }
    }
}