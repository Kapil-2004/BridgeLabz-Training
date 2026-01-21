using System;
using System.Collections.Generic;

class FindFrequency
{
    static void Main()
    {
        // Input list
        List<string> list = new List<string>
        {
            "apple", "banana", "apple", "orange"
        };

        // Dictionary to store frequencies
        Dictionary<string, int> frequency = new Dictionary<string, int>();

        // Count frequency
        foreach (string item in list)
        {
            if (frequency.ContainsKey(item))
            {
                frequency[item] = frequency[item] + 1;
            }
            else
            {
                frequency[item] = 1;
            }
        }

        // Print result
        Console.WriteLine("Element Frequencies:");
        foreach (var pair in frequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}
