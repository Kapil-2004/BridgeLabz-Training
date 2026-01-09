using System;
using System.Collections.Generic;

class QueueUsingStacks
{
    private Stack<int> inStack = new Stack<int>();
    private Stack<int> outStack = new Stack<int>();

    public void Enqueue(int x)
    {
        inStack.Push(x);
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }

        MoveIfNeeded();
        return outStack.Pop();
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return -1;
        }

        MoveIfNeeded();
        return outStack.Peek();
    }

    public bool IsEmpty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }

    private void MoveIfNeeded()
    {
        if (outStack.Count == 0)
        {
            while (inStack.Count > 0)
            {
                outStack.Push(inStack.Pop());
            }
        }
    }
}

class Program
{
    static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();
        int choice;

        do
        {
            Console.WriteLine("\n1. Enqueue");
            Console.WriteLine("2. Dequeue");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Is Empty");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnqueueElement(queue);
                    break;

                case 2:
                    DequeueElement(queue);
                    break;

                case 3:
                    PeekElement(queue);
                    break;

                case 4:
                    Console.WriteLine(queue.IsEmpty() ? "Queue is Empty" : "Queue is Not Empty");
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 5);
    }

    static void EnqueueElement(QueueUsingStacks queue)
    {
        Console.Write("Enter value to enqueue: ");
        int value = int.Parse(Console.ReadLine());
        queue.Enqueue(value);
        Console.WriteLine("Enqueued successfully");
    }

    static void DequeueElement(QueueUsingStacks queue)
    {
        int value = queue.Dequeue();
        if (value != -1)
            Console.WriteLine("Dequeued: " + value);
    }

    static void PeekElement(QueueUsingStacks queue)
    {
        int value = queue.Peek();
        if (value != -1)
            Console.WriteLine("Front element: " + value);
    }
}
