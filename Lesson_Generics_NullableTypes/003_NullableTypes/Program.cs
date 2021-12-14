using System;

namespace _003_NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            int? b;

            b = a ?? 10; // b = 10

            // b = (a != null) ? a : 10;

            //if (a == null)
            //    b = 10;
            //else
            //    b = a;

            Console.WriteLine(b);

            a = 5;
            b = a ?? 10; // b = 5

            Console.ReadLine();
        }
    }
}
