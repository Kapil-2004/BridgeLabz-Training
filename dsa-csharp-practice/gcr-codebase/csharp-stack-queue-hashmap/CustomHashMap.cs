using System;

class HashNode
{
    public int Key;
    public int Value;
    public HashNode Next;

    public HashNode(int key, int value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private int size;
    private HashNode[] table;

    public CustomHashMap(int size)
    {
        this.size = size;
        table = new HashNode[size];
    }

    private int HashFunction(int key)
    {
        return key % size;
    }

    public void Put(int key, int value)
    {
        int index = HashFunction(key);
        HashNode head = table[index];

        while (head != null)
        {
            if (head.Key == key)
            {
                head.Value = value; // update
                return;
            }
            head = head.Next;
        }

        HashNode newNode = new HashNode(key, value);
        newNode.Next = table[index];
        table[index] = newNode;
    }

    public int Get(int key)
    {
        int index = HashFunction(key);
        HashNode head = table[index];

        while (head != null)
        {
            if (head.Key == key)
                return head.Value;
            head = head.Next;
        }

        return -1; // key not found
    }

    public void Remove(int key)
    {
        int index = HashFunction(key);
        HashNode head = table[index];
        HashNode prev = null;

        while (head != null)
        {
            if (head.Key == key)
            {
                if (prev == null)
                    table[index] = head.Next;
                else
                    prev.Next = head.Next;
                return;
            }
            prev = head;
            head = head.Next;
        }
    }

    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write("Bucket " + i + ": ");
            HashNode head = table[i];
            while (head != null)
            {
                Console.Write("[" + head.Key + ", " + head.Value + "] -> ");
                head = head.Next;
            }
            Console.WriteLine("null");
        }
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap map = new CustomHashMap(5);

        map.Put(1, 10);
        map.Put(6, 20);
        map.Put(11, 30);

        Console.WriteLine("Value for key 6: " + map.Get(6));

        map.Remove(6);
        Console.WriteLine("Value for key 6 after removal: " + map.Get(6));

        Console.WriteLine("\nHash Map Contents:");
        map.Display();
    }
}
