using System;

namespace _008_Delegates_Func
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> plus = (a1, a2) => a1 + a2;

            Console.WriteLine("10 + 5 = " + plus(10, 5));
            Console.ReadLine();
        }
    }
}
