using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

// Step 1: Define CacheResult attribute
[AttributeUsage(AttributeTargets.Method)]
public class CacheResultAttribute : Attribute
{
}

// Step 2: Service class with an expensive method
class MathService
{
    [CacheResult]
    public int SlowSquare(int x)
    {
        Console.WriteLine("Computing SlowSquare for: " + x);
        Thread.Sleep(2000); // Simulate expensive computation
        return x * x;
    }
}

// Step 3: Demo class (same as file name)
public class CacheResultDemo
{
    // Cache storage: key -> result
    private static Dictionary<string, object> cache =
        new Dictionary<string, object>();

    public static void Main()
    {
        MathService service = new MathService();

        Console.WriteLine("First call:");
        int r1 = (int)InvokeWithCache(service, "SlowSquare", 5);
        Console.WriteLine("Result: " + r1 + "\n");

        Console.WriteLine("Second call with same input:");
        int r2 = (int)InvokeWithCache(service, "SlowSquare", 5);
        Console.WriteLine("Result: " + r2 + "\n");

        Console.WriteLine("Third call with different input:");
        int r3 = (int)InvokeWithCache(service, "SlowSquare", 6);
        Console.WriteLine("Result: " + r3);
    }

    // Invoke method using Reflection + Cache
    public static object InvokeWithCache(object obj, string methodName, int input)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);

        // Check if method has CacheResult attribute
        CacheResultAttribute attr =
            method.GetCustomAttribute<CacheResultAttribute>();

        string cacheKey = methodName + "_" + input;

        if (attr != null)
        {
            // If cached, return cached value
            if (cache.ContainsKey(cacheKey))
            {
                Console.WriteLine("Returning cached result for: " + input);
                return cache[cacheKey];
            }

            // Otherwise, compute and cache result
            object result = method.Invoke(obj, new object[] { input });
            cache[cacheKey] = result;
            return result;
        }
        else
        {
            // No caching, just invoke
            return method.Invoke(obj, new object[] { input });
        }
    }
}
