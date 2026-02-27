

// ......... ArrayList and String Manipulation in C# ..........


// using System.Collections;
// namespace ArrayListDemo
// {
//     class UsingArrayList
//     {
//         static void Main(string[] args)
//         {
//             ArrayList listData = new ArrayList();
//             listData.Add(100);
//             listData.Add(200);
//             listData.Add(300);
//             listData.Add(400);
//             listData.Add("Dotnet");
//             foreach(object i in listData){
//                 Console.WriteLine(i);
//             }
//             ArrayList listData2 = new ArrayList();
//             listData2.Add(500);
//             listData2.Add(600);
//             listData2.Add(700); 
//             listData2.Add(800);
//             listData2.Add("Java");
//             foreach(object i in listData2){
//                 Console.WriteLine(i);
//             }
//             listData.AddRange(listData2);
//             Console.WriteLine("After adding listData2 to listData");
//             foreach(object i in listData){
//                 Console.WriteLine(i);
//             }
//             string order="       order#1001 | Laptop | Dell | 75000         ";
//             Console.WriteLine(order);
//             string trimOrder=order.Trim();
//             Console.WriteLine(trimOrder);
//             Console.WriteLine(order.Length);
//             Console.WriteLine(trimOrder.Length);

//             string[] parts=trimOrder.Split('|');
//             Console.WriteLine("After Split");
//             foreach(var item in parts){
//                 Console.WriteLine(item.Trim());
//             }
//         }


//     }
// }




// .......... Exception handling in C# ..........


using System;


abstract class OrderProcessor
{
    
    public int OrderId { get; set; }
    public double Amount { get; set; }

    
    public abstract void ProcessPayment();
    public abstract void GenerateInvoice();
    public abstract void SendNotification();

    
    public void DisplayOrderDetails()
    {
        Console.WriteLine("Order ID : " + OrderId);
        Console.WriteLine("Amount   : ₹" + Amount);
    }
}


class OnlineOrder : OrderProcessor
{
    public override void ProcessPayment()
    {
        Console.WriteLine("Online payment processed successfully.");
    }

    public override void GenerateInvoice()
    {
        Console.WriteLine("Digital invoice generated.");
    }

    public override void SendNotification()
    {
        Console.WriteLine("Email notification sent to customer.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        OrderProcessor order = new OnlineOrder();

        
        order.OrderId = 1001;
        order.Amount = 3499.75;

        
        order.DisplayOrderDetails();
        order.ProcessPayment();
        order.GenerateInvoice();
        order.SendNotification();

        Console.ReadLine();
    }
}
