using System;

namespace BookBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BookBuddy – Digital Bookshelf App");
            BookMain main = new BookMain();
            main.Start();
        }
    }
}
