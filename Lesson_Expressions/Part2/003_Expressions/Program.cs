using System;
using System.Linq.Expressions;

namespace _003_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student { Name = "A1", Surname = "A1yan", Age = 18 };
            Expression<Func<Student, Student>> copyExp = p => new Student
            {
                Name = p.Name,
                Surname = p.Surname,
                Age = p.Age
            };

            Func<Student, Student> copy = copyExp.Compile();

            Student st1 = copy(st);
            Console.ReadLine();
        }
    }
}
