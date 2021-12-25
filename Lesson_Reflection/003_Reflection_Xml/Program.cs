using System;
using System.Collections.Generic;

namespace _003_Reflection_Xml
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
                    Age = rnd.Next(17, 40),
                    Name = $"A{i}",
                    Surname = $"A{i}yan",
                    Email = $"a{i}@gmail.com"
                };
            }
        }
    }
}
