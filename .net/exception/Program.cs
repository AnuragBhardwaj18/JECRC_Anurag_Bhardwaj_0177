

// .......... Exception handling in C# .......... 


// using System;
// class ExcDemo
// {
//     public static void Main()
//     {
//         int[] nums =new int[4];
//         try
//         {
//             Console.WriteLine("Before exception is generated");
//             for (int i = 0; i < 10; i++)
//             {
//                 nums[i]=i;
//                 Console.WriteLine("nums[{0}] : {1}", i, nums[i] );

//             }
//             Console.WriteLine("This won't be displayed");
//         }
//         catch (IndexOutOfRangeException)
//         {
//             Console.WriteLine("Index out of bound");
//         }
//         Console.WriteLine("After catch statement");
//     }
// }




// .......... Multiple catch blocks in C# ..........



// using System;
// class ExcDemo2{
//     public static void Main(){
//         int[] numer = {4, 8, 16, 32, 64, 128, 256, 512};
//         int[] denom = {2, 0, 4, 4, 0, 8};
//         for(int i=0;i<numer.Length;i++){
//             try{
//                 Console.WriteLine(numer[i] + " / " + denom[i] + " is " + numer[i]/denom[i]);
//             }
//             catch(DivideByZeroException){
//                 Console.WriteLine("Can't divide by zero");
//             }
//             catch(IndexOutOfRangeException){
//                 Console.WriteLine("No matching expression found");
//             }
//         }
//     }
// }



// ......... Custom exception in C# ..........



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CustomExceptionExampleCode;

namespace CustomExceptionExampleCode
{
    class MyException : Exception
    {
        public MyException(string message) : base(message){}
        public MyException(){}
        public MyException(string message, Exception inner) : base(message, inner){}        
    }


}

class Program
{
    static void Main(string[] args)
    {
        int a=50;
        int b=10;
        int k=a/b;
        try
        {
            if (k < 10)
            {
                throw new MyException("value of k is less than 10");
            }
        }
        catch (MyException e)
        {
            Console.WriteLine("Caught MyException");
            Console.WriteLine(e.Message);
        }
        Console.Read();
    }
}    