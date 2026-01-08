using System;

class MovieNode
{
    public string title;
    public string director;
    public int year;
    public double rating;
    public MovieNode prev;
    public MovieNode next;

    public MovieNode(string title, string director, int year, double rating)
    {
        this.title = title;
        this.director = director;
        this.year = year;
        this.rating = rating;
        prev = null;
        next = null;
    }
}

class MovieDoublyLinkedList
{
    private MovieNode head;
    private MovieNode tail;

    // Add at beginning
    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

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
    public void AddAtEnd(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        tail.next = newNode;
        newNode.prev = tail;
        tail = newNode;
    }

    // Add at specific position (1-based index)
    public void AddAtPosition(int pos, string title, string director, int year, double rating)
    {
        if (pos <= 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        MovieNode temp = head;
        for (int i = 1; i < pos - 1 && temp != null; i++)
        {
            temp = temp.next;
        }

        if (temp == null || temp.next == null)
        {
            AddAtEnd(title, director, year, rating);
            return;
        }

        MovieNode newNode = new MovieNode(title, director, year, rating);
        newNode.next = temp.next;
        newNode.prev = temp;
        temp.next.prev = newNode;
        temp.next = newNode;
    }

    // Remove by movie title
    public void RemoveByTitle(string title)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.title.Equals(title, StringComparison.OrdinalIgnoreCase))
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

                Console.WriteLine("Movie removed successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found!");
    }

    // Search by director
    public void SearchByDirector(string director)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.director.Equals(director, StringComparison.OrdinalIgnoreCase))
            {
                DisplayMovie(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No movies found for this director.");
    }

    // Search by rating
    public void SearchByRating(double rating)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.rating == rating)
            {
                DisplayMovie(temp);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No movies found with this rating.");
    }

    // Update rating by title
    public void UpdateRating(string title, double newRating)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                temp.rating = newRating;
                Console.WriteLine("Rating updated successfully.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found!");
    }

    // Display forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("No movie records.");
            return;
        }

        MovieNode temp = head;
        while (temp != null)
        {
            DisplayMovie(temp);
            temp = temp.next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("No movie records.");
            return;
        }

        MovieNode temp = tail;
        while (temp != null)
        {
            DisplayMovie(temp);
            temp = temp.prev;
        }
    }

    private void DisplayMovie(MovieNode m)
    {
        Console.WriteLine($"Title: {m.title}, Director: {m.director}, Year: {m.year}, Rating: {m.rating}");
    }
}

class Program
{
    static void Main()
    {
        MovieDoublyLinkedList list = new MovieDoublyLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Movie Management System ---");
            Console.WriteLine("1. Add at Beginning");
            Console.WriteLine("2. Add at End");
            Console.WriteLine("3. Add at Position");
            Console.WriteLine("4. Remove by Title");
            Console.WriteLine("5. Search by Director");
            Console.WriteLine("6. Search by Rating");
            Console.WriteLine("7. Display Forward");
            Console.WriteLine("8. Display Reverse");
            Console.WriteLine("9. Update Rating");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            string title, director;
            int year, pos;
            double rating;

            switch (choice)
            {
                case 1:
                    ReadMovie(out title, out director, out year, out rating);
                    list.AddAtBeginning(title, director, year, rating);
                    break;

                case 2:
                    ReadMovie(out title, out director, out year, out rating);
                    list.AddAtEnd(title, director, year, rating);
                    break;

                case 3:
                    Console.Write("Position: ");
                    pos = int.Parse(Console.ReadLine());
                    ReadMovie(out title, out director, out year, out rating);
                    list.AddAtPosition(pos, title, director, year, rating);
                    break;

                case 4:
                    Console.Write("Enter Movie Title: ");
                    title = Console.ReadLine();
                    list.RemoveByTitle(title);
                    break;

                case 5:
                    Console.Write("Enter Director Name: ");
                    director = Console.ReadLine();
                    list.SearchByDirector(director);
                    break;

                case 6:
                    Console.Write("Enter Rating: ");
                    rating = double.Parse(Console.ReadLine());
                    list.SearchByRating(rating);
                    break;

                case 7:
                    list.DisplayForward();
                    break;

                case 8:
                    list.DisplayReverse();
                    break;

                case 9:
                    Console.Write("Enter Movie Title: ");
                    title = Console.ReadLine();
                    Console.Write("Enter New Rating: ");
                    rating = double.Parse(Console.ReadLine());
                    list.UpdateRating(title, rating);
                    break;
            }

        } while (choice != 0);
    }

    static void ReadMovie(out string title, out string director, out int year, out double rating)
    {
        Console.Write("Title: ");
        title = Console.ReadLine();
        Console.Write("Director: ");
        director = Console.ReadLine();
        Console.Write("Year: ");
        year = int.Parse(Console.ReadLine());
        Console.Write("Rating: ");
        rating = double.Parse(Console.ReadLine());
    }
}
