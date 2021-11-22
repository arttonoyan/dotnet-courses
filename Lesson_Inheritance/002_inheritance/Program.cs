using System;

namespace _002_inheritance
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

            Print(st);
            Print(t);

            Console.ReadLine();
        }

        static void Print(Human model)
        {
            Type t = model.GetType();

            Console.WriteLine(t.Name);
            Console.WriteLine(model.FullName);
            //if (model is Student)
            //{
            //    Student st = (Student)model;
            //    Console.WriteLine($"Course: {st.course}");
            //}
            Student st = model as Student;
            if (st != null)
                Console.WriteLine($"Course: {st.Course}");

            Console.WriteLine();
        }

    }
}
