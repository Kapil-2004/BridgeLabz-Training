using System;
using System.Collections.Generic;

class ReverseQueue
{
    static void Main()
    {
        // Input queue
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Console.WriteLine("Original Queue:");
        PrintQueue(queue);

        ReverseQueue(queue);

        Console.WriteLine("\nReversed Queue:");
        PrintQueue(queue);
    }

    static void ReverseQueue(Queue<int> queue)
    {
        // Base case
        if (queue.Count == 0)
            return;

        // Remove front element
        int front = queue.Dequeue();

        // Reverse remaining queue
        ReverseQueue(queue);

        // Add removed element to the rear
        queue.Enqueue(front);
    }

    static void PrintQueue(Queue<int> queue)
    {
        foreach (int item in queue)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
