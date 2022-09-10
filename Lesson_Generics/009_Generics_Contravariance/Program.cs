using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _009_Generics_Contravariance
{
    public class MySet<T>
    {
        private readonly List<T> list = new List<T> ();
        private readonly IMyEqualityComparer<T> comparer;

        public MySet(IMyEqualityComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public void Add(T value)
        {
            bool contains = false;
            foreach (var item in list)
            {
                if(comparer.Equals(item, value))
                {
                    contains = true;
                    break;
                }
            }

            if (!contains)
                list.Add(value);
        }
    }

    public interface IMyEqualityComparer<in T>
    {
        bool Equals(T? x, T? y);

        int GetHashCode([DisallowNull] T obj);
    }

    public class MyPersonEqualityComparer : IMyEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y) =>
            x.Email == y.Email;

        public int GetHashCode([DisallowNull] Person obj) =>
            obj.Email.GetHashCode();
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var equalityComparer = new PersonEqualityComparer();
            IEnumerable<Person> people = new List<Employee>();

            IMyEqualityComparer<Employee> employeeComparer = new MyPersonEqualityComparer();
            var set = new MySet<Employee>(employeeComparer);
            set.Add(new Employee { Email = "a1@gmail.com" });
            set.Add(new Employee { Email = "a1@gmail.com" });
            set.Add(new Employee { Email = "a1@gmail.com" });
            set.Add(new Employee { Email = "a1@gmail.com" });

            var setEmployees = new HashSet<Employee>(equalityComparer)
            {
                new Employee { Email = "a1@gmail.com" },
                new Employee { Email = "a1@gmail.com" },
                new Employee { Email = "b1@gmail.com" }
            };

            var setCustimers = new HashSet<Custimer>(equalityComparer)
            {
                new Custimer { Email = "a1@gmail.com" },
                new Custimer { Email = "a1@gmail.com" },
                new Custimer { Email = "b1@gmail.com" }
            };

            var setStudents = new HashSet<Student>(equalityComparer)
            {
                new Student { Email = "a1@gmail.com" },
                new Student { Email = "a1@gmail.com" },
                new Student { Email = "b1@gmail.com" }
            };
        }
    }

    //public class EmployeeEqualityComparer : IEqualityComparer<Employee>
    //{
    //    public bool Equals(Employee x, Employee y) =>
    //        x.Email == y.Email;

    //    public int GetHashCode([DisallowNull] Employee obj) =>
    //        obj.Email.GetHashCode();
    //}

    //public class CustimerEqualityComparer : IEqualityComparer<Custimer>
    //{
    //    public bool Equals(Custimer x, Custimer y) =>
    //        x.Email == y.Email;

    //    public int GetHashCode([DisallowNull] Custimer obj) =>
    //        obj.Email.GetHashCode();
    //}

    //public class StudentEqualityComparer : IEqualityComparer<Student>
    //{
    //    public bool Equals(Student x, Student y) =>
    //        x.Email == y.Email;

    //    public int GetHashCode([DisallowNull] Student obj) =>
    //        obj.Email.GetHashCode();
    //}

    public class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y) =>
            x.Email == y.Email;

        public int GetHashCode([DisallowNull] Person obj) =>
            obj.Email.GetHashCode();
    }

    public abstract class Person
    {
        public string Email { get; set; }
    }

    public class Employee : Person
    {
        //Other properties
        //...
    }

    public class Custimer : Person
    {
        //Other properties
        //...

        //public string Email { get; set; }
    }

    public class Student : Person
    {
        //Other properties
        //...

        //public string Email { get; set; }
    }
}
