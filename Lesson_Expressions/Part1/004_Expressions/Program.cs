using System;
using System.Linq.Expressions;

namespace _004_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression pe = Expression.Parameter(typeof(Student), "s");

            MemberExpression meAge = Expression.Property(pe, "Age");
            ConstantExpression constant18 = Expression.Constant(18, typeof(int));
            BinaryExpression body = Expression.GreaterThanOrEqual(meAge, constant18);

            var isAdultExprTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });

            Console.WriteLine("Expression Tree: {0}", isAdultExprTree);
            Console.WriteLine("Expression Tree Body: {0}", isAdultExprTree.Body);
            Console.WriteLine("Number of Parameters in Expression Tree: {0}", isAdultExprTree.Parameters.Count);
            Console.WriteLine("Parameters in Expression Tree: {0}", isAdultExprTree.Parameters[0]);

            //var st = new Student { Name = "A1", Surname = "A1yan", Age = 32 };
            //Func<Student, bool> isAdult = isAdultExprTree.Compile();
            //if (isAdult(st))
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("No");
            //}

            Console.ReadLine();
        }
    }
}
