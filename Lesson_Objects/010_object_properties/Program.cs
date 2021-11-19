using System;
using System.Collections.Generic;

namespace _010_object_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = CreateStudents(10);
            foreach (Student item in students)
            {
                //Console.WriteLine($"{item.surname} {item.name}");
                Console.WriteLine(item.FullName);
            }

            Console.ReadLine();

        }

        static List<Student> CreateStudents(int count)
        {
            var rnd = new Random();
            var list = new List<Student>(count);
            for (int i = 0; i < count; i++)
            {
                var st = new Student("a1@gmail.com")
                {
                    name = $"A{i + 1}",
                    surname = $"A{i + 1}yan",
                    Age = rnd.Next(-255, 255)
                };
                list.Add(st);
            }
            return list;
        }

    }
}
