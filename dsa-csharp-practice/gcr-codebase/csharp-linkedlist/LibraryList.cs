using System;

class BookNode
{
    public int id;
    public string title;
    public string author;
    public string genre;
    public bool available;
    public BookNode prev;
    public BookNode next;

    public BookNode(int id, string title, string author, string genre, bool available)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        this.genre = genre;
        this.available = available;
        prev = null;
        next = null;
    }
}

class LibraryList
{
    private BookNode head;
    private BookNode tail;

    // Add at beginning
    public void AddAtBeginning(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        newNode.next = head;
        head.prev = newNode;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        tail.next = newNode;
        newNode.prev = tail;
        tail = newNode;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int pos, int id, string title, string author, string genre, bool available)
    {
        if (pos <= 1)
        {
            AddAtBeginning(id, title, author, genre, available);
            return;
        }

        BookNode temp = head;
        for (int i = 1; i < pos - 1 && temp.next != null; i++)
            temp = temp.next;

        if (temp.next == null)
        {
            AddAtEnd(id, title, author, genre, available);
            return;
        }

        BookNode newNode = new BookNode(id, title, author, genre, available);
        newNode.next = temp.next;
        newNode.prev = temp;
        temp.next.prev = newNode;
        temp.next = newNode;
    }

    // Remove by Book ID
    public void RemoveById(int id)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.id == id)
            {
                if (temp == head)
                {
                    head = head.next;
                    if (head != null)
                        head.prev = null;
                }
                else if (temp == tail)
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                else
                {
                    temp.prev.next = temp.next;
                    temp.next.prev = temp.prev;
                }

                Console.WriteLine("Book removed successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Book not found.");
    }

    // Search by title
    public void SearchByTitle(string title)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    // Search by author
    public void SearchByAuthor(string author)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                DisplayBook(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("Book not found.");
    }

    // Update availability
    public void UpdateAvailability(int id, bool status)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.id == id)
            {
                temp.available = status;
                Console.WriteLine("Availability updated.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Book not found.");
    }

    // Display forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        BookNode temp = head;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("Library is empty.");
            return;
        }

        BookNode temp = tail;
        while (temp != null)
        {
            DisplayBook(temp);
            temp = temp.prev;
        }
    }

    // Count books
    public void CountBooks()
    {
        int count = 0;
        BookNode temp = head;

        while (temp != null)
        {
            count++;
            temp = temp.next;
        }

        Console.WriteLine($"Total Books: {count}");
    }

    private void DisplayBook(BookNode b)
    {
        Console.WriteLine(
            $"ID: {b.id}, Title: {b.title}, Author: {b.author}, Genre: {b.genre}, Available: {b.available}");
    }
}

class Program
{
    static void Main()
    {
        LibraryList list = new LibraryList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add at Beginning");
            Console.WriteLine("2. Add at End");
            Console.WriteLine("3. Add at Position");
            Console.WriteLine("4. Remove by Book ID");
            Console.WriteLine("5. Search by Title");
            Console.WriteLine("6. Search by Author");
            Console.WriteLine("7. Update Availability");
            Console.WriteLine("8. Display Forward");
            Console.WriteLine("9. Display Reverse");
            Console.WriteLine("10. Count Books");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            int id, pos;
            string title, author, genre;
            bool available;

            switch (choice)
            {
                case 1:
                    ReadBook(out id, out title, out author, out genre, out available);
                    list.AddAtBeginning(id, title, author, genre, available);
                    break;

                case 2:
                    ReadBook(out id, out title, out author, out genre, out available);
                    list.AddAtEnd(id, title, author, genre, available);
                    break;

                case 3:
                    Console.Write("Position: ");
                    pos = int.Parse(Console.ReadLine());
                    ReadBook(out id, out title, out author, out genre, out available);
                    list.AddAtPosition(pos, id, title, author, genre, available);
                    break;

                case 4:
                    Console.Write("Book ID: ");
                    id = int.Parse(Console.ReadLine());
                    list.RemoveById(id);
                    break;

                case 5:
                    Console.Write("Book Title: ");
                    title = Console.ReadLine();
                    list.SearchByTitle(title);
                    break;

                case 6:
                    Console.Write("Author: ");
                    author = Console.ReadLine();
                    list.SearchByAuthor(author);
                    break;

                case 7:
                    Console.Write("Book ID: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("Available (true/false): ");
                    available = bool.Parse(Console.ReadLine());
                    list.UpdateAvailability(id, available);
                    break;

                case 8:
                    list.DisplayForward();
                    break;

                case 9:
                    list.DisplayReverse();
                    break;

                case 10:
                    list.CountBooks();
                    break;
            }

        } while (choice != 0);
    }

    static void ReadBook(out int id, out string title, out string author, out string genre, out bool available)
    {
        Console.Write("Book ID: ");
        id = int.Parse(Console.ReadLine());
        Console.Write("Title: ");
        title = Console.ReadLine();
        Console.Write("Author: ");
        author = Console.ReadLine();
        Console.Write("Genre: ");
        genre = Console.ReadLine();
        Console.Write("Available (true/false): ");
        available = bool.Parse(Console.ReadLine());
    }
}
