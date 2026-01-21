using System;
using System.Collections;

class Program
{
    static void ReverseArrayList(ArrayList list)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;

            left++;
            right--;
        }
    }

    static void Main()
    {
        ArrayList arrList = new ArrayList() { 1, 2, 3, 4, 5 };

        ReverseArrayList(arrList);

        Console.WriteLine("Reversed ArrayList:");
        foreach (var item in arrList)
            Console.Write(item + " ");
    }
}
