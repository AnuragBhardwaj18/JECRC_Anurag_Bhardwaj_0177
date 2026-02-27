

// ............. Nullables in C# ............


// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         DateTime? dt = null;
//         dt=DateTime.Now;
//         object o=dt;
//         DateTime? dt2 = o as DateTime?;
//         if (dt2 != null)
//         {
//             Console.WriteLine(dt2.Value.ToString());}
//             Console.ReadLine();

        
//     }
// }



// ............. Nullables in C# ............



using System;
class Program
{
    static void Main(string[] args)
    {
        int? j=null;
        int? k=54;
        int resultt1=j ?? 0;
        int resultt2= k ?? 0;
        Console.WriteLine("resultt1={0},resultt2={1}", resultt1, resultt2 );
        Console.ReadLine();
    }
}


