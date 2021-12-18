using System;
using System.Collections.Generic;

namespace _011_yield
{
    class Program
    {
        static void Main(string[] args)
        {
            //var enumerable = CreateRandomNumbers(20);
            var enumerable = new int[] { 10, 1250, 21 };

            var evenEnumerable = GetEventNumbers(enumerable);

            var greaterThanEnumerable = GreaterThan(evenEnumerable, 1000);

            var list = ToMyList(greaterThanEnumerable);

            //var list = enumerable.ToList();
            //var arr = enumerable.ToArray();


            //IEnumerable<int> en1 = CreateRandomNumbers(100);

            //List<int> list = en2.ToList();
        }

        public static List<int> ToMyList(IEnumerable<int> source)
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                list.Add(item);
            }
            return list;
        }

        public static IEnumerable<int> GetEventNumbers(IEnumerable<int> source)
        {
            foreach (var item in source)
                if (item % 2 == 0)
                    yield return item;
        }

        static IEnumerable<int> CreateRandomNumbers(int count)
        {
            var rnd = new Random();
            for (int i = 0; i < count; i++)
                yield return rnd.Next(0, 5000);
        }

        public static IEnumerable<int> GreaterThan(IEnumerable<int> source, int number)
        {
            foreach (var item in source)
                if (item > number)
                    yield return item;
        }
    }
}
