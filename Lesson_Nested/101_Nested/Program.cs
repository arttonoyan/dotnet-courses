using System;

namespace _101_Nested
{
    class Program
    {
        static void Main()
        {
            var instance = new MyClass.Nested();

            instance.Method();

            Console.ReadKey();
        }
    }

    class MyClass
    {
        public class Nested
        {
            public void Method()
            {
                Console.WriteLine("Method from Nested class.");
            }
        }
    }
}
