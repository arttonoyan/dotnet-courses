using System;

namespace _005_Nested
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass.Nested.StaticMethodFromNested();

            Console.ReadKey();
        }
    }

    public class MyClass
    {
        public static class Nested
        {
            public static void StaticMethodFromNested()
            {
                Console.WriteLine("Static method from Nested class.");
            }
        }
    }
}
