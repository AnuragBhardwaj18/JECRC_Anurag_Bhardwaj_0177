using System;
using System.Threading.Tasks;

class AsyncService
{
    public int requestCount;
    public long lastResponseTime;

    public virtual async Task<string> FetchDataAsync(string endpoint)
    {
        await Task.Delay(2000);
        return "";
    }

    public virtual async Task<string> GetStatusAsync()
    {
        await Task.Delay(0);
        return "";
    }
}

class WeatherService : AsyncService
{
    public string city;
    public int temperature = 22;

    public WeatherService(string city)
    {
        this.city = city;
    }

    public override async Task<string> FetchDataAsync(string endpoint)
    {
        requestCount++;

        Console.WriteLine($"Weather Fetch Started,{city}");

        await Task.Delay(2000);

        Console.WriteLine($"Weather Data Received,{city},{temperature}°C");

        return "";
    }

    public override async Task<string> GetStatusAsync()
    {
        await Task.Delay(0);

        Console.WriteLine($"Weather Service Status,Requests:{requestCount}");

        return "";
    }
}

class StockService : AsyncService
{
    public string symbol;
    public double currentPrice = 150.5;

    public StockService(string symbol)
    {
        this.symbol = symbol;
    }

    public override async Task<string> FetchDataAsync(string endpoint)
    {
        requestCount++;

        Console.WriteLine($"Stock Fetch Started,{symbol}");

        await Task.Delay(2000);

        Console.WriteLine($"Stock Price Update,{symbol},${currentPrice}");

        return "";
    }

    public override async Task<string> GetStatusAsync()
    {
        await Task.Delay(0);

        Console.WriteLine($"Stock Service Status,Requests:{requestCount}");

        return "";
    }
}

class Program
{
    static async Task Main()
    {
        string serviceType = Console.ReadLine();
        string identifier = Console.ReadLine();
        string command = Console.ReadLine();

        AsyncService service;

        if (serviceType == "Weather")
            service = new WeatherService(identifier);
        else
            service = new StockService(identifier);

        if (command == "FetchDataAsync")
            await service.FetchDataAsync(identifier);
        else if (command == "GetStatusAsync")
            await service.GetStatusAsync();
    }
}