using System;
using System.Text;

namespace _004_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 100000;
            string simpleString = "";

            DateTime time = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                simpleString += "a";
            }

            TimeSpan timeSS = DateTime.Now - time;

            Console.WriteLine("Common string build time {0}.", timeSS);

            var builder = new StringBuilder();

            time = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                builder.Append("a");
            }

            TimeSpan timeSB = DateTime.Now - time;

            Console.WriteLine("StringBuilder build time {0}.", timeSB);

            Console.WriteLine("Common string length: {0}", simpleString.Length);

            simpleString = builder.ToString();

            Console.WriteLine("StringBuilder length: {0}", simpleString.Length);

            //Delay.
            Console.ReadKey();
        }
    }
}
