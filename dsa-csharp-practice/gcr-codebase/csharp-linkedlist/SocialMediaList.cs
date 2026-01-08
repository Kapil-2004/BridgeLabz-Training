using System;
using System.Collections.Generic;

class UserNode
{
    public int id;
    public string name;
    public int age;
    public List<int> friends;
    public UserNode next;

    public UserNode(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        friends = new List<int>();
        next = null;
    }
}

class SocialMediaList
{
    private UserNode head;

    // Add new user
    public void AddUser(int id, string name, int age)
    {
        UserNode newNode = new UserNode(id, name, age);
        newNode.next = head;
        head = newNode;
    }

    // Find user by ID
    private UserNode FindById(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.id == id)
                return temp;
            temp = temp.next;
        }
        return null;
    }

    // Add friend connection
    public void AddFriend(int id1, int id2)
    {
        UserNode u1 = FindById(id1);
        UserNode u2 = FindById(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        if (!u1.friends.Contains(id2))
            u1.friends.Add(id2);

        if (!u2.friends.Contains(id1))
            u2.friends.Add(id1);

        Console.WriteLine("Friend connection added.");
    }

    // Remove friend connection
    public void RemoveFriend(int id1, int id2)
    {
        UserNode u1 = FindById(id1);
        UserNode u2 = FindById(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        u1.friends.Remove(id2);
        u2.friends.Remove(id1);

        Console.WriteLine("Friend connection removed.");
    }

    // Display friends of a user
    public void DisplayFriends(int id)
    {
        UserNode user = FindById(id);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine($"Friends of {user.name}:");
        if (user.friends.Count == 0)
        {
            Console.WriteLine("No friends.");
            return;
        }

        foreach (int fid in user.friends)
            Console.WriteLine($"Friend ID: {fid}");
    }

    // Mutual friends
    public void MutualFriends(int id1, int id2)
    {
        UserNode u1 = FindById(id1);
        UserNode u2 = FindById(id2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine("Mutual Friends:");
        bool found = false;

        foreach (int f in u1.friends)
        {
            if (u2.friends.Contains(f))
            {
                Console.WriteLine($"Friend ID: {f}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No mutual friends.");
    }

    // Search by ID
    public void SearchById(int id)
    {
        UserNode user = FindById(id);
        if (user == null)
            Console.WriteLine("User not found.");
        else
            DisplayUser(user);
    }

    // Search by Name
    public void SearchByName(string name)
    {
        UserNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                DisplayUser(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("User not found.");
    }

    // Count friends
    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            Console.WriteLine($"{temp.name} has {temp.friends.Count} friends.");
            temp = temp.next;
        }
    }

    private void DisplayUser(UserNode u)
    {
        Console.WriteLine($"ID: {u.id}, Name: {u.name}, Age: {u.age}, Friends: {u.friends.Count}");
    }
}

class Program
{
    static void Main()
    {
        SocialMediaList sm = new SocialMediaList();
        int choice;

        // Sample users
        sm.AddUser(1, "Alice", 20);
        sm.AddUser(2, "Bob", 21);
        sm.AddUser(3, "Charlie", 22);
        sm.AddUser(4, "David", 23);

        do
        {
            Console.WriteLine("\n--- Social Media Friend System ---");
            Console.WriteLine("1. Add Friend Connection");
            Console.WriteLine("2. Remove Friend Connection");
            Console.WriteLine("3. Find Mutual Friends");
            Console.WriteLine("4. Display Friends of User");
            Console.WriteLine("5. Search User by ID");
            Console.WriteLine("6. Search User by Name");
            Console.WriteLine("7. Count Friends for Each User");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            int id1, id2;
            string name;

            switch (choice)
            {
                case 1:
                    Console.Write("User ID 1: ");
                    id1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    id2 = int.Parse(Console.ReadLine());
                    sm.AddFriend(id1, id2);
                    break;

                case 2:
                    Console.Write("User ID 1: ");
                    id1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    id2 = int.Parse(Console.ReadLine());
                    sm.RemoveFriend(id1, id2);
                    break;

                case 3:
                    Console.Write("User ID 1: ");
                    id1 = int.Parse(Console.ReadLine());
                    Console.Write("User ID 2: ");
                    id2 = int.Parse(Console.ReadLine());
                    sm.MutualFriends(id1, id2);
                    break;

                case 4:
                    Console.Write("User ID: ");
                    id1 = int.Parse(Console.ReadLine());
                    sm.DisplayFriends(id1);
                    break;

                case 5:
                    Console.Write("User ID: ");
                    id1 = int.Parse(Console.ReadLine());
                    sm.SearchById(id1);
                    break;

                case 6:
                    Console.Write("User Name: ");
                    name = Console.ReadLine();
                    sm.SearchByName(name);
                    break;

                case 7:
                    sm.CountFriends();
                    break;
            }

        } while (choice != 0);
    }
}
