using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}

public class AnalysisEngine
{
    public void AnalyzeStudents(List<Student> students)
    {
        
        var passedStudents = students
                             .Where(s => s.Marks >= 50)
                             .Select(s => s.Name);

        Console.WriteLine("Passed Students:");
        foreach (var name in passedStudents)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();

        
        var topper = students
                     .OrderByDescending(s => s.Marks)
                     .First();

        Console.WriteLine("Topper:");
        Console.WriteLine(topper.Name + " - " + topper.Marks);

        Console.WriteLine();

        
        var sortedStudents = students
                             .OrderByDescending(s => s.Marks);

        Console.WriteLine("Students Sorted by Marks:");
        foreach (var s in sortedStudents)
        {
            Console.WriteLine(s.Name + " - " + s.Marks);
        }
    }
}

public class Solution
{
    public static void Main()
    {
        
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 101, Name = "Ananya", Marks = 78 },
            new Student { StudentId = 102, Name = "Ravi", Marks = 45 },
            new Student { StudentId = 103, Name = "Neha", Marks = 88 },
            new Student { StudentId = 104, Name = "Arjun", Marks = 67 }
        };

        
        AnalysisEngine engine = new AnalysisEngine();

        
        engine.AnalyzeStudents(students);
        Console.WriteLine();
    }
}