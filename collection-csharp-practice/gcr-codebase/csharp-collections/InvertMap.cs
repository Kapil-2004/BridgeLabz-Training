using System;
using System.Collections.Generic;

class InvertMap
{
    static void Main()
    {
        // Input dictionary
        Dictionary<string, int> original = new Dictionary<string, int>
        {
            {"A", 1},
            {"B", 2},
            {"C", 1}
        };

        Dictionary<int, List<string>> inverted = InvertDictionary(original);

        // Print result
        Console.WriteLine("Inverted Dictionary:");
        foreach (var pair in inverted)
        {
            Console.Write(pair.Key + " = [");
            Console.Write(string.Join(", ", pair.Value));
            Console.WriteLine("]");
        }
    }

    static Dictionary<V, List<K>> InvertDictionary<K, V>(Dictionary<K, V> dict)
    {
        Dictionary<V, List<K>> inverted = new Dictionary<V, List<K>>();

        foreach (var pair in dict)
        {
            if (!inverted.ContainsKey(pair.Value))
            {
                inverted[pair.Value] = new List<K>();
            }
            inverted[pair.Value].Add(pair.Key);
        }

        return inverted;
    }
}
