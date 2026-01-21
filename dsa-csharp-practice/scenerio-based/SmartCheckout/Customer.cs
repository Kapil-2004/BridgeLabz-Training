using System;

using System.Collections.Generic;

namespace SmartCheckout
{
    public class Customer
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }

        public Customer(string name)
        {
            Name = name;
            Items = new List<string>();
        }
    }
}
