

// ............ Employee Data Collection and Display ...........


// using System;

// namespace ConsoleApp
// {
//     class Employee
//     {
//         public string Name { get; set; }
//         public int Id { get; set; }
//         public string Department { get; set; }
//         public int Salary { get; set; }
//         public string Position { get; set; }
//         public DateTime DateOfJoining { get; set; }

//         public void GetEmployeeData()
//         {
//             Console.Write("Enter Employee Name: ");
//             Name = Console.ReadLine();

//             Console.Write("Enter Employee Id: ");
//             Id = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Employee Department: ");
//             Department = Console.ReadLine();

//             Console.Write("Enter Employee Salary: ");
//             Salary = Convert.ToInt32(Console.ReadLine());

//             Console.Write("Enter Employee Position: ");
//             Position = Console.ReadLine();

//             Console.Write("Enter Employee Date Of Joining (dd-MM-yyyy): ");
//             DateOfJoining = DateTime.Parse(Console.ReadLine());
//         }

//         public void DisplayEmployeeData()
//         {
//             Console.WriteLine("\n--- Employee Details ---");
//             Console.WriteLine($"Name: {Name}");
//             Console.WriteLine($"Id: {Id}");
//             Console.WriteLine($"Department: {Department}");
//             Console.WriteLine($"Salary: {Salary}");
//             Console.WriteLine($"Position: {Position}");
//             Console.WriteLine($"Date Of Joining: {DateOfJoining.ToShortDateString()}");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Employee emp = new Employee();
//             emp.GetEmployeeData();
//             emp.DisplayEmployeeData();
//         }
//     }
// }




// .......... Method Overloading in C# ..........



// using System;

// class ODLExamplel
// {
//     public static void Main(){
//       string[] stringArray= new string[5] { "Csharp", "ASP.net", "EntityFramework", "ADO.net", "WCF" };  
//       Array.Sort(stringArray);
//       foreach (string str in stringArray)
//         {
//             Console.Write(str + " ");
//          }
//     }
     

// }


 

// ............ Delegates in C# ............


// using System;

// class SwitchSelect
// {
//     public static void Main()
//     {
//         string myInput;

// int myInt;

// begin:

// Console.Write("Please enter a number between 1 and 3: "); 
// myInput= Console.ReadLine();

// myInt= Int32.Parse(myInput);

//         //switch with integer type Switch (myInt)
//         switch (myInt)
//         {
//             case 1:

// Console.WriteLine("Your number is {0}", myInt); break;

// case 2:

// Console.WriteLine("Your number is {0}", myInt);

// break;

// case 3:

// Console.WriteLine("Your number is {0}:", myInt);

// break;
// default:

// Console.WriteLine("Your number {0} is not between 1 and 3:", myInt);
//     break;
//         }

//     }
// }

    

// .......... Exception handling in C# ..........


// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter first letter: ");
//         char letter1 = Convert.ToChar(Console.ReadLine());

//         Console.Write("Enter second letter: ");
//         char letter2 = Convert.ToChar(Console.ReadLine());

//         Console.Write("Enter third letter: ");
//         char letter3 = Convert.ToChar(Console.ReadLine());

//         Console.WriteLine("Reversed Order: {0} {1} {2}", letter3, letter2, letter1);
//     }
// }



// .......... Exception handling in C# ..........


// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter a number: ");
//         int number = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter the desired width: ");
//         int width = Convert.ToInt32(Console.ReadLine());

//         for (int i = 1; i <= width; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(number);
//             }
//             Console.WriteLine();
//         }
//     }
// }



// ......... Exception handling in C# ..........


// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Input First number: ");
//         int num1 = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Input Second number: ");
//         int num2 = Convert.ToInt32(Console.ReadLine());

//         bool result = (num1 % 2 == 0 && num2 % 2 == 0) || 
//                       (num1 % 2 != 0 && num2 % 2 != 0);

//         Console.WriteLine("Result: " + result);
//     }
// }



// .......... Exception handling in C# ..........


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

//         public void GetProductData()
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
//             product.GetProductData();
//             product.DisplayProductData();

//             Console.ReadLine(); // Keeps console open
//         }
//     }
// }



// ......... Method Overloading in C# ..........



using System;

class ODLExercise
{
    int num1;
    int num2;

    
    public ODLExercise()
    {
        Console.Write("Enter first number: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        num2 = Convert.ToInt32(Console.ReadLine());
    }

    public void Addition()
    {
        int sum = num1 + num2;
        Console.WriteLine("The sum of {0} and {1} is: {2}", num1, num2, sum);
    }

    public void Subtraction()
    {
        int difference = num1 - num2;
        Console.WriteLine("The difference between {0} and {1} is: {2}", num1, num2, difference);
    }

    public void Multiplication()
    {
        int product = num1 * num2;
        Console.WriteLine("The product of {0} and {1} is: {2}", num1, num2, product);
    }

    public void Division()
    {
        if (num2 != 0)
        {
            double quotient = (double)num1 / num2;
            Console.WriteLine("The quotient of {0} divided by {1} is: {2}", num1, num2, quotient);
        }
        else
        {
            Console.WriteLine("Division by zero is not allowed.");
        }
    }
}

class Demo
{
    public static void Main()
    {
        ODLExercise exercise = new ODLExercise();

        exercise.Addition();
        exercise.Subtraction();
        exercise.Multiplication();
        exercise.Division();

        Console.ReadLine(); 
    }
}

        