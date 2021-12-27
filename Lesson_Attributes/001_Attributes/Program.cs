using System;

namespace _001_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var my = new MyClass();
            MyClass.Method();

            Console.WriteLine();
        }
    }

    [My("5/29/2016", Number = 1)]
    public class MyClass
    {
        [My("2/31/2007", 10)]
        public static void Method()
        {
            Console.WriteLine("MyClass.Method()\n");
        }
    }
}
