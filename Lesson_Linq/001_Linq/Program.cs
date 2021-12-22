using System;
using System.Collections.Generic;
using System.Linq;

namespace _001_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studens = GenerateStudentsData(10).ToList();
            var res1 = studens.MyFind(p => p.age > 20);
            var res2 = studens.MyTake(20).ToList();
        }

        static IEnumerable<Student> GenerateStudentsData(int count)
        {
            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                yield return new Student
                {
                    name = $"A{i + 1}",
                    surname = $"A{i + 1}yan",
                    mark = (byte)rnd.Next(1, 21),
                    age = (byte)rnd.Next(15, 35),
                    university = (University)rnd.Next(1, 4)
                };
            }
        }
    }

    internal static class Ex
    {
        public static IEnumerable<T> MyFind<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
        {
            if (count > 0)
            {
                foreach (var item in source)
                {
                    yield return item;
                    if (--count == 0)
                        break;
                }
            }
        }

        public static IEnumerable<IGrouping<TKey, TValue>> MyGroupBy<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
        {
            var dic = new Dictionary<TKey, Grouping<TKey, TValue>>();
            foreach (var item in source)
            {
                var key = keySelector.Invoke(item);
                if (!dic.TryGetValue(key, out var group))
                {
                    group = new Grouping<TKey, TValue> { Key = key };
                    dic.Add(key, group);
                }

                group.Add(item);
            }

            return dic.Select(p => p.Value);
        }

        private class Grouping<TKey, TValue> : List<TValue>, IGrouping<TKey, TValue>
        {
            public TKey Key { get; set; }
        }
    }
}
