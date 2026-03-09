using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}

public class AnalyticsEngine
{
    public void AnalyzeEmployees(List<Employee> employees)
    {
        // High Salary Employees (Salary >= 50000)
        var highSalaryEmployees = employees
                                  .Where(e => e.Salary >= 50000)
                                  .Select(e => e.Name);

        Console.WriteLine("High Salary Employees:");
        foreach (var name in highSalaryEmployees)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();

        // Employees sorted by salary (Descending)
        var sortedEmployees = employees
                              .OrderByDescending(e => e.Salary);

        Console.WriteLine("Employees Sorted by Salary:");
        foreach (var e in sortedEmployees)
        {
            Console.WriteLine(e.Name + " - " + e.Salary);
        }

        Console.WriteLine();

        // Average Salary
        double avgSalary = employees
                           .Average(e => e.Salary);

        Console.WriteLine("Average Salary:");
        Console.WriteLine("Rs " + avgSalary);
    }
}

public class Solution
{
    public static void Main()
    {
        // Create employee list with hardcoded data
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 301, Name = "Ramesh", Salary = 45000 },
            new Employee { EmployeeId = 302, Name = "Suresh", Salary = 52000 },
            new Employee { EmployeeId = 303, Name = "Kavya", Salary = 68000 },
            new Employee { EmployeeId = 304, Name = "Anita", Salary = 39000 }
        };

        // Create analytics engine
        AnalyticsEngine engine = new AnalyticsEngine();

        // Run analysis
        engine.AnalyzeEmployees(employees);
        Console.WriteLine();
    }
}