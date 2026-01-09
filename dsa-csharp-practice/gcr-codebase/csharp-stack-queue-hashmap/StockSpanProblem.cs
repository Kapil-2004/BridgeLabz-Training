using System;
using System.Collections.Generic;

class StockSpanProblem
{
    static void CalculateSpan(int[] prices, int n)
    {
        int[] span = new int[n];
        Stack<int> st = new Stack<int>();

        st.Push(0);
        span[0] = 1;

        for (int i = 1; i < n; i++)
        {
            while (st.Count > 0 && prices[st.Peek()] <= prices[i])
            {
                st.Pop();
            }

            span[i] = (st.Count == 0) ? (i + 1) : (i - st.Peek());
            st.Push(i);
        }

        Console.WriteLine("\nStock Spans:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(span[i] + " ");
        }
    }

    static void Main()
    {
        Console.Write("Enter number of days: ");
        int n = int.Parse(Console.ReadLine());

        int[] prices = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter price for day " + (i + 1) + ": ");
            prices[i] = int.Parse(Console.ReadLine());
        }

        CalculateSpan(prices, n);
    }
}
