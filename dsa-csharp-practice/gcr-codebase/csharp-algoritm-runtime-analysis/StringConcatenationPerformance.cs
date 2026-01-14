using System;
using System.Diagnostics;
using System.Text;

class StringConcatenationPerformance
{
    // ---------- Using string ----------
    static void UseString(int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += "a";
        }
    }

    // ---------- Using StringBuilder ----------
    static void UseStringBuilder(int count)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append("a");
        }
    }

    static void Test(int count, bool runString)
    {
        Stopwatch sw = new Stopwatch();

        Console.WriteLine("Operations Count: " + count);

        if (runString)
        {
            sw.Start();
            UseString(count);
            sw.Stop();
            Console.WriteLine("string Time: " + sw.ElapsedMilliseconds + " ms");
        }
        else
        {
            Console.WriteLine("string Time: Unusable (O(N²))");
        }

        sw.Restart();
        UseStringBuilder(count);
        sw.Stop();
        Console.WriteLine("StringBuilder Time: " + sw.ElapsedMilliseconds + " ms");
    }

    static void Main()
    {
        Test(1000, true);
        Console.WriteLine();

        Test(10000, true);
        Console.WriteLine();

        Test(1000000, false);
    }
}
