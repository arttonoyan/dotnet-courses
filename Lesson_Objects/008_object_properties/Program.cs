using System;

namespace _008_object_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new("a1@gmail.com")
            {
                name = "A1",
                surname = "A1yan",
                //age = -25896
            };

            st.SetAge(-25896);
            int age = st.GetAge();

        }
    }
}
