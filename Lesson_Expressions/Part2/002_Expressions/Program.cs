using System;
using System.Linq.Expressions;
using System.Reflection;

namespace _002_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expression<Func<string, string>> testExp = p => (string)SomeClass.TestMethod("test");

            var par = Expression.Parameter(typeof(string), "p");
            MethodInfo mi = typeof(SomeClass).GetMethod("TestMethod");
            MethodCallExpression callExp = Expression.Call(mi, par);

            //cast
            var body = Expression.Convert(callExp, typeof(string));

            Expression<Func<string, string>> testMethodExp = 
                Expression.Lambda<Func<string, string>>(body, par);

            Func<string, string> testMethod = testMethodExp.Compile();
            string value = testMethod("test");

            Console.ReadLine();
        }
    }

    static class SomeClass
    {
        public static object TestMethod(string value)
        {
            return "Hello, World! " + value;
        }
    }
}
