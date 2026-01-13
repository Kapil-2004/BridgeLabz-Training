using System;

namespace BookBuddy
{
    interface IBookBuddy
    {
        void AddBook(string title, string author);
        void DisplayBooks();
        void SortBooksAlphabetically();
        void SearchByAuthor(string author);
        string[] ExportBooks();
    }
}
