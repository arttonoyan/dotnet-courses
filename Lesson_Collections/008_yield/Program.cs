using System;

namespace _008_yield
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string item in CollectionHelper.CreateEnumerable())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
