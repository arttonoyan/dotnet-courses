using System;
using System.Linq.Expressions;

namespace _005_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            Expression<Func<Student, bool>> isTeenAgerExpr;
            isTeenAgerExpr = Expression.Lambda<Func<Student, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThan(Expression.Property(pe, "Age"), Expression.Constant(12, typeof(int))),
                    Expression.LessThan(Expression.Property(pe, "Age"), Expression.Constant(20, typeof(int)))),
                        new[] { pe });


            var st = new Student { Name = "A1", Surname = "A1yan", Age = 15 };
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
