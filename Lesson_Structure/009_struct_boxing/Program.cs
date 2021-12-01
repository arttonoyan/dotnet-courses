using System;
using System.Collections.Generic;

namespace _009_struct_boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000;

            DateTime dt_al = DateTime.Now;

            var arr = new List<object>();
            for (int i = 0; i < n; i++)
            {
                arr.Add(i);
            }

            for (int i = 0; i < n; i++)
            {
                int ai = (int)arr[i];
                //Console.WriteLine(ai);
            }

            TimeSpan ts_al = DateTime.Now - dt_al;


            DateTime dt_l = DateTime.Now;

            var list = new List<int>();
            for (int i = 0; i < n; i++)
                list.Add(i);

            for (int i = 0; i < n; i++)
            {
                int ai = list[i];
                //Console.WriteLine(ai);
            }

            TimeSpan ts_l = DateTime.Now - dt_l;


            Console.WriteLine(new string('*', 25));
            Console.WriteLine("ArrayList Time: " + ts_al);
            Console.WriteLine("List<int> Time: " + ts_l);

            Console.ReadLine();
        }
    }
}
