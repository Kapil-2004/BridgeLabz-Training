using System;

class ItemNode
{
    public int id;
    public string name;
    public int qty;
    public double price;
    public ItemNode next;

    public ItemNode(int id, string name, int qty, double price)
    {
        this.id = id;
        this.name = name;
        this.qty = qty;
        this.price = price;
        next = null;
    }
}

class InventoryList
{
    private ItemNode head;

    // Add at beginning
    public void AddAtBeginning(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);

        if (head == null)
        {
            head = newNode;
            return;
        }

        ItemNode temp = head;
        while (temp.next != null)
            temp = temp.next;

        temp.next = newNode;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int pos, int id, string name, int qty, double price)
    {
        if (pos <= 1 || head == null)
        {
            AddAtBeginning(id, name, qty, price);
            return;
        }

        ItemNode temp = head;
        for (int i = 1; i < pos - 1 && temp.next != null; i++)
            temp = temp.next;

        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.next = temp.next;
        temp.next = newNode;
    }

    // Remove by Item ID
    public void RemoveById(int id)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        if (head.id == id)
        {
            head = head.next;
            Console.WriteLine("Item removed.");
            return;
        }

        ItemNode temp = head;
        while (temp.next != null && temp.next.id != id)
            temp = temp.next;

        if (temp.next == null)
            Console.WriteLine("Item not found.");
        else
        {
            temp.next = temp.next.next;
            Console.WriteLine("Item removed.");
        }
    }

    // Update quantity
    public void UpdateQuantity(int id, int newQty)
    {
        ItemNode temp = head;

        while (temp != null)
        {
            if (temp.id == id)
            {
                temp.qty = newQty;
                Console.WriteLine("Quantity updated.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Item not found.");
    }

    // Search by ID
    public void SearchById(int id)
    {
        ItemNode temp = head;

        while (temp != null)
        {
            if (temp.id == id)
            {
                DisplayItem(temp);
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Item not found.");
    }

    // Search by Name
    public void SearchByName(string name)
    {
        ItemNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                DisplayItem(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("Item not found.");
    }

    // Total inventory value
    public void TotalInventoryValue()
    {
        double total = 0;
        ItemNode temp = head;

        while (temp != null)
        {
            total += temp.qty * temp.price;
            temp = temp.next;
        }

        Console.WriteLine($"Total Inventory Value: {total}");
    }

    // Sort by name or price
    public void Sort(string type, bool ascending)
    {
        if (head == null) return;

        for (ItemNode i = head; i.next != null; i = i.next)
        {
            for (ItemNode j = i.next; j != null; j = j.next)
            {
                bool condition = false;

                if (type == "name")
                    condition = ascending ? i.name.CompareTo(j.name) > 0 : i.name.CompareTo(j.name) < 0;
                else if (type == "price")
                    condition = ascending ? i.price > j.price : i.price < j.price;

                if (condition)
                    Swap(i, j);
            }
        }

        Console.WriteLine("Inventory sorted.");
    }

    private void Swap(ItemNode a, ItemNode b)
    {
        (a.id, b.id) = (b.id, a.id);
        (a.name, b.name) = (b.name, a.name);
        (a.qty, b.qty) = (b.qty, a.qty);
        (a.price, b.price) = (b.price, a.price);
    }

    // Display all
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        ItemNode temp = head;
        while (temp != null)
        {
            DisplayItem(temp);
            temp = temp.next;
        }
    }

    private void DisplayItem(ItemNode i)
    {
        Console.WriteLine($"ID: {i.id}, Name: {i.name}, Qty: {i.qty}, Price: {i.price}");
    }
}

class Program
{
    static void Main()
    {
        InventoryList list = new InventoryList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Inventory Management ---");
            Console.WriteLine("1. Add at Beginning");
            Console.WriteLine("2. Add at End");
            Console.WriteLine("3. Add at Position");
            Console.WriteLine("4. Remove by ID");
            Console.WriteLine("5. Update Quantity");
            Console.WriteLine("6. Search by ID");
            Console.WriteLine("7. Search by Name");
            Console.WriteLine("8. Total Inventory Value");
            Console.WriteLine("9. Sort Inventory");
            Console.WriteLine("10. Display All");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            int id, qty, pos;
            string name, type;
            double price;
            bool asc;

            switch (choice)
            {
                case 1:
                    ReadItem(out id, out name, out qty, out price);
                    list.AddAtBeginning(id, name, qty, price);
                    break;

                case 2:
                    ReadItem(out id, out name, out qty, out price);
                    list.AddAtEnd(id, name, qty, price);
                    break;

                case 3:
                    Console.Write("Position: ");
                    pos = int.Parse(Console.ReadLine());
                    ReadItem(out id, out name, out qty, out price);
                    list.AddAtPosition(pos, id, name, qty, price);
                    break;

                case 4:
                    Console.Write("Item ID: ");
                    id = int.Parse(Console.ReadLine());
                    list.RemoveById(id);
                    break;

                case 5:
                    Console.Write("Item ID: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("New Quantity: ");
                    qty = int.Parse(Console.ReadLine());
                    list.UpdateQuantity(id, qty);
                    break;

                case 6:
                    Console.Write("Item ID: ");
                    id = int.Parse(Console.ReadLine());
                    list.SearchById(id);
                    break;

                case 7:
                    Console.Write("Item Name: ");
                    name = Console.ReadLine();
                    list.SearchByName(name);
                    break;

                case 8:
                    list.TotalInventoryValue();
                    break;

                case 9:
                    Console.Write("Sort by (name/price): ");
                    type = Console.ReadLine();
                    Console.Write("Ascending? (true/false): ");
                    asc = bool.Parse(Console.ReadLine());
                    list.Sort(type, asc);
                    break;

                case 10:
                    list.DisplayAll();
                    break;
            }

        } while (choice != 0);
    }

    static void ReadItem(out int id, out string name, out int qty, out double price)
    {
        Console.Write("Item ID: ");
        id = int.Parse(Console.ReadLine());
        Console.Write("Item Name: ");
        name = Console.ReadLine();
        Console.Write("Quantity: ");
        qty = int.Parse(Console.ReadLine());
        Console.Write("Price: ");
        price = double.Parse(Console.ReadLine());
    }
}
