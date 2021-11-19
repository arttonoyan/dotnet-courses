using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _014_object_HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student { name = "A1", email = "a1@gmail.com" };
            var st2 = new Student { name = "A1", email = "a1@gmail.com" };

            if (st1.Equals(st2))
            {

            }

            var set = new HashSet<Student>(new StudentEqualityComparer());
            set.Add(st1);
            set.Add(st2);
        }
    }

    class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x == null && y == null)
                return false;

            if (x == null || y == null)
                return false;

            return x.email == y.email;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.email.GetHashCode();
        }
    }

    class Student
    {
        public string name;
        public string email;
    }
}
