using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    static void Main()
    {
        // Dictionary to store product prices (Product -> Price)
        Dictionary<string, double> priceMap = new Dictionary<string, double>();

        // LinkedDictionary to maintain insertion order
        LinkedDictionary<string, double> cart = new LinkedDictionary<string, double>();

        // Add products to cart
        AddProduct(cart, priceMap, "Apple", 50);
        AddProduct(cart, priceMap, "Banana", 20);
        AddProduct(cart, priceMap, "Milk", 60);
        AddProduct(cart, priceMap, "Bread", 40);

        // Display cart in insertion order
        Console.WriteLine("Shopping Cart (Insertion Order):");
        foreach (var pair in cart)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }

        // Display cart sorted by price
        SortedDictionary<double, List<string>> sortedByPrice = new SortedDictionary<double, List<string>>();

        foreach (var pair in priceMap)
        {
            if (!sortedByPrice.ContainsKey(pair.Value))
                sortedByPrice[pair.Value] = new List<string>();

            sortedByPrice[pair.Value].Add(pair.Key);
        }

        Console.WriteLine("\nShopping Cart (Sorted by Price):");
        foreach (var pair in sortedByPrice)
        {
            foreach (var product in pair.Value)
            {
                Console.WriteLine(product + " : " + pair.Key);
            }
        }
    }

    static void AddProduct(
        LinkedDictionary<string, double> cart,
        Dictionary<string, double> priceMap,
        string product,
        double price)
    {
        if (!priceMap.ContainsKey(product))
        {
            priceMap[product] = price;
            cart.Add(product, price);
        }
    }
}

// Simulate LinkedDictionary (preserve insertion order + key-value pairs)
class LinkedDictionary<K, V>
{
    private Dictionary<K, V> dict = new Dictionary<K, V>();
    private LinkedList<K> order = new LinkedList<K>();

    public void Add(K key, V value)
    {
        if (!dict.ContainsKey(key))
        {
            dict[key] = value;
            order.AddLast(key);
        }
    }

    public bool ContainsKey(K key)
    {
        return dict.ContainsKey(key);
    }

    public V this[K key]
    {
        get { return dict[key]; }
        set { dict[key] = value; }
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        foreach (var key in order)
        {
            yield return new KeyValuePair<K, V>(key, dict[key]);
        }
    }
}
