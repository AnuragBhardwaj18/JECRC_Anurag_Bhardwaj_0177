

// ............. Single Dimensional Array in C# ............

using System;
class Program
{
    static void Main(string[] args)
    {
        int[] Sarray = new int[5] {85, 90, 78, 92, 88};
        Array.Sort(Sarray);
        foreach (int value in Sarray)
        {
            Console.WriteLine(value);
        }
    }
}
