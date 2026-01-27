using System;
using System.Collections;

public class SuppressWarningsDemo
{
    public static void Main()
    {
        // Suppress warning for using non-generic collections (obsolete / type-safety warnings)
#pragma warning disable CS0618

        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Hello");
        list.Add(3.14);

#pragma warning restore CS0618

        Console.WriteLine("Contents of ArrayList:");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
