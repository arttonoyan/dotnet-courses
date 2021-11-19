using System;

namespace _007_object_readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            var st = new Student("a1@gmail.com")
            {
                age = 20,
                name = "A1",
                surname = "A1yan"
            };

            //st.email = "";
        }
    }
}
