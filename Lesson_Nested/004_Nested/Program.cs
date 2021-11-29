using System;

namespace _004_Nested
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass.Nested();
            instance.MethodFromNested();

            MyClass.StaticMethod();
            MyClass.StaticMethod();

            Console.ReadKey();
        }
    }

    public static class MyClass
    {
        static MyClass()
        {
            Console.WriteLine("MyClass Static Constructor");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("Static method from MyClass");
        }

        public class Nested
        {
            public void MethodFromNested()
            {
                Console.WriteLine("Method from Nested class.");
            }
        }
    }
}
