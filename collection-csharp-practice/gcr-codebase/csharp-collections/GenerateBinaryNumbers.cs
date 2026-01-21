using System;
using System.Collections.Generic;

class GenerateBinaryNumbers
{
    static void Main()
    {
        int N = 5; // Input

        List<string> result = GenerateBinary(N);

        Console.WriteLine("First " + N + " Binary Numbers:");
        foreach (string s in result)
        {
            Console.Write(s + " ");
        }
    }

    static List<string> GenerateBinary(int n)
    {
        List<string> result = new List<string>();
        Queue<string> queue = new Queue<string>();

        // Start with "1"
        queue.Enqueue("1");

        for (int i = 0; i < n; i++)
        {
            string current = queue.Dequeue();
            result.Add(current);

            // Generate next binary numbers
            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }

        return result;
    }
}
