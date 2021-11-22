using System;

namespace _015_object_Equatable
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student { Email = "a1@gmail.com", Name = "A1", Surname = "B1" };
            var st2 = new Student { Email = "a1@gmail.com", Name = "A1", Surname = "B1" };

            if (st1.Equals(st2))
            {

            }
        }
    }
}
