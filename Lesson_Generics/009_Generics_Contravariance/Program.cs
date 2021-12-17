using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _009_Generics_Contravariance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var setEmployees = new HashSet<Employee>()
            {
                new Employee { Email = "a1@gmail.com" },
                new Employee { Email = "a1@gmail.com" },
                new Employee { Email = "b1@gmail.com" }
            };

            var setCustimers = new HashSet<Custimer>()
            {
                new Custimer { Email = "a1@gmail.com" },
                new Custimer { Email = "a1@gmail.com" },
                new Custimer { Email = "b1@gmail.com" }
            };

            var setStudents = new HashSet<Student>()
            {
                new Student { Email = "a1@gmail.com" },
                new Student { Email = "a1@gmail.com" },
                new Student { Email = "b1@gmail.com" }
            };
        }
    }

    public class Employee
    {
        //Other properties
        //...

        public string Email { get; set; }
    }

    public class Custimer
    {
        //Other properties
        //...

        public string Email { get; set; }
    }

    public class Student
    {
        //Other properties
        //...

        public string Email { get; set; }
    }
}
