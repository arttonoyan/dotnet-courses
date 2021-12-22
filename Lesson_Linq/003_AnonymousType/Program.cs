using System;

namespace _003_AnonymousType
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            var o1 = new { Name = "A1", dt.Year };
            var o2 = new { Name = "A1", dt.Year };

            if (o1.Equals(o2))
            {

            }

            var o3 = o1;
            if (ReferenceEquals(o1, o3))
            {

            }
        }
    }
}
