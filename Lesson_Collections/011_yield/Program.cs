using System;
using System.Collections.Generic;
using System.Linq;

namespace _011_yield
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> en1 = CreateRandomNumbers(100);

            IEnumerable<int> en2 = en1
                .EvenNumbers()
                .GreaterThen(100);

            List<int> list = en2.ToList();
        }

        static IEnumerable<int> CreateRandomNumbers(int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
                yield return rnd.Next(0, 150);
        }
    }
}
