using System;
using System.Collections.Generic;

namespace BookBuddy
{
    class BookUtility : IBookBuddy
    {
        private List<Book> books = new List<Book>();

        public void AddBook(string title, string author)
        {
            books.Add(new Book(title, author));
            Console.WriteLine("Book added successfully.");
        }

        public void DisplayBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Bookshelf is empty.");
                return;
            }

            foreach (Book book in books)
            {
                Console.WriteLine(book.GetDetails());
            }
        }

        public void SortBooksAlphabetically()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books to sort.");
                return;
            }

            books.Sort((a, b) => a.Title.CompareTo(b.Title));
            Console.WriteLine("Books sorted alphabetically.");
        }

        public void SearchByAuthor(string author)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Bookshelf is empty.");
                return;
            }

            bool found = false;

            foreach (Book book in books)
            {
                if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book.GetDetails());
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No books found for this author.");
        }

        public string[] ExportBooks()
        {
            string[] result = new string[books.Count];

            for (int i = 0; i < books.Count; i++)
            {
                result[i] = books[i].GetDetails();
            }

            return result;
        }
    }
}
