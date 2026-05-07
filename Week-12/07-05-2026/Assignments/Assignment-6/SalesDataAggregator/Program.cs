using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] product = { "P001", "P001", "P002", "P001", "P002", "P003", "P001", "P002", "P003", "P002" };
        string[] region = { "North", "South", "North", "East", "South", "North", "West", "West", "South", "East" };
        int[] sales = { 1500, 2000, 3000, 2500, 1800, 1200, 2200, 2800, 900, 3200 };

        int threshold = 2000;

        Console.WriteLine("--- Sales Report by Product and Region ---\n");

        var products = product.Distinct();

        foreach (string p in products)
        {
            Console.WriteLine("Product " + p + ":");

            int total = 0;
            int count = 0;

            for (int i = 0; i < product.Length; i++)
            {
                if (product[i] == p)
                {
                    Console.WriteLine("  " + region[i] + ": $" + sales[i]);
                    total += sales[i];
                    count++;
                }
            }

            double average = total / (double)count;

            Console.WriteLine("  Total: $" + total + ", Average: $" + average.ToString("0.00"));
            Console.WriteLine();
        }

        Console.WriteLine("Best Selling Product by Region:");

        var regions = region.Distinct();

        foreach (string r in regions)
        {
            int maxSale = 0;
            string bestProduct = "";

            for (int i = 0; i < region.Length; i++)
            {
                if (region[i] == r && sales[i] > maxSale)
                {
                    maxSale = sales[i];
                    bestProduct = product[i];
                }
            }

            Console.WriteLine(r + ": " + bestProduct + " ($" + maxSale + ")");
        }

        Console.WriteLine("\nUnderperforming Products (< $" + threshold + " average):");

        foreach (string p in products)
        {
            int total = 0;
            int count = 0;

            for (int i = 0; i < product.Length; i++)
            {
                if (product[i] == p)
                {
                    total += sales[i];
                    count++;
                }
            }

            double average = total / (double)count;

            if (average < threshold)
            {
                Console.WriteLine(p + " ($" + average.ToString("0.00") + ")");
            }
        }
    }
}