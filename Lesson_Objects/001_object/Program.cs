using System;

namespace _001_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new();

            string text = st1.ToString();
            int[] arr = new int[10];

            Console.WriteLine(arr);
            Console.WriteLine(st1);
            Console.ReadLine();
        }
    }

    class Student { }
}
