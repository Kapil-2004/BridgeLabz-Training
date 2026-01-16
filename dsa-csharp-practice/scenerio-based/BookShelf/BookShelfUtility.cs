using System;
using System.Collections.Generic;

namespace BookShelf
{
    public class BookShelfUtility : IBookShelfManager
    {
        private Dictionary<string, LinkedList<Book>> catalog;

        public BookShelfUtility()
        {
            catalog = new Dictionary<string, LinkedList<Book>>();
        }

        // ================= ADD BOOK =================
        public void AddBook()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();

            if (!catalog.ContainsKey(genre))
            {
                catalog[genre] = new LinkedList<Book>();
            }

            // Avoid duplication
            foreach (Book b in catalog[genre])
            {
                if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                    b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Duplicate book! Already exists.");
                    return;
                }
            }

            catalog[genre].AddLast(new Book(title, author));
            Console.WriteLine("Book added successfully.");
        }

        // ================= REMOVE BOOK =================
        public void RemoveBook()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            if (!catalog.ContainsKey(genre))
            {
                Console.WriteLine("Genre not found.");
                return;
            }

            Console.Write("Enter Book Title to remove: ");
            string title = Console.ReadLine();

            LinkedList<Book> books = catalog[genre];
            LinkedListNode<Book> current = books.First;

            while (current != null)
            {
                if (current.Value.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    books.Remove(current);
                    Console.WriteLine("Book removed successfully.");

                    if (books.Count == 0)
                        catalog.Remove(genre);

                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Book not found.");
        }

        // ================= DISPLAY BY GENRE =================
        public void DisplayByGenre()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            if (!catalog.ContainsKey(genre))
            {
                Console.WriteLine("Genre not found.");
                return;
            }

            Console.WriteLine("Books in " + genre + ":");
            foreach (Book book in catalog[genre])
            {
                Console.WriteLine("- " + book.Title + " by " + book.Author);
            }
        }

        // ================= DISPLAY ALL =================
        public void DisplayAll()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Library is empty.");
                return;
            }

            foreach (var entry in catalog)
            {
                Console.WriteLine("\nGenre: " + entry.Key);
                foreach (Book book in entry.Value)
                {
                    Console.WriteLine("- " + book.Title + " by " + book.Author);
                }
            }
        }
    }
}
