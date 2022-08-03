using System;
using System.Text;

namespace _003_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder();

            builder
                .Append("StringBuilder ")
                .Append("is ")
                .Append("very ")
                .Append("fast ... ");

            string build1 = builder.ToString();

            builder.Append("faster");

            string build2 = builder.ToString();

            Console.WriteLine(build1);
            Console.WriteLine(build2);

            // Delay.
            Console.ReadKey();
        }

        public static void Test(Customer c)
        {
            c.Test = 10;
        }

        public class Customer
        {
            public int Test { get; set; }
        }
    }
}
