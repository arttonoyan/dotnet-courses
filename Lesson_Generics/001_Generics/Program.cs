using System;

namespace _001_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> instance1 = new MyClass<int>();
            instance1.Method();

            MyClass<long> instance2 = new MyClass<long>();
            instance2.Method();

            MyClass<string> instance3 = new MyClass<string>();
            instance3.field = "ABC";
            instance3.Method();

            Console.ReadKey();
        }
    }

    class MyClass<T>
    {
        public T field;

        public void Method()
        {
            Console.WriteLine(field.GetType());
        }
    }
}