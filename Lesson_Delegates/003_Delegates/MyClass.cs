using System;

namespace _003_Delegates
{
    public class MyClass
    {
        public void Method1()
        {
            Console.WriteLine("Call Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Call Method2");
        }

        public void Method3()
        {
            Console.WriteLine("Call Method3");
        }

        public string Method4<T>(T a)
        {
            return a.ToString();
        }
    }
}