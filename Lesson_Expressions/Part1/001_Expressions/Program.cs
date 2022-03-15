using System;

namespace _001_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Student, bool> isTeenager = s => s.Age > 12 && s.Age < 20;

            var st = new Student { Name = "A1", Surname = "A1yan", Age = 18 };
            if (isTeenager(st))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            Console.ReadLine();

        }
    }
}
