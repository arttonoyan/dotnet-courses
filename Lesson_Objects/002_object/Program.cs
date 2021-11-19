using System;

namespace _002_object
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new();
            st1.name = "A1";

            Type type = st1.GetType();
            int code = st1.GetHashCode();

            Student st3 = st1;

            Student st2 = new();
            st2.name = "A1";

            if (st1.Equals(st2))
            {

            }

            if (st3.Equals(st1))
            {

            }
        }
    }

    class Student
    {
        public string name;
    }
}
