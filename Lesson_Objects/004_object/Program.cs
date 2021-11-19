using System;

namespace _004_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new();
            st1.name = "A1";

            Student st2 = new();
            st2.name = "A2";

            st1.Test();
            st2.Test();

            Student st3 = null;
            st3.Test();

            Console.ReadLine();
        }
    }

    class Student
    {
        public string name;
        public string surname;
        public int age;

        public void Test()
        {
            Console.WriteLine(name);
        }
    }
}
