using System;
using System.Collections.Generic;

namespace _012_yield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enumerable = CreateRandomNumbers(20);

            //var evenEnumerable = enumerable.GetEventNumbers();
            //var greaterThanEnumerable = evenEnumerable.GreaterThan(1000);
            //var list = greaterThanEnumerable.ToMyList();

            var list = enumerable
                .GreaterThan(1000)
                .GetEventNumbers()
                .ToMyList();
        }

        static IEnumerable<int> CreateRandomNumbers(int count)
        {
            var rnd = new Random();
            for (int i = 0; i < count; i++)
                yield return rnd.Next(0, 5000);
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<int> GetEventNumbers(this IEnumerable<int> source)
        {
            foreach (var item in source)
                if (item % 2 == 0)
                    yield return item;
        }

        public static IEnumerable<int> GreaterThan(this IEnumerable<int> source, int number)
        {
            foreach (var item in source)
                if (item > number)
                    yield return item;
        }

        public static List<int> ToMyList(this IEnumerable<int> source)
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
