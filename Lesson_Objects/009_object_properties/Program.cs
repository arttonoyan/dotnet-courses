namespace _009_object_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new("a1@gmail.com")
            {
                name = "A1",
                surname = "A1yan",
                Age = -25896
            };

            st.Age = -25896;
            int age = st.Age;
            //st.SetAge(-25896);
            //int age = st.GetAge();

        }
    }
}
