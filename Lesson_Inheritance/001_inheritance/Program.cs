using System;

namespace _001_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student
            {
                Name = "A1",
                Surname = "A1yan",
                Age = 18,
                Course = "C#"
            };

            var t = new Teacher
            {
                Name = "T1",
                Surname = "T1yan",
                Age = 30,
                Salary = 1500
            };

            Human h1 = st;

            Print(st);
            Print(t);

            Console.ReadLine();
        }

        static void Print(Human model)
        {
            Type t = model.GetType();

            Console.WriteLine(t.Name);
            Console.WriteLine(model.FullName);
            Console.WriteLine();
        }

        //static void Print(Student model)
        //{
        //    Console.WriteLine("Student");
        //    Console.WriteLine(model.FullName);
        //    Console.WriteLine();
        //}

        //static void Print(Teacher model)
        //{
        //    Console.WriteLine("Teacher");
        //    Console.WriteLine(model.FullName);
        //    Console.WriteLine();
        //}

    }
}
