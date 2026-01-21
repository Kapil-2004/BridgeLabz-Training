using System;
using System.Collections.Generic;
using System.Linq;

class InsurancePolicySystem
{
    static void Main()
    {
        // Sample policies
        List<Policy> policies = new List<Policy>
        {
            new Policy("P1001", DateTime.Today.AddDays(10), "Health"),
            new Policy("P1002", DateTime.Today.AddDays(40), "Life"),
            new Policy("P1003", DateTime.Today.AddDays(20), "Car"),
            new Policy("P1004", DateTime.Today.AddDays(5), "Health"),
            new Policy("P1001", DateTime.Today.AddDays(10), "Health") // Duplicate
        };

        // Store unique policies (by Policy Number)
        HashSet<Policy> uniquePolicies = new HashSet<Policy>(policies);

        // Maintain insertion order using LinkedList + HashSet
        LinkedHashSet<Policy> linkedPolicies = new LinkedHashSet<Policy>();
        foreach (var p in policies)
        {
            linkedPolicies.Add(p);
        }

        // SortedSet by Expiry Date
        SortedSet<Policy> sortedPolicies = new SortedSet<Policy>(uniquePolicies, new PolicyExpiryComparer());

        // Display all unique policies
        Console.WriteLine("All Unique Policies:");
        foreach (var p in uniquePolicies)
            Console.WriteLine(p);

        // Policies expiring in next 30 days
        Console.WriteLine("\nPolicies expiring within 30 days:");
        DateTime now = DateTime.Today;
        foreach (var p in sortedPolicies)
        {
            if ((p.ExpiryDate - now).TotalDays <= 30)
                Console.WriteLine(p);
        }

        // Policies with a specific coverage type
        string coverageType = "Health";
        Console.WriteLine($"\nPolicies with coverage type: {coverageType}");
        foreach (var p in uniquePolicies)
        {
            if (p.CoverageType.Equals(coverageType, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(p);
        }

        // Duplicate policies based on policy number
        Console.WriteLine("\nDuplicate policies based on policy number:");
        var duplicates = policies.GroupBy(p => p.PolicyNumber)
                                 .Where(g => g.Count() > 1)
                                 .SelectMany(g => g);
        foreach (var p in duplicates)
            Console.WriteLine(p);
    }
}

// Policy class
class Policy
{
    public string PolicyNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string CoverageType { get; set; }

    public Policy(string number, DateTime expiry, string coverage)
    {
        PolicyNumber = number;
        ExpiryDate = expiry;
        CoverageType = coverage;
    }

    // HashSet uses this to detect duplicates
    public override bool Equals(object obj)
    {
        if (obj is Policy other)
            return this.PolicyNumber == other.PolicyNumber;
        return false;
    }

    public override int GetHashCode()
    {
        return PolicyNumber.GetHashCode();
    }

    public override string ToString()
    {
        return $"PolicyNumber: {PolicyNumber}, Expiry: {ExpiryDate.ToShortDateString()}, Coverage: {CoverageType}";
    }
}

// Comparer for SortedSet by ExpiryDate
class PolicyExpiryComparer : IComparer<Policy>
{
    public int Compare(Policy x, Policy y)
    {
        int result = x.ExpiryDate.CompareTo(y.ExpiryDate);
        if (result == 0)
            result = x.PolicyNumber.CompareTo(y.PolicyNumber); // Tie-breaker
        return result;
    }
}

// Simulate LinkedHashSet (preserve insertion order + uniqueness)
class LinkedHashSet<T>
{
    private HashSet<T> set = new HashSet<T>();
    private LinkedList<T> list = new LinkedList<T>();

    public bool Add(T item)
    {
        if (set.Add(item))
        {
            list.AddLast(item);
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }
}
