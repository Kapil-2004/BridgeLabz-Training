using System;

namespace BookShelf
{
    public class CustomGenreMap
    {
        private GenreEntry[] buckets;
        private int size;

        public CustomGenreMap(int capacity)
        {
            size = capacity;
            buckets = new GenreEntry[size];
        }

        private int GetHash(string key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public GenreEntry GetGenre(string genre)
        {
            int index = GetHash(genre);
            GenreEntry current = buckets[index];

            while (current != null)
            {
                if (current.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                    return current;

                current = current.Next;
            }
            return null;
        }

        public GenreEntry AddGenre(string genre)
        {
            int index = GetHash(genre);
            GenreEntry existing = GetGenre(genre);

            if (existing != null)
                return existing;

            GenreEntry entry = new GenreEntry(genre);
            entry.Next = buckets[index];
            buckets[index] = entry;

            return entry;
        }

        public GenreEntry[] GetAllGenres()
        {
            return buckets;
        }
    }
}
