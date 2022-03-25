using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _010_Expressions
{
    class Program
    {
        //https://github.com/agileobjects/ReadableExpressions
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/debugging-expression-trees-in-visual-studio
        static void Main(string[] args)
        {
            var st = new Student { Name = "A1", Surname = "A1yan", Age = 15 };

            Expression<Func<Student, bool>> q1 = s => s.Age > 12;
            Expression<Func<Student, bool>> q2 = s => s.Age < 20;

            Expression<Func<Student, bool>> isTeenAgerExpr = q1.And(q2);

            Func<Student, bool> isTeenAger = isTeenAgerExpr.Compile();
            if (isTeenAger(st))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            Console.ReadLine();
        }
    }
}
