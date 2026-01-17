using System;

namespace FlashDealz
{
    public class Products
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Products(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void Display()
        {
            Console.WriteLine("Product: " + Name + " | Price: " + Price);
        }
    }
}
