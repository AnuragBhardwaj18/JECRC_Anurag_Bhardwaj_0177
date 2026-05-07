using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] names = { "John", "Sarah", "Mike", "Emma" };

        int[][] grades =
        {
            new int[] { 85, 90, 78, 92 },
            new int[] { 95, 88, 91, 89 },
            new int[] { 70, 65, 80, 75 },
            new int[] { 88, 92, 94, 96 }
        };

        Console.WriteLine("--- Student Grade Report ---\n");

        double highestAverage = 0;
        string topStudent = "";

        HashSet<int> uniqueGrades = new HashSet<int>();

        for (int i = 0; i < names.Length; i++)
        {
            int sum = grades[i].Sum();
            double average = sum / 4.0;
            int highest = grades[i].Max();
            int lowest = grades[i].Min();

            Console.WriteLine(names[i] + ": Average = " + average.ToString("0.00") +
                              ", Highest = " + highest +
                              ", Lowest = " + lowest);

            if (average > highestAverage)
            {
                highestAverage = average;
                topStudent = names[i];
            }

            foreach (int grade in grades[i])
            {
                uniqueGrades.Add(grade);
            }
        }

        Console.WriteLine("\nTop Performer: " + topStudent +
                          " (Average: " + highestAverage.ToString("0.00") + ")\n");

        Console.WriteLine("Students with all grades >= 80:");

        for (int i = 0; i < names.Length; i++)
        {
            bool allAbove80 = true;

            foreach (int grade in grades[i])
            {
                if (grade < 80)
                {
                    allAbove80 = false;
                }
            }

            if (allAbove80)
            {
                Console.WriteLine(names[i] + " (" + string.Join(",", grades[i]) + ")");
            }
        }

        Console.WriteLine("\nUnique Grade Values Across All Students:");

        var sortedGrades = uniqueGrades.OrderBy(x => x);

        Console.WriteLine(string.Join(",", sortedGrades));
        Console.WriteLine("Total unique grades: " + uniqueGrades.Count);
    }
}