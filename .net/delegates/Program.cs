

// ......... Delegates in C# ..........


// namespace DelegateDemo
// {
//     class UsingDelegate
//     {
//         public delegate void ArithmaticOperation(int x,int y);
//         static void Add(int x,int y)
//         {
//             Console.WriteLine(x+y);
//         }
//         static void Subtract(int x,int y)
//         {
//             Console.WriteLine(x-y);
//         }

//         static void Multiply(int x,int y)
//         {
//             Console.WriteLine(x*y);
//         }

//         static void Divide(int x,int y)
//         {
//             Console.WriteLine(x/y);
//         }
        
//         static void Main(string[] args)
//         {
//             ArithmaticOperation operation;
//             operation = Add;
//             operation(10, 5);
//             operation = Subtract;
//             operation(10, 5);
//             operation = Multiply;
//             operation(10, 5);
//             operation = Divide;
//             operation(10, 5);
//         }
//     }
    
// }




// ......... Exception handling in C# ..........


using System;


delegate void NotificationSender(string message);


class Notifiers
{
    public static void SendEmail(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }

    public static void SendSMS(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }

    public static void SendPushNotification(string message)
    {
        Console.WriteLine("Push Notification sent: " + message);
    }
}


class NotificationManager
{
    public void NotifyUser(string message, NotificationSender sender)
    {
        sender(message); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        NotificationManager manager = new NotificationManager();

        manager.NotifyUser("Welcome User", Notifiers.SendEmail);
        manager.NotifyUser("Your OTP is 1234", Notifiers.SendSMS);
        manager.NotifyUser("New Offer Available", Notifiers.SendPushNotification);

        Console.ReadLine();
    }
}
