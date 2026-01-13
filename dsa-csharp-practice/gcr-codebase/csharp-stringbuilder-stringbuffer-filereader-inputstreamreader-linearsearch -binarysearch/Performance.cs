using System;
using System.Diagnostics;
using System.Text;

class Performance
{
    static void Main()
    {
        int iterations = 100000;

        // -------- String Concatenation --------
        Stopwatch sw1 = Stopwatch.StartNew();
        string normalString = "";

        for (int i = 0; i < iterations; i++)
        {
            normalString += "A";
        }

        sw1.Stop();
        Console.WriteLine("String Concatenation Time: " + sw1.ElapsedMilliseconds + " ms");

        // -------- StringBuilder Concatenation --------
        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            sb.Append("A");
        }

        sw2.Stop();
        Console.WriteLine("StringBuilder Time: " + sw2.ElapsedMilliseconds + " ms");
    }
}
