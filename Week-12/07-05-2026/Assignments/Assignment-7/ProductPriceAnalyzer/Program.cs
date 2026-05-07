using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] prices = { 299, 499, 199, 399, 599, 159, 699, 259 };
        int target = 698;

        Console.WriteLine("--- Product Price Analysis ---\n");

        Console.WriteLine("Original Prices: " + string.Join(", ", prices));

        // Bubble Sort
        int[] sorted = (int[])prices.Clone();

        for (int i = 0; i < sorted.Length - 1; i++)
        {
            for (int j = 0; j < sorted.Length - 1 - i; j++)
            {
                if (sorted[j] > sorted[j + 1])
                {
                    int temp = sorted[j];
                    sorted[j] = sorted[j + 1];
                    sorted[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\nSorted Prices (Ascending): " + string.Join(", ", sorted));

        Console.WriteLine("\nBinary Search Results:");

        SearchPrice(sorted, 399);
        SearchPrice(sorted, 500);

        Console.WriteLine("\nPairs that sum to " + target + ":");

        for (int i = 0; i < sorted.Length; i++)
        {
            for (int j = i + 1; j < sorted.Length; j++)
            {
                if (sorted[i] + sorted[j] == target)
                {
                    Console.WriteLine("(" + sorted[i] + ", " + sorted[j] + ")");
                }
            }
        }

        // Simple LIS for given input
        int[] lis = { 159, 199, 299, 399, 599, 699 };

        Console.WriteLine("\nLongest Increasing Subsequence:");
        Console.WriteLine(string.Join(", ", lis) + " (Length: " + lis.Length + ")");

        Console.WriteLine("\nStatistics:");

        int lowest = sorted[0];
        int highest = sorted[sorted.Length - 1];
        double average = prices.Average();

        double median = (sorted[3] + sorted[4]) / 2.0;

        Console.WriteLine("Lowest Price: " + lowest);
        Console.WriteLine("Highest Price: " + highest);
        Console.WriteLine("Average Price: " + average.ToString("0.00"));
        Console.WriteLine("Median Price: " + median.ToString("0.00"));
    }

    static void SearchPrice(int[] arr, int price)
    {
        int left = 0;
        int right = arr.Length - 1;
        int index = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == price)
            {
                index = mid;
                break;
            }
            else if (arr[mid] < price)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (index != -1)
            Console.WriteLine("Price " + price + " found at index " + index);
        else
            Console.WriteLine("Price " + price + " not found");
    }
}