using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    static void Main()
    {
        // Dictionary to store votes (Candidate -> Vote Count)
        Dictionary<string, int> votes = new Dictionary<string, int>();

        // Simulate voting
        List<string> votesCast = new List<string>
        {
            "Alice", "Bob", "Alice", "Charlie", "Bob", "Alice"
        };

        // Count votes
        foreach (var candidate in votesCast)
        {
            if (votes.ContainsKey(candidate))
                votes[candidate]++;
            else
                votes[candidate] = 1;
        }

        // Display votes in order of candidate names using SortedDictionary
        SortedDictionary<string, int> sortedResults = new SortedDictionary<string, int>(votes);
        Console.WriteLine("Votes sorted by candidate name:");
        foreach (var pair in sortedResults)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }

        // Maintain order of votes cast using LinkedHashMap simulation
        LinkedHashMap<string, int> linkedVoteOrder = new LinkedHashMap<string, int>();
        foreach (var candidate in votesCast)
        {
            if (linkedVoteOrder.ContainsKey(candidate))
                linkedVoteOrder[candidate]++;
            else
                linkedVoteOrder.Add(candidate, 1);
        }

        Console.WriteLine("\nVotes in order of first appearance:");
        foreach (var pair in linkedVoteOrder)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
}

// Simulate LinkedHashMap (preserve insertion order + key-value pairs)
class LinkedHashMap<K, V>
{
    private Dictionary<K, V> dict = new Dictionary<K, V>();
    private LinkedList<K> order = new LinkedList<K>();

    public void Add(K key, V value)
    {
        if (!dict.ContainsKey(key))
        {
            dict[key] = value;
            order.AddLast(key);
        }
    }

    public bool ContainsKey(K key)
    {
        return dict.ContainsKey(key);
    }

    public V this[K key]
    {
        get { return dict[key]; }
        set { dict[key] = value; }
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        foreach (var key in order)
        {
            yield return new KeyValuePair<K, V>(key, dict[key]);
        }
    }
}
