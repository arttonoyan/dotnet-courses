using System;
using System.Collections.Generic;

namespace _006_Attributes_Xml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateStudents(10).WriteToXml("Students.xml");

            // Delay.
            Console.ReadLine();
        }

        private static IEnumerable<Student> CreateStudents(int count)
        {
            var rnd = new Random();
            for (int i = 1; i <= count; i++)
            {
                yield return new Student
                {
                    Id = i,
                    BirthDay = new DateTime(rnd.Next(1980, 2000), rnd.Next(1, 13), rnd.Next(1, 25)),
                    Name = $"A{i}",
                    Surname = $"A{i}yan",
                    Email = $"a{i}@gmail.com"
                };
            }
        }
    }
}
