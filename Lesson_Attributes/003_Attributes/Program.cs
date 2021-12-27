using System;
using System.Reflection;

namespace _003_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemberInfo type = typeof(MyClass);

            object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), true);

            if (attributes.Length != 0)
            {
                // We display the obtained values.
                foreach (MyAttribute attribute in attributes)
                {
                    Console.WriteLine(attribute.Text);
                    Console.WriteLine(attribute.Data);
                    attribute.Method();
                }
            }

            // Delay.
            Console.ReadLine();
        }
    }
}
