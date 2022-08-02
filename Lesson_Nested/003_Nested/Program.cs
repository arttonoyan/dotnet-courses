using System;

namespace _003_Nested
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass.Nested();
            var my = new MyClass();

            instance.Method(1);

            Console.ReadKey();
        }
    }

    class MyClass
    {
        private int field = 0;

        public class Nested
        {
            private readonly MyClass instance = new();

            public void Method(int a)
            {
                instance.field = a;

                Console.WriteLine(instance.field);
            }
        }
    }
}
