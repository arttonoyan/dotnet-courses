using System;

namespace _003_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = null;
            Student st2 = null;

            if (object.ReferenceEquals(st1, st2))
            {

            }

            //int age1 = st1.age;
            if (st1 != null)
            {
                int age = st1.age;
            }

            //int age = st1?.age;
        }
    }

    class Student
    {
        public string name;
        public string surname;
        public int age;
    }
}
