using System;

namespace _001_NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            int? b = a + 10; // b = null
            int? c = a * 10; // c = null

            Console.WriteLine(">{0}<", a);

            Console.ReadLine();
        }
    }
}
