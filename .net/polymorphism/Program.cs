

// ......... Method Overloading in C# ..........


// using System;

// class Car
// {
//     public string Name;
//     public int NumberOfDoors;

//     // Default constructor
//     public Car()
//     {
//         Name = "NoName";
//         NumberOfDoors = 3;
//     }

//     // Constructor with name and doors
//     public Car(string name, int numberOfDoors)
//     {
//         Name = name;
//         NumberOfDoors = numberOfDoors;
//     }

//     // Constructor with only name
//     public Car(string name)
//     {
//         Name = name;
//         NumberOfDoors = 0;
//     }

//     // Constructor with only doors
//     public Car(int numberOfDoors)
//     {
//         Name = "Unknown";
//         NumberOfDoors = numberOfDoors;
//     }
// }

// class ODLExce
// {
//     static void Main(string[] args)
//     {
//         Car car1 = new Car();
//         Car car2 = new Car(3);
//         Car car3 = new Car("MyName");
//         Car car4 = new Car("MyName", 4);

//         Console.WriteLine(car1.Name + " " + car1.NumberOfDoors);
//         Console.WriteLine(car2.Name + " " + car2.NumberOfDoors);
//         Console.WriteLine(car3.Name + " " + car3.NumberOfDoors);
//         Console.WriteLine(car4.Name + " " + car4.NumberOfDoors);
//     }
// }





// .......... Method Overriding in C# ..........



//Method Overhiding
// using System;
// using System.Text.RegularExpressions;
// class GroupAgent
// {
//     public void show()
//     {
//     Console.WriteLine("GroupAgent Created !!!");
//     Console.ReadLine();

//     }
// }
// class Agent : GroupAgent
// {
//     public new void show()
//     {
//         Console.WriteLine("Agent Created !!!");
//         Console.ReadLine();
//     }
// }

// class ODLExercise{
//     public static void Main(string[] args)
//     {
//         GroupAgent a1 = new GroupAgent();
//         a1.show();
//         Agent a2 = new Agent();
//         a2.show();
//         GroupAgent a3 = new Agent();
//         a3.show();
//     }
// }




// .......... Runtime Polymorphism in C# ..........


using System;

class GroupAgent
{
    
    public virtual void Show()
    {
        Console.WriteLine("GroupAgent Created !!!");
    }
}

class Agent : GroupAgent
{
    
    public override void Show()
    {
        Console.WriteLine("Agent Created !!!");
    }
}

class ODLExercise
{
    public static void Main(string[] args)
    {
        GroupAgent a1 = new GroupAgent();
        a1.Show();        

        Agent a2 = new Agent();
        a2.Show();        

        GroupAgent a3 = new Agent();
        a3.Show();        
    }
}
