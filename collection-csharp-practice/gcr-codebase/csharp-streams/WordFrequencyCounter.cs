using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    static void Main()
    {
        string filePath = "input.txt";   // Change to your file path

        try
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: " + filePath);
                return;
            }

            Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            long totalWordCount = 0;

            // Use StreamReader to read the file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Extract words using regex (handles punctuation)
                    string[] words = Regex.Split(line, @"\W+");

                    foreach (string word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                            continue;

                        totalWordCount++;

                        if (wordCounts.ContainsKey(word))
                            wordCounts[word]++;
                        else
                            wordCounts[word] = 1;
                    }
                }
            }

            // Sort words by frequency (descending), then alphabetically
            var topWords = wordCounts
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .Take(5);

            Console.WriteLine("========= WORD COUNT RESULT =========");
            Console.WriteLine("Total Words: " + totalWordCount);
            Console.WriteLine("\nTop 5 Most Frequent Words:\n");

            int rank = 1;
            foreach (var item in topWords)
            {
                Console.WriteLine($"{rank}. {item.Key}  →  {item.Value} times");
                rank++;
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access denied:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}