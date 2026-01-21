using System;
using System.Collections.Generic;

namespace SmartCheckout
{
    public class SmartCheckoutUtility : ISmartCheckout
    {
        private CustomQueue<Customer> queue;
        private CustomHashMap<string, Item> itemMap;

        public SmartCheckoutUtility()
        {
            queue = new CustomQueue<Customer>();
            itemMap = new CustomHashMap<string, Item>();

            LoadItems();
        }

        // ===== Load Initial Items (stored in lowercase) =====
        private void LoadItems()
        {
            itemMap.Put("milk", new Item(50, 20));
            itemMap.Put("bread", new Item(40, 15));
            itemMap.Put("rice", new Item(60, 30));
            itemMap.Put("eggs", new Item(10, 50));
        }

        // ===== Display All Items =====
        private void DisplayAllItems()
        {
            Console.WriteLine("\nAvailable Items:");

            foreach (var key in itemMap.Keys())
            {
                Item item = itemMap.Get(key);
                Console.WriteLine(
                    "- " + Capitalize(key) +
                    " | Price: ₹" + item.Price +
                    " | Stock: " + item.Stock
                );
            }
        }

        // ===== Menu Option 1: Add Customer =====
        public void AddCustomer()
        {
            Console.Write("\nEnter customer name: ");
            string name = Console.ReadLine();

            Customer customer = new Customer(name);

            DisplayAllItems();

            Console.Write("\nEnter number of items: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter item name: ");
                string input = Console.ReadLine();
                string itemKey = input.ToLower();   // 🔹 case-insensitive

                if (!itemMap.ContainsKey(itemKey))
                {
                    Console.WriteLine("Item not found. Choose from the list.");
                    i--;
                    continue;
                }

                Item item = itemMap.Get(itemKey);

                if (item.Stock <= 0)
                {
                    Console.WriteLine("Out of stock.");
                    i--;
                    continue;
                }

                customer.Items.Add(itemKey);
            }

            queue.Enqueue(customer);
            Console.WriteLine("Customer added to queue.");
        }

        // ===== Menu Option 2: Serve Customer =====
        public void ServeCustomer()
        {
            if (queue.IsEmpty())
            {
                Console.WriteLine("No customers in queue.");
                return;
            }

            Customer customer = queue.Dequeue();
            int totalBill = 0;

            Console.WriteLine("\nServing Customer: " + customer.Name);

            foreach (var itemKey in customer.Items)
            {
                Item item = itemMap.Get(itemKey);
                totalBill += item.Price;
                item.Stock--; // 🔹 update stock
            }

            Console.WriteLine("Total Bill: ₹" + totalBill);
            Console.WriteLine("Customer checkout complete.");
        }

        // ===== Menu Option 3: Show Queue =====
        public void ShowQueue()
        {
            if (queue.IsEmpty())
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            Console.WriteLine("\nCustomers in Queue:");

            foreach (var customer in queue.GetAll())
            {
                Console.WriteLine("- " + customer.Name);
            }
        }

        // ===== Utility =====
        private string Capitalize(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
