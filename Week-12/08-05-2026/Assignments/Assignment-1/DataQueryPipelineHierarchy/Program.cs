using System;
using System.Collections.Generic;
using System.Linq;

class Query
{
    public List<int> dataSource;
    public bool isExecuted;

    public Query(List<int> data)
    {
        dataSource = data;
        isExecuted = false;
    }

    public virtual IEnumerable<int> Apply()
    {
        return dataSource;
    }

    public virtual List<int> Execute()
    {
        isExecuted = true;
        return Apply().ToList();
    }

    public virtual string GetQueryType()
    {
        return "Query";
    }
}

class FilterQuery : Query
{
    public string predicate;
    public int filteredCount;

    public FilterQuery(List<int> data, string pred) : base(data)
    {
        predicate = pred;
    }

    public override IEnumerable<int> Apply()
    {
        if (predicate == "even")
            return dataSource.Where(x => x % 2 == 0);

        if (predicate.StartsWith(">"))
        {
            int value = int.Parse(predicate.Substring(1));
            return dataSource.Where(x => x > value);
        }

        if (predicate.StartsWith("<"))
        {
            int value = int.Parse(predicate.Substring(1));
            return dataSource.Where(x => x < value);
        }

        return dataSource;
    }

    public override List<int> Execute()
    {
        List<int> result = Apply().ToList();
        filteredCount = result.Count;
        isExecuted = true;

        Console.WriteLine($"Filter Executed,Predicate:{predicate},Result Count:{filteredCount}");
        return result;
    }

    public override string GetQueryType()
    {
        return "FilterQuery";
    }
}

class AggregateQuery : Query
{
    public string operation;
    public double result;

    public AggregateQuery(List<int> data, string op) : base(data)
    {
        operation = op;
    }

    public override IEnumerable<int> Apply()
    {
        return dataSource;
    }

    public override List<int> Execute()
    {
        List<int> list = Apply().ToList();

        if (operation == "Sum")
            result = list.Sum();
        else if (operation == "Average")
            result = list.Average();
        else if (operation == "Max")
            result = list.Max();
        else if (operation == "Min")
            result = list.Min();

        isExecuted = true;

        Console.WriteLine($"Aggregation Executed,Operation:{operation},Result:{result}");
        return list;
    }

    public override string GetQueryType()
    {
        return "AggregateQuery";
    }
}

class Program
{
    static void Main()
    {
        string queryType = Console.ReadLine();

        List<int> data = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        string condition = Console.ReadLine();

        Query query;

        if (queryType == "Filter")
            query = new FilterQuery(data, condition);
        else
            query = new AggregateQuery(data, condition);

        query.Execute();
    }
}