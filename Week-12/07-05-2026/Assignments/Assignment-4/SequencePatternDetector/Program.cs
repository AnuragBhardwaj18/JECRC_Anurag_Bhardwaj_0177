using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 3, 2, 3, 3, 4, 5, 3, 6, 7, 8, 9, 10, 3 };
        int k = 2;

        Console.WriteLine("--- Access Pattern Analysis ---\n");

        // Frequency count
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach (int num in arr)
        {
            if (freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num] = 1;
        }

        // Longest consecutive sequence
        int start = 0, maxLength = 0;

        foreach (int num in arr.Distinct())
        {
            if (!arr.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while (arr.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                if (length > maxLength)
                {
                    maxLength = length;
                    start = num;
                }
            }
        }

        Console.Write("Longest Consecutive Sequence: ");
        for (int i = start; i < start + maxLength; i++)
        {
            Console.Write(i);
            if (i < start + maxLength - 1)
                Console.Write(",");
        }
        Console.WriteLine(" (Length: " + maxLength + ")\n");

        // Most frequent element
        int mostFrequent = freq.OrderByDescending(x => x.Value).First().Key;
        int mostCount = freq[mostFrequent];

        Console.WriteLine("Most Frequent Element: " + mostFrequent +
                          " (appears " + mostCount + " times)\n");

        // First non-repeating element
        foreach (int num in arr)
        {
            if (freq[num] == 1)
            {
                Console.WriteLine("First Non-Repeating Element: " + num + "\n");
                break;
            }
        }

        // Pairs with difference K
        Console.WriteLine("Pairs with Difference " + k + ":");

        HashSet<int> unique = new HashSet<int>(arr);

        foreach (int num in unique.OrderBy(x => x))
        {
            if (unique.Contains(num + k))
            {
                Console.Write("(" + num + ", " + (num + k) + ") ");
            }
        }

        Console.WriteLine("\n");

        // Majority element
        double percentage = (mostCount * 100.0) / arr.Length;

        if (mostCount > arr.Length / 2)
        {
            Console.WriteLine("Majority Element: " + mostFrequent +
                              " (appears " + mostCount + " out of " + arr.Length +
                              " times - " + percentage.ToString("0.0") + "% - Majority)");
        }
        else
        {
            Console.WriteLine("Majority Element: " + mostFrequent +
                              " (appears " + mostCount + " out of " + arr.Length +
                              " times - " + percentage.ToString("0.0") + "% - No majority)");
        }
    }
}