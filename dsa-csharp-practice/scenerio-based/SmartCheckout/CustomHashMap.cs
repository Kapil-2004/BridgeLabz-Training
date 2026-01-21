using System;
using System.Collections.Generic;

namespace SmartCheckout
{
    // Simple generic HashMap using chaining
    public class CustomHashMap<K, V>
    {
        private const int SIZE = 16;
        private List<KeyValuePair<K, V>>[] buckets;

        public CustomHashMap()
        {
            buckets = new List<KeyValuePair<K, V>>[SIZE];
            for (int i = 0; i < SIZE; i++)
                buckets[i] = new List<KeyValuePair<K, V>>();
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % SIZE;
        }

        public void Put(K key, V value)
        {
            int index = GetIndex(key);

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    buckets[index].Remove(pair);
                    break;
                }
            }

            buckets[index].Add(new KeyValuePair<K, V>(key, value));
        }

        public bool ContainsKey(K key)
        {
            int index = GetIndex(key);

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                    return true;
            }

            return false;
        }

        public V Get(K key)
        {
            int index = GetIndex(key);

            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                    return pair.Value;
            }

            throw new KeyNotFoundException("Key not found: " + key);
        }

        public List<K> Keys()
        {
            List<K> keys = new List<K>();

            foreach (var bucket in buckets)
                foreach (var pair in bucket)
                    keys.Add(pair.Key);

            return keys;
        }
    }
}
