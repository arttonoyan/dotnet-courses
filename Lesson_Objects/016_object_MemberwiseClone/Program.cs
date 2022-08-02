using System;

namespace _016_object_MemberwiseClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new Student 
            { 
                Email = "a1@gmail.com", 
                Name = "A1", Surname = "B1",
                University = new University { Id = 10 }
            };
            var st2 = st1.Clone();

            if (st1.Equals(st2))
            {

            }

            if(st1.University.Equals(st2.University))
            {

            }

            st1.University.Id = 25;

            Console.WriteLine($"Name:     {st2.Name}");
            Console.WriteLine($"Surname:  {st2.Surname}");
            Console.WriteLine($"Email:    {st2.Email}");
        }
    }
}
