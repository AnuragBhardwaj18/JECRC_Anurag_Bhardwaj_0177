using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = "The quick brown fox jumps over the lazy dog. The fox is quick and the dog is lazy. Quick brown fox jumps over the lazy dog again.";

        int N = 3;

        // Convert into lowercase
        text = text.ToLower();

        // Remove punctuation manually
        text = text.Replace(".", "")
                   .Replace(",", "");

        // Split words
        string[] words = text.Split(' ');

        // Store frequency
        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (freq.ContainsKey(word))
            {
                freq[word]++;
            }
            else
            {
                freq[word] = 1;
            }
        }

        Console.WriteLine("--- Word Frequency Analysis ---\n");

        // Total words
        Console.WriteLine("Total words: " + words.Length);

        // Unique words
        Console.WriteLine("Unique words: " + freq.Count);

        Console.WriteLine("\nTop " + N + " Frequent Words:\n");

        // Top frequent words
        var topWords = freq.OrderByDescending(x => x.Value).Take(N);

        foreach (var item in topWords)
        {
            Console.WriteLine(item.Key + ": " + item.Value + " times");
        }

        Console.WriteLine("\nWords appearing exactly once:\n");

        foreach (var item in freq)
        {
            if (item.Value == 1)
            {
                Console.Write(item.Key + " ");
            }
        }

        // Average frequency
        double average = (double)words.Length / freq.Count;

        Console.WriteLine("\n\nAverage frequency: " + average.ToString("0.00"));
    }
}