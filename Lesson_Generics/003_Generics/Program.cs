using System;

namespace _003_Generics
{
    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            instance.Method<string>("Hello world!");

            instance.Method("Hello world!");

            // Delay.
            Console.ReadKey();
        }
    }

    class MyClass
    {
        public void Method<T>(T argument)
        {
            T variable = argument;

            Console.WriteLine(variable);
        }
    }
}
