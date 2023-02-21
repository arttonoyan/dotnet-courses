using System;
using System.Linq.Expressions;

namespace _003_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Action<Student>> printStudentNameExp = s => Console.WriteLine(s.Name);

            var st = new Student { Name = "A1", Surname = "A1yan", Age = 18 };
            Action<Student> printStudentName = printStudentNameExp.Compile();
            printStudentName.Invoke(st);

            Console.ReadLine();
        }
    }
}
