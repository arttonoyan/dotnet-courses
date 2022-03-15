using System;
using System.Linq.Expressions;

namespace _006_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var mi = typeof(Convert).GetMethod("ToInt32", new[] { typeof(string) });

            var par = Expression.Parameter(typeof(string), "p");
            var convertEx = Expression.Convert(par, typeof(int), mi);
            Expression<Func<string, int>> toInt32Exp = Expression.Lambda<Func<string, int>>(convertEx, par);

            Func<string, int> toInt32 = toInt32Exp.Compile();
            int a = toInt32("10");
        }
    }
}
