using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace _004_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var destType = typeof(Student);
            Dictionary<string, PropertyInfo> members = destType
                .GetProperties()
                .ToDictionary(p => p.Name, p => p);

            ParameterExpression par = Expression.Parameter(destType, "p");

            MemberExpression meName = Expression.Property(par, nameof(Student.Name));
            MemberExpression meSurname = Expression.Property(par, nameof(Student.Surname));
            MemberExpression meAge = Expression.Property(par, nameof(Student.Age));

            NewExpression model = Expression.New(destType);
            MemberAssignment miName = Expression.Bind(members[nameof(Student.Name)], meName);
            MemberAssignment miSurName = Expression.Bind(members[nameof(Student.Surname)], meSurname);
            MemberAssignment miAge = Expression.Bind(members[nameof(Student.Age)], meAge);

            MemberInitExpression body = Expression.MemberInit(model, miName, miSurName, miAge);

            //Expression<Func<Student, Student>>
            var copyExp = Expression.Lambda<Func<Student, Student>>(body, new[] { par });
            Func<Student, Student> copy = copyExp.Compile();

            var st = new Student { Name = "A1", Surname = "A1yan", Age = 18 };
            Student st1 = copy(st);
        }
    }
}
