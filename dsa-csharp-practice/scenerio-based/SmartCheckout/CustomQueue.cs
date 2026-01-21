using System;
using System.Collections.Generic;

namespace SmartCheckout
{
    // Simple generic FIFO queue
    public class CustomQueue<T>
    {
        private List<T> items;

        public CustomQueue()
        {
            items = new List<T>();
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            T value = items[0];
            items.RemoveAt(0);
            return value;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }

        public int Count()
        {
            return items.Count;
        }

        public List<T> GetAll()
        {
            return new List<T>(items);
        }
    }
}
