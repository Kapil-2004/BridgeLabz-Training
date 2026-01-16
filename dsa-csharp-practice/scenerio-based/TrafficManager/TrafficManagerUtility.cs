using System;

namespace TrafficManager
{
    public class TrafficManagerUtility : ITrafficManager
    {
        private CarNode last;          // Circular Linked List
        private Car[] queue;           // Queue
        private int front;
        private int rear;
        private int capacity;

        public TrafficManagerUtility(int queueSize)
        {
            last = null;
            capacity = queueSize;
            queue = new Car[capacity];
            front = 0;
            rear = -1;
        }

        // ================= QUEUE =================

        public void AddCarToQueue()
        {
            if (rear == capacity - 1)
            {
                Console.WriteLine("Queue Overflow! Cannot add more cars.");
                return;
            }

            Console.Write("Enter car number: ");
            string number = Console.ReadLine();

            queue[++rear] = new Car(number);
            Console.WriteLine("Car added to waiting queue: " + number);
        }

        public void MoveCarToRoundabout()
        {
            if (rear < front)
            {
                Console.WriteLine("Queue Underflow! No cars waiting.");
                return;
            }

            Car car = queue[front++];
            AddCarToCircularList(car);
        }

        // ================= CIRCULAR LINKED LIST =================

        public void AddCarToCircularList(Car car)
        {
            CarNode newNode = new CarNode(car);

            if (last == null)
            {
                last = newNode;
                last.Next = last;
            }
            else
            {
                newNode.Next = last.Next;
                last.Next = newNode;
                last = newNode;
            }

            Console.WriteLine("Car entered roundabout: " + car.CarNumber);
        }

        public Car RemoveCarFromRoundabout()
        {
            if (last == null)
            {
                Console.WriteLine("Roundabout is empty");
                return null;
            }

            CarNode first = last.Next;
            Car removedCar = first.Data;

            if (first == last)
            {
                last = null;
            }
            else
            {
                last.Next = first.Next;
            }

            Console.WriteLine("Car exited roundabout: " + removedCar.CarNumber);
            return removedCar;
        }

        public void DisplayRoundabout()
        {
            if (last == null)
            {
                Console.WriteLine("Roundabout is empty");
                return;
            }

            CarNode temp = last.Next;
            Console.Write("Roundabout: ");

            do
            {
                Console.Write(temp.Data.CarNumber + " -> ");
                temp = temp.Next;
            }
            while (temp != last.Next);

            Console.WriteLine("(back to start)");
        }
    }
}
