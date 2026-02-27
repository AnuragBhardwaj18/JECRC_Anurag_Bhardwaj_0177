// ............ Static Constructor in C# ...........

// using System;
// class ODLExercise
// {
//     private static int number;
//     public static int Number { get { return number; } }
//     static ODLExercise()
//     {
//         Random r=new Random();
//         number=r.Next();

//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Static Number =" + ODLExercise.Number);

//     }
// }



// .......... Default Constructer ..........




// using System;
// class ODLExercise
// {
//     private int number;
//     public int Number { get { return number; } }
//     public ODLExercise()
//     {
//         Random r=new Random();
//         number=r.Next();

//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         ODLExercise num=new ODLExercise();

//         Console.WriteLine("Static Number=" + num.Number);


//     }
// }




// .......... overloaded constructor ..........



// using System;
// class ODLExercise
// {
//     private int number;
//     public int Number { get { return number; } }
//     public ODLExercise()
//     {
//         Random r=new Random();
//         number=r.Next();

//     }
//     public ODLExercise(int num)
//     {
//         Random r=new Random(num);
//         number=r.Next();

//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         ODLExercise num=new ODLExercise();
//         Console.WriteLine("Static Number=" + num.Number);

//         ODLExercise num1=new ODLExercise(10);
//         Console.WriteLine("Static Number=" + num1.Number);


//     }
// }



// ........... Inheritance in C# ...........


// using System;

// namespace ConsoleApp
// {
//     class Product
//     {
//         public string Name { get; set; }
//         public int Id { get; set; }
//         public DateTime ExpiryDate { get; set; }
//         public bool ISOStandard { get; set; }
//         public decimal Price { get; set; }
//         public int StockQuantity { get; set; }

         
//         public Product()
//         {
//             Console.Write("Enter Product Name: ");
//             Name = Console.ReadLine();

//             Console.Write("Enter Product Id: ");
//             Id = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Expiry Date (dd-MM-yyyy): ");
//             ExpiryDate = DateTime.Parse(Console.ReadLine());

//             Console.Write("Is ISO Standard Certified? (true/false): ");
//             ISOStandard = Convert.ToBoolean(Console.ReadLine());

//             Console.Write("Enter Product Price: ");
//             Price = Convert.ToDecimal(Console.ReadLine());

//             Console.Write("Enter Stock Quantity: ");
//             StockQuantity = Convert.ToInt32(Console.ReadLine());
//         }

        
//         public void DisplayProductData()
//         {
//             Console.WriteLine("\n----- Product Details -----");
//             Console.WriteLine($"Name           : {Name}");
//             Console.WriteLine($"Id             : {Id}");
//             Console.WriteLine($"Expiry Date    : {ExpiryDate.ToShortDateString()}");
//             Console.WriteLine($"ISO Standard   : {ISOStandard}");
//             Console.WriteLine($"Price          : ₹{Price}");
//             Console.WriteLine($"Stock Quantity : {StockQuantity}");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {

//             Product product = new Product();


//             product.DisplayProductData();

//             Console.ReadLine(); // keeps console open
//         }
//     }
// }



// .......... Method Overloading in C# ..........


// namespace InterfaceDemo
// {
//     interface IArea
//     {
//         void CalcArea(double radius);
//     }
//     interface IVolume
//     {
//         void CalcVolume(int radius);
//     }
//     public class CircleCube : IArea,IVolume
//     {
//         public void CalcArea(double radius)
//         {
//             double pie = 3.14;
//             double result = pie*radius*radius;
//             Console.WriteLine("Area of Circle is " + result);
//         }

//         public void CalcVolume(int side)
//         {
            
//             double result = side*side*side;
//             Console.WriteLine("Volume of Cube is " + result);
//         }
//         class TestApp
//         {
//             public static void Main(string[] args)
//             {
//                 CircleCube obj=new CircleCube();
//                 double radius;
//                 int side;
//                 Console.WriteLine("Enter the radius of circle");
//                 radius=Convert.ToDouble(Console.ReadLine());
//                 obj.CalcArea(radius);
//                 Console.WriteLine("Enter the side of cube");
//                 side=Convert.ToInt32(Console.ReadLine());
//                 obj.CalcVolume(side);
//             } 
//         }
//     }
// }




// .......... Method Overriding in C# ..........



// namespace AbstractDemo
// {
//     public abstract class CalcArea
//     {
//         public abstract void Area(double radius);
//         public void bfunction()
//         {
//             Console.WriteLine("I am non abstract method");
//         }
//     }
//     interface IVolume
//     {
//         void CalcVolume(int radius);
//     }
//     public class CircleCube : CalcArea,IVolume
//     {
//         public override void Area(double radius)
//         {
//             double pie = 3.14;
//             double result = pie*radius*radius;
//             Console.WriteLine("Area of Circle is " + result);
//         }

//         public void CalcVolume(int side)
//         {
            
//             double result = side*side*side;
//             Console.WriteLine("Volume of Cube is " + result);
//         }
//         class TestApp
//         {
//             public static void Main(string[] args)
//             {
//                 CircleCube obj=new CircleCube();
//                 double radius;
//                 int side;
//                 Console.WriteLine("Enter the radius of circle");
//                 radius=Convert.ToDouble(Console.ReadLine());
//                 obj.Area(radius);
//                 obj.bfunction();
//                 Console.WriteLine("Enter the side of cube");
//                 side=Convert.ToInt32(Console.ReadLine());
//                 obj.CalcVolume(side);
//             } 
//         }
//     }
// }



// .......... Runtime Polymorphism in C# ..........



// using System;

// // Abstract base class
// abstract class DrawingObject
// {
//     public abstract void Draw();
// }

// // Derived class Line
// class Line : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Line.");
//     }
// }

// // Derived class Circle
// class Circle : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Circle.");
//     }
// }

// // Derived class Square
// class Square : DrawingObject
// {
//     public override void Draw()
//     {
//         Console.WriteLine("I'm a Square.");
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Array of abstract class type
//         DrawingObject[] objects = new DrawingObject[3];

//         objects[0] = new Line();
//         objects[1] = new Circle();
//         objects[2] = new Square();

//         // Calling Draw() using loop
//         foreach (DrawingObject obj in objects)
//         {
//             obj.Draw();
//         }

//         Console.ReadLine();
//     }
// }



// .......... Method Overhiding in C# ..........



using System;


class DrawingObject
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing an object");
    }
}


class Line : DrawingObject
{
    public override void Draw()
    {
        Console.WriteLine("I'm a Line.");
    }
}


class Circle : DrawingObject
{
    public override void Draw()
    {
        Console.WriteLine("I'm a Circle.");
    }
}


class Square : DrawingObject
{
    public override void Draw()
    {
        Console.WriteLine("I'm a Square.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        DrawingObject[] objects = new DrawingObject[3];

        objects[0] = new Line();
        objects[1] = new Circle();
        objects[2] = new Square();

        
        foreach (DrawingObject obj in objects)
        {
            obj.Draw();
        }

        Console.ReadLine();
    }
}

