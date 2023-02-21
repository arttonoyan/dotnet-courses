using System;
using System.Linq.Expressions;

namespace _002_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
            //var exc = ((isTeenAgerExpr as LambdaExpression).Body as BinaryExpression);

            Func<Student, bool> isTeenAger = isTeenAgerExpr.Compile();
            var st = new Student { Name = "A1", Surname = "A1yan", Age = 18 };
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
