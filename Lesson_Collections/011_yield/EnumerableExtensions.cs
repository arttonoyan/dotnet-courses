using System.Collections.Generic;

namespace _011_yield
{
    static class EnumerableExtensions
    {
        public static IEnumerable<int> EvenNumbers(this IEnumerable<int> source)
        {
            foreach (int item in source)
                if (item % 2 == 0)
                    yield return item;
        }

        public static IEnumerable<int> GreaterThen(this IEnumerable<int> source, int number)
        {
            foreach (int item in source)
                if (item > number)
                    yield return item;
        }

        //public static List<int> EvenNumbers(this List<int> source)
        //{
        //    List<int> items = new List<int>();
        //    foreach (int item in source)
        //    {
        //        if (item % 2 == 0)
        //            items.Add(item);
        //    }
        //    return items;
        //}

        //public static List<int> GreaterThen(this List<int> source, int number)
        //{
        //    List<int> items = new List<int>();
        //    foreach (int item in source)
        //    {
        //        if (item > number)
        //            items.Add(item);
        //    }
        //    return items;
        //}
    }
}
