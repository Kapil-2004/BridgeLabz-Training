using System;

namespace TrafficManager
{
    public class CarQueue
    {
        private Car[] queue;   // ✅ Car array
        private int front;
        private int rear;
        private int capacity;

        public CarQueue(int size)
        {
            capacity = size;
            queue = new Car[size];
            front = 0;
            rear = -1;
        }

        public bool IsFull()
        {
            return rear == capacity - 1;
        }

        public bool IsEmpty()
        {
            return rear < front;
        }

        public void Enqueue(string number)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue Overflow! Vehicle cannot enter.");
                return;
            }

            queue[++rear] = new Car(number);   // ✅ create Car
            Console.WriteLine("Vehicle added to waiting queue: " + number);
        }

        public Car Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue Underflow! No waiting vehicles.");
                return null;
            }

            return queue[front++];   // ✅ return Car
        }
    }
}
