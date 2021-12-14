using System;

namespace _002_NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            int? b = 10;

            // Expression is always null
            if (a > b)
            {
                Console.WriteLine("a > b");
            }
            else
            {
                Console.WriteLine("a < b");
            }

            // Expression is always null
            if (a == null)
            {
                Console.WriteLine("a == b");
            }
            else
            {
                Console.WriteLine("a != b");
            }

            Console.ReadLine();
        }
    }
}
