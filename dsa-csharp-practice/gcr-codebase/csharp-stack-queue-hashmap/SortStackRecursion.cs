using System;
using System.Collections.Generic;

class SortStackRecursion
{
    static void SortStack(Stack<int> st)
    {
        if (st.Count == 0)
            return;

        int top = st.Pop();
        SortStack(st);
        InsertSorted(st, top);
    }

    static void InsertSorted(Stack<int> st, int value)
    {
        if (st.Count == 0 || st.Peek() <= value)
        {
            st.Push(value);
            return;
        }

        int temp = st.Pop();
        InsertSorted(st, value);
        st.Push(temp);
    }

    static void Main()
    {
        Stack<int> st = new Stack<int>();

        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element: ");
            st.Push(int.Parse(Console.ReadLine()));
        }

        SortStack(st);

        Console.WriteLine("\nSorted Stack (Top to Bottom):");
        while (st.Count > 0)
        {
            Console.WriteLine(st.Pop());
        }
    }
}
