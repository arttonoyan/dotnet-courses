using System;
using System.Linq.Expressions;
using System.Reflection;

namespace _001_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var par = Expression.Parameter(typeof(string), "p");

            MethodInfo mi = typeof(SomeClass).GetMethod(nameof(SomeClass.TestMethod));
            MethodCallExpression body = Expression.Call(mi, par);
            Expression<Func<string, object>> testMethodExp = 
                Expression.Lambda<Func<string, object>>(body, par);

            Func<string, object> testMethod = testMethodExp.Compile();
            object value = testMethod("test");

            Console.ReadLine();
        }

        static class SomeClass
        {
            public static object TestMethod(string value)
            {
                return "Hello, World! " + value;
            }
        }
    }
}
