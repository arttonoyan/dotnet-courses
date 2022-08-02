using System;
using System.Collections.Generic;

namespace _012_struct_StackOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            Rec(3);

            Console.WriteLine();
            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        public static void Rec(int a)
        {
            if (a == 0)
                return;

            Console.WriteLine(a);
            Rec(a--);
        }
    }
}
