using System;

namespace _002_AnonymousType
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new
            {
                Name = "A1",
                Age = 36
            };

            //student.Name = "";

            Type type = student.GetType();
            Console.WriteLine(type);

            Console.ReadLine();
        }
    }
}
