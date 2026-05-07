using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Customer sets
        HashSet<string> electronics = new HashSet<string>
        {
            "C001","C002","C003","C005","C008"
        };

        HashSet<string> clothing = new HashSet<string>
        {
            "C002","C004","C005","C006","C009"
        };

        HashSet<string> books = new HashSet<string>
        {
            "C003","C005","C007","C008","C010"
        };

        Console.WriteLine("--- Customer Preference Analysis ---\n");

        // 1. Union -> Customers who bought from ANY category
        HashSet<string> anyCategory = new HashSet<string>(electronics);
        anyCategory.UnionWith(clothing);
        anyCategory.UnionWith(books);

        Console.WriteLine("1. Customers in ANY category (Union):");
        foreach (string customer in anyCategory)
        {
            Console.Write(customer + " ");
        }

        Console.WriteLine("\nTotal: " + anyCategory.Count + " customers\n");

        // 2. Intersection -> Customers who bought from ALL categories
        HashSet<string> allCategories = new HashSet<string>(electronics);
        allCategories.IntersectWith(clothing);
        allCategories.IntersectWith(books);

        Console.WriteLine("2. Customers in ALL categories (Intersection):");
        foreach (string customer in allCategories)
        {
            Console.Write(customer + " ");
        }

        Console.WriteLine("\nTotal: " + allCategories.Count + " customer\n");

        // 3. Only Electronics
        HashSet<string> onlyElectronics = new HashSet<string>(electronics);
        onlyElectronics.ExceptWith(clothing);
        onlyElectronics.ExceptWith(books);

        Console.WriteLine("3. Customers ONLY in Electronics (Difference):");
        foreach (string customer in onlyElectronics)
        {
            Console.Write(customer + " ");
        }

        Console.WriteLine("\nTotal: " + onlyElectronics.Count + " customers\n");

        // 4. Electronics AND Books but NOT Clothing
        HashSet<string> electronicsAndBooks = new HashSet<string>(electronics);
        electronicsAndBooks.IntersectWith(books);
        electronicsAndBooks.ExceptWith(clothing);

        Console.WriteLine("4. Customers in Electronics AND Books but NOT Clothing:");
        foreach (string customer in electronicsAndBooks)
        {
            Console.Write(customer + " ");
        }

        Console.WriteLine("\nTotal: " + electronicsAndBooks.Count + " customers");
    }
}