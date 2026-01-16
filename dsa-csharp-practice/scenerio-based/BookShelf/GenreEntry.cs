using System.Collections.Generic;

namespace BookShelf
{
    public class GenreEntry
    {
        public string Genre { get; private set; }
        public LinkedList<Book> Books { get; private set; }
        public GenreEntry Next { get; set; }

        public GenreEntry(string genre)
        {
            Genre = genre;
            Books = new LinkedList<Book>();
            Next = null;
        }
    }
}
